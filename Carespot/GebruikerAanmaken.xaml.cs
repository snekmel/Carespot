using System;
using System.IO;
using System.Threading;
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
    ///     Interaction logic for GebruikerAanmaken.xaml
    /// </summary>
    public partial class GebruikerAanmaken : Window
    {
        private byte[] foto;
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
                var wachtwoord = tbWachtwoord.Password;
                var wachtwoordOpnieuw = tbHerhalen.Password;
                var naam = tbNaam.Text;
                var geslacht = (Gebruiker.GebruikerGeslacht) cbGeslacht.SelectedItem;
                var telNr = tbTelefoon.Text;
                var adres = tbAdres.Text;
                var huisNummer = tbNummer.Text;
                var postcode = tbPostcode.Text;
                var plaats = tbPlaats.Text;
                var land = tbLand.Text;
                if (img == null)
                {
                    var inf = new GebruikerSQLContext();
                    var repo = new GebruikerRepository(inf);
                    foto = repo.RetrieveGebruiker(1).Foto;
                }
                else
                {
                    foto = img;
                }

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(wachtwoord) &&
                    !string.IsNullOrEmpty(wachtwoordOpnieuw) && !string.IsNullOrEmpty(naam) &&
                    !string.IsNullOrEmpty(telNr) && !string.IsNullOrEmpty(adres) && !string.IsNullOrEmpty(huisNummer) &&
                    !string.IsNullOrEmpty(postcode) && !string.IsNullOrEmpty(plaats) && !string.IsNullOrEmpty(land))
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
                        var id = 0;
                        bool gebruikerIsAaangemaakt = false;
                        if (chbHulpbehoevnde.IsChecked == true)
                        {
                            var hlp = new HulpbehoevendeSQLContext();
                            var repohlp = new HulpbehoevendeRepository(hlp);
                            id = repo.CreateGebruiker(g);
                            var hulpverlener = repohlp.HulpverlenerId();
                            gebruikerIsAaangemaakt = true;

                            try
                            {
                                repohlp.CreateHulpbehoevende(id, hulpverlener);
                                tbNaam.Text = "";
                                tbEmail.Text = "";
                                tbWachtwoord.Password = "";
                                tbHerhalen.Password = "";
                                cbGeslacht.SelectedItem = -1;
                                chbHulpbehoevnde.IsChecked = false;
                                chbVrijwilliger.IsChecked = false;
                                tbTelefoon.Text = "";
                                tbAdres.Text = "";
                                tbNummer.Text = "";
                                tbPostcode.Text = "";
                                tbPlaats.Text = "";
                                tbLand.Text = "";
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Er is iets mis gegaan. Foutomschrijving: " + ex.Message);
                            }
                        }
                        if (chbVrijwilliger.IsChecked == true)
                        {
                            var vrw = new VrijwilligerSQLContext();
                            var repovrw = new VrijwilligerRepository(vrw);
                            try
                            {
                                if (!gebruikerIsAaangemaakt)
                                {
                                    id = repo.CreateGebruiker(g);
                                    repovrw.CreateVrijwilliger(id);
                                }
                                else
                                {
                                    repovrw.CreateVrijwilliger(id);
                                }
                               
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Er is iets mis gegaan. Foutomschrijving: " + ex.Message);
                            }
                        }
                        if (chbHulpbehoevnde.IsChecked == false && chbVrijwilliger.IsChecked == false)
                            MessageBox.Show("Er moet een gebruikers type aangeklikt zijn.");

                        // repo.CreateHulpbehoevende(naam, wachtwoord, geslacht, adres, huisNummer, postcode, plaats, land, email,
                        //    telNr, gebruikertype, foto, 3);
                    }
                    else
                    {
                        MessageBox.Show("Wachtwoorden komen niet overeen.");
                    }
                else
                    MessageBox.Show("Alle velden moeten zijn ingevuld.");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Er moet een geslacht gekozen zijn.");
            }
        }

        private void imgSluiten_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var inlog = new Inlogscherm();
            inlog.Show();
            Close();
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
            var result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                var filename = dlg.FileName;

                var fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                var br = new BinaryReader(fs);
                img = br.ReadBytes((int) fs.Length);
                var imageUri = new Uri(filename);
                var imageBitmap = new BitmapImage(imageUri);
                imgProfielfoto.Source = imageBitmap;
            }
        }

        private void vulComboBox()
        {
            foreach (var item in Enum.GetValues(typeof(Gebruiker.GebruikerGeslacht)))
                cbGeslacht.Items.Add(item);
        }
    }
}