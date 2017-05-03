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
            //als hulpverlener ingelogd is ga terug naar HulpverlenerHoofdscherm.
            //als beheerder ignelgod is ga tertug naar Beheerderscherm
            var inlogscherm = new Inlogscherm();
            inlogscherm.Show();
            this.Close();
        }

        public void vulListView()
        {
            lvGebruikers.Items.Clear();

            var context = new GebruikerSQLContext();
            var gRepo = new GebruikerRepository(context);
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
        }

        private void imgGebruikerToevoegen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var beheerscherm = new Beheerderscherm(_ingelogdeGebruiker);
            beheerscherm.Show();
        }
    }
}