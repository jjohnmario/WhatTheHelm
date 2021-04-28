using System;
using System.Collections.Generic;
using System.Text;

namespace CanLib.ParameterGroups
{
    /// <summary>
    /// Represents a key value pair consisting of a parameter group field name and its value.
    /// </summary>
    public class ParameterGroupField
    {
        /// <summary>
        /// Name of the parameter group field
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Value of the parameter group field
        /// </summary>
        object Value { get; set; }

        /// <summary>
        /// Creates an object reference to parameter group field with the defined name and value.
        /// </summary>
        /// <param name="name">Name of the parameter group field to create.</param>
        /// <param name="value">Value of the parameter group field to create.</param>
        public ParameterGroupField(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
