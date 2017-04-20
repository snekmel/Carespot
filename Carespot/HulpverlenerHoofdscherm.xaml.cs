using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Carespot.DAL.Context;
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

        public HulpverlenerHoofdscherm(Gebruiker ingelogdeGebruiker)
        {
            InitializeComponent();
            _ingelogdeGebruiker = ingelogdeGebruiker;
            profielImg.Source = FunctionRepository.ByteToImage(_ingelogdeGebruiker.Foto);
            lblNaam.Content = ingelogdeGebruiker.Naam;
            Cliëntenlijst();
        }

        public void Cliëntenlijst()
        {
            //lvCliënten.Items.Add();
        }

        public void HulpvraagLijst()
        {
            List<HulpOpdracht> Opdrachten = new List<HulpOpdracht>();
            //Opdrachten = hr.GetAllHulpopdrachtenByHulpbehoevendeID(_ingelogdeGebr.Id);
        }
        //Geef lijst met gekoppelde cliënten
        //Geef lijst met de daarbijhorende hulpvragen

        private void imgHulpverlenerToevoegen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var hulpverlenerToevoegen = new HulpverlenerToevoegen();
            hulpverlenerToevoegen.Show();
        }

        private void imgUitloggen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //hulpverlener uitloggen en terug naar inlogscherm
        }
    }
}