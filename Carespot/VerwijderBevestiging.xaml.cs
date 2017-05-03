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
using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;

namespace Carespot
{
    /// <summary>
    /// Interaction logic for VerwijderBevestiging.xaml
    /// </summary>
    public partial class VerwijderBevestiging : Window
    {
        Gebruiker _ontvangGebr;
        Gebruiker _ingelogdeGebr;
        GebruikerBeheer _scherm;
        public VerwijderBevestiging()
        {
            InitializeComponent();
            
        }
        public VerwijderBevestiging(Gebruiker ingelogdeGebr,Gebruiker ontvangGebr, GebruikerBeheer scherm)
        {
            InitializeComponent();
            //haal gebruiker op
            _ontvangGebr = ontvangGebr;
            _ingelogdeGebr = ingelogdeGebr;
            _scherm = scherm;
        }

        private void btnJa_Click(object sender, RoutedEventArgs e)
        {
            //verwijder gebruiker
            if (_ontvangGebr.Type == Gebruiker.GebruikerType.Hulpverlener)
            {
                var hvContext = new HulpverlenerSQLContext();
                var hulpverlenerRepo = new HulpverlenerRepository(hvContext);
                try
                {
                    hulpverlenerRepo.DeleteHulpverlener(_ontvangGebr.Id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Er is iets mis gegaan. Foutomschrijving: " + ex.Message);
                }
            }
            else if (_ontvangGebr.Type == Gebruiker.GebruikerType.Hulpbehoevende)
            {
                var hbContext = new HulpbehoevendeSQLContext();
                var hulpbehoevendeRepo = new HulpbehoevendeRepository(hbContext);
                try
                {
                    hulpbehoevendeRepo.DeleteHulpbehoevende(_ontvangGebr.Id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Er is iets mis gegaan. Foutomschrijving: " + ex.Message);
                }
            }
            else if (_ontvangGebr.Type == Gebruiker.GebruikerType.Vrijwilliger)
            {
                var vContext = new VrijwilligerSQLContext();
                var vrijwilligerRepo = new VrijwilligerRepository(vContext);
                try
                {
                    vrijwilligerRepo.DeleteVrijwilliger(_ontvangGebr.Id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Er is iets mis gegaan. Foutomschrijving: " + ex.Message);
                }
            }
            _scherm.vulListView();
            this.Close();
        }

        private void btnNee_Click(object sender, RoutedEventArgs e)
        {
            //terug naar GebruikerBeheer
            this.Close();
        }
    }
}
