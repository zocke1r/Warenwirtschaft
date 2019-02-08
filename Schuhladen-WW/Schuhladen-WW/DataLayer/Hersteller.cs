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
    public class Hersteller : BaseClassDataLayer
    {
        private string str_name;
        private int int_adressid;

        public Adresse _Adresse => DataController.ReturnAdresse().Where(x => x.int_Id == int_adressid).First();

        [PropertyBridge("ID")]
       public int int_ID
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

        [PropertyBridge("Name")]
        public string str_Name
        {
            get { return str_name; }
            set
            {
                if (str_name != value)
                {
                    str_name = value;
                    RaiseEvent(this.GetType(), "Name", str_name);
                }
            }
        }

        [PropertyBridge("Adresse")]
        public int int_AdressId
        {
            get { return int_adressid; }
            set
            {
                if (int_adressid != value)
                {
                    int_adressid = value;
                    RaiseEvent(this.GetType(), "Aresse", int_adressid);
                }
            }
        }

		public override void Update () {
			executeUpdate ("dbo.UpdateHerstellerRow");
        }

        public void InsertNewHersteller(Hersteller _Hersteller, Adresse __Adresse)
        {
            var cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.InsertHerstellerRow";
            cmd.Parameters.Add(new SqlParameter("@Bezeichnung", _Hersteller.str_Name));
            cmd.Parameters.Add(new SqlParameter("@Strasse", __Adresse.str_Strasse));
            cmd.Parameters.Add(new SqlParameter("@Hausnummer", __Adresse.str_Hausnummer));
            cmd.Parameters.Add(new SqlParameter("@Ort", __Adresse.str_Ort));
            cmd.Parameters.Add(new SqlParameter("@Plz", __Adresse.str_Plz));
            cmd.Parameters.Add(new SqlParameter("@Adresszusatz", __Adresse.str_Adresszusatz));

            DataController.UpdateObject(cmd);
        }

        public override void Delete()
        {
			base.Delete ();
			_Adresse.Delete ();
        }

		public override void Insert () {
			executeUpdate ("dbo.InsertHerstellerRow");
		}

		protected override void fillParameter (SqlCommand cmd_Command) {
			cmd_Command.Parameters.Add (new SqlParameter ("@Name", this.str_Name));
			cmd_Command.Parameters.Add (new SqlParameter ("@Adresse", this.int_AdressId));
		}
	}
}
