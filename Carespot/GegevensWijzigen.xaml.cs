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
    /// Interaction logic for GegevensWijzigen.xaml
    /// </summary>
    public partial class GegevensWijzigen : Window
    {
        private Gebruiker _g;
        private byte[] img;

        public GegevensWijzigen(Gebruiker g)
        {
            InitializeComponent();
            _g = g;
            vulTextBox();
            vulCombobox();
        }

        private void imgSluiten_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
        }

        private void btGegevensWijzigen_Click(object sender, RoutedEventArgs e)
        {
            var inf = new GebruikerSQLContext();
            var repo = new GebruikerRepository(inf);
            if (!String.IsNullOrEmpty(tbEmail.Text) && !String.IsNullOrEmpty(tbNaam.Text) &&
                !String.IsNullOrEmpty(tbTelefoon.Text) && !String.IsNullOrEmpty(tbAdres.Text) &&
                !String.IsNullOrEmpty(tbNummer.Text) && !String.IsNullOrEmpty(tbPostcode.Text) && !String.IsNullOrEmpty(tbPlaats.Text) &&
                !String.IsNullOrEmpty(tbLand.Text))
            {
                _g.Email = tbEmail.Text;
                _g.Naam = tbNaam.Text;
                _g.Telefoonnummer = tbTelefoon.Text;
                _g.Straat = tbAdres.Text;
                _g.Huisnummer = tbNummer.Text;
                _g.Postcode = tbPostcode.Text;
                _g.Plaats = tbPlaats.Text;
                _g.Land = tbLand.Text;
                if (!String.IsNullOrEmpty(pwbWachtwoord.Password) && !String.IsNullOrEmpty(pwbWachtwoordHerhalen.Password))
                {
                    if (pwbWachtwoord.Password == pwbWachtwoordHerhalen.Password)
                    {
                        _g.Wachtwoord = pwbWachtwoord.Password;
                    }
                    else
                    {
                        MessageBox.Show("Wachtwoorden komen niet overeen");
                    }
                }

                _g.Wachtwoord = pwbWachtwoord.Password;
                _g.Geslacht = (Gebruiker.GebruikerGeslacht)cbGeslacht.SelectedItem;
                if (img == null)
                {
                }
                else
                {
                    _g.Foto = img;
                }

                repo.UpdateGebruiker(_g);
            }
            else
            {
                MessageBox.Show("Er mogen geen velden leeggelaten worden");
            }
        }

        private void btVeranderen_Click(object sender, RoutedEventArgs e)
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

        private void vulTextBox()
        {
            tbEmail.Text = _g.Email;
            tbNaam.Text = _g.Naam;
            tbTelefoon.Text = _g.Telefoonnummer;
            tbAdres.Text = _g.Straat;
            tbNummer.Text = _g.Huisnummer;
            tbPostcode.Text = _g.Postcode;
            tbPlaats.Text = _g.Plaats;
            tbLand.Text = _g.Land;
            cbGeslacht.Text = _g.Geslacht.ToString();
            imgProfielfoto.Source = FunctionRepository.ByteToImage(_g.Foto);
        }

        private void vulCombobox()
        {
            foreach (var item in Enum.GetValues(typeof(Gebruiker.GebruikerGeslacht)))
            {
                cbGeslacht.Items.Add(item);
            }
        }
    }
}