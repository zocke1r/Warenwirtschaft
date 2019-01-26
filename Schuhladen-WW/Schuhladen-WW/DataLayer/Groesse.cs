using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schuhladen_WW.Mapping;

namespace Schuhladen_WW.DataLayer
{
    public class Groesse : BaseClassDataLayer
    {
        private int int_id;
        private string str_us;
        private string str_eu;
        private string str_gb;
        private string str_cm;

        [PropertyBridge("ID")]
        public int int_Id
        {
            get { return int_id; }
            set
            {
                if (int_id != value) {
                    int_id = value;
                    RaiseEvent(this.GetType(), "ID", int_id);
                }
            }
        }

        [PropertyBridge("US")]
        public string str_US
        {
            get { return str_us; }
            set
            {
                if (str_us != value)
                {
                    str_us = value;
                    RaiseEvent(this.GetType(), "US", str_us);
                }
            }
        }

        [PropertyBridge("EU")]
        public string str_EU
        {
            get { return str_eu; }
            set
            {
                if (str_eu != value)
                {
                    str_eu = value;
                    RaiseEvent(this.GetType(), "EU", str_eu);
                }
            }
        }

        [PropertyBridge("GB")]
        public string str_GB
        {
            get { return str_gb; }
            set
            {
                if (str_gb != value)
                {
                    str_gb = value;
                    RaiseEvent(this.GetType(), "GB", str_gb);
                }
            }
        }

        [PropertyBridge("CM")]
        public string str_CM
        {
            get { return str_cm; }
            set
            {
                if (str_cm != value)
                {
                    str_cm = value;
                    RaiseEvent(this.GetType(), "CM", str_cm);
                }
            }
        }
    }
}
