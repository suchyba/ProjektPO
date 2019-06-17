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
        public Zawodnicy()
        {
            InitializeComponent();
            ZawodnicyDataGrid.ItemsSource = StatycznaBazaWszytkichDanych.GetBaza().GetListaZawodnikow();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource zawodnikViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("zawodnikViewSource")));
            System.Windows.Data.CollectionViewSource druzynaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("druzynaViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // druzynaViewSource.Źródło = [ogólne źródło danych]
        }
        private void DruzynyCombo_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = StatycznaBazaWszytkichDanych.GetBaza().GetListaDruzyn();
        }

        private void DodajZawodnikaButt_Click(object sender, RoutedEventArgs e)
        {
            StatycznaBazaWszytkichDanych.GetBaza().DodajZawodnika(Imie.Text, Nazwisko.Text, DataUrodzenia.Text, Druzyna.SelectedItem as Druzyna);
        }

        private void UsunZawodnikaButt_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
