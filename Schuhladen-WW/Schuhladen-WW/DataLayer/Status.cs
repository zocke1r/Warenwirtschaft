﻿using Schuhladen_WW.Mapping;
using System.Data.SqlClient;

namespace Schuhladen_WW.DataLayer
{
    public class Status : BaseClassDataLayer
    {
        #region private Members

        private int int_numeral;
        private string str_bezeichnung;

        #endregion private Members

        #region public members

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

        [PropertyBridge("Numeral")]
        public int int_Numeral
        {
            get { return int_numeral; }
            set
            {
                if (int_numeral != value)
                {
                    int_numeral = value;
                    RaiseEvent(this.GetType(), "Numeral", int_numeral);
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

        public override void Update()
        {
            executeUpdate("dbo.UpdateStatusRow");
        }

        public override void Insert()
        {
            executeCommand("dbo.InsertStatusRow");
        }

        protected override void fillParameter(SqlCommand cmd_Command)
        {
            cmd_Command.Parameters.Add(new SqlParameter("@Bezeichnung", this.str_Bezeichnung));
            cmd_Command.Parameters.Add(new SqlParameter("@Numeral", this.int_Numeral));
        }

        #endregion public members
    }
}