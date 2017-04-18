using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Carespot.Models;
using Microsoft.Win32;

namespace Carespot
{
    /// <summary>
    /// Interaction logic for GebruikerAanmaken.xaml
    /// </summary>
    public partial class GebruikerAanmaken : Window
    {
        private byte[] img;

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
                var foto = img;
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
                            Foto = foto,
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
                            var hulpverlener = repohlp.HulpverlenerId();
                            repohlp.CreateHulpbehoevende(id, hulpverlener);
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
            //profielfoto uploaden
            var dlg = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            // Display OpenFileDialog by calling ShowDialog method
            bool? result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                var filename = dlg.FileName;

                var fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                var br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                Uri imageUri = new Uri(filename);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                imgProfielfoto.Source = imageBitmap;
            }
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