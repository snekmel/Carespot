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
    ///     Interaction logic for Beheerderscherm.xaml
    /// </summary>
    public partial class Beheerderscherm : Window
    {
        private Gebruiker _ingelogdeGebruiker;
        private byte[] foto;
        private byte[] img;

        public Beheerderscherm()
        {
            InitializeComponent();
            vulComboBox();
        }

        public Beheerderscherm(Gebruiker ingelogdeGebruiker)
        {
            InitializeComponent();
            _ingelogdeGebruiker = ingelogdeGebruiker;
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
                imgProfielfotoH.Source = imageBitmap;
            }
        }

        private void btOpslaan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //gebruik gegevens om hulpverlener/beheerder (afhankelijk van de combobox) aan te maken

                var wachtwoord = pwbWachtwoordd.Password;
                var wachtwoordHerhalen = pwbWachtwoordOpnieuw.Password;
                var email = tbEmailH.Text;
                var naam = tbNaamH.Text;
                var geslacht = (Gebruiker.GebruikerGeslacht) cbGeslachtH.SelectedItem;
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
                if (!string.IsNullOrEmpty(wachtwoord) && !string.IsNullOrEmpty(wachtwoordHerhalen)
                    && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(naam) && !string.IsNullOrEmpty(telNr) && !string.IsNullOrEmpty(adres) && !string.IsNullOrEmpty(nr)
                    && !string.IsNullOrEmpty(postcode) && !string.IsNullOrEmpty(plaats) && !string.IsNullOrEmpty(land))
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
                else
                    MessageBox.Show("Alle velden moeten ingevuld zijn.");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Er moet een geslacht en een soort gekozen zijn.");
            }
        }

        private void imgUitloggen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var inlogscherm = new Inlogscherm();
            inlogscherm.Show();
            Hide();
        }

        private void imgGebruikersbeheer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var gebruikerBeheer = new GebruikerBeheer();
            gebruikerBeheer.Show();
            Close();
        }

        private void vulComboBox()
        {
            foreach (var item in Enum.GetValues(typeof(Gebruiker.GebruikerGeslacht)))
                cbGeslachtH.Items.Add(item);

            cbSoortH.Items.Add("Hulpverlener");
            cbSoortH.Items.Add("Beheerder");
        }
    }
}