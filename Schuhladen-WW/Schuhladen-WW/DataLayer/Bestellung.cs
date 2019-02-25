using Schuhladen_WW.DataLayer.Mapping;
using Schuhladen_WW.Mapping;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Schuhladen_WW.DataLayer
{
    public class Bestellung : BaseClassDataLayer
    {
        private string str_nummer;
        private DateTime t_datum;
        private int int_lieferant;
        private int int_status;
        private string str_betrag;

        public Lieferant _Lieferant => DataController.ReturnLieferant().Where(x => x.int_Id == int_Id).First();
        public Status _Status => DataController.ReturnStatus().Where(x => x.int_Id == int_status).First();

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

        [PropertyBridge("Nummer")]
        public string str_Nummer
        {
            get { return str_nummer; }
            set
            {
                if (str_nummer != value)
                {
                    str_nummer = value;
                    RaiseEvent(this.GetType(), "Nummer", str_nummer);
                }
            }
        }

        [PropertyBridge("Datum")]
        public DateTime t_Datum
        {
            get { return t_datum; }
            set
            {
                if (t_datum != value)
                {
                    t_datum = value;
                    RaiseEvent(this.GetType(), "Datum", t_datum);
                }
            }
        }

        [PropertyBridge("Lieferant")]
        public int int_Lieferant
        {
            get { return int_lieferant; }
            set
            {
                if (int_lieferant != value)
                {
                    int_lieferant = value;
                    RaiseEvent(this.GetType(), "Lieferant", int_lieferant);
                }
            }
        }

        [PropertyBridge("Status")]
        public int int_Status
        {
            get { return int_status; }
            set
            {
                if (int_status != value)
                {
                    int_status = value;
                    RaiseEvent(this.GetType(), "Status", int_status);
                }
            }
        }

        [PropertyBridge("Betrag")]
        public string str_Betrag
        {
            get { return str_betrag; }
            set
            {
                if (str_betrag != value)
                {
                    str_betrag = value;
                    RaiseEvent(this.GetType(), "Betrag", str_betrag);
                }
            }
        }

        public override void Update()
        {
            executeUpdate("dbo.UpdateBestellungRow");
        }

        protected override void fillParameter(SqlCommand cmd)
        {
            cmd.Parameters.Add(new SqlParameter("@Nummer", this.str_Nummer));
            cmd.Parameters.Add(new SqlParameter("@Datum", this.t_datum));
            cmd.Parameters.Add(new SqlParameter("@Lieferant", this.int_Lieferant));
            cmd.Parameters.Add(new SqlParameter("@Status", this.int_Status));
            cmd.Parameters.Add(new SqlParameter("@Betrag", this.str_Betrag));
        }

        public override void Insert()
        {
            executeCommand("dbo.UpdateBestellungRow");
        }
    }
}