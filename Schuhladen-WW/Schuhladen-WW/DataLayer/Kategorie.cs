using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schuhladen_WW.DataLayer.Mapping;
using Schuhladen_WW.Mapping;
using System.Data.SqlClient;

namespace Schuhladen_WW.DataLayer
{
    public class Kategorie : BaseClassDataLayer
    {
        private int int_id;
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
			SqlCommandBuilder _CommandBuilder = new SqlCommandBuilder ();
			_CommandBuilder.GetUpdateCommand ().CommandText = "dbo.UpdateKategorieRow";
			_CommandBuilder.GetUpdateCommand ().Parameters.Add (new SqlParameter ("@Bezeichnung", this.str_Bezeichnung));
			_CommandBuilder.GetUpdateCommand ().Parameters.Add (new SqlParameter ("@ID", this.int_Id));

			DataController.UpdateObject (_CommandBuilder);
		}
	}
}
