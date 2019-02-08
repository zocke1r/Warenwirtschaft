using System;
using System.Collections.Generic;
using Schuhladen_WW.DataLayer.Mapping;
using Schuhladen_WW.Mapping;
using System.Data.SqlClient;
using Schuhladen_WW.DataLayer;
using System.Linq;

namespace Schuhladen_WW.DataLayer
{
    public class Model : BaseClassDataLayer
    {
        private string str_description { get; set; }
        private int int_manufacturer { get; set; }

        public Hersteller _Hersteller => DataController.ReturnHersteller().Where(x => x.int_ID == int_manufacturer).First();

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
            get { return str_description; }
            set
            {
                if (str_description != value)
                {
                    str_description = value;
                    RaiseEvent(this.GetType(), "Bezeichnung", str_description);
                }
            }
        }

        [PropertyBridge("Hersteller")]
        public int int_Manufacturer
        {
            get { return int_manufacturer; }
            set
            {
                if (int_manufacturer != value)
                {
                    int_manufacturer = value;
                    RaiseEvent(this.GetType(), "Hersteller", int_manufacturer);
                }
            }
        }

		public override void Update () {
			// Insert validation method here :)
			SqlCommand cmd = new SqlCommand ();
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandText = "dbo.UpdateModelRow";
			cmd.Parameters.Add (new SqlParameter ("@ID", this.int_Id));
			fillParameter (cmd);

			DataController.UpdateObject (cmd);
		}

		private void fillParameter (SqlCommand cmd) {
			cmd.Parameters.Add (new SqlParameter ("@Bezeichnung", this.str_Description));
			cmd.Parameters.Add (new SqlParameter ("@Hersteller", this.int_Manufacturer));
		}

		public override void Insert () {
			SqlCommand cmd = new SqlCommand ();
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandText = "dbo.UpdateModelRow";
			fillParameter (cmd);

			DataController.UpdateObject (cmd);
		}
	}
}
