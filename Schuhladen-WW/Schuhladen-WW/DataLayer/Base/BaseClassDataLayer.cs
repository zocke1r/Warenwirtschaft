using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Schuhladen_WW.CustomEvents;
using System.Reflection;
using System.Data.SqlClient;

namespace Schuhladen_WW.DataLayer
{
    public  abstract class BaseClassDataLayer : INotifyCustmPropertyChanged
    {

        private int int_id;

        public event CustomPropertyChanged _CustomPropertyChanged;

        protected virtual void RaiseEvent(Type _Type, string str_ColumnName, object obj_Value)
        {
            if (_CustomPropertyChanged !=null)
                _CustomPropertyChanged(_Type, str_ColumnName, obj_Value);
        }

        public abstract void Update();

		//public abstract SqlCommand InsertCommand ();
	}
}
