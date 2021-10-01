using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmRuntime.NMEA0183
{
    /// <summary>
    /// Represents a key value pair consisting of a sentence field name and its value.
    /// </summary>
    public class SentenceField
    {
        /// <summary>
        /// Name of the sentence field
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Value of the sentence field
        /// </summary>
        object Value { get; set; }

        /// <summary>
        /// Creates an object reference to sentence field with the defined name and value.
        /// </summary>
        /// <param name="name">Name of the sentence field to create.</param>
        /// <param name="value">Value of the sentence field to create.</param>
        public SentenceField(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
