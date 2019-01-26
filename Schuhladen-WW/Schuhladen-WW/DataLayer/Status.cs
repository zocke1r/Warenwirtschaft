using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schuhladen_WW.Mapping;

namespace Schuhladen_WW.DataLayer
{
    public class Status : BaseClassDataLayer
    {
        private int int_id;
        private int int_numeral;
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
    }
}
