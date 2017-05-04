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
    ///     Interaction logic for HulpverlenerToevoegen.xaml
    /// </summary>
    public partial class HulpverlenerToevoegen : Window
    {
        private readonly Gebruiker _ingelogdeGebruiker;
        private byte[] foto;
        private byte[] img;

        public HulpverlenerToevoegen(Gebruiker ingelogdeGebruiker)
        {
            InitializeComponent();
            VulComboBox();
            //cbGeslacht krijgt enum Geslacht {man, vrouw}
            _ingelogdeGebruiker = ingelogdeGebruiker;
        }

        private void VulComboBox()
        {
            foreach (var item in Enum.GetValues(typeof(Gebruiker.GebruikerGeslacht)))
                cbGeslacht.Items.Add(item);
        }

        public void CleanForm()
        {
            tbmail.Text = "";
            pwbWachtwoordOpnieuw.Password = "";
            pwbWachtwoordd.Password = "";
            tbNaam.Text = "";
            cbGeslacht.SelectedItem = -1;
            tbTelefoon.Text = "";
            tbAdres.Text = "";
            tbNummer.Text = "";
            tbPostcode.Text = "";
            tbPlaats.Text = "";
            tbLand.Text = "";
            //foto
        }

        private void imgSluiten_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var hhs = new HulpverlenerHoofdscherm(_ingelogdeGebruiker);
            hhs.Show();
            Close();
        }

        private void btUploaden_Click(object sender, RoutedEventArgs e)
        {
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
                img = br.ReadBytes((int)fs.Length);
                var imageUri = new Uri(filename);
                var imageBitmap = new BitmapImage(imageUri);
                imgProfielfoto.Source = imageBitmap;
            }
        }

        private void btnHulpverlenerAanmaken_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var email = tbmail.Text;
                var wachtwoord = pwbWachtwoordd.Password;
                var wachtwoordOpnieuw = pwbWachtwoordOpnieuw.Password;
                var naam = tbNaam.Text;
                var geslacht = (Gebruiker.GebruikerGeslacht)cbGeslacht.SelectedItem;
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
                    try
                    {
                        foto = repo.RetrieveGebruiker(1).Foto;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Er is iets mis gegaan. Foutomschrijving: " + ex.Message);
                    }
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

                        var hlp = new HulpverlenerSQLContext();
                        var repohlp = new HulpverlenerRepository(hlp);
                        try
                        {
                            var id = repo.CreateGebruiker(g);
                            repohlp.CreateHulpverlener(id);
                            CleanForm();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Er is iets mis gegaan. Foutomschrijving: " + ex.Message);
                        }
                        MessageBox.Show("De hulpverlener is succesvol aangemaakt.");
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
    }
}