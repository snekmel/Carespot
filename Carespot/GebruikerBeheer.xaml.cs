using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Carespot.Models;

namespace Carespot
{
    /// <summary>
    ///     Interaction logic for GebruikerBeheer.xaml
    /// </summary>
    public partial class GebruikerBeheer : Window
    {
        private readonly Gebruiker _ingelogdeGebruiker;

        public GebruikerBeheer()
        {
            InitializeComponent();
            //lijst van gebruikers ophalen in de listview
            vulListView();
        }

        public GebruikerBeheer(Gebruiker ingelogdeGebruiker)
        {
            InitializeComponent();
            //lijst van gebruikers ophalen in de listview
            _ingelogdeGebruiker = ingelogdeGebruiker;
            vulListView();
        }

        private void imgGebruiker_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var geselecteerdeGebr = (Gebruiker)lvGebruikers.SelectedItem;
            //VerwijderBevestiging openen en geselecteerde gebruiker mee geven
            var window = new VerwijderBevestiging(_ingelogdeGebruiker, geselecteerdeGebr, this);
            window.Show();
        }

        private void imgSluitAf_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var inlogscherm = new Inlogscherm();
            inlogscherm.Show();
            Close();
        }

        public void vulListView()
        {
            lvGebruikers.Items.Clear();
            lvOpdrachten.Items.Clear();

            var context = new GebruikerSQLContext();
            var gRepo = new GebruikerRepository(context);


            try
            {
                var gebruikersLijst = new List<Gebruiker>();
                gebruikersLijst = gRepo.RetrieveAll();

                foreach (var g in gebruikersLijst)
                {
                    if (g.GetType() == typeof(Beheerder))
                        g.Type = Gebruiker.GebruikerType.Beheerder;
                    else if (g.GetType() == typeof(Hulpbehoevende))
                        g.Type = Gebruiker.GebruikerType.Hulpbehoevende;
                    else if (g.GetType() == typeof(Hulpverlener))
                        g.Type = Gebruiker.GebruikerType.Hulpverlener;
                    else if (g.GetType() == typeof(Vrijwilliger))
                        g.Type = Gebruiker.GebruikerType.Vrijwilliger;
                    lvGebruikers.Items.Add(g);
                }


                var opdrcontext = new HulpopdrachtSQLContext();
                var oRepo = new HulpopdrachtRepository(opdrcontext);

                var opdrachtLijst = new List<HulpOpdracht>();
                opdrachtLijst = oRepo.GetAllHulpopdrachten();

                foreach (var o in opdrachtLijst)
                    lvOpdrachten.Items.Add(o);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is iets mis gegaan. Foutomschrijving: " + ex.Message);
            }
        

          
          
        }

        private void imgGebruikerToevoegen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var beheerscherm = new Beheerderscherm(_ingelogdeGebruiker);
            beheerscherm.Show();
        }

        private void lvOpdrachten_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HulpOpdracht ho = (HulpOpdracht)lvOpdrachten.SelectedItem;

            Opdracht scherm = new Opdracht(_ingelogdeGebruiker, ho);
            scherm.Show();
        }
    }
}