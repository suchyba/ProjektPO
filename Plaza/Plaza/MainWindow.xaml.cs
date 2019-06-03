using Plaza.Technologie_Testowe;
using Plaza.Testowe_okna;
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

namespace Plaza
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StatycznaBazaWszytkichDanych.GetBaza().DodajSedziego(new Sedzia("Bartek", "Konopka", 20, "EXC2003"));
            DruzynyDataGrid.ItemsSource = StatycznaBazaWszytkichDanych.GetBaza().GetListaDruzyn();
        }

        private void ZatwierdzButt_Click(object sender, RoutedEventArgs e)
        {
            StatycznaBazaWszytkichDanych.GetBaza().ZglosDruzyne(new DruzynaDwaOgnie(NazwaDruzynyTxtBox.Text, int.Parse(RokPowstaniaTxtBox.Text), OpisTxtBox.Text));
            DruzynyDataGrid.Items.Refresh();
        }

        private void OdswiezButt_Click(object sender, RoutedEventArgs e)
        {
            DruzynyDataGrid.Items.Refresh();            
        }

        private void UsunButt_Click(object sender, RoutedEventArgs e)
        {
            StatycznaBazaWszytkichDanych.GetBaza().WycofajDruzyne(NazwaDruzynyTxtBox.Text);
            DruzynyDataGrid.Items.Refresh();
        }

        private void MeczeButt_Click(object sender, RoutedEventArgs e)
        {
            Mecze meczeOkno = new Mecze();
            meczeOkno.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource druzynaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("druzynaViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // druzynaViewSource.Źródło = [ogólne źródło danych]
        }
    }
}
