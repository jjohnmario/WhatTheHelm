using CanLib.Devices;
using CanLib.Devices.Nmea2000;
using CanLib.Devices.Nmea2000.GridConnect;
using CanLib.Messages;
using CanLib.ParameterGroups;
using CanLib.ParameterGroups.J1939;
using CanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.Mvec;
using CanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.MVec;
using CanLib.ParameterGroups.J1939.ProprietaryB;
using CanLib.ParameterGroups.J1939.ProprietaryB.CooperBussman.Mvec;
using CanLib.ParameterGroups.NMEA2000;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace NMEA2000_Test
{
    class Program
    {
        static Can232Fd CanGateway;
        static CanGateWayListener CanGateWayListener;
        static CanRequestHandler CanRequestHandler;
        static List<CanMessage> FastPacketMessageQueue;
        static Queue<CanMessage> MainMessageQueue;
        static void Main(string[] args)
        {
            Pgn0x1F200 foo = new Pgn0x1F200();
            var results = foo.ToList();
            CanName name = new CanName(false, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);
            ProductInformation productInformation = new ProductInformation(22276, 15406, "MarioWare Display", "v1.0.0", "1.0.0", "01229330JJF", 1, 2);

            //Pgn0x1F014 food = new Pgn0x1F014(new CanLib.Devices.Nmea2000.ProductInformation(22, 33, "MarioWare Display", "v1.0.0", "1.0.0", "01229330JJF", 1, 2));
            //var serial = food.SerializeFields();
            //var deserial = food.DeserializeFields(serial);
            //var reserial = deserial.SerializeFields();
            //var redeserial = deserial.DeserializeFields(reserial);

            //Pgn0x0EA00 req = new Pgn0x0EA00(new Pgn0x1F014(), 255);


            CanGateway = new Can232Fd(new SerialPort("COM8", 115200, Parity.None, 8, StopBits.One) { NewLine = ";" }, 0, name, productInformation);
            CanGateway.Open();

            Pgn0x0EF00 pgnn = new Pgn0x0EF00(new MvecCommand0x80(0, 2, RelayCommandState.TurnRelayOn), 176);

            CanMessage messg = new CanMessage(pgnn.Pgn, Format.EXTENDED, 6, CanGateway.Address, pgnn.Command.SerializeFields());
            CanGateway.Write(messg);

            Pgn0x0EF00 foodle = new Pgn0x0EF00();
            byte[] b = new byte[] { 0x96, 0x00, 0x02, 0x00, 0x00, 0x00, 0xE8, 0x03 };
            var ff = foodle.DeserializeFields(b);

            CanGateWayListener = new CanGateWayListener(CanGateway);
            CanGateWayListener.NewMessage += CanGateWayListener_NewMessage;
            CanGateWayListener.Start();
            CanRequestHandler = new CanRequestHandler(CanGateway);
            CanRequestHandler.Start();
            //CanGateway.MessageRecieved += Gateway_MessageRecieved;
            //string msg = ":X18EA0300N14F001;";

            //REMEMBER TO READ DATA BYTES IN REVERSE ORDER!
            System.Timers.Timer t = new System.Timers.Timer();
            t.Interval = 250;
            t.Elapsed += T_Elapsed;
            t.Start();
            
            //string msg = ":X18EA0300N05F801;"; 
           // CanGateway.Write(msg);

            //Pgn0x1F805 gnssData = new Pgn0x1F805();
            //Pgn0x0EA00 isoRequest = new Pgn0x0EA00(gnssData, 3);
            //CanMessage message = new CanMessage(isoRequest.MessagePgn, Format.EXTENDED, 3, CanGateway.Address, BitConverter.GetBytes(gnssData.Pgn), false);
            //CanGateway.Write(message);

            //Pgn0x1F014 prodInfo = new Pgn0x1F014();
            //isoRequest = new Pgn0x0EA00(prodInfo, 3);
            //message = new CanMessage(isoRequest.MessagePgn, Format.EXTENDED, 3, CanGateway.Address, BitConverter.GetBytes(prodInfo.Pgn), false);
            //CanGateway.Write(message);
            //Pgn0x1F014 food = new Pgn0x1F014(new CanLib.Devices.Nmea2000.ProductInformation(22, 33, "MarioWare Display", "v1.0.0", "1.0.0", "01229330JJF", 1, 2));
            //var ddod = food.SerializeFields();
            ////Create to gateway
            //Gateway = new Can232Fd(new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One) { NewLine = ";" }, 0);
            //Gateway.Open();
            //MainMessageQueue = new Queue<CanMessage>();
            //FastPacketMessageQueue = new List<CanMessage>();
            //Gateway.MessageRecieved += Gateway_MessageRecieved;
            //Task.Run(() => ScanFastPacketMessageQueue());
            //Task.Run(() => ScanMainMessageQueue());

            ////Claim source address using PGN 60928 (0x00EE00) Address Claimed Message
            //CanName name = new CanName(false, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);
            //Pgn0x0EE00 pgn = new Pgn0x0EE00(name);
            //CanMessage msg = new CanMessage(pgn.Pgn, Format.EXTENDED, 3, Gateway.Address, name.DataToArray(), false);
            //Gateway.Write(msg);

            ////Request PGN Transmit List using PGN 126464 (0x01EE00) from VHF. Note the requested PGN byte order must be reversed when transmitting.
            //Pgn0x1EE00 pgnListReq = new Pgn0x1EE00(PgnList.ReceivePgnList);
            //Pgn0x0EA00 isoReq = new Pgn0x0EA00(pgnListReq, 3);
            //var dataFrame = isoReq.SerializeFields();
            //dataFrame.Reverse();
            //CanMessage canMessage = new CanMessage(isoReq.MessagePgn, Format.EXTENDED, 6, Gateway.Address, dataFrame, false);
            //Gateway.Write(canMessage);

            Console.ReadLine();
        }

        private static void CanGateWayListener_NewMessage(object sender, CanMessage e)
        {
            var parameterGroup = ParameterGroup.GetPgnType(e.ParameterGroupNumber).DeserializeFields(e.Data);
            if(parameterGroup.Pgn == 127489)
            {
                Pgn0x1F201 p = (Pgn0x1F201)parameterGroup;
                var imp = p.ToImperial();
                var foo = p.ToString();
                Console.WriteLine(DateTime.Now + ":"+foo);
            }
            else if(parameterGroup.Pgn == 0x1F200)
            {
                Pgn0x1F200 p = (Pgn0x1F200)parameterGroup;
                Console.WriteLine(DateTime.Now + ":" + p.ToString());
            }
            else if(parameterGroup.Pgn == 0x0FFA0)
            {
                Pgn0x0FFA0 p = (Pgn0x0FFA0)parameterGroup;
                var ser = p.DeserializeFields(e.Data);
            }
            else if (parameterGroup.Pgn == 0x0FFA1)
            {
                Pgn0x0FFA1 p = (Pgn0x0FFA1)parameterGroup;
                var ser = p.DeserializeFields(e.Data);
            }
        }

        private static void T_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Pgn0x1F805 gnssData = new Pgn0x1F805();
            //Pgn0x0EA00 isoRequest = new Pgn0x0EA00(gnssData, 3);
            //CanMessage message = new CanMessage(isoRequest.MessagePgn, Format.EXTENDED, 3, CanGateway.Address, BitConverter.GetBytes(gnssData.Pgn), false);
            //CanGateway.Write(message);

            //Pgn0x1F014 prodInfo = new Pgn0x1F014();
            //isoRequest = new Pgn0x0EA00(prodInfo, 2);
            //message = new CanMessage(isoRequest.MessagePgn, Format.EXTENDED, 3, CanGateway.Address, BitConverter.GetBytes(prodInfo.Pgn), false);
            //CanGateway.Write(message);
        }

        private static void Gateway_MessageRecieved(object sender, CanMessageArgs e)
        {
            if (e.Message == null)
                Console.WriteLine("Parameter group not suppored.");
            if (e.Message != null)
            {
                var parameterGroup = ParameterGroup.GetPgnType(e.Message.ParameterGroupNumber);
                if (parameterGroup.MultiFrame)
                    FastPacketMessageQueue.Add(e.Message);
                else
                    MainMessageQueue.Enqueue(e.Message);
            }
        }

        

        private static void ScanFastPacketMessageQueue()
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
                        int packetCountReq = ((dataBytesLen - 6) / 7) + 2;

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

        private static void ScanMainMessageQueue()
        {
            while(true)
            {
                if(MainMessageQueue.Count > 0)
                {
                    CanMessage message = MainMessageQueue.Dequeue();
                    //Use reflection to create an instance of the correct PGN.

                    var foo = ParameterGroup.GetPgnType(message.ParameterGroupNumber).DeserializeFields(message.Data);
                    Console.WriteLine("Data Recieved: " + foo.Pgn.ToString() + ", " + foo.Description + ", byte count: " + message.Data.Length.ToString());
                    if(foo.Pgn == 0x01EE00)
                    {
                        var foo1 = (Pgn0x1EE00)foo;
                        if (foo1.PgnList == PgnList.TransmitPgnList)
                            {
                            foreach (int i in foo1.PgnTransmitList)
                                Console.WriteLine("PGN: " + i);
                        }
                        else if (foo1.PgnList == PgnList.ReceivePgnList)
                        {
                            foreach(int i in foo1.PgnReceiveList)
                                Console.WriteLine("PGN: " + i);
                        }
                    }
                }
            Thread.Sleep(1);
            }
        }

        static class CanMessageHelper
        {
            public static byte[] SwapByteArray(byte[] byteArray)
            {
                if (byteArray.Length == 2)
                {
                    byte[] results = new byte[2];
                    results[0] = byteArray[1];
                    results[1] = byteArray[0];
                    return results;
                }
                else if (byteArray.Length == 4)
                {
                    byte[] results = new byte[4];
                    results[3] = byteArray[0];
                    results[2] = byteArray[1];
                    results[1] = byteArray[2];
                    results[0] = byteArray[3];
                    return results;
                }
                else
                    throw new FormatException("Parameter must be exactly 2 or 4 bytes.");
            }
        }
    }
}
