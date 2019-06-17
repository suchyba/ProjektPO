using Plaza.Technologie_Testowe;
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
using System.Windows.Shapes;

namespace Plaza.Testowe_okna
{
    /// <summary>
    /// Logika interakcji dla klasy Mecze.xaml
    /// </summary>
    public partial class Mecze : Window
    {
        /// <summary>
        /// Lista Meczy
        /// </summary>
        public Mecze()
        {
            InitializeComponent();
            MeczeDataGrid.ItemsSource = StatycznaBazaWszytkichDanych.GetBaza().GetListaMeczy();
        }
        /// <summary>
        /// Ładowanie okna
        /// </summary>
        /// <param name="sender">parametr z  referencją do obiektu, który wywołuje wydarzenie</param>
        /// <param name="e">parametr zawierający dane wydarzenia</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource meczViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("meczViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // meczViewSource.Źródło = [ogólne źródło danych]
            System.Windows.Data.CollectionViewSource meczSiatkowkiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("meczSiatkowkiViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // meczSiatkowkiViewSource.Źródło = [ogólne źródło danych]
            System.Windows.Data.CollectionViewSource druzynaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("druzynaViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // druzynaViewSource.Źródło = [ogólne źródło danych]
            List<string> listaSportow = new List<string>();
            listaSportow.Add("Siatkówka");
            listaSportow.Add("Przeciąganie Liny");
            listaSportow.Add("Dwa Ognie");
            Sport.ItemsSource = listaSportow;

            System.Windows.Data.CollectionViewSource sedziaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("sedziaViewSource")));
        }
        /// <summary>
        /// Ładowanie comboboxa drużyn
        /// </summary>
        /// <param name="sender">parametr z  referencją do obiektu, który wywołuje wydarzenie</param>
        /// <param name="e">parametr zawierający dane wydarzenia</param>
        private void DruzynyCombo_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = StatycznaBazaWszytkichDanych.GetBaza().GetListaDruzyn();
        }
        /// <summary>
        /// Przycisk odpowiedzialny za dodawanie meczów
        /// </summary>
        /// <param name="sender">parametr z  referencją do obiektu, który wywołuje wydarzenie</param>
        /// <param name="e">parametr zawierający dane wydarzenia</param>
        private void DodajMeczButt_Click(object sender, RoutedEventArgs e)
        {
            BazaDanych baza = StatycznaBazaWszytkichDanych.GetBaza();

            if (Druzyna1Combo.SelectedItem is DruzynaSiatkowka)
            {
                baza.DodajMecz(new MeczSiatkowki(Druzyna1Combo.SelectedItem as Druzyna, Druzyna2Combo.SelectedItem as Druzyna, SedziaGlownyCombo.SelectedItem as Sedzia, (int)StopienMeczu.MeczLigowy, SedziaPomocniczy1Combo.SelectedItem as Sedzia, SedziaPomocniczy2Combo.SelectedItem as Sedzia, int.Parse(WynikDruzyna1.Text), int.Parse(WynikDruzyna2.Text)));
            }
            else 
            {
                baza.DodajMecz(new Mecz(Druzyna1Combo.SelectedItem as Druzyna, Druzyna2Combo.SelectedItem as Druzyna, SedziaGlownyCombo.SelectedItem as Sedzia, (int)StopienMeczu.MeczLigowy));
            }
            
            

            MeczeDataGrid.Items.Refresh();
            Druzyna1Combo.SelectedItem = null;
            Druzyna2Combo.SelectedItem = null;
            WynikDruzyna1.Text = null;
            WynikDruzyna2.Text = null;
            CzyRozegranyCheckBox.IsChecked = false;
        }
        /// <summary>
        /// Przycisk odpowiedzialny za generowanie półfinałów
        /// </summary>
        /// <param name="sender">parametr z  referencją do obiektu, który wywołuje wydarzenie</param>
        /// <param name="e">parametr zawierający dane wydarzenia</param>
        private void GenerujPolfinalyButt_Click(object sender, RoutedEventArgs e)
        {
            StatycznaBazaWszytkichDanych.GetBaza().GenerujPolfinaly((Sporty)Sport.SelectedIndex);
            MeczeDataGrid.Items.Refresh();
        }
        /// <summary>
        /// Przycisk odpowiedzialny za generowanie finałów
        /// </summary>
        /// <param name="sender">parametr z  referencją do obiektu, który wywołuje wydarzenie</param>
        /// <param name="e">parametr zawierający dane wydarzenia</param>
        private void GenerujFinalyButt_Click(object sender, RoutedEventArgs e)
        {
            StatycznaBazaWszytkichDanych.GetBaza().GenerujFinaly(Sporty.DwaOgnie);
            MeczeDataGrid.Items.Refresh();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">parametr z  referencją do obiektu, który wywołuje wydarzenie</param>
        /// <param name="e">parametr zawierający dane wydarzenia</param>
        private void Druzyna1Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Druzyna1Combo.SelectedItem is DruzynaDwaOgnie)
            {
                Druzyna2Combo.ItemsSource = StatycznaBazaWszytkichDanych.GetBaza().GetListaDruzyn().Where(d => d is DruzynaDwaOgnie && d != Druzyna1Combo.SelectedItem);
                SedziaPomocniczy1Combo.IsEnabled = false;
                SedziaPomocniczy2Combo.IsEnabled = false;
            }
            else if(Druzyna1Combo.SelectedItem is DruzynaPrzeciaganieLiny)
            {
                Druzyna2Combo.ItemsSource = StatycznaBazaWszytkichDanych.GetBaza().GetListaDruzyn().Where(d => d is DruzynaPrzeciaganieLiny && d != Druzyna1Combo.SelectedItem);
                SedziaPomocniczy1Combo.IsEnabled = false;
                SedziaPomocniczy2Combo.IsEnabled = false;
            }
            else if(Druzyna1Combo.SelectedItem is DruzynaSiatkowka)
            {
                Druzyna2Combo.ItemsSource = StatycznaBazaWszytkichDanych.GetBaza().GetListaDruzyn().Where(d => d is DruzynaSiatkowka && d != Druzyna1Combo.SelectedItem);
                SedziaPomocniczy1Combo.IsEnabled = true;
                SedziaPomocniczy2Combo.IsEnabled = true;
            }
        }

        private void Sport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GenerujFinałyButt.IsEnabled = Sport.SelectedIndex == -1 ? false : true;
            GenerujPolfinalyButt.IsEnabled = Sport.SelectedIndex == -1 ? false : true;
        }
        private void SedziowieCombo_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = StatycznaBazaWszytkichDanych.GetBaza().GetListaSedziow();
        }
    }
}
