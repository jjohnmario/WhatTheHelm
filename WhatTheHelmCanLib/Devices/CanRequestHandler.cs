using WhatTheHelmCanLib.Devices.Nmea2000;
using WhatTheHelmCanLib.Messages;
using WhatTheHelmCanLib.ParameterGroups;
using WhatTheHelmCanLib.ParameterGroups.J1939;
using WhatTheHelmCanLib.ParameterGroups.NMEA2000;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WhatTheHelmCanLib.Devices
{
    /// <summary>
    /// Handles ISO requests from connected CAN devices and optionally facilitates requests to connected CAN devices from the host.
    /// </summary>
    public class CanRequestHandler
    {
        /// <summary>
        /// Represents the CAN gateway to which the handler is bound.
        /// </summary>
        public CanGateway CanGateway { get; }
        private Queue<CanMessage> MainMessageQueue;
        private Queue<CanMessage> OutgoingMessageQueue;
        private System.Timers.Timer _RequestTimer;
        public List<ParameterGroup> RequestedParameterGroups { get; set; }
        /// <summary>
        /// Creates a handler for PGN requests (0x0EA00) from connected CAN devices allowing reponses only to PGN types contained in the executing assembly.
        /// </summary>
        /// <param name="canGateway">The CAN gateway to which the lister will bind.</param>
        public CanRequestHandler(CanGateway canGateway)
        {
            CanGateway = canGateway;
            MainMessageQueue = new Queue<CanMessage>();
            OutgoingMessageQueue = new Queue<CanMessage>();
        }

        /// <summary>
        /// Creates a handler for PGN requests (0x0EA00) from connected CAN devices allowing reponses only to PGN types contained in the executing assembly; as well as provides cyclical PGN requests for listed PGNs at the defined interval.
        /// </summary>
        /// <param name="canGateway">The CAN gateway to which the lister will bind.</param>
        /// <param name="requestedParameterGroups">The parameter groups that will be requested by the host.</param>
        /// <param name="requestInterval">The interval in which te parameter groups will be requested by the host.</param>
        public CanRequestHandler(CanGateway canGateway, List<ParameterGroup> requestedParameterGroups, int requestInterval)
        {
            CanGateway = canGateway;
            MainMessageQueue = new Queue<CanMessage>();
            OutgoingMessageQueue = new Queue<CanMessage>();
            RequestedParameterGroups = requestedParameterGroups;
            _RequestTimer = new System.Timers.Timer(requestInterval);
            _RequestTimer.Elapsed += _RequestTimer_Elapsed;
        }

        /// <summary>
        /// Adds the defined CAN message to the outgoing message queue.  Messages are written to the underlying CAN gateway on an first-in-first-out basis.
        /// </summary>
        /// <param name="message">The CAN message to be added to the outgoing message queue.</param>
        public void QueueOutgoingMessage(CanMessage message)
        {
            OutgoingMessageQueue.Enqueue(message);
        }

        private void _RequestTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            foreach(ParameterGroup pg in RequestedParameterGroups)
            {
                Pgn0x0EA00 isoRequest = new Pgn0x0EA00(pg, 255);
                CanMessage message = new CanMessage(isoRequest.MessagePgn, Format.EXTENDED, 3, CanGateway.Address, BitConverter.GetBytes(pg.Pgn));
                CanGateway.Write(message);
            }
        }

        /// <summary>
        /// Starts the handler.
        /// </summary>
        public void Start()
        {
            CanGateway.MessageRecieved += CanGateway_MessageRecieved;
            Task.Run(() => ScanMainMessageQueue());
            Task.Run(() => ScanOutgoingMessageQueue());
            if (RequestedParameterGroups != null && RequestedParameterGroups.Count != 0)
                if(_RequestTimer!=null)
                    _RequestTimer.Start();
        }

        private void CanGateway_MessageRecieved(object sender, Messages.CanMessageArgs e)
        {
            if (e.Message != null)
            {
                //Filter by 0x0EA00 only.
                if(59904 <= e.Message.ParameterGroupNumber && e.Message.ParameterGroupNumber <= 60159)
                {
                    MainMessageQueue.Enqueue(e.Message);
                }                   
            }
        }

        private void ScanOutgoingMessageQueue()
        {
            while(true)
            {
                if (OutgoingMessageQueue.Count > 0)
                {
                    CanGateway.Write(OutgoingMessageQueue.Dequeue());
                }
                Thread.Sleep(5);
            }
        }

        private void ScanMainMessageQueue()
        {
            while (true)
            {
                if (MainMessageQueue.Count > 0)
                {
                    CanMessage message = MainMessageQueue.Dequeue();
                    Pgn0x0EA00 request = new Pgn0x0EA00();

                    //Get the requested PGN
                    var requestedParameterGroup = request.DeserializeFields(message.Data);

                    switch(requestedParameterGroup.Pgn)
                    {
                        case uint n when (n <= 0x0EEFF && n >= 0x0EE00):
                            {
                                Pgn0x0EE00 response = new Pgn0x0EE00(CanGateway.Name);
                                CanMessage responseMsg = new CanMessage(response.Pgn, Format.EXTENDED, 3, CanGateway.Address, response.SerializeFields());
                                CanGateway.Write(responseMsg);
                            }
                            break;
                        case 0x1F014:
                            {
                                var gateway = (Nmea2000Gateway)CanGateway;
                                Pgn0x1F014 response = new Pgn0x1F014(gateway.ProductInformation);
                                var fields = response.SerializeFields().Reverse().ToArray();
                                CanMessage responseMsg = new CanMessage(response.Pgn, Format.EXTENDED, 3, CanGateway.Address, fields);
                                CanGateway.Write(responseMsg);
                            }
                            break;
                    }
                }             
                Thread.Sleep(5);
            }
        }
    }
}
