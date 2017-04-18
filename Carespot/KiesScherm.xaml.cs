using System.Windows;

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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var inlogscherm = new Inlogscherm();
            inlogscherm.Show();
        }

        private void Keuzescherm_Click(object sender, RoutedEventArgs e)
        {
            var keuzescherm = new Keuzescherm();
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
            var opdracht = new Opdracht();
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
    }
}