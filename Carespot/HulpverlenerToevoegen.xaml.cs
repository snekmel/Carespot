using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
using Microsoft.Win32;
using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Carespot.Models;

namespace Carespot
{
    /// <summary>
    /// Interaction logic for HulpverlenerToevoegen.xaml
    /// </summary>
    public partial class HulpverlenerToevoegen : Window
    {
        private byte[] img;
        private byte[] foto;

        public HulpverlenerToevoegen()
        {
            InitializeComponent();
            VulComboBox();
            //cbGeslacht krijgt enum Geslacht {man, vrouw}
        }

        private void VulComboBox()
        {
            foreach (var item in Enum.GetValues(typeof(Gebruiker.GebruikerGeslacht)))
            {
                cbGeslacht.Items.Add(item);
            }
        }

        private void imgSluiten_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            HulpverlenerHoofdscherm hhs = new HulpverlenerHoofdscherm();
            hhs.Show();
            this.Close();
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
                    foto = repo.RetrieveGebruiker(1).Foto;
                }
                else
                {
                    foto = img;
                }

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

                        var hlp = new HulpverlenerSQLContext();
                        var repohlp = new HulpverlenerRepository(hlp);
                        var id = repo.CreateGebruiker(g);
                        repohlp.CreateHulpverlener(id);
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
    }
}