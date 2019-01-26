using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schuhladen_WW.Mapping;

namespace Schuhladen_WW.DataLayer
{
    internal class Adresse : BaseClassDataLayer
    {
        private int int_id;
        private string str_strasse;
        private string str_hausnummer;
        private string str_ort;
        private string str_plz;
        private string str_addresszusatz;

        [PropertyBridge("ID")]
        public int int_ID
        {
            get
            {
                return int_id;
            }
            set
            {
                int_id = value;
                RaiseEvent(this.GetType(), "ID", int_id);
            }
        }

        [PropertyBridge("Strasse")]
        public string str_Strasse
        {
            get
            {
                return str_strasse;
            }
            set
            {
                str_strasse = value;
                RaiseEvent(this.GetType(), "ID", str_strasse);
            }
        }

        [PropertyBridge("Hausnummer")]
        public string str_Hausnummer
        {
            get
            {
                return str_hausnummer;
            }
            set
            {
                str_hausnummer = value;
                RaiseEvent(this.GetType(), "ID", str_hausnummer);
            }
        }

        [PropertyBridge("Ort")]
        public string str_Ort
        {
            get
            {
                return str_ort;
            }
            set
            {
                str_ort = value;
                RaiseEvent(this.GetType(), "ID", str_ort);
            }
        }

        [PropertyBridge("Plz")]
        public string str_Plz
        {
            get
            {
                return str_plz;
            }
            set
            {
                str_plz = value;
                RaiseEvent(this.GetType(), "ID", str_plz);
            }
        }

        [PropertyBridge("Adresszusatz")]
        public string str_Addresszusatz
        {
            get
            {
                return str_addresszusatz;
            }
            set
            {
                str_addresszusatz = value;
                RaiseEvent(this.GetType(), "ID", str_addresszusatz);
            }
        }
    }
}