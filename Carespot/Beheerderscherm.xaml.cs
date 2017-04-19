using System;
using System.Collections.Generic;
using System.IO;
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
using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Carespot.Models;
using Microsoft.Win32;

namespace Carespot
{
    /// <summary>
    /// Interaction logic for Beheerderscherm.xaml
    /// </summary>
    public partial class Beheerderscherm : Window
    {
        private byte[] img;
        private byte[] foto;

        public Beheerderscherm()
        {
            InitializeComponent();
            vulComboBox();
        }

        private void btUploaden_Click(object sender, RoutedEventArgs e)
        {
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
                imgProfielfotoH.Source = imageBitmap;
            }
        }

        private void btOpslaan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //gebruik gegevens om hulpverlener/beheerder (afhankelijk van de combobox) aan te maken
                var wachtwoord = pwbWachtwoord.Password;
                var wachtwoordHerhalen = tbHerhalenH.Text;
                var email = tbEmailH.Text;
                var naam = tbNaamH.Text;
                var geslacht = (Gebruiker.GebruikerGeslacht)cbGeslachtH.SelectedItem;
                var telNr = tbTelefoonH.Text;
                if (img == null)
                {
                    var inf = new GebruikerSQLContext();
                    var repo = new GebruikerRepository(inf);
                    foto = repo.RetrieveGebruiker(1039).Foto;
                }
                else
                {
                    foto = img;
                }

                var soort = cbSoortH.SelectedItem.ToString();
                var adres = tbAdres.Text;
                var nr = tbNummer.Text;
                var postcode = tbPostcode.Text;
                var plaats = tbPlaats.Text;
                var land = tbLand.Text;
                if (!String.IsNullOrEmpty(wachtwoord) && !String.IsNullOrEmpty(wachtwoordHerhalen)
                    && !String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(naam) && !String.IsNullOrEmpty(telNr) && !String.IsNullOrEmpty(adres) && !String.IsNullOrEmpty(nr)
                    && !String.IsNullOrEmpty(postcode) && !String.IsNullOrEmpty(plaats) && !String.IsNullOrEmpty(land))
                {
                    if (wachtwoord == wachtwoordHerhalen)
                    {
                        var inf = new GebruikerSQLContext();
                        var repo = new GebruikerRepository(inf);
                        var g = new Gebruiker
                        {
                            Email = email,
                            Foto = foto,
                            Geslacht = geslacht,
                            Naam = naam,
                            Wachtwoord = wachtwoord,
                            Telefoonnummer = telNr,
                            Straat = adres,
                            Huisnummer = nr,
                            Postcode = postcode,
                            Plaats = plaats,
                            Land = land
                        };
                        if (soort == "Hulpverlener")
                        {
                            var hlpv = new HulpverlenerSQLContext();
                            var repohulpv = new HulpverlenerRepository(hlpv);
                            var id = repo.CreateGebruiker(g);
                            repohulpv.CreateHulpverlener(id);
                        }
                        if (soort == "Beheerder")
                        {
                            var bhr = new BeheerderSQLContext();
                            var bhrrepo = new BeheerderRepository(bhr);
                            var id = repo.CreateGebruiker(g);
                            bhrrepo.CreateBeheerder(id);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wachtwoorden komen niet overeen.");
                    }
                }
                else
                {
                    MessageBox.Show("Alle velden moeten ingevuld zijn.");
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Er moet een geslacht en een soort gekozen zijn.");
            }
        }

        private void imgUitloggen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Inlogscherm inlogscherm = new Inlogscherm();
            inlogscherm.Show();
            this.Hide();
        }

        private void imgGebruikersbeheer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GebruikerBeheer gebruikerBeheer = new GebruikerBeheer();
            gebruikerBeheer.Show();
            this.Close();
        }

        private void vulComboBox()
        {
            foreach (var item in Enum.GetValues(typeof(Gebruiker.GebruikerGeslacht)))
            {
                cbGeslachtH.Items.Add(item);
            }

            cbSoortH.Items.Add("Hulpverlener");
            cbSoortH.Items.Add("Beheerder");
        }
    }
}