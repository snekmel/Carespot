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
    /// Interaction logic for VrijwilligerOpdrachtAannemen.xaml
    /// </summary>
    public partial class VrijwilligerOpdrachtAannemen : Window
    {
        Gebruiker _ingelogdeGebr;
        public VrijwilligerOpdrachtAannemen(Gebruiker ingelogdeGebr)
        {
            InitializeComponent();
            //laad naam
            _ingelogdeGebr = ingelogdeGebr;
            //vul combobox
            vulOpdrachtLijst();
        }
        //Geef lijst met beschikbare hulpvragen
        private void image_Copy1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //'VrijwilligerHoofdscherm' openen
        }

        private void btKiesOpdracht_Click(object sender, RoutedEventArgs e)
        {
            HulpOpdracht gelsecteerdeOpdr = (HulpOpdracht)lvOpdrachten.SelectedItem;
            ReactieOpHulpvraag window = new ReactieOpHulpvraag(_ingelogdeGebr, gelsecteerdeOpdr);
            window.Show();
            this.Close();
        }

        private void vulOpdrachtLijst()
        {
            lvOpdrachten.Items.Clear();

            var context = new HulpopdrachtSQLContext();
            var opdrRepo = new HulpopdrachtRepository(context);

            List<HulpOpdracht> opdrachtenLijst = new List<HulpOpdracht>();
            opdrachtenLijst = opdrRepo.GetAllHulpopdrachten();

            foreach (var opdracht in opdrachtenLijst)
            {
                lvOpdrachten.Items.Add(opdracht);
            }
        }
    }
}
