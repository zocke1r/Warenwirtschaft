using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Schuhladen_WW.CustomEvents;
using System.Reflection;
using Schuhladen_WW.DataLayer.Mapping;
using System.Data.SqlClient;
using System.Data;

namespace Schuhladen_WW.DataLayer
{
    public  abstract class BaseClassDataLayer : INotifyCustmPropertyChanged
    {

        protected int int_id;

		public event CustomPropertyChanged _CustomPropertyChanged;

        protected virtual void RaiseEvent(Type _Type, string str_ColumnName, object obj_Value)
        {
            if (_CustomPropertyChanged !=null)
                _CustomPropertyChanged(_Type, str_ColumnName, obj_Value);
        }

        public abstract void Update();

		public virtual void Delete () {
			var cmd = new SqlCommand ();
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandText = "dbo.DeleteRow";
			cmd.Parameters.Add (new SqlParameter ("@ID", this.int_id));
			cmd.Parameters.Add (new SqlParameter ("@Table", this.GetType ().Name));

			DataController.UpdateObject (cmd);
		}

		public abstract void Insert ();
	}
}
