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

namespace Carespot
{
    /// <summary>
    /// Interaction logic for KiesScherm.xaml
    /// </summary>
    public partial class KiesScherm : Window
    {
        public KiesScherm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Inlogscherm inlogscherm = new Inlogscherm();
            inlogscherm.Show();
            
        }

        private void Keuzescherm_Click(object sender, RoutedEventArgs e)
        {
            Keuzescherm keuzescherm = new Keuzescherm();
            keuzescherm.Show();
        }

        private void Aanmelden_Click(object sender, RoutedEventArgs e)
        {
            GebruikerAanmaken gebruikerAanmaken = new GebruikerAanmaken();
            gebruikerAanmaken.Show();
        }

        private void Cliëntoverzicht_Click(object sender, RoutedEventArgs e)
        {
           CliëntOverzicht cliëntOverzicht = new CliëntOverzicht();
           cliëntOverzicht.Show();
        }

        private void Hulpvraag_Click(object sender, RoutedEventArgs e)
        {
            Hulpvraagxaml hulpvraag = new Hulpvraagxaml();
            hulpvraag.Show();
        }

        private void VrijwilligerOverzicht_Click(object sender, RoutedEventArgs e)
        {
            VrijwilligerHoofdscherm vrijwilligerHoofdscherm = new VrijwilligerHoofdscherm();
            vrijwilligerHoofdscherm.Show();
        }

        private void OpdrachtAannemen_Click(object sender, RoutedEventArgs e)
        {
            VrijwilligerOpdrachtAannemen vrijwilligerOpdrachtAannemen = new VrijwilligerOpdrachtAannemen();
            vrijwilligerOpdrachtAannemen.Show();
        }

        private void OpdrachtScherm_Click(object sender, RoutedEventArgs e)
        {
            Opdracht opdracht = new Opdracht();
            opdracht.Show();
        }

        private void HulpverlenerToevoegen_Click(object sender, RoutedEventArgs e)
        {
            Carespot.HulpverlenerToevoegen hulpverlenerToevoegen = new HulpverlenerToevoegen();
            hulpverlenerToevoegen.Show();
        }

        private void GebruikerBeheer_Click(object sender, RoutedEventArgs e)
        {
            Carespot.GebruikerBeheer gebruikerBeheer = new GebruikerBeheer();
            gebruikerBeheer.Show();
        }

        private void VerwijderBevestiging_Click(object sender, RoutedEventArgs e)
        {
            Carespot.VerwijderBevestiging verwijderBevestiging = new VerwijderBevestiging();
            verwijderBevestiging.Show();
        }

        private void BeheerderScherm_Click(object sender, RoutedEventArgs e)
        {
            Beheerderscherm beheerderscherm = new Beheerderscherm();
            beheerderscherm.Show();
        }

        private void RecensieScherm_Click(object sender, RoutedEventArgs e)
        {
            Carespot.Recensie recensie = new Carespot.Recensie();
            recensie.Show();
        }

        private void HulpverlenerOverzicht_Click(object sender, RoutedEventArgs e)
        {
            HulpverlenerHoofdscherm hulpverlenerHoofdscherm = new HulpverlenerHoofdscherm();
            hulpverlenerHoofdscherm.Show();
        }
    }
}
