using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CanLib.ParameterGroups.NMEA2000
{
    public enum PgnList { ReceivePgnList, TransmitPgnList }
    /// <summary>
    /// PGN: 126464 PGN List (Transmit and Receive)
    /// </summary>
    public class Pgn0x1EE00 : Nmea2000ParameterGroup
    {
        public override string Description
        {
            get
            {
                return "PGN List (Transmit and Receive)";
            }
        }

        public override bool MultiFrame
        {
            get
            {
                return true;
            }
        }

        public override int Pgn
        {
            get
            {
                return 0x1EE00;
            }
        }

        public PgnList PgnList { get; private set; }

        public override Target Target
        {
            get
            {
                return Target.Defined;
            }
        }

        /// <summary>
        /// A list of receive PGNs
        /// </summary>
        public List<int> PgnReceiveList { get; private set; }

        /// <summary>
        /// A list of transmit PGNs
        /// </summary>
        public List<int> PgnTransmitList { get; private set; }

        public Pgn0x1EE00()
        {

        }

        public Pgn0x1EE00(PgnList pgnList)
        {
            PgnList = pgnList;
        }

        public override ParameterGroup DeserializeFields(byte[] data)
        {
            List<byte> list = data.ToList();
            PgnList listType = (PgnList)list.First();
            list.RemoveAt(0);
            List<byte[]> pgnList = new List<byte[]>();
            PgnReceiveList = new List<int>();
            pgnList = Split(list.ToArray(), 3);
            foreach (byte[] pgn in pgnList)
            {
                string msgIdBin = Convert.ToString(pgn[0], 2).PadLeft(8, '0');
                string msbToBin = Convert.ToString(pgn[1], 2).PadLeft(8, '0');
                string lsbToBin = Convert.ToString(pgn[2], 2).PadLeft(8, '0');
                string pgnAssembledBytesBin = String.Concat(lsbToBin, msbToBin, msgIdBin);
                if (listType == PgnList.ReceivePgnList)
                {
                    if (PgnReceiveList == null)
                        PgnReceiveList = new List<int>();
                    PgnReceiveList.Add(Convert.ToInt32(pgnAssembledBytesBin, 2));
                }

                else if (listType == PgnList.TransmitPgnList)
                {
                    if (PgnTransmitList == null)
                        PgnTransmitList = new List<int>();
                    PgnTransmitList.Add(Convert.ToInt32(pgnAssembledBytesBin, 2));
                }
            }
            return this;
        }

        /// <summary>
        /// Splits an array into several smaller arrays.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to split.</param>
        /// <param name="size">The size of the smaller arrays.</param>
        /// <returns>An array containing smaller arrays.</returns>
        private List<byte[]> Split (byte[] array, int size)
        {
            List<byte[]> list = new List<byte[]>();
            for (int i = 0; i<array.Length/size; i++)
            {
                list.Add(array.Skip(i * size).Take(size).ToArray());
            }
            return list;
        }

        public override byte[] SerializeFields()
        {
            byte[] bytes = new byte[1];
            bytes[0] = (byte)PgnList;
            return bytes;
        }

        public override ParameterGroup ToImperial()
        {
            throw new NotImplementedException();
        }

        public override ParameterGroup ToMetric()
        {
            throw new NotImplementedException();
        }
    }
}
