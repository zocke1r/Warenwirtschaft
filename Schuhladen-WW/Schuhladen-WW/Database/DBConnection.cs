﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Schuhladen_WW.DataBase
{
    internal sealed class DBConnection
    {
        private SqlConnection _Connection;

        // Instanz die zurückgegeben werden soll
        private static DBConnection _DBConnection;

        // Konstruktor
        protected DBConnection()
        {
            // Initialisieren
            _Connection = new SqlConnection();
            _Connection.ConnectionString = GetConnectionString("DBConnectionString");
        }

        #region Public Methods

        // Gibt die zuvor deklarierte Instanz zurück
        public static DBConnection Instance()
        {
            if (_DBConnection == null)
            {
                _DBConnection = new DBConnection();
            }
            return _DBConnection;
        }

        // Holt Daten aus der Datenbank
        public DataTable GetData(string str_QueryString)
        {
            var _ResultTable = new DataTable();
            try
            {
                if (Open())
                {
                    using (SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter(str_QueryString, _Connection))
                    {
                        _SqlDataAdapter.Fill(_ResultTable);
                        Close();
                        return _ResultTable;
                    }
                }
                return _ResultTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception occured: " + ex.Message);
                return _ResultTable;
            }
            finally
            {
                _Connection.Close();
            }
        }

        public bool UpdateData(SqlCommand _command)
        {
            try
            {
                if (Open())
                {
                    _command.Connection = _Connection;
                    _command.ExecuteNonQuery();
                    Close();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception occured: " + ex.Message);
                return false;
            }
            finally
            {
                _Connection.Close();
            }
        }

        #endregion Public Methods

        #region Private Methods

        // Öffnet eine Verbindung zu Datenbank
        private bool Open()
        {
            try
            {
                _Connection.Open();
                if (!(_Connection.State == ConnectionState.Open))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception occured: " + ex.Message);
                return false;
            }
        }

        // Schließt die aktuelle Verbindung zur Datenbank
        private bool Close()
        {
            int int_CurrentState = Convert.ToInt32(_Connection.State);
            try
            {
                if (int_CurrentState == 1)
                {
                    _Connection.Close();
                    return true;
                }
                Console.WriteLine("Could not close connection. Current connection state: " + int_CurrentState);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception occured: " + ex.Message);
                return false;
            }
            finally
            {
                _Connection.Close();
            }
        }

        // Holt den Connection string aus App.conf oder gibt Null zurück, wenn Wert nicht gefunden wird.
        private static string GetConnectionString(string str_NameOfString)
        {
            string str_ValueToReturn = null;
            if (ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString != null)
            {
                return ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            }
            return str_ValueToReturn;
        }

        #endregion Private Methods
    }
}