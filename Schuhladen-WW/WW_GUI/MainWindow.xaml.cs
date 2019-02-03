using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Schuhladen_WW.DataLayer.Mapping;
using Schuhladen_WW.Mapping;
using Schuhladen_WW.CustomEvents;
using Schuhladen_WW.DataLayer;
using MahApps.Metro;
using MahApps.Metro.Controls;

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

        #region Bearbeiten
        private void HerstellerGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (HerstellerGrid.SelectedIndex != -1)
            {
                Hersteller _Hersteller = (Hersteller)HerstellerGrid.SelectedItem;
                HerstellerNothingSelected.Visibility = Visibility.Hidden;
                HerstellerNothingSelected.Content = "Selektieren Sie einen Datensatz";
                HerstellerSaveButton.IsEnabled = true;

                HerstellerNameUpdate.Text = _Hersteller.str_Name;
                HerstellerStrasseUpdate.Text = _Hersteller._Adresse.str_Strasse;
                HerstellerHausnummerUpdate.Text = _Hersteller._Adresse.str_Hausnummer;
                HerstellerPostleitzahlUpdate.Text = _Hersteller._Adresse.str_Plz;
                HerstellerOrtUpdate.Text = _Hersteller._Adresse.str_Ort;
                HerstellerAdresszusatzUpdate.Text = _Hersteller._Adresse.str_Adresszusatz;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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

                // Recreate data layer
                DataController.UpdateHerstellerRelations();

                HerstellerGrid.Items.Refresh();

                HerstellerNothingSelected.Content = "Datensatz erfolgreich aktualisiert!";
                HerstellerNothingSelected.Foreground = Brushes.Green;
                HerstellerNothingSelected.Visibility = Visibility.Visible;
                HerstellerSaveButton.IsEnabled = false;
            }
        }
        #endregion

        #endregion
    }
}
