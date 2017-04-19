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
using Carespot.Models;

namespace Carespot
{
    /// <summary>
    /// Interaction logic for Opdracht.xaml
    /// </summary>
    public partial class Opdracht : Window
    {

        private Gebruiker _loggedInUser;
        private HulpOpdracht _hulpOpdracht;

        public Opdracht()
        {
            InitializeComponent();
        }
        public Opdracht(Gebruiker g, HulpOpdracht h)
        {
            InitializeComponent();

            System.Windows.MessageBox.Show("Test");
            _loggedInUser = g;
            _hulpOpdracht = h;
            ViewLoader();
        }

        private void ViewLoader()
        {
            lblOpdrachtTitel.Content = _hulpOpdracht.Titel;
            tbOmschrijving.Text = _hulpOpdracht.Omschrijving;


            //client
            lblNaamCliënt.Content = _hulpOpdracht.Hulpbehoevende.Naam;
            lblTelefoonCliënt.Content = _hulpOpdracht.Hulpbehoevende.Telefoonnummer;
            lblEmailCliënt.Content = _hulpOpdracht.Hulpbehoevende.Email;


            //Vrijwilliger
            lblNaamVrijwilliger.Content = _hulpOpdracht.Vrijwilleger.Naam;
            lblTelefoonVrijwilliger.Content = _hulpOpdracht.Vrijwilleger.Telefoonnummer;
            lblEmailVrijwilliger.Content = _hulpOpdracht.Vrijwilleger.Email;


            //Profesionele begeleider
         // lblNaamHulpverlener.Content = _hulpOpdracht.




            //laad omschrijvingstab
        }


        private void imgSluitAf_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //'VrijwilligerHoofdscherm openen'
        }

        private void tabOmschrijving_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //laad omschrijvingstab
        }

        private void tabChat_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //laad chatberichten
        }

        private void tabContact_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //laad contacteninfo
        }
    }
}
