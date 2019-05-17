using Schuhladen_WW.DataLayer.Mapping;
using Schuhladen_WW.Mapping;
using System.Data.SqlClient;
using System.Linq;

namespace Schuhladen_WW.DataLayer
{
    public class AusgangsrechnungPosition : BaseClassDataLayer
    {
        #region Private Members

        private int int_anzahl;
        private double dbl_preis;
        private int int_ausgangsrechnung;
        private int int_artikel;

        #endregion Private Members

        #region Public Members

        public Live_Artikel _LiveArticle => DataController.ReturnLiveArtikel().Where(x => x.int_ID == int_artikel).First();
        public AusgangsRechnung _AusgangsRechnung => DataController.ReturnAusgangsRechnung().Where(x => x.int_Id == int_ausgangsrechnung).First();

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

        [PropertyBridge("AusgangsRechnung")]
        public int int_AusgansRechnung
        {
            get { return int_ausgangsrechnung; }
            set
            {
                if (int_ausgangsrechnung != value)
                {
                    int_ausgangsrechnung = value;
                    RaiseEvent(this.GetType(), "AusgangsRechnung", int_ausgangsrechnung);
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
            executeUpdate("dbo.UpdateAusgangsrechnungPositionRow");
        }

        protected override void fillParameter(SqlCommand cmd_Command)
        {
            cmd_Command.Parameters.Add(new SqlParameter("@Anzahl", this.int_Anzahl));
            cmd_Command.Parameters.Add(new SqlParameter("@Preis ", this.dbl_Preis));
            cmd_Command.Parameters.Add(new SqlParameter("@Ausgangsrechnung", this.int_AusgansRechnung));
            cmd_Command.Parameters.Add(new SqlParameter("@Artikel  ", this.int_Artikel));
        }

        public override void Insert()
        {
            executeCommand("dbo.InsertAusgangsrechnungPositionRow");
        }

        #endregion Public Members
    }
}