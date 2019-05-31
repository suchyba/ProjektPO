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
        public Mecze()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            odswierz();
        }

        private void DruzynyCombo_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = StatycznaBazaWszytkichDanych.GetBaza().GetListaDruzyn();
        }

        private void DodajMeczButt_Click(object sender, RoutedEventArgs e)
        {
            BazaDanych baza = StatycznaBazaWszytkichDanych.GetBaza();
            baza.DodajMecz(new Mecz(Druzyna1Combo.SelectedItem as Druzyna, Druzyna2Combo.SelectedItem as Druzyna, StatycznaBazaWszytkichDanych.GetBaza().GetListaSedziow()[0], (int)StopienMeczu.MeczLigowy, int.Parse(WynikDruzyna1.Text), int.Parse(WynikDruzyna2.Text)));
            odswierz();
        }
        private void odswierz()
        {
            ListaMeczyTextBox.Text = "";
            foreach (var mecz in StatycznaBazaWszytkichDanych.GetBaza().GetListaMeczy())
            {
                ListaMeczyTextBox.Text += "Mecz: " + mecz.GetDruzyny()[0] + " vs " + mecz.GetDruzyny()[1] + " " + mecz.GetWynik()[0] + ":" + mecz.GetWynik()[1] + "\n";
            }
        }

        private void GenerujPolfinalyButt_Click(object sender, RoutedEventArgs e)
        {
            StatycznaBazaWszytkichDanych.GetBaza().GenerujPolfinaly(Sporty.DwaOgnie);
            odswierz();
        }
    }
}
