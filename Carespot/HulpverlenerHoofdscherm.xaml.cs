using System.Windows;
using System.Windows.Input;
using Carespot.DAL.Repositorys;
using Carespot.Models;

namespace Carespot
{
    /// <summary>
    ///     Interaction logic for HulpverlenerHoofdscherm.xaml
    /// </summary>
    public partial class HulpverlenerHoofdscherm : Window
    {
        private readonly Gebruiker _ingelogdeGebruiker;

        public HulpverlenerHoofdscherm()
        {
            InitializeComponent();
            //laad naam
            //laad functie
        }

        public HulpverlenerHoofdscherm(Gebruiker ingelogdeGebruiker)
        {
            InitializeComponent();
            _ingelogdeGebruiker = ingelogdeGebruiker;
            profielImg.Source = FunctionRepository.ByteToImage(_ingelogdeGebruiker.Foto);
            //laad naam
            //laad functie
        }

        //Geef lijst met gekoppelde cliënten
        //Geef lijst met de daarbijhorende hulpvragen

        private void imgHulpverlenerToevoegen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //'Hulpverlener toevoegen' openen
        }

        private void imgUitloggen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //hulpverlener uitloggen en terug naar inlogscherm
        }
    }
}