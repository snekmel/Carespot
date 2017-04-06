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

namespace Carespot
{
    /// <summary>
    /// Interaction logic for Beheerderscherm.xaml
    /// </summary>
    public partial class Beheerderscherm : Window
    {
        public Beheerderscherm()
        {
            InitializeComponent();
            //vul combobox geslacht
            //vul combobox hulpverlener/beheerder
        }

        private void btUploaden_Click(object sender, RoutedEventArgs e)
        {
            //profielfoto uploaden
        }

        private void btOpslaan_Click(object sender, RoutedEventArgs e)
        {
            //gebruik gegevens om hulpverlener/beheerder (afhankelijk van de combobox) aan te maken
        }

        private void imgUitloggen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //beheerder uitloggen
        }

        private void imgGebruikersbeheer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //gebruikersoverzicht openen
        }
    }
}
