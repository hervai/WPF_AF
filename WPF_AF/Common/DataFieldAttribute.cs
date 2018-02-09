using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Attributes
{
    /// <summary>
    /// Provides the mapping between the name of the source and target entity properties
    /// </summary>

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class DataFieldAttribute : Attribute
    {
        private readonly string _name;

        public DataFieldAttribute(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }
    }
}