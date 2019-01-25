using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schuhladen_WW.DataBase;
using Schuhladen_WW.DataLayer.Mapping;
using Schuhladen_WW.Mapping;
using System.Data;
using System.ComponentModel;
using Schuhladen_WW.DataLayer;

namespace Schuhladen_WW
{
    class Program
    {
        static void Main(string[] args)
        {
            DBConnection _Con = DBConnection.Instance();
            DataTable dt_DataTable = _Con.GetData("SELECT * FROM dbo.Live_Artikel;");

            

            PropertyMapper<Live_Article> ___LiveArticleMapper = new PropertyMapper<Live_Article>();
            List<Live_Article> _LiveArticle = ___LiveArticleMapper.Map(dt_DataTable).ToList();

            foreach (Live_Article item in _LiveArticle)
            {
                Console.WriteLine(item.int_ID);
            }

            _LiveArticle[0]._CustomPropertyChanged += Program__CustomPropertyChanged;

            _LiveArticle[0].int_ID = 2;
            _LiveArticle[0].str_EAN = "akdfakfdhaksdf";
            _LiveArticle[0].int_SizeID = 25;

            Console.WriteLine(_LiveArticle[0].model.str_Description);

            _LiveArticle[0].model.str_Description = "New Description";

            List<Model> model = DataController.ReturnModels();


            Console.WriteLine(model.Where(x => x.int_Id == _LiveArticle[0].int_ModelID).First().str_Description);



            


            foreach (Model var in model)
            {
                Console.WriteLine(var.str_Description);
            }

            Console.ReadKey();

        }

        private static void Program__CustomPropertyChanged(Type _Type, string str_ColumnName, object obj_Value)
        {
            Console.WriteLine("Type: " + _Type.Name);
            Console.WriteLine("ColumnName: " + str_ColumnName);
            Console.WriteLine("Changed value: " + obj_Value.ToString());
            //throw new NotImplementedException();
        }
    }
}
