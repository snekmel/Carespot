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
using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Carespot.Models;

namespace Carespot
{
    /// <summary>
    /// Interaction logic for ProfielVrijwilliger.xaml
    /// </summary>
    public partial class ProfielVrijwilliger : Window
    {
        private Gebruiker profielGebruiker;
        private Gebruiker ingelogd;

        public ProfielVrijwilliger(Gebruiker ingelogdeGebuiker, Gebruiker ontvangGebruiker)
        {
            InitializeComponent();
            profielGebruiker = ontvangGebruiker;
            ingelogd = ingelogdeGebuiker;
            lblNaam.Content = profielGebruiker.Naam;
            vulListView();
        }

        private void imgSluitAf_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //terug naar vorige scherm
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void imgSchrijfRecensie_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BeoordelingScherm window = new BeoordelingScherm(ingelogd, profielGebruiker);
            window.Show();
            this.Close();
        }

        public void vulListView()
        {
            lvRecensies.Items.Clear();

            var b = new BeoordelingSQLContext();
            var bRepo = new BeoordelingRepository(b);
            List<Beoordeling> beoordelingLijst = new List<Beoordeling>();
            beoordelingLijst = bRepo.RetrieveBeoordeling(profielGebruiker.Id);

            foreach (var beoordeling in beoordelingLijst)
            {
                lvRecensies.Items.Add(beoordeling);
            }
        }
    }
}