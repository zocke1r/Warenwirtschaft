using System.Collections.Generic;
using Schuhladen_WW.Mapping;
using System.Data.SqlClient;

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
			executeUpdate ("dbo.UpdateGroesseRow");
		}

		protected override void fillParameter (SqlCommand cmd) {
			cmd.Parameters.Add (new SqlParameter ("@US", this.str_US));
			cmd.Parameters.Add (new SqlParameter ("@EU", this.str_EU));
			cmd.Parameters.Add (new SqlParameter ("@GB", this.str_GB));
			cmd.Parameters.Add (new SqlParameter ("@cm", this.dbl_CM));
		}

		public override void Insert () {
			executeCommand ("dbo.UpdateGroesseRow");
		}
	}
}
