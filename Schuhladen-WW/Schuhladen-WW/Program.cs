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
			List<t2> l = new List<t2> ();
			Console.WriteLine (typeof (l));
			test (new t2 ());

            DataController.PullArticles();

            List<Live_Article> __LiveArticle = DataController.ReturnLiveArtikel();

            __LiveArticle[0].int_Stock = 3;
            __LiveArticle[0].Update();

            Console.ReadKey();

            
        }

		static void test (t1 t) {
			Console.WriteLine (t.GetType ().Name);
		}

		 abstract class t1 { }

		class t2 : t1 { }

        private static void Program__CustomPropertyChanged(Type _Type, string str_ColumnName, object obj_Value)
        {
            Console.WriteLine("Type: " + _Type.Name);
            Console.WriteLine("ColumnName: " + str_ColumnName);
            Console.WriteLine("Changed value: " + obj_Value.ToString());
            //throw new NotImplementedException();
        }
    }
}
