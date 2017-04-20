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
using Carespot.Models;
using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;

namespace Carespot
{
    /// <summary>
    /// Interaction logic for GebruikerBeheer.xaml
    /// </summary>
    public partial class GebruikerBeheer : Window
    {
        Gebruiker _ingelogdeGebruiker;
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
            Gebruiker geselecteerdeGebr = (Gebruiker)lvGebruikers.SelectedItem;
            //VerwijderBevestiging openen en geselecteerde gebruiker mee geven
            VerwijderBevestiging window = new VerwijderBevestiging(_ingelogdeGebruiker, geselecteerdeGebr, this);
            window.Show();
        }

        private void imgSluitAf_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //als hulpverlener ingelogd is ga terug naar HulpverlenerHoofdscherm.
            //als beheerder ignelgod is ga tertug naar Beheerderscherm
        }

        public void vulListView()
        {
            lvGebruikers.Items.Clear();

            var context = new GebruikerSQLContext();
            var gRepo = new GebruikerRepository(context);
            List<Gebruiker> gebruikersLijst = new List<Gebruiker>();
            gebruikersLijst = gRepo.RetrieveAll();

            foreach (var g in gebruikersLijst)
            {
                lvGebruikers.Items.Add(g);
            }       
        }
    }
}
