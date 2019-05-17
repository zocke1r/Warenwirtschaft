using Schuhladen_WW.DataLayer.Mapping;
using Schuhladen_WW.Mapping;
using System.Data.SqlClient;
using System.Linq;

namespace Schuhladen_WW.DataLayer
{
    public class BestellungPositionPosition : BaseClassDataLayer
    {
        private int int_anzahl;
        private double dbl_preis;
        private int int_bestellung;
        private int int_artikel;

        public Live_Artikel _LiveArticle => DataController.ReturnLiveArtikel().Where(x => x.int_ID == int_artikel).First();
        public Bestellung _Bestellung => DataController.ReturnBestellung().Where(x => x.int_Id == int_bestellung).First();

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

        [PropertyBridge("Anzahl")]
        public int int_Anzahl
        {
            get { return int_anzahl; }
            set
            {
                if (int_anzahl != value)
                {
                    int_anzahl = value;
                    RaiseEvent(this.GetType(), "Anzahl", int_anzahl);
                }
            }
        }

        [PropertyBridge("Preis")]
        public double dbl_Preis
        {
            get { return dbl_preis; }
            set
            {
                if (dbl_preis != value)
                {
                    dbl_preis = value;
                    RaiseEvent(this.GetType(), "Preis", dbl_preis);
                }
            }
        }

        [PropertyBridge("Bestellung")]
        public int int_Bestellung
        {
            get { return int_bestellung; }
            set
            {
                if (int_bestellung != value)
                {
                    int_bestellung = value;
                    RaiseEvent(this.GetType(), "Bestellung", int_bestellung);
                }
            }
        }

        [PropertyBridge("Artikel")]
        public int int_Artikel
        {
            get { return int_artikel; }
            set
            {
                if (int_artikel != value)
                {
                    int_artikel = value;
                    RaiseEvent(this.GetType(), "Artikel", int_artikel);
                }
            }
        }

        public override void Update()
        {
            executeUpdate("dbo.UpdateBestellungPositionRow");
        }

        protected override void fillParameter(SqlCommand cmd)
        {
            cmd.Parameters.Add(new SqlParameter("@Anzahl", this.int_Anzahl));
            cmd.Parameters.Add(new SqlParameter("@Preis", this.dbl_Preis));
            cmd.Parameters.Add(new SqlParameter("@Bestellung", this.int_Bestellung));
            cmd.Parameters.Add(new SqlParameter("@Artikel", this.int_Artikel));
        }

        public override void Insert()
        {
            executeCommand("dbo.UpdateBestellungPositionRow");
        }
    }
}