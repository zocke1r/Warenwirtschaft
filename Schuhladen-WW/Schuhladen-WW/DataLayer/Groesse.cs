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
    public class Groesse : BaseClassDataLayer
    {
        private string str_us;
        private string str_eu;
        private string str_gb;
        private double dbl_cm;

        private Dictionary<string, string> _SizeList = new Dictionary<string, string>();


        [PropertyBridge("ID")]
        public int int_Id
        {
            get { return int_id; }
            set
            {
                if (int_id != value) {
                    int_id = value;
                    RaiseEvent(this.GetType(), "ID", int_id);
                }
            }
        }

        [PropertyBridge("US")]
        public string str_US
        {
            get { return str_us; }
            set
            {
                if (str_us != value)
                {
                    str_us = value;
                    RaiseEvent(this.GetType(), "US", str_us);
                }
            }
        }

        [PropertyBridge("EU")]
        public string str_EU
        {
            get { return str_eu; }
            set
            {
                if (str_eu != value)
                {
                    str_eu = value;
                    RaiseEvent(this.GetType(), "EU", str_eu);
                }
            }
        }

        [PropertyBridge("GB")]
        public string str_GB
        {
            get { return str_gb; }
            set
            {
                if (str_gb != value)
                {
                    str_gb = value;
                    RaiseEvent(this.GetType(), "GB", str_gb);
                }
            }
        }

        [PropertyBridge("CM")]
        public double dbl_CM
        {
            get { return dbl_cm; }
            set
            {
                if (dbl_cm != value)
                {
                    dbl_cm = value;
                    RaiseEvent(this.GetType(), "CM", dbl_cm);
                }
            }
        }

		public override void Update () {
			// Insert validation method here :)
			var cmd = new SqlCommand ();
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandText = "dbo.UpdateKategorieRow";
			cmd.Parameters.Add (new SqlParameter ("@US", this.str_US));
			cmd.Parameters.Add (new SqlParameter ("@EU", this.str_EU));
			cmd.Parameters.Add (new SqlParameter ("@GB", this.str_GB));
			cmd.Parameters.Add (new SqlParameter ("@cm", this.dbl_CM));

			DataController.UpdateObject (cmd);
		}
	}
}
