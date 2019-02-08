using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schuhladen_WW.Mapping;
using System.Data.SqlClient;
using Schuhladen_WW.DataLayer.Mapping;

namespace Schuhladen_WW.DataLayer
{
    public class Status : BaseClassDataLayer
    {
		#region private Members
        private int int_numeral;
        private string str_bezeichnung;
		#endregion
		#region public members
		[PropertyBridge ("ID")]
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

        [PropertyBridge("Numeral")]
        public int int_Numeral
        {
            get { return int_numeral; }
            set
            {
                if (int_numeral != value)
                {
                    int_numeral = value;
                    RaiseEvent(this.GetType(), "Numeral", int_numeral);
                }
            }
        }

        [PropertyBridge("Bezeichnung")]
        public string str_Bezeichnung
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
			var sqlCommand = new SqlCommand ();
			sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
			sqlCommand.CommandText = "dbo.UpdateStatusRow";
			sqlCommand.Parameters.Add (new SqlParameter ("@ID", this.int_Id));
			sqlCommand.Parameters.Add (new SqlParameter ("@Bezeichnung", this.str_Bezeichnung));
			sqlCommand.Parameters.Add (new SqlParameter ("@Numeral", this.int_Numeral));

			DataController.UpdateObject (sqlCommand);
		}

		public override void Insert () {
			var sqlCommand = new SqlCommand ();
			sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
			sqlCommand.CommandText = "dbo.InsertStatusRow";
			sqlCommand.Parameters.Add (new SqlParameter ("@Bezeichnung", this.str_Bezeichnung));
			sqlCommand.Parameters.Add (new SqlParameter ("@Numeral", this.int_Numeral));

			DataController.UpdateObject (sqlCommand);
		}
		#endregion
	}
}
