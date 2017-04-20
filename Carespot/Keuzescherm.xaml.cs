using System.Windows;
using System.Windows.Input;
using Carespot.Models;

namespace Carespot
{
    /// <summary>
    ///     Interaction logic for Keuzescherm.xaml
    /// </summary>
    public partial class Keuzescherm : Window
    {
        private readonly Gebruiker gebrHulpbehoevende;
        private readonly Gebruiker gebrVrijwilliger;

        public Keuzescherm(Gebruiker vrijwilliger, Gebruiker hulpbehoevende)
        {
            InitializeComponent();
            gebrVrijwilliger = vrijwilliger;
            gebrHulpbehoevende = hulpbehoevende;
        }

        private void btHulpbehoevende_Click(object sender, RoutedEventArgs e)
        {
            var cliëntscherm = new CliëntOverzicht(gebrHulpbehoevende);
            cliëntscherm.Show();
            Close();
            //log in als hulpbehoevende --> open 'CliëntOverzicht'
            //MessageBox.Show(gebrHulpbehoevende + " - " + gebrHulpbehoevende.Email);
        }

        private void btVrijwilliger_Click(object sender, RoutedEventArgs e)
        {
            var vrijwilligerscherm = new VrijwilligerHoofdscherm(gebrVrijwilliger);
            vrijwilligerscherm.Show();
            Close();
            //log in als vrijwilliger --> open 'VrijwilligerHoofdscherm'
            //MessageBox.Show(gebrVrijwilliger + " - " + gebrVrijwilliger.Email);
        }

        private void imgSluiten_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var inlog = new Inlogscherm();
            inlog.Show();
            Close();
        }
    }
}