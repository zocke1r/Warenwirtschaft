using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schuhladen_WW.Mapping;
using Schuhladen_WW.DataLayer.Mapping;
using System.Data.SqlClient;

namespace Schuhladen_WW.DataLayer
{
    public class Lieferant : BaseClassDataLayer
    {
        private string str_bezeichnung;

        [PropertyBridge("ID")]
        public int int_Id
        {
            get { return int_id; }
            set
            {
                if (int_id != value)
                {
                    int_id = value;
                    RaiseEvent(this.GetType(), "ID", int_id);
                }
            }
        }

        [PropertyBridge("Bezeichnung")]
        public string str_Description
        {
            get { return str_bezeichnung; }
            set
            {
                if (str_bezeichnung != value)
                {
                    str_bezeichnung = value;
                    RaiseEvent(this.GetType(), "Bezeichnung", str_bezeichnung);
                }
            }
        }

		public override void Update () {
			// Insert validation method here :)
			var cmd = new SqlCommand();
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandText = "dbo.UpdateLieferantRow";
			cmd.Parameters.Add (new SqlParameter ("@Bezeichnung", this.str_Description));
			cmd.Parameters.Add (new SqlParameter ("@ID", this.int_Id));

			DataController.UpdateObject (cmd);
		}

		public override void Insert () {
			var cmd = new SqlCommand ();
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandText = "dbo.InsertLieferantRow";
			cmd.Parameters.Add (new SqlParameter ("@Bezeichnung", this.str_Description));

			DataController.UpdateObject (cmd);
		}
	}
}
