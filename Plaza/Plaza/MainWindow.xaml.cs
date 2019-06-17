﻿using Plaza.Technologie_Testowe;
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
            switch(SportCombo.SelectedIndex)
            {
                case 0:
                    {
                        StatycznaBazaWszytkichDanych.GetBaza().ZglosDruzyne(new DruzynaSiatkowka(NazwaDruzynyTxtBox.Text, int.Parse(RokPowstaniaTxtBox.Text), OpisTxtBox.Text));
                        break;
                    }
                case 1:
                    {
                        StatycznaBazaWszytkichDanych.GetBaza().ZglosDruzyne(new DruzynaPrzeciaganieLiny(NazwaDruzynyTxtBox.Text, int.Parse(RokPowstaniaTxtBox.Text), OpisTxtBox.Text));
                        break;
                    }
                case 2:
                    {
                        StatycznaBazaWszytkichDanych.GetBaza().ZglosDruzyne(new DruzynaDwaOgnie(NazwaDruzynyTxtBox.Text, int.Parse(RokPowstaniaTxtBox.Text), OpisTxtBox.Text));
                        break;
                    }
                default:
                    break;
            }
            DruzynyDataGrid.Items.Refresh();
            NazwaDruzynyTxtBox.Text = null;
            OpisTxtBox.Text = null;
            SportCombo.SelectedItem = null;
            RokPowstaniaTxtBox.Text = null;
        }

        private void OdswiezButt_Click(object sender, RoutedEventArgs e)
        {
            DruzynyDataGrid.Items.Refresh();            
        }

        private void UsunButt_Click(object sender, RoutedEventArgs e)
        {
            StatycznaBazaWszytkichDanych.GetBaza().WycofajDruzyne(DruzynyDataGrid.SelectedItem as Druzyna);
            DruzynyDataGrid.Items.Refresh();
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
            List<string> listaSportow = new List<string>();
            listaSportow.Add("Siatkówka");
            listaSportow.Add("Przeciąganie Liny");
            listaSportow.Add("Dwa Ognie");
            SportCombo.ItemsSource = listaSportow;
        }

        private void DruzynyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UsunButt.IsEnabled = DruzynyDataGrid.SelectedItems.Count > 0 ? true : false;
        }
    }
}
