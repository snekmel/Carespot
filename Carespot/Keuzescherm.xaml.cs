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
    /// Interaction logic for Keuzescherm.xaml
    /// </summary>
    public partial class Keuzescherm : Window
    {
        public Keuzescherm()
        {
            InitializeComponent();
        }

        private void btHulpbehoevende_Click(object sender, RoutedEventArgs e)
        {
            //log in als hulpbehoevende --> open 'CliëntOverzicht'
        }

        private void btVrijwilliger_Click(object sender, RoutedEventArgs e)
        {
            //log in als vrijwilliger --> open 'VrijwilligerHoofdscherm'
        }

        private void imgSluiten_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Annuleer het inloggen, open 'Inlogscherm' opnieuw
        }
    }
}
