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
    /// Interaction logic for ReactieOpHulpvraag.xaml
    /// </summary>
    public partial class ReactieOpHulpvraag : Window
    {

        private Gebruiker _loggedInUser;
        private HulpOpdracht _hulpOpdracht;
        public ReactieOpHulpvraag()
        {
            InitializeComponent();
        }

        public ReactieOpHulpvraag(Gebruiker g, HulpOpdracht h)
        {
            InitializeComponent();
            _loggedInUser = g;
            _hulpOpdracht = h;
        }

        private void btInsturen_Click(object sender, RoutedEventArgs e)
        {
            if (tbReactie.Text == "Schrijf een bericht..." || tbReactie.Text == "") 
            {
                MessageBox.Show("Schrijf eerst een bericht");
            }
            else
            {
                ReactieSQLContext rsc = new ReactieSQLContext();
                ReactieRepository rr = new ReactieRepository(rsc);
                rr.CreateReactie(_loggedInUser.Id, _hulpOpdracht.Id, tbReactie.Text);
                MessageBox.Show("Uw reactie is verzonden.");
            }

        }


        private void tbReactie_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (tbReactie.Text == "Schrijf een bericht...")
            {
                tbReactie.Text = "";
            }
        }
    }
}
