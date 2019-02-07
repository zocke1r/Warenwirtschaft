﻿using System;
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
			var cmd = new SqlCommand ();
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandText = "dbo.UpdateHerstellerRow";
			cmd.Parameters.Add (new SqlParameter ("@Name", this.str_Name));
			cmd.Parameters.Add (new SqlParameter ("@Adresse", this.int_AdressId));
			cmd.Parameters.Add (new SqlParameter ("@ID", this.int_ID));

			DataController.UpdateObject (cmd);
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

        public void DeleteHersteller()
        {
            var cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.DeleteRow";
            cmd.Parameters.Add(new SqlParameter("@ID", this.int_ID));
            cmd.Parameters.Add(new SqlParameter("@Table", this.GetType().Name));

            DataController.UpdateObject(cmd);

            var cmd1 = new SqlCommand();
            cmd1.CommandType = System.Data.CommandType.StoredProcedure;
            cmd1.CommandText = "dbo.DeleteRow";
            cmd1.Parameters.Add(new SqlParameter("@ID", this._Adresse.int_Id));
            cmd1.Parameters.Add(new SqlParameter("@Table", this._Adresse.GetType().Name));

            DataController.UpdateObject(cmd1);
        }
    }
}
