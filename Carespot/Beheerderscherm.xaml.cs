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
using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Carespot.Models;

namespace Carespot
{
    /// <summary>
    /// Interaction logic for Beheerderscherm.xaml
    /// </summary>
    public partial class Beheerderscherm : Window
    {
        public Beheerderscherm()
        {
            InitializeComponent();
            vulComboBox();
            //vul combobox hulpverlener/beheerder
        }

        private void btUploaden_Click(object sender, RoutedEventArgs e)
        {
            //profielfoto uploaden
        }

        private void btOpslaan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //gebruik gegevens om hulpverlener/beheerder (afhankelijk van de combobox) aan te maken
                var wachtwoord = tbWachtwoordH.Text;
                var wachtwoordHerhalen = tbHerhalenH.Text;
                var email = tbEmailH.Text;
                var naam = tbNaamH.Text;
                var geslacht = (Gebruiker.GebruikerGeslacht)cbGeslachtH.SelectedItem;
                var telNr = tbTelefoonH.Text;
                //var foto = imgProfielfotoH.Source.ToString();
                var soort = cbSoortH.SelectedItem.ToString();
                if (!String.IsNullOrEmpty(wachtwoord) && !String.IsNullOrEmpty(wachtwoordHerhalen)
                    && !String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(naam) && !String.IsNullOrEmpty(telNr))
                {
                    if (wachtwoord == wachtwoordHerhalen)
                    {
                        var inf = new GebruikerSQLContext();
                        var repo = new GebruikerRepository(inf);
                        var g = new Gebruiker
                        {
                            Email = email,
                            //   Foto = foto,
                            Geslacht = geslacht,
                            Naam = naam,
                            Wachtwoord = wachtwoord,
                            Telefoonnummer = telNr
                        };
                        if (soort == "Hulpverlener")
                        {
                            //var id = repo.CreateGebruiker(g);
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
            //beheerder uitloggen
        }

        private void imgGebruikersbeheer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //gebruikersoverzicht openen
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