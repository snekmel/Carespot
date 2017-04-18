using System;
using System.Collections.Generic;
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
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select a picture";
            ofd.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (ofd.ShowDialog() == true)
            {
                ImageSource imageSource = new BitmapImage(new Uri(ofd.FileName));
                imgProfielfoto.Source = imageSource;
            }
        }

        private void btnHulpverlenerAanmaken_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var email = tbEmail.Text;
                var wachtwoord = tbWachtwoord.Text;
                var wachtwoordOpnieuw = tbHerhalen.Text;
                var naam = tbNaam.Text;
                var geslacht = (Gebruiker.GebruikerGeslacht)cbGeslacht.SelectedItem;
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

                        var hlpv = new HulpverlenerSQLContext();
                        var repohulpv = new HulpverlenerRepository(hlpv);
                        var id = repo.CreateGebruiker(g);
                        repohulpv.CreateHulpverlener(id);
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
        
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
