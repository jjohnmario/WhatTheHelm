using System;

namespace CanLib.ParameterGroups.NMEA2000
{
    /// <summary>
    /// PGN:128267 Water Depth (With Transducer Offset)
    /// </summary>
    public class Pgn0x1F50B : ParameterGroup
    {
        public override int Pgn
        {
            get
            {
                return 128267;
            }
        }
        public override string Description
        {
            get
            {
                if (UomSystem == UomSystem.Metric)
                    return "Water Depth (With Transducer Offset) in Meters";
                else
                    return "Water Depth (With Transducer Offset) in Feet";
            }
        }
        public int Sid { get; private set; }
        public double Depth { get; private set; }
        public double Offset { get; private set; }
        public UomSystem UomSystem { get; private set; }
        public override bool MultiFrame
        {
            get
            {
                return false;
            }
        }
        public override PgnType PgnType
        {
            get
            {
                return PgnType.NMEA2000;
            }
        }

        public override Target Target
        {
            get
            {
                return Target.Defined;
            }
        }

        public Pgn0x1F50B()
        {

        }

        public Pgn0x1F50B(int sid, double depth, double offset)
        {
            Sid = sid;
            Depth = depth;
            Offset = offset;
        }

        public Pgn0x1F50B(int sid, double depth, double offset, UomSystem uomSystem)
        {
            Sid = sid;
            Depth = depth;
            Offset = offset;
            UomSystem = uomSystem;
        }

        public override ParameterGroup DeserializeFields(byte[] data)
        {
            if (data.Length != 8)
                throw new FormatException("Data frame must be exactly 8 bytes.");
            else
            {
                //SID
                Sid = data[0];

                //Depth
                byte[] depthByteArray = new byte[4];
                Array.Copy(data, 1, depthByteArray, 0, 4);
                Depth = BitConverter.ToInt32(depthByteArray, 0) * 0.001;
                depthByteArray = null;

                //Offset
                byte[] offsetByteArray = new byte[4];
                Array.Copy(data, 5, offsetByteArray, 0, 2);
                Offset = BitConverter.ToInt32(offsetByteArray, 0) * 0.01;
                offsetByteArray = null;
            }
            return this;
        }

        public override ParameterGroup ToImperial()
        {
            return new Pgn0x1F50B(Sid, Depth * 3.28084, Offset * 3.28084, UomSystem.Imperial);
        }

        public override ParameterGroup ToMetric()
        {
            return this;
        }

        public override byte[] SerializeFields()
        {
            throw new NotImplementedException();
        }
    }
}
