using System;
using Schuhladen_WW.CustomEvents;
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

		protected virtual void executeCommand (string commandText, bool needsId= false) {
			SqlCommand command = new SqlCommand (commandText);
			command.CommandType = CommandType.StoredProcedure;
			if (needsId) {
				command.Parameters.Add (new SqlParameter ("@ID", this.int_id));
			}
			fillParameter (command);
			executeCommand (command);
		}

		protected abstract void fillParameter (SqlCommand cmd_Command);

		protected void executeCommand (SqlCommand cmd_Command) {
			DataController.UpdateObject (cmd_Command);
		}

		protected void executeUpdate(string commandText) {
			executeCommand (commandText, true);
		}
	}
}
