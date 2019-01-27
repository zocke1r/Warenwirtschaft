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
        // New database connection
        private static DBConnection _Connection = DBConnection.Instance();

        // Collections (Lazyloading)
        static List<Live_Article> __LiveArticle { get; set; }

        static List<Model> __Model { get; set; }

        static List<Groesse> __Groesse { get; set; }

        static List<Hersteller> __Hersteller { get; set; }

        static List<Adresse> __Adresse { get; set; }

        static List<AusgangsRechnung> __AusgangsRechnung { get; set; }

        static List<Status> __Status { get; set; }
        
        static List<Benutzer> __Benutzer { get; set; }

        static List<Lieferant> __Lieferant { get; set; }

        // Initialize object mappers
        private static PropertyMapper<Live_Article> ___LiveArticleMapper = new PropertyMapper<Live_Article>();
        private static PropertyMapper<Model> ___ModelListMapper = new PropertyMapper<Model>();
        private static PropertyMapper<Groesse> ___GroesseListMapper = new PropertyMapper<Groesse>();
        private static PropertyMapper<Hersteller> ___HerstellerListMapper = new PropertyMapper<Hersteller>();
        private static PropertyMapper<Adresse> ___AdresseListMapper = new PropertyMapper<Adresse>();
        private static PropertyMapper<AusgangsRechnung> ___AusgangsRechnungListMapper = new PropertyMapper<AusgangsRechnung>();
        private static PropertyMapper<Status> ___StatusListMapper = new PropertyMapper<Status>();
        private static PropertyMapper<Benutzer> ___BenutzerListMapper = new PropertyMapper<Benutzer>();
        private static PropertyMapper<Lieferant> ___LieferantListMapper = new PropertyMapper<Lieferant>();


        // Pulls all from db and creates datalayer according to dbm relations
        public static void CreateDataLayer()
        {
            // Gets Live_Article collection
            __LiveArticle = ___LiveArticleMapper.Map(_Connection.GetData("SELECT * FROM dbo.LiveArticle;")).ToList();

            // Gets Model collection
            __Model = ___ModelListMapper.Map(_Connection.GetData("SELECT * FROM dbo.Model;")).ToList();

            // Get Groesse collection
            __Groesse = ___GroesseListMapper.Map(_Connection.GetData("SELECT * FROM dbo.Groesse;")).ToList();

            // Get Groesse collection
            __Hersteller = ___HerstellerListMapper.Map(_Connection.GetData("SELECT * FROM dbo.Hersteller;")).ToList();

            // Get Adresse collection
            __Adresse = ___AdresseListMapper.Map(_Connection.GetData("SELECT * FROM dbo.Adresse;")).ToList();

            // Get Status collection
            __Status = ___StatusListMapper.Map(_Connection.GetData("SELECT * FROM dbo.Status;")).ToList();

            // Get AusgangsRechnung collection
            __AusgangsRechnung = ___AusgangsRechnungListMapper.Map(_Connection.GetData("SELECT * FROM dbo.AusgangsRechnung;")).ToList();

            // GetBenutzer collection
            __Benutzer = ___BenutzerListMapper.Map(_Connection.GetData("SELECT * FROM dbo.Benutzer;")).ToList();

            // Get Lieferant collection
            __Lieferant = ___LieferantListMapper.Map(_Connection.GetData("SELECT * FROM dbo.Lieferant;")).ToList();
        }

        // Public methods
        public static List<Model> ReturnModels()
        {
            return __Model;
        }

        public static List<Groesse> ReturnGroesse()
        {
            return __Groesse;
        }

        public static List<Status> ReturnStatus()
        {
            return __Status;
        }

        public static List<Adresse> ReturnAdresse()
        {
            return __Adresse;
        }

        public static List<Lieferant> ReturnLiéferant()
        {
            return __Lieferant;
        }

    }
}
