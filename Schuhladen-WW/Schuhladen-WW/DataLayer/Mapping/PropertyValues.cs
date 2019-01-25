using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schuhladen_WW.Mapping
{
    public static class PropertyValues
    {
        public static string GetPropertyValues (Type _Type, string str_PropName)
        {
            var var_Property = _Type.GetProperty(str_PropName).GetCustomAttributes(false).Where(x => x.GetType().Name == "PropertyBridge").First();
            if (var_Property != null)
            {
                return ((PropertyBridge)var_Property).str_PropertyNames;
            }
            return "";
        }
    }
}
