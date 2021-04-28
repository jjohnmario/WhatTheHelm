using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CanLib.ParameterGroups.J1939
{
    /// <summary>
    /// PGN: 059904 J1939 Request
    /// </summary>
    public class Pgn0x0EA00 : J1939ParameterGroup
    {
        /// <summary>
        /// The requested parameter group.
        /// </summary>
        public ParameterGroup RequestedParameterGroup { get; set; }
        public override string Description
        {
            get
            {
                return "PGN: 059904 J1939 Request";
            }
        }

        public override PgnType PgnType
        {
            get
            {
                return PgnType.J3919;
            }
        }

        public override bool MultiFrame
        {
            get
            {
                return false;
            }
        }

        public override int Pgn
        {
            get
            {
                return 059904;
            }
        }

        public override Target Target
        {
            get
            {
                return Target.Defined;
            }
        }

        /// <summary>
        /// Represents the base PGN with the LSB replaced with the destination address of the intended CAN node.
        /// </summary>
        public int MessagePgn
        {
            get
            {
                byte[] pgn = BitConverter.GetBytes(Pgn);
                pgn[0] = DestinationAddress;
                return BitConverter.ToInt32(pgn, 0);
            }
        }

        public byte RequestedPgnFields { get; set; }

        /// <summary>
        /// Creates an object reference to PGN: 059904 (0x0EA00) ISO Request
        /// </summary>
        public Pgn0x0EA00()
        {

        }
        /// <summary>
        /// Creates an object reference to PGN: 059904 (0x0EA00) ISO Request and defines the address of the targeted node.
        /// </summary>
        /// <param name="destinationAddress">The address of the targeted node(s) (1-253 = single node, 255 = all nodes).</param>
        public Pgn0x0EA00(ParameterGroup requestedParameterGroup, byte destinationAddress)
        {
            RequestedParameterGroup = requestedParameterGroup;
            DestinationAddress = destinationAddress;
        }

        public override byte[] SerializeFields()
        {
            //Bytes 1-4
            byte[] temp = BitConverter.GetBytes(RequestedParameterGroup.Pgn);
            byte[] reqPgn = new byte[3];
            Array.Copy(temp, reqPgn, 3);
            byte[] reqPgnFields = RequestedParameterGroup.SerializeFields();
            var fields = reqPgn.Concat(reqPgnFields).ToArray();
                
            if (fields.Length > 8)
                throw new IndexOutOfRangeException("The total length of all fields must not exceed 8 bytes.");
            else
                return fields;
        }

        public override ParameterGroup DeserializeFields(byte[] data)
        {
            //Byes 1-3 Requested parameter group
            string byteToBin1 = Convert.ToString(data[0], 2).PadLeft(8, '0');
            string byteToBin2 = Convert.ToString(data[1], 2).PadLeft(8, '0');
            string byteToBin3 = Convert.ToString(data[2], 2).PadLeft(8, '0');
            string concat = string.Concat(byteToBin3,byteToBin2,byteToBin1);
            var reqPgn = Convert.ToInt32(concat, 2);
            return GetPgnType(reqPgn);
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
