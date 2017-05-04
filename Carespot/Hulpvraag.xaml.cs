using System;
using System.Windows;
using System.Windows.Input;
using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Carespot.Models;

namespace Carespot
{
    /// <summary>
    ///     Interaction logic for Hulpvraagxaml.xaml
    /// </summary>
    public partial class Hulpvraagxaml : Window
    {
        private readonly Gebruiker _loggedinUser;

        public Hulpvraagxaml(Gebruiker g)
        {
            InitializeComponent();
            _loggedinUser = g;
            lblNaam.Content = _loggedinUser.Naam;
            imgProfiel.Source = FunctionRepository.ByteToImage(_loggedinUser.Foto);
        }

        private void image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var window = new CliëntOverzicht(_loggedinUser);
            window.Show();
            Close();
        }

        private void btToevoegen_Click(object sender, RoutedEventArgs e)
        {
            tbTitel.SelectAll();
            var titel = tbTitel.SelectedText;

            tbBeschrijving.SelectAll();
            var omschrijving = tbBeschrijving.Selection.Text;

            var opdrachtdatum = (DateTime) dpOpdrachtDatum.SelectedDate;

            var geaccepteerd = false;

            try
            {
                var hsc = new HulpbehoevendeSQLContext();
                var hr = new HulpbehoevendeRepository(hsc);

                var opdrachtEigenaar = hr.RetrieveHulpbehoevendeById(_loggedinUser.Id);

                //plaats hulpvraag
                var hulpOpdracht = new HulpOpdracht(geaccepteerd, titel, DateTime.Now, omschrijving, opdrachtdatum, opdrachtEigenaar);
                var hulpOpdrachtContext = new HulpopdrachtSQLContext();
                var hulpOpdrachtRepo = new HulpopdrachtRepository(hulpOpdrachtContext);
                hulpOpdrachtRepo.CreateHulpopdracht(hulpOpdracht);
                tbTitel.Text = "";
                tbBeschrijving.Selection.Text = "";
                MessageBox.Show("Uw hulpvraag is succesvol aangemaakt.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is iets mis gegaan. Foutomschrijving: " + ex.Message);
            }
        }
    }
}