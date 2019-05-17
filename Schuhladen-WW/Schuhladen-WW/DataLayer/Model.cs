using Schuhladen_WW.DataLayer.Mapping;
using Schuhladen_WW.Mapping;
using System.Data.SqlClient;
using System.Linq;

namespace Schuhladen_WW.DataLayer
{
    public class Model : BaseClassDataLayer
    {
        private string str_description { get; set; }
        private int int_manufacturer { get; set; }

        public Hersteller _Hersteller => DataController.ReturnHersteller().Where(x => x.int_ID == int_manufacturer).First();

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
            get { return str_description; }
            set
            {
                if (str_description != value)
                {
                    str_description = value;
                    RaiseEvent(this.GetType(), "Bezeichnung", str_description);
                }
            }
        }

        [PropertyBridge("Hersteller")]
        public int int_Manufacturer
        {
            get { return int_manufacturer; }
            set
            {
                if (int_manufacturer != value)
                {
                    int_manufacturer = value;
                    RaiseEvent(this.GetType(), "Hersteller", int_manufacturer);
                }
            }
        }

        public override void Update()
        {
            executeUpdate("dbo.UpdateModelRow");
        }

        protected override void fillParameter(SqlCommand cmd_Command)
        {
            cmd_Command.Parameters.Add(new SqlParameter("@Bezeichnung", this.str_Description));
            cmd_Command.Parameters.Add(new SqlParameter("@Hersteller", this.int_Manufacturer));
        }

        public override void Insert()
        {
            executeCommand("dbo.InsertModelRow");
        }
    }
}