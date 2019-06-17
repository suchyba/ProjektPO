using Plaza.Technologie_Testowe;
using Plaza.Testowe_okna;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
            DruzynyDataGrid.ItemsSource = StatycznaBazaWszytkichDanych.GetBaza().GetListaDruzyn();
        }
        /// <summary>
        /// Guzik odpowiedzialny za zatwierdzanie drużyny
        /// </summary>
        /// <param name="sender">parametr z  referencją do obiektu, który wywołuje wydarzenie</param>
        /// <param name="e">parametr zawierający dane wydarzenia</param>
        private void ZatwierdzButt_Click(object sender, RoutedEventArgs e)
        {
            switch (SportCombo.SelectedIndex)
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
        /// <summary>
        /// Przycisk odpowiedzialny za odświeżanie datagrida drużyny
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
            StatycznaBazaWszytkichDanych.GetBaza().WycofajDruzyne(DruzynyDataGrid.SelectedItem as Druzyna);
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
            List<string> listaSportow = new List<string>();
            listaSportow.Add("Siatkówka");
            listaSportow.Add("Przeciąganie Liny");
            listaSportow.Add("Dwa Ognie");
            SportCombo.ItemsSource = listaSportow;
        }
        /// <summary>
        /// Włączanie i wyłączanie przycisku usuwania drużyny
        /// </summary>
        /// <param name="sender">parametr z  referencją do obiektu, który wywołuje wydarzenie</param>
        /// <param name="e">parametr zawierający dane wydarzenia</param>
        private void DruzynyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UsunButt.IsEnabled = DruzynyDataGrid.SelectedItems.Count > 0 ? true : false;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            DruzynyDataGrid.Items.Refresh();
        }
    }
}
