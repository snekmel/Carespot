﻿using System.Windows;
using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;

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

            /*
            /*

             *
             * Hulpopdracht:
                        HulpopdrachtSQLContext hsc = new HulpopdrachtSQLContext();
                   HulpopdrachtRepository hr = new HulpopdrachtRepository(hsc);

                        HulpOpdracht ho = hr.GetHulpopdrachtByID(2);

                        VrijwilligerSQLContext vsc = new VrijwilligerSQLContext();
                        VrijwilligerRepository vr = new VrijwilligerRepository(vsc);

                       Opdracht opdrachtScherm = new Opdracht(ho.Vrijwilleger, ho);
                        opdrachtScherm.Show();

                        System.Windows.MessageBox.Show(hr.GetAllHulpopdrachten().Count + "");

                        VrijwilligerSQLContext vsc = new VrijwilligerSQLContext();
                        VrijwilligerRepository vr = new VrijwilligerRepository(vsc);

                       Opdracht opdrachtScherm = new Opdracht(ho.Vrijwilleger, ho);
                        opdrachtScherm.Show();

                      */

            //Maak nieuwe hulpopdracht
            /*  HulpbehoevendeSQLContext hsc = new HulpbehoevendeSQLContext();
                HulpbehoevendeRepository hr = new HulpbehoevendeRepository(hsc);

                Hulpvraagxaml hulpvraagScherm = new Hulpvraagxaml(hr.RetrieveHulpbehoevendeById(5));

                hulpvraagScherm.Show();
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
            var cliëntOverzicht = new CliëntOverzicht(null);
            cliëntOverzicht.Show();
        }

        private void Hulpvraag_Click(object sender, RoutedEventArgs e)
        {
            // var hulpvraag = new Hulpvraagxaml();
            // hulpvraag.Show();
        }

        private void VrijwilligerOverzicht_Click(object sender, RoutedEventArgs e)
        {
            //    var vrijwilligerHoofdscherm = new VrijwilligerHoofdscherm();
            //    vrijwilligerHoofdscherm.Show();
        }

        private void OpdrachtAannemen_Click(object sender, RoutedEventArgs e)
        {
            var vrijwilligerOpdrachtAannemen = new VrijwilligerOpdrachtAannemen(null);
            vrijwilligerOpdrachtAannemen.Show();
        }

        private void OpdrachtScherm_Click(object sender, RoutedEventArgs e)
        {
            var gsc = new GebruikerSQLContext();
            var gr = new GebruikerRepository(gsc);

            var hsc = new HulpopdrachtSQLContext();
            var hr = new HulpopdrachtRepository(hsc);

            var lijst = hr.GetAllHulpopdrachten();
            var g = gr.RetrieveGebruiker(1);

            var opdracht = new Opdracht(g, lijst[0]);
            opdracht.Show();
        }

        private void HulpverlenerToevoegen_Click(object sender, RoutedEventArgs e)
        {
        //    var hulpverlenerToevoegen = new HulpverlenerToevoegen();
        //    hulpverlenerToevoegen.Show();
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
            //var hulpverlenerHoofdscherm = new HulpverlenerHoofdscherm();
            //hulpverlenerHoofdscherm.Show();
        }

        private void Gegevenswijzigen_Click(object sender, RoutedEventArgs e)
        {
            var inf = new HulpbehoevendeSQLContext();
            var repo = new HulpbehoevendeRepository(inf);
            var h = repo.RetrieveHulpbehoevendeById(5);
            var gegevenswijzigen = new GegevensWijzigen(h);
            gegevenswijzigen.Show();
        }

        private void ReactieOpHulpvraag_Click(object sender, RoutedEventArgs e)
        {
            var reactieOpHulpvraag = new ReactieOpHulpvraag();
            reactieOpHulpvraag.Show();
        }
    }
}