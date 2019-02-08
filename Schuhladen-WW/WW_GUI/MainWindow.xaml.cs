using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Schuhladen_WW.DataLayer.Mapping;
using Schuhladen_WW.DataLayer;


namespace WW_GUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataController.CreateDataLayer();

            FillArticleGrid();
            FillHerstellerGrid();
        }

        public void FillArticleGrid()
        {
            List<Live_Article> _ListArticles = DataController.ReturnLiveArtikel();
            
            // Clear items
            ArticleGrid.Items.Clear();

            foreach (Live_Article Article in _ListArticles)
            {
                ArticleGrid.Items.Add(Article);
            }
        }

        #region Hersteller
        public void FillHerstellerGrid()
        {
            List<Hersteller> _ListArticles = DataController.ReturnHersteller();

            // Clear items
            HerstellerGrid.Items.Clear();

            foreach (Hersteller hersteller in _ListArticles)
            {
                HerstellerGrid.Items.Add(hersteller);
            }
        }

        #region Erstellen

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Leider keine Zeit mehr für Validierung des Inputs gehabt...
            if (HerstellerNameUpdateInsert.Text != "" && HerstellerStrasseUpdateInsert.Text != "" && HerstellerHausnummerUpdateInsert.Text != "" && HerstellerPostleitzahlUpdateInsert.Text != "" && HerstellerOrtUpdateInsert.Text != "" && HerstellerAdresszusatzUpdateInsert.Text != "")
            {
                HerstellerSaveButtonInsert.IsEnabled = true;
            }
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
            FillHerstellerGrid();
            HerstellerGrid.Items.Refresh();

            // Clear formular
            HerstellerNameUpdateInsert.Text = "";
            HerstellerStrasseUpdateInsert.Text = "";
            HerstellerHausnummerUpdateInsert.Text = "";
            HerstellerPostleitzahlUpdateInsert.Text = "";
            HerstellerOrtUpdateInsert.Text = "";
            HerstellerAdresszusatzUpdateInsert.Text = "";

            HerstellerNothingSelectedInsert.Content = "Datensatz erfolgreich erstellt!";
            HerstellerNothingSelectedInsert.Foreground = Brushes.Green;
            HerstellerNothingSelectedInsert.Visibility = Visibility.Visible;
            HerstellerSaveButtonInsert.IsEnabled = false;

        }
        #endregion

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

                FillHerstellerGrid();
                HerstellerGrid.Items.Refresh();

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

            HerstellerNameUpdate.Text = "";
            HerstellerStrasseUpdate.Text = "";
            HerstellerHausnummerUpdate.Text = "";
            HerstellerPostleitzahlUpdate.Text = "";
            HerstellerOrtUpdate.Text = "";
            HerstellerAdresszusatzUpdate.Text = "";

            DataController.UpdateHerstellerRelations();
            FillHerstellerGrid();
            HerstellerGrid.Items.Refresh();
            HerstellerGrid.UnselectAll();

            HerstellerNothingSelected.Content = "Datensatz erfolgreich gelöscht!";
            HerstellerNothingSelected.Foreground = Brushes.Green;
            HerstellerNothingSelected.Visibility = Visibility.Visible;
            HerstellerSaveButton.IsEnabled = false;
        }

        #endregion

        #endregion

        #region Live_Artikel

        private void ArtikelGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (ArticleGrid.SelectedIndex != -1)
            {
                Live_Article _LiveArtikel = (Live_Article)ArticleGrid.SelectedItem;
                ArtikelNothingSelected.Visibility = Visibility.Hidden;
                ArtikelNothingSelected.Content = "Selektieren Sie einen Datensatz";
                ArtikelSaveButtonUpdate.IsEnabled = true;
                // ArtikelDeleteButton.IsEnabled = true;

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
                ArtikelGroesseUpdate.Items.Refresh();
                ArtikelEKUpdate.Text = _LiveArtikel.dbl_BuyPrice.ToString();
                ArtikelVKUpdate.Text = _LiveArtikel.dbl_SellPrice.ToString();
                ArtikelBestandUpdate.Text = _LiveArtikel.int_Stock.ToString();
            }
        }

        private void ArtikelSaveButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            // Leider keine Zeit mehr für Validierung des Inputs gehabt...
            if (ArtikelBestandUpdate.Text != "" && ArtikelVKUpdate.Text != "" && ArtikelEKUpdate.Text != "" && ArtikelGroesseUpdate.Text != "" && ArtikelGroesseUpdate.Text != "" && ArtikelEANUpdate.Text != "")
            {
                // Fill objects for update
                Live_Article _LiveArticle = (Live_Article)ArticleGrid.SelectedItem;

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
                FillArticleGrid();
                ArticleGrid.Items.Refresh();

                ArtikelNothingSelected.Content = "Datensatz erfolgreich aktualisiert!";
                ArtikelNothingSelected.Foreground = Brushes.Green;
                ArtikelNothingSelected.Visibility = Visibility.Visible;
                ArtikelSaveButtonUpdate.IsEnabled = false;
            }
        }
        #endregion
    }

}
