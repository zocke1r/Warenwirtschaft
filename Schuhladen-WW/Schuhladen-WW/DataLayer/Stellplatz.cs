using Schuhladen_WW.DataLayer.Mapping;
using Schuhladen_WW.Mapping;
using System.Data.SqlClient;

namespace Schuhladen_WW.DataLayer
{
    public class Stellplatz : BaseClassDataLayer
    {
        #region Private Members
        private string str_bezeichnung;
        private string str_macadress;
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
                    RaiseEvent(this.GetType(), "int_StellplatzID", int_id);
                }
            }
        }

        [PropertyBridge("str_Bezeichnung")]
        public string str_Bezeichnung
        {
            get { return str_bezeichnung; }
            set
            {
                if (str_bezeichnung != value)
                {
                    str_bezeichnung = value;
                    RaiseEvent(this.GetType(), "str_Bezeichnung", str_bezeichnung);
                }
            }
        }

        [PropertyBridge("str_MacAdress")]
        public string str_MacAdress
        {
            get { return str_macadress; }
            set
            {
                if (str_macadress != value)
                {
                    str_macadress = value;
                    RaiseEvent(this.GetType(), "str_MacAdress", str_macadress);
                }
            }
        }

        public override void Update()
        {
            executeUpdate("dbo.UpdateStellplatz");
        }

        public override void Insert()
        {
            executeCommand("dbo.InsertStellplatz");
        }

        protected override void fillParameter(SqlCommand cmd_Command)
        {
            cmd_Command.Parameters.Add(new SqlParameter("@str_Bezeichnung", this.str_bezeichnung));
            cmd_Command.Parameters.Add(new SqlParameter("@str_MacAdress", this.str_macadress));
        }

        #endregion
    }
}
