using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Carespot.Models;

namespace Carespot
{
    /// <summary>
    ///     Interaction logic for VrijwilligerHoofdscherm.xaml
    /// </summary>
    public partial class VrijwilligerHoofdscherm : Window
    {
        private Gebruiker _ingelogdeGebruiker;

        public VrijwilligerHoofdscherm(Gebruiker ingelogdeGebruiker)
        {
            InitializeComponent();
            _ingelogdeGebruiker = ingelogdeGebruiker;
            //laad naam gebruiker
            lblNaam.Content = _ingelogdeGebruiker.Naam;
            imgGebruiker.Source = FunctionRepository.ByteToImage(_ingelogdeGebruiker.Foto);
            //lijst actieve opdrachten ophalen en in listbox zetten
            Viewloader();
        }

        private void Viewloader()
        {
            HulpopdrachtSQLContext hsc = new HulpopdrachtSQLContext();
            HulpopdrachtRepository hr = new HulpopdrachtRepository(hsc);

          List<HulpOpdracht> opdrachten =  hr.RetrieveHulpopdrachtByVrijwilligerId(_ingelogdeGebruiker.Id);

            foreach (HulpOpdracht ho in opdrachten)
            {
                lvOpdracht.Items.Add(ho);
            }


        }

        private void imgLogout_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //gebruiker uitloggen en terug naar Inlogscherm
        }

        private void btOpgeven_Click(object sender, RoutedEventArgs e)
        {
            //open scherm: VrijwilligerOpdrachtAannemen
            VrijwilligerOpdrachtAannemen aannemen = new VrijwilligerOpdrachtAannemen(_ingelogdeGebruiker);
            aannemen.Show();
        }

        private void imgGebruiker_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            var gegevenswijzigen = new GegevensWijzigen(_ingelogdeGebruiker);
            gegevenswijzigen.Show();
            this.Close();
        }

        private void lvOpdracht_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HulpOpdracht ho = (HulpOpdracht)lvOpdracht.SelectedItem;

            Opdracht scherm = new Opdracht(_ingelogdeGebruiker, ho);
            scherm.Show();
        }
    }
}