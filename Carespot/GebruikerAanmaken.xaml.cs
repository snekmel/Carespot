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
        private HulpbehoevendeSQLContext inf;
        private HulpbehoevendeRepository repo;

        public GebruikerAanmaken()
        {
            InitializeComponent();
            inf = new HulpbehoevendeSQLContext();
            repo = new HulpbehoevendeRepository(inf);
            //cbGeslacht krijgt Enum Geslacht {man, vrouw}
        }

        private void btGebruikerAanmaken_Click(object sender, RoutedEventArgs e)
        {
            //if (rdHulpbehoevnde.IsChecked == true)
            //{
            //}
            try
            {
                var email = tbEmail.Text;
                var wachtwoord = tbWachtwoord.Text;
                var wachtwoordOpnieuw = tbHerhalen.Text;
                var naam = tbNaam.Text;
                var geslacht = (Gebruiker.GebruikerGeslacht)cbGeslacht.SelectedItem;
                var gebruikertype = (Gebruiker.GebruikerType)cmGebruikerType.SelectedItem;
                var telNr = tbTelefoon.Text;
                var adres = tbAdres.Text;
                var huisNummer = tbNummer.Text;
                var postcode = tbPostcode.Text;
                var plaats = tbPlaats.Text;
                var land = tbLand.Text;
                var foto = imgProfielfoto.Source.ToString();
                if (wachtwoord == wachtwoordOpnieuw)
                {
                   // repo.CreateHulpbehoevende(naam, wachtwoord, geslacht, adres, huisNummer, postcode, plaats, land, email,
                    //    telNr, gebruikertype, foto, 3);
                }
                else
                {
                    MessageBox.Show("Wachtwoorden komen niet overeen.");
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Er moet een geslacht en een gebruikerstype gekozen zijn.");
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
    }
}