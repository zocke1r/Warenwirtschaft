using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schuhladen_WW.Mapping;
using System.Runtime.CompilerServices;
using System.Reflection;
using Schuhladen_WW.DataLayer.Mapping;
using System.Data.SqlClient;

namespace Schuhladen_WW.DataLayer
{
    public class Live_Article : BaseClassDataLayer
    {
        // private Methods
        private int int_id { get; set; }
        private string str_ean { get; set; }
        private double dbl_sellprice { get; set; }
        private double dbl_buyprice { get; set; }
        private int int_stock { get; set; }
        private int int_modelid { get; set; }
        private int int_sizeid { get; set; }

        public Model _Model => DataController.ReturnModels().Where(x => x.int_Id == int_modelid).First();
        public Groesse _Groesse => DataController.ReturnGroesse().Where(x => x.int_Id == int_sizeid).First();

        // public Methods
        [PropertyBridge("ID")]
        public int int_ID
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

        [PropertyBridge("EAN")]
        public string str_EAN
        {
            get { return str_ean; }
            set
            {
                if (str_ean != value)
                {
                    str_ean = value;
                    RaiseEvent(this.GetType(), "EAN", str_ean);
                }
            }
        }

        [PropertyBridge("VK")]
        public double dbl_SellPrice
        {
            get { return dbl_sellprice; }
            set
            {
                if (dbl_sellprice != value)
                {
                    dbl_sellprice = value;
                    RaiseEvent(this.GetType(), "VK", dbl_SellPrice);
                }

            }
        }

        [PropertyBridge("EK")]
        public double dbl_BuyPrice
        {
            get { return dbl_buyprice; }
            set
            {
                if (dbl_buyprice != value)
                {
                    dbl_buyprice = value;
                    RaiseEvent(this.GetType(), "EK", dbl_buyprice);
                }
            }
        }

        [PropertyBridge("Bestand")]
        public int int_Stock
        {
            get { return int_stock; }
            set
            {
                if (int_stock != value)
                {
                    int_stock = value;
                    RaiseEvent(this.GetType(), "Bestand", int_stock);
                }
            }
        }

        [PropertyBridge("Model")]
        public int int_ModelID
        {
            get { return int_modelid; }
            set
            {
                if (int_modelid != value)
                {
                    int_modelid = value;
                    RaiseEvent(this.GetType(), "Model", int_modelid);
                }
            }
        }

        [PropertyBridge("Groesse")]
        public int int_SizeID
        {
            get { return int_sizeid; }
            set
            {
                if (int_sizeid != value)
                {
                    int_sizeid = value;
                    RaiseEvent(this.GetType(), "Groesse", dbl_buyprice);
                }
            }
        }

		public override void Update () {
			// Insert validation method here :)
			SqlCommandBuilder _CommandBuilder = new SqlCommandBuilder ();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.UpdateLiveArtikelRow";
            cmd.Parameters.Add (new SqlParameter ("@EAN", this.str_EAN));
			cmd.Parameters.Add (new SqlParameter ("@VK", this.dbl_SellPrice));
			cmd.Parameters.Add (new SqlParameter ("@EK", this.dbl_BuyPrice));
			cmd.Parameters.Add (new SqlParameter ("@Bestand", this.int_Stock));
			cmd.Parameters.Add (new SqlParameter ("@Model", this.int_ModelID));
			cmd.Parameters.Add (new SqlParameter ("@Groesse", this.int_SizeID));
			cmd.Parameters.Add (new SqlParameter ("@ID", this.int_ID));

			DataController.UpdateObject (cmd);
		}
	}
}
