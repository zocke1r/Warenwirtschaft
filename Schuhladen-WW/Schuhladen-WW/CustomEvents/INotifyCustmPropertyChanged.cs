using System;

namespace Schuhladen_WW.CustomEvents
{

    // Public delegates
    public delegate void CustomPropertyChanged(Type _Type, string str_ColumnName, object obj_Value);

    interface INotifyCustmPropertyChanged
    {
        event CustomPropertyChanged _CustomPropertyChanged;
    }
}
