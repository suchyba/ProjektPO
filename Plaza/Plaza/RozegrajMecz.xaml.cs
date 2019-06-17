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

namespace Plaza
{
    /// <summary>
    /// Logika interakcji dla klasy RozegrajMecz.xaml
    /// </summary>
    public partial class RozegrajMecz : Window
    {

        private int[] wyniki;
        private int idMecz;
        public RozegrajMecz()
        {
            wyniki = new int[2];
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource druzynaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("druzynaViewSource")));
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            wyniki[0] = int.Parse(Wynik1TextBox.Text);
            wyniki[1] = int.Parse(Wynik2TextBox.Text);
            StatycznaBazaWszytkichDanych.GetBaza().RozegrajMecz(idMecz, wyniki[0], wyniki[1]);
            Close();
        }

        private void AnulujButton_Click(object sender, RoutedEventArgs e)
        {
            wyniki[0] = -1;
            Close();
        }

        public void PokazOkno(int idMeczu)
        {
            Show();
            idMecz = idMeczu;
            Druzyna1Label.Content = StatycznaBazaWszytkichDanych.GetBaza().GetListaMeczy()[idMeczu].DruzynaPierwsza.Nazwa;
            Druzyna2Label.Content = StatycznaBazaWszytkichDanych.GetBaza().GetListaMeczy()[idMeczu].DruzynaDruga.Nazwa;
        }
    }
}
