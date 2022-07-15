using CanLib.Messages;
using CanLib.ParameterGroups;
using CanLib.ParameterGroups.NMEA2000;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CanLib.Devices
{
    /// <summary>
    /// Listens for messages from a specific CAN gateway.
    /// </summary>
    public class CanGateWayListener
    {
        /// <summary>
        /// Represents the CAN gateway to which the lister is bound.
        /// </summary>
        public CanGateway CanGateway { get; set; }
        /// <summary>
        /// List of partial fast packet messages.  Completed fast packet messages are transferred to the main message queue.
        /// </summary>
        public List<CanMessage> FastPacketMessageQueue { get; private set; }
        /// <summary>
        /// The main J1939/NMEA2000 message queue.
        /// </summary>
        public Queue<CanMessage> MainMessageQueue { get; private set; }
        /// <summary>
        /// An event that is invoked when the listener recieves a new message from the CAN gateway to which it is bound.
        /// </summary>
        public event EventHandler<CanMessage> NewMessage;

        /// <summary>
        /// A list of PGNs to be evaluated.  PGNs not in this list will be ignored.
        /// </summary>
        public List<int> PgnFilter { get; } = new List<int>();

        /// <summary>
        /// When true, only PGNs in the filter will be evaluated.
        /// </summary>
        public bool PgnFilterEnabled { get; }

        /// <summary>
        /// Creates a object representation of a CAN message listener that is bound to the defined CAN gateway.
        /// </summary>
        /// <param name="canGateway">The CAN gateway to which the listener is to be bound.</param>
        public CanGateWayListener(CanGateway canGateway)
        {
            CanGateway = canGateway;
            FastPacketMessageQueue = new List<CanMessage>();
            MainMessageQueue = new Queue<CanMessage>();
        }

        /// <summary>
        /// Creates a object representation of a CAN message listener that is bound to the defined CAN gateway and ignores PGNs not listed in the PGN filter.
        /// </summary>
        /// <param name="canGateway">The CAN gateway to which the listener is to be bound.</param>
        /// <param name="pgnFilter">A list of PGNs to be evaluated. PGNs not in this list will be ignored.</param>
        public CanGateWayListener(CanGateway canGateway, List<int> pgnFilter)
        {
            PgnFilterEnabled = true;
            PgnFilter = pgnFilter;
            CanGateway = canGateway;
            FastPacketMessageQueue = new List<CanMessage>();
            MainMessageQueue = new Queue<CanMessage>();
        }

        /// <summary>
        /// Starts the listener.
        /// </summary>
        public void Start()
        {
            CanGateway.MessageRecieved += CanGateway_MessageRecieved;
            CanGateway.Open();
            Task.Run(() => ScanFastPacketMessageQueue());
            Task.Run(() => ScanMainMessageQueue());
        }

        /// <summary>
        /// Stops the listener.
        /// </summary>
        public void Stop()
        {
            CanGateway.Close();
        }

        private void CanGateway_MessageRecieved(object sender, CanMessageArgs e)
        {
            Task.Run(() =>
            {
                if (PgnFilterEnabled)
                {
                    if(PgnFilter.Contains(e.Message.ParameterGroupNumber))
                    {
                        if(ParameterGroup.GetPgnType(e.Message.ParameterGroupNumber).MultiFrame == true)
                            FastPacketMessageQueue.Add(e.Message);
                        else
                            MainMessageQueue.Enqueue(e.Message);
                    }
                } 
                else
                {
                    if (ParameterGroup.GetPgnType(e.Message.ParameterGroupNumber).MultiFrame == true)
                        FastPacketMessageQueue.Add(e.Message);
                    else
                        MainMessageQueue.Enqueue(e.Message);
                }
            });
        }

        private void ScanMainMessageQueue()
        {
            try
            {
                while (true)
                {
                    if (MainMessageQueue.Count > 0)
                    {
                        CanMessage message = MainMessageQueue.Dequeue();
                        if (NewMessage != null)
                            NewMessage.Invoke(this, message);
                    }
                    Thread.Sleep(5);
                }
            }
            catch
            {
                MainMessageQueue.Clear();
                ScanMainMessageQueue();
            }
        }

        private void ScanFastPacketMessageQueue()
        {
            try
            {
                while (true)
                {
                    if (FastPacketMessageQueue.Count > 0)
                    { 
                        //Find all first packets indicated by a zero in the LSB of the packet sequence identifier.
                        var firstFastPacketMessageList = FastPacketMessageQueue.ToList().Where(x => Convert.ToString(x.Data[0], 2).PadLeft(8, '0').EndsWith("0000"));

                        foreach (CanMessage firstFastPacketMessage in firstFastPacketMessageList.ToList())
                        {
                            //Get data length of FPM which is in the second byte of the first FPM data frame.
                            ushort dataBytesLen = firstFastPacketMessage.Data[1];

                            //Calculate the number of packets required to meet data byte length (first packet = 6 bytes, remaining = 7 bytes) 
                            int packetCountReq = (int)Math.Ceiling((float)(((dataBytesLen - 6.00) / 7.00) + 1));

                            //Get the packets that belong the pgn of the source address.
                            var totalPackets = FastPacketMessageQueue.ToList().Where(x => x.Data[0] >> 4 == firstFastPacketMessage.Data[0] >> 4 && x.ParameterGroupNumber == firstFastPacketMessage.ParameterGroupNumber && x.SourceAddress == firstFastPacketMessage.SourceAddress).ToList();

                            //If all packets are present then process fast packet message.
                            if (totalPackets.Count() == packetCountReq)
                            {
                                //Sort packets by ascending packet sequence identifier
                                var dataArray = totalPackets.OrderBy(x => x.Data[0]).Select(y => y.Data);

                                //Remove first two bytes (packet sequence identifier, total data bytes) of first data frame.
                                var data = dataArray.First().Skip(2);

                                //Remove first byte (packet sequence identifier) for remaining data frames.
                                foreach (byte[] byteArray in dataArray.Skip(1).ToList())
                                {
                                    data = data.Concat(byteArray.Skip(1));
                                }

                                //Verify the data length is as expected
                                data = data.Take(dataBytesLen);
                                if (data.Count() == dataBytesLen)
                                {
                                    //Use the first fast packet message as a template but overwrite the data property with the parsed fast packet data.
                                    firstFastPacketMessage.Data = data.ToArray();

                                    //Add message to main message queue.
                                    MainMessageQueue.Enqueue(firstFastPacketMessage);
                                }

                                //Remove message(s) from fast packet queue.                                
                                FastPacketMessageQueue = FastPacketMessageQueue.Except(totalPackets).ToList();
                            }
                        }
                    }
                    Thread.Sleep(1);
                }
            }
            catch
            {
                FastPacketMessageQueue.Clear();
                ScanFastPacketMessageQueue();
            }
        }
    }
}
