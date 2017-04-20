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
        private Gebruiker _loggedinUser;

        public Hulpvraagxaml(Gebruiker g)
        {
            InitializeComponent();
            _loggedinUser = g;
            lblNaam.Content = _loggedinUser.Naam;
        }

        private void image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
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

            HulpbehoevendeSQLContext hsc = new HulpbehoevendeSQLContext();
            HulpbehoevendeRepository hr = new HulpbehoevendeRepository(hsc);

            Hulpbehoevende opdrachtEigenaar = hr.RetrieveHulpbehoevendeById(_loggedinUser.Id);

            //plaats hulpvraag
            HulpOpdracht hulpOpdracht = new HulpOpdracht(geaccepteerd , titel, DateTime.Now, omschrijving, opdrachtdatum, opdrachtEigenaar);
            HulpopdrachtSQLContext hulpOpdrachtContext = new HulpopdrachtSQLContext();            
            HulpopdrachtRepository hulpOpdrachtRepo = new HulpopdrachtRepository(hulpOpdrachtContext);
            hulpOpdrachtRepo.CreateHulpopdracht(hulpOpdracht);
        }
    }
}
