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
    /// Logika interakcji dla klasy Zawodnicy.xaml
    /// </summary>
    public partial class Zawodnicy : Window
    {
        /// <summary>
        /// Pobieranie listy zawodników
        /// </summary>
        public Zawodnicy()
        {
            InitializeComponent();
            ZawodnicyDataGrid.ItemsSource = StatycznaBazaWszytkichDanych.GetBaza().GetListaZawodnikow();
        }
        /// <summary>
        /// Ładowanie danych zawodnika i drużyny
        /// </summary>
        /// <param name="sender">parametr z  referencją do obiektu, który wywołuje wydarzenie</param>
        /// <param name="e">parametr zawierający dane wydarzenia</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource zawodnikViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("zawodnikViewSource")));
            System.Windows.Data.CollectionViewSource druzynaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("druzynaViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // druzynaViewSource.Źródło = [ogólne źródło danych]
        }
        /// <summary>
        /// Pobieranie listy zawodników do comboboxa
        /// </summary>
        /// <param name="sender">parametr z  referencją do obiektu, który wywołuje wydarzenie</param>
        /// <param name="e">parametr zawierający dane wydarzenia</param>
        private void DruzynyCombo_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = StatycznaBazaWszytkichDanych.GetBaza().GetListaDruzyn();
        }
        /// <summary>
        /// Przycisk odpowiedzialny za dodawanie zawodników
        /// </summary>
        /// <param name="sender">parametr z  referencją do obiektu, który wywołuje wydarzenie</param>
        /// <param name="e">parametr zawierający dane wydarzenia</param>
        private void DodajZawodnikaButt_Click(object sender, RoutedEventArgs e)
        {
            StatycznaBazaWszytkichDanych.GetBaza().DodajZawodnika(Imie.Text, Nazwisko.Text, int.Parse(DataUrodzenia.Text), Druzyna.SelectedItem as Druzyna);
            ZawodnicyDataGrid.Items.Refresh();
        }
        /// <summary>
        /// Przycisk odpowiedzialny za usuwanie zawodników
        /// </summary>
        /// <param name="sender">parametr z  referencją do obiektu, który wywołuje wydarzenie</param>
        /// <param name="e">parametr zawierający dane wydarzenia</param>
        private void UsunZawodnikaButt_Click(object sender, RoutedEventArgs e)
        {
            StatycznaBazaWszytkichDanych.GetBaza().UsunZawodnika(ZawodnicyDataGrid.SelectedItem as Zawodnik);
            ZawodnicyDataGrid.Items.Refresh();
        }
        /// <summary>
        /// Włączanie oraz wyłączanie guzika od dodawania zawodnika
        /// </summary>
        /// <param name="sender">parametr z  referencją do obiektu, który wywołuje wydarzenie</param>
        /// <param name="e">parametr zawierający dane wydarzenia</param>
        private void Druzyna_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DodajZawodnikaButt.IsEnabled = Druzyna.SelectedIndex == -1 ? false : true;
        }
    }
}
