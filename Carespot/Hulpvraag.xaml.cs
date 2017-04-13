using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Carespot.Models;
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

namespace Carespot
{
    /// <summary>
    /// Interaction logic for Hulpvraagxaml.xaml
    /// </summary>
    public partial class Hulpvraagxaml : Window
    {
        Hulpbehoevende hulpbehoevende;
        public Hulpvraagxaml(Hulpbehoevende hb)
        {
            InitializeComponent();
            hulpbehoevende = hb;
            lblNaam.Content = hulpbehoevende.Naam;
            //laadt naam
        }

        private void image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //ga terug naar CliëntOverzicht
            CliëntOverzicht window = new CliëntOverzicht();
            window.Show();
            this.Close();
        }

        private void btToevoegen_Click(object sender, RoutedEventArgs e)
        {
            tbTitel.SelectAll();
            string titel = tbTitel.SelectedText;

            tbBeschrijving.SelectAll();
            string omschrijving = tbBeschrijving.Selection.Text;

            DateTime opdrachtdatum = (DateTime)dpOpdrachtDatum.SelectedDate;

            bool geaccepteerd = false;

            //plaats hulpvraag
            HulpOpdracht hulpOpdracht = new HulpOpdracht(hulpbehoevende.Id, geaccepteerd , titel, DateTime.Now, omschrijving, opdrachtdatum, hulpbehoevende);
            HulpopdrachtSQLContext hulpOpdrachtContext = new HulpopdrachtSQLContext();            
            HulpopdrachtRepository hulpOpdrachtRepo = new HulpopdrachtRepository(hulpOpdrachtContext);
            hulpOpdrachtRepo.CreateHulpopdracht(hulpOpdracht);
        }
    }
}
