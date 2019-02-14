using System;
using System.Linq;
using Schuhladen_WW.Mapping;
using Schuhladen_WW.DataLayer.Mapping;
using System.Data.SqlClient;

namespace Schuhladen_WW.DataLayer
{
    public class AusgangsRechnung : BaseClassDataLayer
    {

        #region Private Members
        private string str_nummer;
        private DateTime t_datum;
        private int int_status;
        private string str_betrag;
        #endregion

        #region Public Members
        public Status _Status => DataController.ReturnStatus().Where(x => x.int_Id == int_Status).First();

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

        [PropertyBridge("Nummer")]
        private string str_Nummer
        {
            get { return str_nummer; }
            set
            {
                if (str_nummer != value)
                {
                    str_nummer = value;
                    RaiseEvent(this.GetType(), "Nummer", str_nummer);
                }
            }
        }

        [PropertyBridge("Datum")]
        public DateTime t_Datum
        {
            get { return t_datum; }
            set
            {
                if(t_datum != value)
                {
                    t_datum = value;
                    RaiseEvent(this.GetType(), "Datum", t_datum);
                }
            }
        }

        [PropertyBridge("Status")]
        public int int_Status
        {
            get { return int_status; }
            set
            {
                if (int_status != value)
                {
                    int_status = value;
                    RaiseEvent(this.GetType(), "Status", int_status);
                }
            }
        }

        [PropertyBridge("Betrag")]
        public string str_Betrag
        {
            get { return str_betrag; }
            set
            {
                if (str_betrag != value)
                {
                    str_betrag = value;
                    RaiseEvent(this.GetType(), "Betrag", str_betrag);
                }
            }
        }

        public override void Update() {
			executeUpdate("dbo.UpdateAusgangsrechnungRow");
		}
		protected override void fillParameter (SqlCommand cmd_Command) {
			cmd_Command.Parameters.Add (new SqlParameter ("@Nummer ", this.str_Nummer));
			cmd_Command.Parameters.Add (new SqlParameter ("@Datum ", this.t_Datum));
			cmd_Command.Parameters.Add (new SqlParameter ("@Status", this.int_Status));
			cmd_Command.Parameters.Add (new SqlParameter ("@Betrag ", this.str_Betrag));
		}

		public override void Insert () {
			executeCommand ("dbo.InsertAusgangsrechnungRow");
		}
		#endregion
	}
}
