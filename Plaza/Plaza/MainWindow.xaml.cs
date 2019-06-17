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
        /// <summary>
        /// Ładowanie danych sędziego
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            StatycznaBazaWszytkichDanych.GetBaza().DodajSedziego(new Sedzia("Bartek", "Konopka", 20, "EXC2003"));
            DruzynyDataGrid.ItemsSource = StatycznaBazaWszytkichDanych.GetBaza().GetListaDruzyn();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">parametr z  referencją do obiektu, który wywołuje wydarzenie</param>
        /// <param name="e">parametr zawierający dane wydarzenia</param>
        private void ZatwierdzButt_Click(object sender, RoutedEventArgs e)
        {
            StatycznaBazaWszytkichDanych.GetBaza().ZglosDruzyne(new DruzynaDwaOgnie(NazwaDruzynyTxtBox.Text, int.Parse(RokPowstaniaTxtBox.Text), OpisTxtBox.Text));
            DruzynyDataGrid.Items.Refresh();
        }
        /// <summary>
        /// Przycisk odpowiedzialny za odświeżanie datagrida
        /// </summary>
        /// <param name="sender">parametr z  referencją do obiektu, który wywołuje wydarzenie</param>
        /// <param name="e">parametr zawierający dane wydarzenia</param>
        private void OdswiezButt_Click(object sender, RoutedEventArgs e)
        {
            DruzynyDataGrid.Items.Refresh();            
        }
        /// <summary>
        /// Przycisk odpowiedzialny za usuwanie drużyny
        /// </summary>
        /// <param name="sender">parametr z  referencją do obiektu, który wywołuje wydarzenie</param>
        /// <param name="e">parametr zawierający dane wydarzenia</param>
        private void UsunButt_Click(object sender, RoutedEventArgs e)
        {
            StatycznaBazaWszytkichDanych.GetBaza().WycofajDruzyne(NazwaDruzynyTxtBox.Text);
            DruzynyDataGrid.Items.Refresh();
        }
        /// <summary>
        /// Przycisk odpowiedzialny za wywoływanie nowego okna z meczami
        /// </summary>
        /// <param name="sender">parametr z  referencją do obiektu, który wywołuje wydarzenie</param>
        /// <param name="e">parametr zawierający dane wydarzenia</param>
        private void MeczeButt_Click(object sender, RoutedEventArgs e)
        {
            Mecze meczeOkno = new Mecze();
            meczeOkno.Show();
        }
        /// <summary>
        /// Przycisk odpowiedzialny za wywoływanie nowego okna z zawodnikami
        /// </summary>
        /// <param name="sender">parametr z  referencją do obiektu, który wywołuje wydarzenie</param>
        /// <param name="e">parametr zawierający dane wydarzenia</param>
        private void ZawodnicyButt_Click(object sender, RoutedEventArgs e)
        {
            Zawodnicy zawodnicyOkno = new Zawodnicy();
            zawodnicyOkno.Show();
        }
        /// <summary>
        /// Przycisk odpowiedzialny za wywoływanie nowego okna z sędziami
        /// </summary>
        /// <param name="sender">parametr z  referencją do obiektu, który wywołuje wydarzenie</param>
        /// <param name="e">parametr zawierający dane wydarzenia</param>
        private void SedziowieButt_Click(object sender, RoutedEventArgs e)
        {
            Sedziowie sedziowieOkno = new Sedziowie();
            sedziowieOkno.Show();
        }
        /// <summary>
        /// Ładowanie drużyn
        /// </summary>
        /// <param name="sender">parametr z  referencją do obiektu, który wywołuje wydarzenie</param>
        /// <param name="e">parametr zawierający dane wydarzenia</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource druzynaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("druzynaViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // druzynaViewSource.Źródło = [ogólne źródło danych]
        }
    }
}
