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
        Gebruiker gebruiker;
        string hbNaam;
        public ProfielVrijwilliger(Gebruiker g)
        {
            InitializeComponent();
            gebruiker = g;
            lblNaam.Content = gebruiker.Naam;
            lblRol.Content = gebruiker.Type;
            vulListView();
            //laad lijst van recensies 
            //laad naam
            //laad functie
            //laadt profielfoto
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
            Recensie window = new Recensie(/*gebruiker*/);
            window.Show();
            this.Close();
        }

        public void vulListView()
        {
            var b = new BeoordelingSQLContext();
            var bRepo = new BeoordelingRepository(b);
            List<Beoordeling> beoordelingLijst = new List<Beoordeling>();
            beoordelingLijst = bRepo.RetrieveBeoordeling(gebruiker.Id);

            var hb = new HulpbehoevendeSQLContext();
            var hbRepo = new HulpbehoevendeRepository(hb);
            List<Hulpbehoevende> hulpbehoevendeLijst = new List<Hulpbehoevende>();
            hulpbehoevendeLijst = hbRepo.HulpbehoevendeList();

            foreach (var beoordeling in beoordelingLijst)
            {
                foreach (var h in hulpbehoevendeLijst)
                {
                    if (h.Id == beoordeling.HulpbehoevendeId)
                    {
                        hbNaam = h.Naam;
                    }
                }
                lvRecensies.Items.Add("Beoordeeld door: " + hbNaam + "cijfer: " + beoordeling.Cijfer + "Opmerking: " + beoordeling.Opmerking);                
            }
        }


    }
}
