using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace WhatTheHelmCanLib.ParameterGroups
{
    public enum PgnType { J3919, NMEA2000 }
    public enum UomSystem { Metric, Imperial }
    public enum IsoAckControl { ACK, NAK, AccessDenied, AddressBusy }

    /// <summary>
    /// Enumeration reprenting the target device(s) of the PGN.  Broadcast indicates the PGN is intended to reach all network nodes, while Defined indicates the PGN is intended for specific node(s).
    /// </summary>
    public enum Target { Broadcast, Defined }

    public abstract class ParameterGroup
    {
        /// <summary>
        /// Describes the parameter group.
        /// </summary>
        public abstract string Description { get; }
        /// <summary>
        /// Defines whether the parameter group type is J1939 or NMEA2000.
        /// </summary>
        public abstract PgnType PgnType { get; }
        /// <summary>
        /// Indicates whether the defined parameter group utilizes multi-frame messaging.
        /// </summary>
        public abstract bool MultiFrame { get; }
        /// <summary>
        /// Parameter Group Number
        /// </summary>
        public abstract uint Pgn { get; }
        /// <summary>
        /// Indicates whether the PGN targets a single CAN node or is broadcasted to all nodes on the CAN network.
        /// </summary>
        public abstract Target Target { get; }

        private static object Lock = new object();
        /// <summary>
        /// Serializes parameter group fields into a byte array.
        /// </summary>
        /// <returns></returns>
        public abstract byte[] SerializeFields();
        /// <summary>
        /// Deserializes a byte array into a an object of type: ParameterGroup
        /// </summary>
        /// <param name="data">Byte array comtaining fields to deserialize.</param>
        /// <returns></returns>
        public abstract ParameterGroup DeserializeFields(byte[] data);
        /// <summary>
        /// Converts the data fields to imperial measurement.
        /// </summary>
        /// <returns></returns>
        public abstract ParameterGroup ToImperial();
        /// <summary>
        /// Converts the data fields to metric measurement.
        /// </summary>
        /// <returns></returns>
        public abstract ParameterGroup ToMetric();

        /// <summary>
        /// Returns an object reference to a ParameterGroup derivative.
        /// </summary>
        /// <param name="parameterGroupNumber">The parameter group number of the desired object</param>
        /// <returns></returns>
        public static ParameterGroup GetPgnType(uint parameterGroupNumber)
        {
            lock (Lock)
            {
                //Use reflection to create an instance of the correct PGN.
                var hexid = $"Pgn0x{parameterGroupNumber.ToString("X5")}";

                //Try to find literal PGN.  This is a PGN where the destination address does not replace the published LSB of the PGN. If null, try to find the modified PGN.  This is a PGN where the destination address replaces the published LSB of the PGN.
                
                var pgnObj = Assembly.GetAssembly(typeof(ParameterGroup)).GetTypes().Where(myType => myType.IsSubclassOf(typeof(ParameterGroup))).Where(name => name.Name == hexid).ToList().FirstOrDefault();
                if(pgnObj == null)
                {
                    var prefix = hexid.Substring(0, 8);
                    pgnObj = Assembly.GetAssembly(typeof(ParameterGroup)).GetTypes().Where(myType => myType.IsSubclassOf(typeof(ParameterGroup))).Where(name => name.Name.Substring(0, 8) == prefix).ToList().FirstOrDefault();
                }
                try
                {
                    var pg = (ParameterGroup)Activator.CreateInstance(pgnObj);
                    return pg;
                }
                catch(Exception e)
                {
                    return null;
                }

            }
        }

        /// <summary>
        /// Returns a list of property/value pairs.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<ParameterGroupField> ToList()
        {
            var results = new List<ParameterGroupField>();
            PropertyInfo[] props = this.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                results.Add(new ParameterGroupField(prop.Name, prop.GetValue(this)));
            }
            return results;
        }
    }
}
