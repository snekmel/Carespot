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
    /// Interaction logic for Opdracht.xaml
    /// </summary>
    public partial class Opdracht : Window
    {
        public Opdracht()
        {
            InitializeComponent();
            //Laad naam
            //Laad functie
            //laad omschrijvingstab
        }

        private void imgSluitAf_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //'VrijwilligerHoofdscherm openen'
        }

        private void tabOmschrijving_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //laad omschrijvingstab
        }

        private void tabChat_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //laad chatberichten
        }

        private void tabContact_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //laad contacteninfo
        }
    }
}
