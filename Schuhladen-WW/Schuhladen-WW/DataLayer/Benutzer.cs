using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schuhladen_WW.Mapping;
using Schuhladen_WW.DataLayer.Mapping;
using System.Data.SqlClient;

namespace Schuhladen_WW.DataLayer
{
    public class Benutzer : BaseClassDataLayer
    {
        private int int_id;
        private string str_name;
        private string str_password;
        private int int_adresse;
        private string str_email;
        private string str_berechtigung;
        private string str_telefon;

        public Adresse _Adresse => DataController.ReturnAdresse().Where(x => x.int_Id == int_adresse).First();

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

        [PropertyBridge("Name")]
        public string str_Name
        {
            get { return str_name; }
            set
            {
                if (str_name != value)
                {
                    str_name = value;
                    RaiseEvent(this.GetType(), "Name", str_name);
                }
            }
        }

        [PropertyBridge("Pasword")]
        public string str_Password
        {
            get { return str_password; }
            set
            {
                if (str_password != value)
                {
                    str_password = value;
                    RaiseEvent(this.GetType(), "Password", str_password);
                }
            }
        }

        [PropertyBridge("Adresse")]
        public int int_Adresse
        {
            get { return int_adresse; }
            set
            {
                if (int_adresse != value)
                {
                    int_adresse = value;
                    RaiseEvent(this.GetType(), "Adresse", int_adresse);
                }
            }
        }

        [PropertyBridge("Email")]
        public string str_Email
        {
            get { return str_email; }
            set
            {
                if (str_email != value)
                {
                    str_email = value;
                    RaiseEvent(this.GetType(), "Email", str_email);
                }
            }
        }

        [PropertyBridge("Berechtigung")]
        public string str_Berechtigung
        {
            get { return str_berechtigung; }
            set
            {
                if (str_berechtigung != value)
                {
                    str_email = value;
                    RaiseEvent(this.GetType(), "Berechtigung", str_berechtigung);
                }
            }
        }

        [PropertyBridge("Telefon")]
        public string str_Telefon
        {
            get { return str_telefon; }
            set
            {
                if (str_telefon != value)
                {
                    str_telefon = value;
                    RaiseEvent(this.GetType(), "Telefon", str_telefon);
                }
            }
        }

        public override void Update()
        {
            // Insert validation method here :)
            SqlCommandBuilder _CommandBuilder = new SqlCommandBuilder();
            _CommandBuilder.GetUpdateCommand().CommandText = "dbo.UpdateAdressRow";
            _CommandBuilder.GetUpdateCommand().Parameters.Add(new SqlParameter("@ID", this.int_Id));
            _CommandBuilder.GetUpdateCommand().Parameters.Add(new SqlParameter("@Name", this.str_Name));
            _CommandBuilder.GetUpdateCommand().Parameters.Add(new SqlParameter("@Password", this.str_Password));
            _CommandBuilder.GetUpdateCommand().Parameters.Add(new SqlParameter("@Adresse", this.int_Adresse));
            _CommandBuilder.GetUpdateCommand().Parameters.Add(new SqlParameter("@Email", this.str_Email));
            _CommandBuilder.GetUpdateCommand().Parameters.Add(new SqlParameter("@Berechtigung", this.str_Berechtigung));
            _CommandBuilder.GetUpdateCommand().Parameters.Add(new SqlParameter("@Telefon", this.str_Telefon));

            DataController.UpdateObject(_CommandBuilder);
        }
    }
}
