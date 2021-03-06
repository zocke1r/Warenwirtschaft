﻿using Schuhladen_WW.DataBase;
using Schuhladen_WW.Mapping;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Schuhladen_WW.DataLayer.Mapping
{
    public static class DataController
    {
        #region Private Members

        // New database connection
        private static DBConnection _Connection = DBConnection.Instance();

        // Collections (Lazyloading)
        private static List<Live_Artikel> __LiveArticle { get; set; }

        private static List<Model> __Model { get; set; }

        private static List<Groesse> __Groesse { get; set; }

        private static List<Hersteller> __Hersteller { get; set; }

        private static List<Adresse> __Adresse { get; set; }

        private static List<AusgangsRechnung> __AusgangsRechnung { get; set; }

        private static List<Status> __Status { get; set; }

        private static List<Benutzer> __Benutzer { get; set; }

        private static List<Lieferant> __Lieferant { get; set; }

        private static List<Kategorie> __Kategorie { get; set; }

        private static List<Bestellung> __Bestellung { get; set; }

        private static List<BestellungPositionPosition> __BestellungPositionPosition { get; set; }

        private static List<AusgangsrechnungPosition> __AusgangsrechnungPosition { get; set; }

        private static List<Stellplatz> __Stellplatz { get; set; }

        private static List<StellplatzArtikel> __StellplatzArtikel { get; set; }

        // Initialize object mappers
        private static PropertyMapper<Live_Artikel> ___LiveArticleMapper = new PropertyMapper<Live_Artikel>();
        private static PropertyMapper<Model> ___ModelListMapper = new PropertyMapper<Model>();
        private static PropertyMapper<Groesse> ___GroesseListMapper = new PropertyMapper<Groesse>();
        private static PropertyMapper<Hersteller> ___HerstellerListMapper = new PropertyMapper<Hersteller>();
        private static PropertyMapper<Adresse> ___AdresseListMapper = new PropertyMapper<Adresse>();
        private static PropertyMapper<AusgangsRechnung> ___AusgangsRechnungListMapper = new PropertyMapper<AusgangsRechnung>();
        private static PropertyMapper<Status> ___StatusListMapper = new PropertyMapper<Status>();
        private static PropertyMapper<Benutzer> ___BenutzerListMapper = new PropertyMapper<Benutzer>();
        private static PropertyMapper<Lieferant> ___LieferantListMapper = new PropertyMapper<Lieferant>();
        private static PropertyMapper<Kategorie> ___KategorieListMapper = new PropertyMapper<Kategorie>();
        private static PropertyMapper<Bestellung> ___BestellungListMapper = new PropertyMapper<Bestellung>();
        private static PropertyMapper<BestellungPositionPosition> ___BestellungPositionPositionListMapper = new PropertyMapper<BestellungPositionPosition>();
        private static PropertyMapper<AusgangsrechnungPosition> ___AusgangsrechnungPositionListMapper = new PropertyMapper<AusgangsrechnungPosition>();
        private static PropertyMapper<Stellplatz> ___StellplatzMapper = new PropertyMapper<Stellplatz>();
        private static PropertyMapper<StellplatzArtikel> ___StellplatzArtikelMapper = new PropertyMapper<StellplatzArtikel>();

        #endregion Private Members

        #region Public Members

        

        static DataController()
        {
            //SqlCommand _cmd = new SqlCommand();
            //_cmd.CommandType = System.Data.CommandType.Text;
            //_cmd.CommandText = "DELETE FROM dbo.StellplatzArtikel WHERE ID != 0;";
            //_Connection.UpdateData(_cmd);
            //_cmd.CommandText = "DELETE FROM dbo.Stellplatz WHERE ID != 0;";
            //_Connection.UpdateData(_cmd);
        }

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

        public static List<Lieferant> ReturnLieferant()
        {
            return __Lieferant;
        }

        public static List<Live_Artikel> ReturnLiveArtikel()
        {
            return __LiveArticle;
        }

        public static List<Bestellung> ReturnBestellung()
        {
            return __Bestellung;
        }

        public static List<AusgangsRechnung> ReturnAusgangsRechnung()
        {
            return __AusgangsRechnung;
        }

        public static List<Hersteller> ReturnHersteller()
        {
            return __Hersteller;
        }

        public static List<Stellplatz> ReturnStellplatz()
        {
            return __Stellplatz;
        }

        public static List<StellplatzArtikel> ReturnStellplatzArtikel()
        {
            return __StellplatzArtikel;
        }

        #endregion Public Members

        #region Public Methods

        public static void UpdateHerstellerRelations()
        {
            // Get Hersteller collection
            __Hersteller = ___HerstellerListMapper.Map(_Connection.GetData("SELECT * FROM dbo.Hersteller;")).ToList();

            // Get Adresse collection
            __Adresse = ___AdresseListMapper.Map(_Connection.GetData("SELECT * FROM dbo.Adresse;")).ToList();
        }

        public static void UpdateArtikel()
        {
            // Gets Live_Article collection
            __LiveArticle = ___LiveArticleMapper.Map(_Connection.GetData("SELECT * FROM dbo.Live_Artikel;")).ToList();
        }

        public static void CreateDataLayer()
        {
            // Gets Live_Article collection
            __LiveArticle = ___LiveArticleMapper.Map(_Connection.GetData("SELECT * FROM dbo.Live_Artikel;")).ToList();

            // Gets Model collection
            __Model = ___ModelListMapper.Map(_Connection.GetData("SELECT * FROM dbo.Model;")).ToList();

            // Get Groesse collection
            __Groesse = ___GroesseListMapper.Map(_Connection.GetData("SELECT * FROM dbo.Groesse;")).ToList();

            // Get Hersteller collection
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

            // Get Kategorie collection
            __Kategorie = ___KategorieListMapper.Map(_Connection.GetData("SELECT * FROM dbo.Kategorie;")).ToList();

            // Get Bestellung collection
            __Bestellung = ___BestellungListMapper.Map(_Connection.GetData("SELECT * FROM dbo.Bestellung;")).ToList();

            // Get BestellungPositionPosition collection
            // __BestellungPositionPosition = ___BestellungPositionPositionListMapper.Map(_Connection.GetData("SELECT * FROM dbo.BestellungPosition;")).ToList();

            // Get AusgangsrechnungPosition collection
            __AusgangsrechnungPosition = ___AusgangsrechnungPositionListMapper.Map(_Connection.GetData("SELECT * FROM dbo.AusgangsrechnungPosition;")).ToList();

            // Get Stellplatz collection
            __Stellplatz = ___StellplatzMapper.Map(_Connection.GetData("SELECT * FROM dbo.Stellplatz;")).ToList();

            // Get Stellplatz collection
            __StellplatzArtikel = ___StellplatzArtikelMapper.Map(_Connection.GetData("SELECT * FROM dbo.StellplatzArtikel;")).ToList();
        }

        public static bool UpdateObject(SqlCommand _Command)
        {
            if (_Connection.UpdateData(_Command))
            {
                return true;
            }
            return false;
        }

        #endregion Public Methods
    }
}