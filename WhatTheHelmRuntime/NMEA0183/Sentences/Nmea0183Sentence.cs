using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WhatTheHelmRuntime.NMEA0183.Sentences
{
    public abstract class Nmea0183Sentence
    {
        /// <summary>
        /// Describes the sentence.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Sentence Id
        /// </summary>
        public abstract string SentenceId { get; }


        private static object Lock = new object();
        /// <summary>
        /// Serializes sentence fields into a string array.
        /// </summary>
        /// <returns></returns>
        public abstract string[] SerializeFields();
        /// <summary>
        /// Deserializes a string into a an object of type: Nmea0183Sentence
        /// </summary>
        /// <param name="data">string comtaining fields to deserialize.</param>
        /// <returns></returns>
        public abstract Nmea0183Sentence DeserializeFields(string data);
        /// <summary>
        /// Converts the data fields to imperial measurement.
        /// </summary>
        /// <returns></returns>
        public abstract Nmea0183Sentence ToImperial();
        /// <summary>
        /// Converts the data fields to metric measurement.
        /// </summary>
        /// <returns></returns>
        public abstract Nmea0183Sentence ToMetric();

        /// <summary>
        /// Returns an object reference to a ParameterGroup derivative.
        /// </summary>
        /// <param name="sentenceId">The parameter group number of the desired object</param>
        /// <returns></returns>
        public static Nmea0183Sentence GetSentenceType(string sentenceId)
        {
            lock (Lock)
            {
                //Try to find literal sentence.

                var pgnObj = Assembly.GetAssembly(typeof(Nmea0183Sentence)).GetTypes().Where(myType => myType.IsSubclassOf(typeof(Nmea0183Sentence))).Where(name => name.Name == sentenceId).ToList().FirstOrDefault();

                try
                {
                    var sentence = (Nmea0183Sentence)Activator.CreateInstance(pgnObj);
                    return sentence;
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Returns a list of property/value pairs.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<SentenceField> ToList()
        {
            var results = new List<SentenceField>();
            PropertyInfo[] props = this.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                results.Add(new SentenceField(prop.Name, prop.GetValue(this)));
            }
            return results;
        }
    }
}
