using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schuhladen_WW.Mapping
{
    [AttributeUsage(AttributeTargets.Property)]
    class PropertyBridge : Attribute
    {
        private string str_propertyNames { get; set; }

        public string str_PropertyNames
        {
            get { return str_propertyNames;  }
            set { str_propertyNames = value; }
        }

        public PropertyBridge(string str_PropertyValue)
        {
            str_propertyNames = str_PropertyValue;
        }
    }
}
