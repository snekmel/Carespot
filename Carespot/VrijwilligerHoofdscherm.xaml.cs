using System.Windows;
using System.Windows.Input;
using Carespot.DAL.Repositorys;
using Carespot.Models;

namespace Carespot
{
    /// <summary>
    ///     Interaction logic for VrijwilligerHoofdscherm.xaml
    /// </summary>
    public partial class VrijwilligerHoofdscherm : Window
    {
        private Gebruiker _ingelogdeGebruiker;

        public VrijwilligerHoofdscherm(Gebruiker ingelogdeGebruiker)
        {
            InitializeComponent();
            _ingelogdeGebruiker = ingelogdeGebruiker;
            //laad naam gebruiker
            lblNaam.Content = _ingelogdeGebruiker.Naam;
            imgGebruiker.Source = FunctionRepository.ByteToImage(_ingelogdeGebruiker.Foto);
            //lijst actieve opdrachten ophalen en in listbox zetten
        }

        private void imgLogout_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //gebruiker uitloggen en terug naar Inlogscherm
        }

        private void btOpgeven_Click(object sender, RoutedEventArgs e)
        {
            //open scherm: VrijwilligerOpdrachtAannemen
            VrijwilligerOpdrachtAannemen aannemen = new VrijwilligerOpdrachtAannemen(_ingelogdeGebruiker);
            aannemen.Show();
        }
    }
}