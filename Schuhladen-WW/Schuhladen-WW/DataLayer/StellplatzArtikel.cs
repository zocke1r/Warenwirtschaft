using Schuhladen_WW.DataLayer.Mapping;
using Schuhladen_WW.Mapping;
using System.Data.SqlClient;
using System.Linq;

namespace Schuhladen_WW.DataLayer
{
    public class StellplatzArtikel : BaseClassDataLayer
    {

        #region private members

        private int int_stellplatzid;
        private int int_articleid;

        #endregion

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
                    RaiseEvent(this.GetType(), "int_StellPlatzArtikel", int_id);
                }
            }
        }

        [PropertyBridge("int_StellplatzID")]
        public int int_StellplatzID
        {
            get { return int_stellplatzid; }
            set
            {
                if (int_stellplatzid != value)
                {
                    int_stellplatzid = value;
                    RaiseEvent(this.GetType(), "int_StellplatzID", int_stellplatzid);
                }
            }
        }

        [PropertyBridge("int_ArtikelID")]
        public int int_ArtikelID
        {
            get { return int_articleid; }
            set
            {
                if (int_articleid != value)
                {
                    int_articleid = value;
                    RaiseEvent(this.GetType(), "int_ArtikelID", int_articleid);
                }
            }
        }

        public override void Update()
        {
            executeUpdate("dbo.UpdateStellplatzArtikel");
        }

        public override void Insert()
        {
            executeCommand("dbo.InsertStellplatzArtikel");
        }

        protected override void fillParameter(SqlCommand cmd_Command)
        {
            cmd_Command.Parameters.Add(new SqlParameter("@int_StellplatzID", this.int_stellplatzid));
            cmd_Command.Parameters.Add(new SqlParameter("@int_ArtikelID", this.int_articleid));
        }

        #endregion
    }
}
