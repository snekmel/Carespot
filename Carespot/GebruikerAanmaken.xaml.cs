using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for GebruikerAanmaken.xaml
    /// </summary>
    public partial class GebruikerAanmaken : Window
    {
        public GebruikerAanmaken()
        {
            InitializeComponent();

            //cbGeslacht krijgt Enum Geslacht {man, vrouw}
            vulComboBox();
        }

        private void btGebruikerAanmaken_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var email = tbEmail.Text;
                var wachtwoord = tbWachtwoord.Text;
                var wachtwoordOpnieuw = tbHerhalen.Text;
                var naam = tbNaam.Text;
                var geslacht = (Gebruiker.GebruikerGeslacht)cbGeslacht.SelectedItem;
                // var gebruikertype = (Gebruiker.GebruikerType)cmGebruikerType.SelectedItem;
                var telNr = tbTelefoon.Text;
                var adres = tbAdres.Text;
                var huisNummer = tbNummer.Text;
                var postcode = tbPostcode.Text;
                var plaats = tbPlaats.Text;
                var land = tbLand.Text;
                // var foto = imgProfielfoto.Source.ToString();
                if (!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(wachtwoord) &&
                    !String.IsNullOrEmpty(wachtwoordOpnieuw) && !String.IsNullOrEmpty(naam) &&
                    !String.IsNullOrEmpty(telNr) && !String.IsNullOrEmpty(adres) && !String.IsNullOrEmpty(huisNummer) &&
                    !String.IsNullOrEmpty(postcode) && !String.IsNullOrEmpty(plaats) && !String.IsNullOrEmpty(land))
                {
                    if (wachtwoord == wachtwoordOpnieuw)
                    {
                        var inf = new GebruikerSQLContext();
                        var repo = new GebruikerRepository(inf);
                        var g = new Gebruiker
                        {
                            Email = email,
                            //   Foto = foto,
                            Geslacht = geslacht,
                            Huisnummer = huisNummer,
                            Land = land,
                            Naam = naam,
                            Plaats = plaats,
                            Postcode = postcode,
                            Straat = adres,
                            Wachtwoord = wachtwoord,
                            Telefoonnummer = telNr
                        };

                        if (chbHulpbehoevnde.IsChecked == true)
                        {
                            var hlp = new HulpbehoevendeSQLContext();
                            var repohlp = new HulpbehoevendeRepository(hlp);
                            var id = repo.CreateGebruiker(g);
                            repohlp.CreateHulpbehoevende(id, 3);
                        }
                        if (chbVrijwilliger.IsChecked == true)
                        {
                            var vrw = new VrijwilligerSQLContext();
                            var repovrw = new VrijwilligerRepository(vrw);
                            var id = repo.CreateGebruiker(g);
                            repovrw.CreateVrijwilliger(id);
                        }
                        if (chbHulpbehoevnde.IsChecked == false && chbVrijwilliger.IsChecked == false)
                        {
                            MessageBox.Show("Er moet een gebruikers type aangeklikt zijn.");
                        }

                        // repo.CreateHulpbehoevende(naam, wachtwoord, geslacht, adres, huisNummer, postcode, plaats, land, email,
                        //    telNr, gebruikertype, foto, 3);
                    }
                    else
                    {
                        MessageBox.Show("Wachtwoorden komen niet overeen.");
                    }
                }
                else
                {
                    MessageBox.Show("Alle velden moeten zijn ingevuld.");
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Er moet een geslacht gekozen zijn.");
            }
        }

        private void imgSluiten_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Inlogscherm inlog = new Inlogscherm();
            inlog.Show();
            this.Close();
        }

        private void btUploaden_Click(object sender, RoutedEventArgs e)
        {
            //foto uploaden
        }

        private void vulComboBox()
        {
            foreach (var item in Enum.GetValues(typeof(Gebruiker.GebruikerGeslacht)))
            {
                cbGeslacht.Items.Add(item);
            }
        }
    }
}