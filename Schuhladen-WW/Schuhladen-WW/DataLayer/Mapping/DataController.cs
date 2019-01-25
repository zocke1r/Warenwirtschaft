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



namespace Schuhladen_WW.DataLayer.Mapping
{
    public static class DataController
    {
        // Handles database connection
        static DBConnection _Connection = DBConnection.Instance();

        static DataTable dt_DataTable = _Connection.GetData("SELECT * FROM dbo.Live_Artikel;");



        static PropertyMapper<Live_Article> ___LiveArticleMapper = new PropertyMapper<Live_Article>();


        static PropertyMapper<Model> ___ModelListMapper = new PropertyMapper<Model>();

        static List<Model> ___ModelList
        {
            get;
            set;
        }

        static List<>

        public static List<Model> ReturnModels()
        {
            if (___ModelList == null)
            {
                dt_DataTable = _Connection.GetData("SELECT * FROM dbo.Model;");
                ___ModelList = ___ModelListMapper.Map(dt_DataTable).ToList();
            }
            return ___ModelList;
        }

    }
}
