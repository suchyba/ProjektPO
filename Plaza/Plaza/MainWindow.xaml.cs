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
        private BazaDanych baza;
        public MainWindow()
        {
            InitializeComponent();
            baza = new BazaDanych();
        }

        private void ZatwierdzButt_Click(object sender, RoutedEventArgs e)
        {
            baza.ZglosDruzyne(new Druzyna(NazwaDruzynyTxtBox.Text, int.Parse(RokPowstaniaTxtBox.Text), OpisTxtBox.Text));
            TestTxtBlock.Text = baza.GetListaDruzyn().FirstOrDefault().GetNazwa() + " " + baza.GetListaDruzyn().FirstOrDefault().GetRokPowstania() + " " + baza.GetListaDruzyn().FirstOrDefault().GetOpis();
        }
    }
}
