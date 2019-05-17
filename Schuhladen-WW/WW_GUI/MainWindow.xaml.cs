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
using WW_GUI.Frontend;
using System.Linq;

namespace WW_GUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        FrontenController _Controller = new FrontenController();


        public MainWindow()
        {
            InitializeComponent();

            DataController.CreateDataLayer();

            HerstellerGrid =  _Controller.FillHerstellerGrid(HerstellerGrid, DataController.ReturnHersteller());
            ModelGrid = _Controller.FillModelGrid(ModelGrid, DataController.ReturnModels());
            ArticleGrid = _Controller.FillArticleGrid(ArticleGrid, DataController.ReturnLiveArtikel());

            _Controller.ClientSubscribe();

            _Controller.ResubcribeClients();

        }

        #region Hersteller

        #region Erstellen

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _Controller.UnlockSaveButton(HerstellerSaveButtonInsert, HerstellerInsertGrid);
        }

        private void HerstellerSaveButtonInsert_Click(object sender, RoutedEventArgs e)
        {
            Hersteller _Hersteller = new Hersteller();
            Adresse _Adresse = new Adresse();

            _Hersteller.str_Name = HerstellerNameUpdateInsert.Text;
            _Adresse.str_Strasse = HerstellerStrasseUpdateInsert.Text;
            _Adresse.str_Hausnummer = HerstellerHausnummerUpdateInsert.Text;
            _Adresse.str_Plz = HerstellerPostleitzahlUpdateInsert.Text;
            _Adresse.str_Ort = HerstellerOrtUpdateInsert.Text;
            _Adresse.str_Adresszusatz = HerstellerAdresszusatzUpdateInsert.Text;

            _Hersteller.InsertNewHersteller(_Hersteller, _Adresse);

            DataController.UpdateHerstellerRelations();

            HerstellerGrid = _Controller.FillHerstellerGrid(HerstellerGrid, DataController.ReturnHersteller());
            ModelGrid = _Controller.FillModelGrid(ModelGrid, DataController.ReturnModels());
            ArticleGrid = _Controller.FillArticleGrid(ArticleGrid, DataController.ReturnLiveArtikel());

            // Clear formular
            _Controller.ClearGrid(HerstellerInsertGrid, false);

            HerstellerNothingSelectedInsert.Content = "Datensatz erfolgreich erstellt!";
            HerstellerNothingSelectedInsert.Foreground = Brushes.Green;
            HerstellerNothingSelectedInsert.Visibility = Visibility.Visible;
            HerstellerSaveButtonInsert.IsEnabled = false;
        }

        #endregion Erstellen

        #region Bearbeiten

        private void HerstellerGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (HerstellerGrid.SelectedIndex != -1)
            {
                Hersteller _Hersteller = (Hersteller)HerstellerGrid.SelectedItem;
                HerstellerNothingSelected.Visibility = Visibility.Hidden;
                HerstellerNothingSelected.Content = "Selektieren Sie einen Datensatz";
                HerstellerSaveButton.IsEnabled = true;
                HerstellerDeleteButton.IsEnabled = true;

                HerstellerNameUpdate.Text = _Hersteller.str_Name;
                HerstellerStrasseUpdate.Text = _Hersteller._Adresse.str_Strasse;
                HerstellerHausnummerUpdate.Text = _Hersteller._Adresse.str_Hausnummer;
                HerstellerPostleitzahlUpdate.Text = _Hersteller._Adresse.str_Plz;
                HerstellerOrtUpdate.Text = _Hersteller._Adresse.str_Ort;
                HerstellerAdresszusatzUpdate.Text = _Hersteller._Adresse.str_Adresszusatz;
            }
        }

        // Speichern
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Leider keine Zeit mehr für Validierung des Inputs gehabt...
            if (HerstellerNameUpdate.Text != "" && HerstellerStrasseUpdate.Text != "" && HerstellerHausnummerUpdate.Text != "" && HerstellerPostleitzahlUpdate.Text != "" && HerstellerOrtUpdate.Text != "" && HerstellerAdresszusatzUpdate.Text != "")
            {
                // Fill objects for update
                Hersteller _Hersteller = (Hersteller)HerstellerGrid.SelectedItem;
                _Hersteller.str_Name = HerstellerNameUpdate.Text;
                _Hersteller._Adresse.str_Strasse = HerstellerStrasseUpdate.Text;
                _Hersteller._Adresse.str_Hausnummer = HerstellerHausnummerUpdate.Text;
                _Hersteller._Adresse.str_Plz = HerstellerPostleitzahlUpdate.Text;
                _Hersteller._Adresse.str_Ort = HerstellerOrtUpdate.Text;
                _Hersteller._Adresse.str_Adresszusatz = HerstellerAdresszusatzUpdate.Text;

                // Update corresponding objects
                _Hersteller.Update();
                _Hersteller._Adresse.Update();

                HerstellerGrid = _Controller.FillHerstellerGrid(HerstellerGrid, DataController.ReturnHersteller());
                ModelGrid = _Controller.FillModelGrid(ModelGrid, DataController.ReturnModels());
                ArticleGrid = _Controller.FillArticleGrid(ArticleGrid, DataController.ReturnLiveArtikel());

                HerstellerNothingSelected.Content = "Datensatz erfolgreich aktualisiert!";
                HerstellerNothingSelected.Foreground = Brushes.Green;
                HerstellerNothingSelected.Visibility = Visibility.Visible;
                HerstellerSaveButton.IsEnabled = false;
            }
        }

        // Löschen
        private void HerstellerDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Hersteller _Hersteller = (Hersteller)HerstellerGrid.SelectedItem;
            _Hersteller.Delete();

            // Clear formular
            _Controller.ClearGrid(HerstellerUpdateGrid, false);

            DataController.UpdateHerstellerRelations();

            HerstellerGrid = _Controller.FillHerstellerGrid(HerstellerGrid, DataController.ReturnHersteller());
            ModelGrid = _Controller.FillModelGrid(ModelGrid, DataController.ReturnModels());
            ArticleGrid = _Controller.FillArticleGrid(ArticleGrid, DataController.ReturnLiveArtikel());

            HerstellerGrid.UnselectAll();

            HerstellerNothingSelected.Content = "Datensatz erfolgreich gelöscht!";
            HerstellerNothingSelected.Foreground = Brushes.Green;
            HerstellerNothingSelected.Visibility = Visibility.Visible;
            HerstellerSaveButton.IsEnabled = false;
        }

        #endregion Bearbeiten

        #endregion Hersteller

        #region Model

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Leider keine Zeit mehr für Validierung des Inputs gehabt...
            if (ModelBezeichnungUpdateInsert.Text != "" && ModelHerstellerUpdateInsert.Text != "")
            {
                ModelSaveButtonInsert.IsEnabled = true;
            }
            _Controller.UnlockSaveButton(HerstellerSaveButtonInsert, HerstellerInsertGrid);
        }

        private void textBox1_TextChanged(object sender, SelectionChangedEventArgs e)
        {
            // Leider keine Zeit mehr für Validierung des Inputs gehabt...
            if (ModelBezeichnungUpdateInsert.Text != "" && ModelHerstellerUpdateInsert.Text != "")
            {
                ModelSaveButtonInsert.IsEnabled = true;
            }
        }

        private void ModelGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (ModelGrid.SelectedIndex != -1)
            {
                Model _Model = (Model)ModelGrid.SelectedItem;
                ModelNothingSelectedUpdate.Content = "";
                ModelNothingSelectedUpdate.Visibility = Visibility.Hidden;
                ModelNothingSelectedUpdate.Content = "Selektieren Sie einen Datensatz";
                ModelSaveButtonUpdate.IsEnabled = true;
                ModelDeleteButtonUpdate.IsEnabled = true;

                ModelHerstellerUpdateInsert.Items.Clear();
                foreach (Hersteller item in DataController.ReturnHersteller())
                {
                    ComboBoxItem cbitem = new ComboBoxItem();
                    cbitem.Content = item.str_Name;
                    ModelHerstellerUpdateInsert.Items.Add(cbitem);
                }

                ModelHerstellerUpdateUpdate.Items.Clear();
                foreach (Hersteller item in DataController.ReturnHersteller())
                {
                    ComboBoxItem cbitem = new ComboBoxItem();
                    cbitem.Content = item.str_Name;
                    ModelHerstellerUpdateUpdate.Items.Add(cbitem);
                }
                foreach (ComboBoxItem item in ModelHerstellerUpdateUpdate.Items)
                {
                    if (item.Content.ToString() == _Model._Hersteller.str_Name)
                    {
                        ModelHerstellerUpdateUpdate.SelectedItem = item;
                    }
                }
                ModelBezeichnungUpdateUpdate.Text = _Model.str_Description;
            }
        }

        private void ModelSaveButtonInsert_Click(object sender, RoutedEventArgs e)
        {
            Model _Model = new Model();

            _Model.str_Description = ModelBezeichnungUpdateInsert.Text;

            foreach (Hersteller item in DataController.ReturnHersteller())
            {
                if (ModelHerstellerUpdateInsert.Text == item.str_Name)
                {
                    _Model.int_Manufacturer = item.int_ID;
                }
            }

            _Model.Insert();

            DataController.CreateDataLayer();

            HerstellerGrid = _Controller.FillHerstellerGrid(HerstellerGrid, DataController.ReturnHersteller());
            ModelGrid = _Controller.FillModelGrid(ModelGrid, DataController.ReturnModels());
            ArticleGrid = _Controller.FillArticleGrid(ArticleGrid, DataController.ReturnLiveArtikel());

            // Clear formular
            _Controller.ClearGrid(ModelInsertGrid, true);

            ModelNothingSelectedInsert.Content = "Datensatz erfolgreich erstellt!";
            ModelNothingSelectedInsert.Foreground = Brushes.Green;
            ModelNothingSelectedInsert.Visibility = Visibility.Visible;
            ModelSaveButtonInsert.IsEnabled = false;
        }

        private void ModelSaveButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            Model _Model = (Model)ModelGrid.SelectedItem;

            _Model.str_Description = ModelBezeichnungUpdateUpdate.Text;

            foreach (Hersteller item in DataController.ReturnHersteller())
            {
                if (ModelHerstellerUpdateUpdate.Text == item.str_Name)
                {
                    _Model.int_Manufacturer = item.int_ID;
                }
            }

            _Model.Update();

            DataController.CreateDataLayer();
            HerstellerGrid = _Controller.FillHerstellerGrid(HerstellerGrid, DataController.ReturnHersteller());
            ModelGrid = _Controller.FillModelGrid(ModelGrid, DataController.ReturnModels());
            ArticleGrid = _Controller.FillArticleGrid(ArticleGrid, DataController.ReturnLiveArtikel());

            ModelNothingSelectedUpdate.Content = "Datensatz erfolgreich aktualisiert!";
            ModelNothingSelectedUpdate.Foreground = Brushes.Green;
            ModelNothingSelectedUpdate.Visibility = Visibility.Visible;
            ModelSaveButtonUpdate.IsEnabled = false;
        }

        // Löschen
        private void ModelDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Model _Model = (Model)ModelGrid.SelectedItem;
            _Model.Delete();

            // Clear formular
            _Controller.ClearGrid(ModelUpdateGrid, true);

            DataController.CreateDataLayer();
            HerstellerGrid = _Controller.FillHerstellerGrid(HerstellerGrid, DataController.ReturnHersteller());
            ModelGrid = _Controller.FillModelGrid(ModelGrid, DataController.ReturnModels());
            ArticleGrid = _Controller.FillArticleGrid(ArticleGrid, DataController.ReturnLiveArtikel());

            ModelNothingSelectedUpdate.Content = "Datensatz erfolgreich gelöscht!";
            ModelNothingSelectedUpdate.Foreground = Brushes.Green;
            ModelNothingSelectedUpdate.Visibility = Visibility.Visible;
            ModelSaveButtonUpdate.IsEnabled = false;
        }


        #endregion

        #region Live_Artikel

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Leider keine Zeit mehr für Validierung des Inputs gehabt...
            if (ArtikelModelInsert.Text != "" && ArtikelEANInsert.Text != "" && ArtikelGroesseInsert.Text != "" && ArtikelEKInserte.Text != "" && ArtikelVKInsert.Text != "" && ArtikelBestandInsert.Text != "")
            {
                ArtikelSaveButtonInsert.IsEnabled = true;
            }
        }

        private void textBox3_TextChanged(object sender, SelectionChangedEventArgs e)
        {
            // Leider keine Zeit mehr für Validierung des Inputs gehabt...
            if (ArtikelModelInsert.Text != "" && ArtikelEANInsert.Text != "" && ArtikelGroesseInsert.Text != "" && ArtikelEKInserte.Text != "" && ArtikelVKInsert.Text != "" && ArtikelBestandInsert.Text != "")
            {
                ArtikelSaveButtonInsert.IsEnabled = true;
            }
        }

        private void ArtikelGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (ArticleGrid.SelectedIndex != -1)
            {
                Live_Artikel _LiveArtikel = (Live_Artikel)ArticleGrid.SelectedItem;
                ArtikelNothingSelected.Visibility = Visibility.Hidden;
                ArtikelNothingSelected.Content = "Selektieren Sie einen Datensatz";
                ArtikelSaveButtonUpdate.IsEnabled = true;
                ArtikelDeleteButton.IsEnabled = true;

                Live_Artikel _LiveArticle = (Live_Artikel)ArticleGrid.SelectedItem;

                if (_LiveArticle != null)
                {
                    ArtikelLabelDelete.IsEnabled = true;
                } else
                {
                    ArtikelLabelDelete.IsEnabled = false;
                }

                ArtikelModelUpdate.Items.Clear();
                foreach (Model item in DataController.ReturnModels())
                {
                    ComboBoxItem cbitem = new ComboBoxItem();
                    cbitem.Content = item.str_Description;
                    ArtikelModelUpdate.Items.Add(cbitem);
                }
                foreach (ComboBoxItem item in ArtikelModelUpdate.Items)
                {
                    if (item.Content.ToString() == _LiveArtikel._Model.str_Description)
                    {
                        ArtikelModelUpdate.SelectedItem = item;
                    }
                }

                ArtikelModelInsert.Items.Clear();
                foreach (Model item in DataController.ReturnModels())
                {
                    ComboBoxItem cbitem = new ComboBoxItem();
                    cbitem.Content = item.str_Description;
                    ArtikelModelInsert.Items.Add(cbitem);
                }
                ArtikelModelInsert.Items.Refresh();
                ArtikelModelUpdate.Items.Refresh();
                ArtikelEANUpdate.Text = _LiveArtikel.str_EAN;
                ArtikelGroesseUpdate.Items.Clear();
                foreach (Groesse item in DataController.ReturnGroesse())
                {
                    ComboBoxItem cbitem = new ComboBoxItem();
                    cbitem.Content = item.str_EU;
                    ArtikelGroesseUpdate.Items.Add(cbitem);
                }
                foreach (ComboBoxItem item in ArtikelGroesseUpdate.Items)
                {
                    if (item.Content.ToString() == _LiveArtikel._Groesse.str_EU)
                    {
                        ArtikelGroesseUpdate.SelectedItem = item;
                    }
                }
                ArtikelGroesseInsert.Items.Refresh();

                ArtikelGroesseInsert.Items.Clear();
                foreach (Groesse item in DataController.ReturnGroesse())
                {
                    ComboBoxItem cbitem = new ComboBoxItem();
                    cbitem.Content = item.str_EU;
                    ArtikelGroesseInsert.Items.Add(cbitem);
                }
                ArtikelGroesseInsert.Items.Refresh();
                ArtikelGroesseUpdate.Items.Refresh();
                ArtikelEKUpdate.Text = _LiveArtikel.dbl_BuyPrice.ToString();
                ArtikelVKUpdate.Text = _LiveArtikel.dbl_SellPrice.ToString();
                ArtikelBestandUpdate.Text = _LiveArtikel.int_Stock.ToString();

                _Controller.UpdateArticleView(_LiveArtikel, ArtikelStellplatzUpdate, ArtikelIsActive);
            }
        }

        private void ArtikelSaveButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            // Leider keine Zeit mehr für Validierung des Inputs gehabt...
            if (ArtikelBestandUpdate.Text != "" && ArtikelVKUpdate.Text != "" && ArtikelEKUpdate.Text != "" && ArtikelGroesseUpdate.Text != "" && ArtikelGroesseUpdate.Text != "" && ArtikelEANUpdate.Text != "")
            {
                // Fill objects for update
                Live_Artikel _LiveArticle = (Live_Artikel)ArticleGrid.SelectedItem;
                Message _Msg = new Message();

                foreach (Model item in DataController.ReturnModels())
                {
                    if (item.str_Description == ArtikelModelUpdate.Text)
                    {
                        _LiveArticle.int_ModelID = item.int_Id;
                    }
                }

                _LiveArticle.str_EAN = ArtikelEANUpdate.Text;

                double dbl;
                double.TryParse(ArtikelEKUpdate.Text, out dbl);
                _LiveArticle.dbl_BuyPrice = dbl;
                double.TryParse(ArtikelVKUpdate.Text, out dbl);
                _LiveArticle.dbl_SellPrice = dbl;
                _LiveArticle.int_Stock = Convert.ToInt32(ArtikelBestandUpdate.Text);

                _LiveArticle.Update();
                DataController.UpdateArtikel();

                HerstellerGrid = _Controller.FillHerstellerGrid(HerstellerGrid, DataController.ReturnHersteller());
                ModelGrid = _Controller.FillModelGrid(ModelGrid, DataController.ReturnModels());
                ArticleGrid = _Controller.FillArticleGrid(ArticleGrid, DataController.ReturnLiveArtikel());

                if (ArtikelStellplatzUpdate.Text != "")
                {

                    foreach (StellplatzArtikel item in DataController.ReturnStellplatzArtikel())
                    {
                        if (_LiveArticle.int_ID == item.int_ArtikelID)
                        {
                            item.Delete();
                        }
                    }


                    StellplatzArtikel _StellplatzArtikel = new StellplatzArtikel();
                    _StellplatzArtikel.int_ArtikelID = _LiveArticle.int_ID;

                    List<Stellplatz> test = DataController.ReturnStellplatz();

                    foreach (ComboBoxItem item in ArtikelStellplatzUpdate.Items)
                    {
                        foreach (Stellplatz item1 in DataController.ReturnStellplatz())
                        {
                            Console.WriteLine("CB: " + item.Content);
                            Console.WriteLine("Stellplatz: " + item1.str_Bezeichnung);

                            if (item.Content.ToString() == item1.str_Bezeichnung)
                            {
                                _StellplatzArtikel.int_StellplatzID = item1.int_Id;
                                _Msg.str_TopicName = item1.str_Bezeichnung;
                            }
                        }
                    }

                    _StellplatzArtikel.Insert();

                    DataController.CreateDataLayer();

                    
                    _Msg._Message = _LiveArticle.dbl_SellPrice.ToString();

                    _Controller.ClientSendMessage(_Msg);

                    ArtikelIsActive.Content = "Aktiv!";
                    ArtikelIsActive.Foreground = Brushes.Green;
                }

                ArtikelNothingSelected.Content = "Datensatz erfolgreich aktualisiert!";
                ArtikelNothingSelected.Foreground = Brushes.Green;
                ArtikelNothingSelected.Visibility = Visibility.Visible;
                ArtikelSaveButtonUpdate.IsEnabled = false;
            }
        }

        private void ArtikelLabelDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ArtikelIsActive.Content.ToString() == "Aktiv!")
            {
                Live_Artikel _LiveArticle = (Live_Artikel)ArticleGrid.SelectedItem;

                if (DataController.ReturnStellplatzArtikel().Count > 0)
                {
                    try
                    {
                        foreach (StellplatzArtikel Item in DataController.ReturnStellplatzArtikel())
                        {
                            if (Item.int_ArtikelID == _LiveArticle.int_ID)
                            {
                                Item.Delete();
                                DataController.CreateDataLayer();

                                ArticleGrid = _Controller.FillArticleGrid(ArticleGrid, DataController.ReturnLiveArtikel());
                                _Controller.UpdateArticleView(_LiveArticle, ArtikelStellplatzUpdate, ArtikelIsActive);

                                ArtikelIsActive.Content = "Nicht Aktiv!";
                                ArtikelIsActive.Foreground = Brushes.Red;

                                foreach (Stellplatz Items in DataController.ReturnStellplatz())
                                {
                                    if (Item.int_StellplatzID == Items.int_Id)
                                    {
                                        Message _msg = new Message();

                                        _msg.str_TopicName = Items.str_Bezeichnung + "/delete";
                                        _msg._Message = "delete";

                                        _Controller.ClientSendMessage(_msg);
                                    }
                                }
                            }
                        }
                    } catch (Exception ex)
                    {
                        DataController.CreateDataLayer();
                    }
                } else
                {
                    ArtikelIsActive.Content = "Nicht Aktiv!";
                    ArtikelIsActive.Foreground = Brushes.Red;
                }
            }
        }

        private void ArtikelSaveButtonInsert_Click(object sender, RoutedEventArgs e)
        {
            // Leider keine Zeit mehr für Validierung des Inputs gehabt...
            if (ArtikelBestandUpdate.Text != "" && ArtikelVKUpdate.Text != "" && ArtikelEKUpdate.Text != "" && ArtikelGroesseUpdate.Text != "" && ArtikelGroesseUpdate.Text != "" && ArtikelEANUpdate.Text != "")
            {
                // Fill objects for update
                Live_Artikel _LiveArticle = new Live_Artikel();

                foreach (Model item in DataController.ReturnModels())
                {
                    if (item.str_Description == ArtikelModelInsert.Text)
                    {
                        _LiveArticle.int_ModelID = item.int_Id;
                    }
                }

                foreach (Groesse item in DataController.ReturnGroesse())
                {
                    if (item.str_EU == ArtikelGroesseInsert.Text)
                    {
                        _LiveArticle.int_SizeID = item.int_Id;
                    }
                }

                _LiveArticle.str_EAN = ArtikelEANInsert.Text;

                double dbl;
                double.TryParse(ArtikelEKInserte.Text, out dbl);
                _LiveArticle.dbl_BuyPrice = dbl;
                double.TryParse(ArtikelVKInsert.Text, out dbl);
                _LiveArticle.dbl_SellPrice = dbl;
                _LiveArticle.int_Stock = Convert.ToInt32(ArtikelBestandInsert.Text);

                _LiveArticle.Insert();

                _Controller.ClearGrid(ArtikelInsertGrid, true);

                DataController.CreateDataLayer();
                ArticleGrid = _Controller.FillArticleGrid(ArticleGrid, DataController.ReturnLiveArtikel());

                ArtikelNothingSelectedInsert.Content = "Datensatz erfolgreich erstellt!";
                ArtikelNothingSelectedInsert.Foreground = Brushes.Green;
                ArtikelNothingSelectedInsert.Visibility = Visibility.Visible;
                ArtikelSaveButtonInsert.IsEnabled = false;
            }
        }

        private void ArticleDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Live_Artikel _Live_Article = (Live_Artikel)ArticleGrid.SelectedItem;
            _Live_Article.Delete();

            _Controller.ClearGrid(ArtikelUpdateGrid, true);

            foreach (StellplatzArtikel item in DataController.ReturnStellplatzArtikel())
            {
                if (item.int_ArtikelID == _Live_Article.int_ID)
                {
                    item.Delete();

                    ArtikelIsActive.Content = "Nicht Aktiv!";
                    ArtikelIsActive.Foreground = Brushes.Red;
                }
            }

            DataController.CreateDataLayer();
            HerstellerGrid = _Controller.FillHerstellerGrid(HerstellerGrid, DataController.ReturnHersteller());
            ModelGrid = _Controller.FillModelGrid(ModelGrid, DataController.ReturnModels());
            ArticleGrid = _Controller.FillArticleGrid(ArticleGrid, DataController.ReturnLiveArtikel());

            ArtikelNothingSelected.Content = "Datensatz erfolgreich gelöscht!";
            ArtikelNothingSelected.Foreground = Brushes.Green;
            ArtikelNothingSelected.Visibility = Visibility.Visible;
            ArtikelDeleteButton.IsEnabled = false; 
            
        }

        #endregion Live_Artikel

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _Controller.sendExitCode();
        }
    }
}