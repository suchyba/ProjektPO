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
    /// Logika interakcji dla klasy Sedziowie.xaml
    /// </summary>
    public partial class Sedziowie : Window
    {
        public Sedziowie()
        {
            InitializeComponent();
            SedziowieDataGrid.ItemsSource = StatycznaBazaWszytkichDanych.GetBaza().GetListaSedziow();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource sedziaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("sedziaViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // meczViewSource.Źródło = [ogólne źródło danych]
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource sedziaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("sedziaViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // sedziaViewSource.Źródło = [ogólne źródło danych]
        }

        private void DodajSedziegoButt_Click(object sender, RoutedEventArgs e)
        {
            StatycznaBazaWszytkichDanych.GetBaza().DodajSedziego(new Sedzia(Imie.Text, Nazwisko.Text, int.Parse(Wiek.Text), NumerLicencji.Text));
            SedziowieDataGrid.Items.Refresh();
        }

        private void UsunSedziegoButt_Click(object sender, RoutedEventArgs e)
        {
            StatycznaBazaWszytkichDanych.GetBaza().UsunSedziego((SedziowieDataGrid.SelectedItem as Sedzia).NumerLicencji);
            SedziowieDataGrid.Items.Refresh();
        }

        private void SedziowieDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UsunSedziegoButt.IsEnabled = SedziowieDataGrid.SelectedItems.Count > 0 ? true : false;
        }
    }
}
