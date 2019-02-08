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
