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
    /// Interaction logic for HulpverlenerToevoegen.xaml
    /// </summary>
    public partial class HulpverlenerToevoegen : Window
    {
        public HulpverlenerToevoegen()
        {
            InitializeComponent();
            //cbGeslacht krijgt enum Geslacht {man, vrouw} 
        }

        private void imgSluiten_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //terug naar HulpverlenerHoofdscherm
        }

        private void btUploaden_Click(object sender, RoutedEventArgs e)
        {
            //foto uploaden
        }

        private void btOpslaan_Click(object sender, RoutedEventArgs e)
        {
            //gebruiker wordt toegevoegd met ingevulde gegevens
        }
    }
}
