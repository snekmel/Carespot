﻿using System;
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
            if (_g.GetType() == typeof(Hulpverlener))
            {
                var hulpscherm = new HulpverlenerHoofdscherm(_g);
                hulpscherm.Show();
                this.Close();
            }
            if (_g.GetType() == typeof(Vrijwilliger))
            {
                var vrijscherm = new VrijwilligerHoofdscherm(_g);
                vrijscherm.Show();
                this.Close();
            }
            if (_g.GetType() == typeof(Hulpbehoevende))
            {
                var hulpscherm = new CliëntOverzicht(_g);
                hulpscherm.Show();
                this.Close();
            }
        }

        private void btGegevensWijzigen_Click(object sender, RoutedEventArgs e)
        {
            var inf = new GebruikerSQLContext();
            bool canUpdate = true;
            var repo = new GebruikerRepository(inf);
            if (!String.IsNullOrEmpty(tbEmail.Text) && !String.IsNullOrEmpty(tbNaam.Text) &&
                !String.IsNullOrEmpty(tbTelefoon.Text) && !String.IsNullOrEmpty(tbAdres.Text) &&
                !String.IsNullOrEmpty(tbNummer.Text) && !String.IsNullOrEmpty(tbPostcode.Text) && !String.IsNullOrEmpty(tbPlaats.Text) &&
                !String.IsNullOrEmpty(tbLand.Text))
            {
                System.Windows.MessageBox.Show(_g.Wachtwoord);
                _g.Email = tbEmail.Text;
                _g.Naam = tbNaam.Text;
                _g.Telefoonnummer = tbTelefoon.Text;
                _g.Straat = tbAdres.Text;
                _g.Huisnummer = tbNummer.Text;
                _g.Postcode = tbPostcode.Text;
                _g.Plaats = tbPlaats.Text;
                _g.Land = tbLand.Text;

                //Wanneer 1 van de 2 leeg is
                if (String.IsNullOrEmpty(pwbWachtwoord.Password) || String.IsNullOrEmpty(pwbWachtwoordHerhalen.Password))
                {
                    if (String.IsNullOrEmpty(pwbWachtwoord.Password) &&
                        String.IsNullOrEmpty(pwbWachtwoordHerhalen.Password))
                    {
                        //allebei is leeg
                        _g.Wachtwoord = _g.Wachtwoord;
                        System.Windows.MessageBox.Show("allebei leeg + updaten");
                    }
                    else
                    {
                        //een van de 2 is leeg
                        System.Windows.MessageBox.Show("Vul allebei de velden in.");
                        canUpdate = false;
                    }
                }
                else
                {
                    //allebei gevuld
                    if (!String.IsNullOrEmpty(pwbWachtwoord.Password) &&
                        !String.IsNullOrEmpty(pwbWachtwoordHerhalen.Password))
                    {
                        if (pwbWachtwoord.Password != pwbWachtwoordHerhalen.Password)
                        {
                            System.Windows.MessageBox.Show("De wachtwoorden zijn niet gelijk.");
                            canUpdate = false;
                        }
                        else
                        {
                            _g.Wachtwoord = pwbWachtwoordHerhalen.Password;
                        }
                    }
                }

                if (cbGeslacht.SelectedItem != null)
                {
                    _g.Geslacht = (Gebruiker.GebruikerGeslacht)cbGeslacht.SelectedItem;
                }

                if (img == null)
                {
                }
                else
                {
                    _g.Foto = img;
                }

                if (canUpdate)
                {
                    repo.UpdateGebruiker(_g);
                }
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
            cbGeslacht.SelectedValue = _g.Geslacht;
            imgProfielfoto.Source = FunctionRepository.ByteToImage(_g.Foto);
        }

        private void vulCombobox()
        {
            foreach (var item in Enum.GetValues(typeof(Gebruiker.GebruikerGeslacht)))
            {
                cbGeslacht.Items.Add(item);
            }
        }

        private void btnVerwijderAccount_Click(object sender, RoutedEventArgs e)
        {
            if (_g.GetType() == typeof(Vrijwilliger))
            {
                var context = new VrijwilligerSQLContext();
                var repo = new VrijwilligerRepository(context);
                repo.DeleteVrijwilliger(_g.Id);
                var inlogScherm = new Inlogscherm();
                inlogScherm.Show();
                this.Close();
            }
            if (_g.GetType() == typeof(Hulpbehoevende))
            {
                var context = new HulpbehoevendeSQLContext();
                var repo = new HulpbehoevendeRepository(context);
                repo.DeleteHulpbehoevende(_g.Id);
                var inlogScherm = new Inlogscherm();
                inlogScherm.Show();
                this.Close();
            }
            if (_g.GetType() == typeof(Hulpverlener))
            {
                var context = new HulpverlenerSQLContext();
                var repo = new HulpverlenerRepository(context);
                repo.DeleteHulpverlener(_g.Id);
                var inlogScherm = new Inlogscherm();
                inlogScherm.Show();
                this.Close();
            }
        }
    }
}