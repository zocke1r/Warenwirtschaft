using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schuhladen_WW.Mapping;
using System.Data.SqlClient;
using Schuhladen_WW.DataLayer.Mapping;
using System.Data;

namespace Schuhladen_WW.DataLayer
{
    public class Adresse : BaseClassDataLayer
    {
        #region Private Members
        private string str_strasse;
        private string str_hausnummer;
        private string str_ort;
        private string str_plz;
        private string str_adresszusatz;
        #endregion

        #region Public Members
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

        [PropertyBridge("Strasse")]
        public string str_Strasse
        {
            get { return str_strasse; }
            set
            {
                if (str_strasse != value)
                {
                    str_strasse = value;
                    RaiseEvent(this.GetType(), "Strasse", str_strasse);
                }
            }
        }

        [PropertyBridge("Hausnummer")]
        public string str_Hausnummer
        {
            get { return str_hausnummer; }
            set
            {
                if (str_hausnummer != value)
                {
                    str_hausnummer = value;
                    RaiseEvent(this.GetType(), "Hausnummer", str_hausnummer);
                }
            }
        }

        [PropertyBridge("Ort")]
        public string str_Ort
        {
            get { return str_ort; }
            set
            {
                if (str_ort != value)
                {
                    str_ort = value;
                    RaiseEvent(this.GetType(), "ORT", str_ort);
                }
            }
        }

        [PropertyBridge("PLZ")]
        public string str_Plz
        {
            get { return str_plz; }
            set
            {
                if (str_plz != value)
                {
                    str_plz = value;
                    RaiseEvent(this.GetType(), "PLZ", str_plz);
                }
            }
        }

        [PropertyBridge("Adresszusatz")]
        public string str_Adresszusatz
        {
            get { return str_adresszusatz; }
            set
            {
                if (str_adresszusatz != value)
                {
                    str_adresszusatz = value;
                    RaiseEvent(this.GetType(), "Adresszusatz", str_adresszusatz);
                }
            }
        }

        public override void Update() {
			executeUpdate ("dbo.UpdateAdressRow");
			DataController.UpdateHerstellerRelations ();
		}

		protected override void fillParameter (SqlCommand cmd_Command) {
			cmd_Command.Parameters.Add (new SqlParameter ("@Strasse", this.str_Strasse));
			cmd_Command.Parameters.Add (new SqlParameter ("@Hausnummer", this.str_Hausnummer));
			cmd_Command.Parameters.Add (new SqlParameter ("@Ort", this.str_Ort));
			cmd_Command.Parameters.Add (new SqlParameter ("@PLZ", this.str_Plz));
			cmd_Command.Parameters.Add (new SqlParameter ("@Adresszusatz", this.str_Adresszusatz));
		}

		public override void Insert () {
			executeCommand ("dbo.InsertAdressRow");
			DataController.UpdateHerstellerRelations ();
		}
		#endregion

	}
}
