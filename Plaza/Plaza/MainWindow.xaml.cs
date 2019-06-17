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
            TestTxtBlock.Text = "";
            StatycznaBazaWszytkichDanych.GetBaza().DodajSedziego(new Sedzia("Bartek", "Konopka", 20, "EXC2003"));
        }

        private void ZatwierdzButt_Click(object sender, RoutedEventArgs e)
        {
            StatycznaBazaWszytkichDanych.GetBaza().ZglosDruzyne(new DruzynaDwaOgnie(NazwaDruzynyTxtBox.Text, int.Parse(RokPowstaniaTxtBox.Text), OpisTxtBox.Text));
            odswiez();
        }

        private void OdswiezButt_Click(object sender, RoutedEventArgs e)
        {
            odswiez();
            
        }
        private void odswiez()
        {
            TestTxtBlock.Text = "";
            foreach (var druzyna in StatycznaBazaWszytkichDanych.GetBaza().GetListaDruzyn())
            {
                TestTxtBlock.Text += druzyna.GetNazwa() + " " + druzyna.GetRokPowstania() + " " + druzyna.GetPunkty() + " " + druzyna +  "\n";
            }
        }

        private void UsunButt_Click(object sender, RoutedEventArgs e)
        {
            StatycznaBazaWszytkichDanych.GetBaza().WycofajDruzyne(NazwaDruzynyTxtBox.Text);
            odswiez();
        }

        private void MeczeButt_Click(object sender, RoutedEventArgs e)
        {
            Mecze meczeOkno = new Mecze();
            meczeOkno.Show();
        }

        private void ZawodnicyButt_Click(object sender, RoutedEventArgs e)
        {
            Zawodnicy zawodnicyOkno = new Zawodnicy();
            zawodnicyOkno.Show();
        }
        private void SedziowieButt_Click(object sender, RoutedEventArgs e)
        {
            Sedziowie sedziowieOkno = new Sedziowie();
            sedziowieOkno.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource druzynaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("druzynaViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // druzynaViewSource.Źródło = [ogólne źródło danych]
        }
    }
}
