﻿using Schuhladen_WW.Mapping;
using System.Data.SqlClient;

namespace Schuhladen_WW.DataLayer
{
    public class Lieferant : BaseClassDataLayer
    {
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
        public string str_Description
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

        public override void Update()
        {
            executeUpdate("dbo.UpdateLieferantRow");
        }

        public override void Insert()
        {
            executeCommand("dbo.InsertLieferantRow");
        }

        protected override void fillParameter(SqlCommand cmd_Command)
        {
            cmd_Command.Parameters.Add(new SqlParameter("@Bezeichnung", this.str_Description));
        }
    }
}