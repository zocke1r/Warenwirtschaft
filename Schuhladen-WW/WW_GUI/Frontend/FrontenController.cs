using System;
using System.Threading;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Schuhladen_WW.DataLayer;
using Schuhladen_WW.DataLayer.Mapping;
using MQTTClient.Client;
using MQTTClient.Data;

namespace WW_GUI.Frontend
{
    class FrontenController
    {
        #region Private members
        private static Client _Client = new Client();
        #endregion

        #region Public members
        #endregion

        #region Public methods
        public FrontenController()
        {

        }

        #region Buttons
        public void UnlockSaveButton(Button _btn, Grid _grid)
        {
            _btn.IsEnabled = CheckGridContent(_grid, true) ? true : false;
        }
        #endregion

        #region Grids
        public DataGrid FillHerstellerGrid(DataGrid _grid, List<Hersteller> _list)
        {
            // Clear grid if data exists
            _grid.Items.Clear();

            // Fill grid with items 
            foreach (BaseClassDataLayer Item in _list)
            {
                _grid.Items.Add(Item);
            }

            _grid.Items.Refresh();

            //return results
            return _grid;
        }

        public DataGrid FillModelGrid(DataGrid _grid, List<Model> _list)
        {
            // Clear grid if data exists
            _grid.Items.Clear();

            // Fill grid with items 
            foreach (BaseClassDataLayer Item in _list)
            {
                _grid.Items.Add(Item);
            }

            _grid.Items.Refresh();

            //return results
            return _grid;
        }

        public DataGrid FillArticleGrid(DataGrid _grid, List<Live_Artikel> _list)
        {
            // Clear grid if data exists
            _grid.Items.Clear();

            // Fill grid with items 
            foreach (BaseClassDataLayer Item in _list)
            {
                _grid.Items.Add(Item);
            }

            _grid.Items.Refresh();

            //return results
            return _grid;
        }

        public void ClearGrid(Grid _grid, bool bool_ClearComboboxes)
        {    
            foreach (Control Item in _grid.Children)
            {
                if (Item is TextBox)
                {
                    ((TextBox)Item).Text = "";
                } else if (Item is ComboBox && bool_ClearComboboxes)
                {
                    ((ComboBox)Item).Items.Clear();
                }
            }
        }

        public bool CheckGridContent(Grid _grid, bool bool_WithComboboxes)
        {
            bool bool_IsNotEmpty = true;
            foreach (Control Item in _grid.Children)
            {
                if (Item is TextBox)
                {
                    if (((TextBox)Item).Text == "")
                    {
                        bool_IsNotEmpty = false;
                    }
                }
                else if (Item is ComboBox && bool_WithComboboxes)
                {
                    if (((ComboBox)Item).SelectedValue.ToString() == "")
                    {
                        bool_IsNotEmpty = false;
                    }
                }
            }
            return bool_IsNotEmpty;
        }
        #endregion

        #region MQTT Client
        public void ClientSubscribe()
        {
            Thread.Sleep(1500);
            _Client.SubscribeAsyncInitial();
        }

        public void ClientSendMessage(Message _msg)
        {
            _Client.publish(_msg);
        }

        public void sendExitCode()
        {
            Message _msg = new Message();

            _msg.str_TopicName = "exit";
            _msg._Message = "";

            _Client.publish(_msg);
        }

        public void ResubcribeClients()
        {
            foreach(Stellplatz Item in DataController.ReturnStellplatz())
            {
                Message _msg = new Message();

                _msg.str_TopicName = Item.str_Bezeichnung;
                _Client.SubscribeAsync(_msg);

                _msg.str_TopicName = Item.str_Bezeichnung + "/delete";
                _Client.SubscribeAsync(_msg);
            }
            sendExitCode();
        }
        #endregion

        #region Live_artikel
        public void UpdateArticleView(Live_Artikel _LiveArtikel, ComboBox ArtikelStellplatzUpdate, Label ArtikelIsActive)
        {
            ArtikelStellplatzUpdate.Items.Clear();

            foreach (Stellplatz item in DataController.ReturnStellplatz())
            {
                bool bool_IsInUse = false;

                foreach (StellplatzArtikel item1 in DataController.ReturnStellplatzArtikel())
                {
                    if (item.int_Id == item1.int_StellplatzID)
                    {
                        bool_IsInUse = true;
                        if (_LiveArtikel.int_ID == item1.int_ArtikelID)
                        {
                            bool_IsInUse = false;
                            ArtikelIsActive.Content = "Aktiv!";
                            ArtikelIsActive.Foreground = Brushes.Green;
                        }
                        else
                        {
                            ArtikelIsActive.Content = "Nicht Aktiv!";
                            ArtikelIsActive.Foreground = Brushes.Red;
                        }
                    }
                }
                if (!bool_IsInUse)
                {
                    ComboBoxItem cbitem = new ComboBoxItem();
                    cbitem.Content = item.str_Bezeichnung;
                    ArtikelStellplatzUpdate.Items.Add(cbitem);
                }
            }

            foreach (ComboBoxItem item in ArtikelStellplatzUpdate.Items)
            {
                foreach (Stellplatz item1 in DataController.ReturnStellplatz())
                {
                    if (item.Content.ToString() == item1.str_Bezeichnung)
                    {
                        foreach (StellplatzArtikel item2 in DataController.ReturnStellplatzArtikel())
                        {
                            if (item1.int_Id.ToString() == item2.int_StellplatzID.ToString())
                            {
                                ArtikelStellplatzUpdate.SelectedItem = item;
                            }
                        }
                    }
                }
            }
            ArtikelStellplatzUpdate.Items.Refresh();
        }
        #endregion

        #region Hersteller
        #endregion

        #region Model
        #endregion

        #endregion

    }
}
