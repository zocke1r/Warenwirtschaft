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
        private int int_id;
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
			// Insert validation method here :)
			var cmd = new SqlCommand ();
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandText = "dbo.UpdateKategorieRow";
			cmd.Parameters.Add (new SqlParameter ("@Name", this.str_Name));
			cmd.Parameters.Add (new SqlParameter ("@Adresse", this.int_AdressId));
			cmd.Parameters.Add (new SqlParameter ("@ID", this.int_ID));

			DataController.UpdateObject (cmd);
		}
	}
}
