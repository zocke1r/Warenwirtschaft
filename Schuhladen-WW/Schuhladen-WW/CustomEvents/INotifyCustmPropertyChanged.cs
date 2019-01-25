using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schuhladen_WW.DataLayer;
using System.Reflection;

namespace Schuhladen_WW.CustomEvents
{

    // Public delegates
    public delegate void CustomPropertyChanged(Type _Type, string str_ColumnName, object obj_Value);

    interface INotifyCustmPropertyChanged
    {
        event CustomPropertyChanged _CustomPropertyChanged;
    }
}
