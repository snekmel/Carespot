using System.Collections.Generic;
using System.Windows;
using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Carespot.Models;

namespace Carespot
{
    /// <summary>
    ///     Interaction logic for KiesScherm.xaml
    /// </summary>
    public partial class KiesScherm : Window
    {
        public KiesScherm()
        {
            InitializeComponent();

            // Test code---------------------------------
            /*
                        HulpopdrachtSQLContext hsc = new HulpopdrachtSQLContext();
                   HulpopdrachtRepository hr = new HulpopdrachtRepository(hsc);

                        HulpOpdracht ho = hr.GetHulpopdrachtByID(2);

                        VrijwilligerSQLContext vsc = new VrijwilligerSQLContext();
                        VrijwilligerRepository vr = new VrijwilligerRepository(vsc);

                       Opdracht opdrachtScherm = new Opdracht(ho.Vrijwilleger, ho);
                        opdrachtScherm.Show();

                        System.Windows.MessageBox.Show(hr.GetAllHulpopdrachten().Count + "");
                        */
            //----------------------------------------
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var inlogscherm = new Inlogscherm();
            inlogscherm.Show();
        }

        private void Keuzescherm_Click(object sender, RoutedEventArgs e)
        {
            var keuzescherm = new Keuzescherm(null, null);
            keuzescherm.Show();
        }

        private void Aanmelden_Click(object sender, RoutedEventArgs e)
        {
            var gebruikerAanmaken = new GebruikerAanmaken();
            gebruikerAanmaken.Show();
        }

        private void Cliëntoverzicht_Click(object sender, RoutedEventArgs e)
        {
            var cliëntOverzicht = new CliëntOverzicht();
            cliëntOverzicht.Show();
        }

        private void Hulpvraag_Click(object sender, RoutedEventArgs e)
        {
            var hulpvraag = new Hulpvraagxaml();
            hulpvraag.Show();
        }

        private void VrijwilligerOverzicht_Click(object sender, RoutedEventArgs e)
        {
            var vrijwilligerHoofdscherm = new VrijwilligerHoofdscherm();
            vrijwilligerHoofdscherm.Show();
        }

        private void OpdrachtAannemen_Click(object sender, RoutedEventArgs e)
        {
            var vrijwilligerOpdrachtAannemen = new VrijwilligerOpdrachtAannemen();
            vrijwilligerOpdrachtAannemen.Show();
        }

        private void OpdrachtScherm_Click(object sender, RoutedEventArgs e)
        {
            GebruikerSQLContext gsc = new GebruikerSQLContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);

            HulpopdrachtSQLContext hsc = new HulpopdrachtSQLContext();
            HulpopdrachtRepository hr = new HulpopdrachtRepository(hsc);

            List<HulpOpdracht> lijst = hr.GetAllHulpopdrachten();
            Gebruiker g = gr.RetrieveGebruiker(1);

            Opdracht opdracht = new Opdracht(g, lijst[0]);
            opdracht.Show();
        }

        private void HulpverlenerToevoegen_Click(object sender, RoutedEventArgs e)
        {
            var hulpverlenerToevoegen = new HulpverlenerToevoegen();
            hulpverlenerToevoegen.Show();
        }

        private void GebruikerBeheer_Click(object sender, RoutedEventArgs e)
        {
            var gebruikerBeheer = new GebruikerBeheer();
            gebruikerBeheer.Show();
        }

        private void VerwijderBevestiging_Click(object sender, RoutedEventArgs e)
        {
            var verwijderBevestiging = new VerwijderBevestiging();
            verwijderBevestiging.Show();
        }

        private void BeheerderScherm_Click(object sender, RoutedEventArgs e)
        {
            var beheerderscherm = new Beheerderscherm();
            beheerderscherm.Show();
        }

        private void RecensieScherm_Click(object sender, RoutedEventArgs e)
        {
            var beoordelingsScherm = new BeoordelingScherm();
            beoordelingsScherm.Show();
        }

        private void HulpverlenerOverzicht_Click(object sender, RoutedEventArgs e)
        {
            var hulpverlenerHoofdscherm = new HulpverlenerHoofdscherm();
            hulpverlenerHoofdscherm.Show();
        }

        private void Gegevenswijzigen_Click(object sender, RoutedEventArgs e)
        {
            var gegevenswijzigen = new GegevensWijzigen();
            gegevenswijzigen.Show();
        }
    }
}