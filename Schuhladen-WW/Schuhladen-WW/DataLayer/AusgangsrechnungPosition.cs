using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schuhladen_WW.Mapping;
using Schuhladen_WW.DataLayer.Mapping;

namespace Schuhladen_WW.DataLayer
{
    public class AusgangsrechnungPosition : BaseClassDataLayer
    {
        private int int_id;
        private int int_anzahl;
        private double dbl_preis;
        private int int_ausgangsrechnung;
        private int int_artikel;

        public Live_Article _LiveArticle => DataController.ReturnLiveArtikel().Where(x => x.int_ID == int_artikel).First();
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
    }
}
