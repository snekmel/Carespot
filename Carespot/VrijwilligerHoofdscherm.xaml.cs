using System.Windows;
using System.Windows.Input;
using Carespot.Models;

namespace Carespot
{
    /// <summary>
    ///     Interaction logic for VrijwilligerHoofdscherm.xaml
    /// </summary>
    public partial class VrijwilligerHoofdscherm : Window
    {
        private Gebruiker _ingelogdeGebruiker;

        public VrijwilligerHoofdscherm()
        {
            InitializeComponent();
            //laad naam gebruiker
            //laad functie gebruiker
            //lijst actieve opdrachten ophalen en in listbox zetten
        }

        public VrijwilligerHoofdscherm(Gebruiker ingelogdeGebruiker)
        {
            InitializeComponent();
            _ingelogdeGebruiker = ingelogdeGebruiker;
            //laad naam gebruiker
            //laad functie gebruiker
            //lijst actieve opdrachten ophalen en in listbox zetten
        }

        private void imgLogout_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //gebruiker uitloggen en terug naar Inlogscherm
        }

        private void btOpgeven_Click(object sender, RoutedEventArgs e)
        {
            //open scherm: VrijwilligerOpdrachtAannemen
        }
    }
}