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
    /// Interaction logic for CliëntOverzicht.xaml
    /// </summary>
    public partial class CliëntOverzicht : Window
    {
        private readonly Gebruiker _ingelogdeGebr;
        private int _geselecteerdeHulpopdracht;

        public CliëntOverzicht(Gebruiker ingelogdegebr)
        {
            InitializeComponent();
            _ingelogdeGebr = ingelogdegebr;
            FillMijnOpdrachtenList();
            imgGebruiker.Source = FunctionRepository.ByteToImage(_ingelogdeGebr.Foto);
            lblNaam.Content = _ingelogdeGebr.Naam;
        }

        private void FillMijnOpdrachtenList()
        {
            lvMijnOpdrachten.Items.Clear();

            var context = new HulpopdrachtSQLContext();
            var hr = new HulpopdrachtRepository(context);

            //Vul lijst met mijn hulpopdrachten
            List<HulpOpdracht> mijnOpdrachten = new List<HulpOpdracht>();
            mijnOpdrachten = hr.GetAllHulpopdrachtenByHulpbehoevendeID(_ingelogdeGebr.Id);

            foreach (var hulpopdracht in mijnOpdrachten)
            {
                lvMijnOpdrachten.Items.Add(hulpopdracht);
            }
        }

        private void FillReactieOpOpdracht(int hulpopdrachtid)
        {
            _geselecteerdeHulpopdracht = hulpopdrachtid;

            lvReacties.Items.Clear();

            var contextho = new HulpopdrachtSQLContext();
            var hr = new HulpopdrachtRepository(contextho);

            bool accepted = hr.IsGeacepteerd(hulpopdrachtid);

            if (accepted)
            {
                lvReacties.Visibility = Visibility.Hidden;
            }

            else
            {
                lvReacties.Visibility = Visibility.Visible;

                lvReacties.Items.Clear();
                var context = new ReactieSQLContext();
                var rr = new ReactieRepository(context);

                //Vul lijst met mijn reacties
                List<Reactie> reactiesOpOpdracht = new List<Reactie>();
                reactiesOpOpdracht = rr.GetAllReactiesByHulopdrachtID(hulpopdrachtid);

                foreach (var reactie in reactiesOpOpdracht)
                {
                    lvReacties.Items.Add(reactie);
                }
            }
        }




        private void lvMijnOpdrachten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Haal de reacties op aan de hand van de geselecteerde hulpopdracht
            HulpOpdracht geselecteerdeHulpOpdracht = (HulpOpdracht)lvMijnOpdrachten.SelectedItem;
            FillReactieOpOpdracht(geselecteerdeHulpOpdracht.Id);
        }

        private void AcepteerOpdracht(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Reactie reactie = b.CommandParameter as Reactie;

            //Update de bijbehorende hulpodpracht
            var contextho = new HulpopdrachtSQLContext();
            var hr = new HulpopdrachtRepository(contextho);
            hr.AcceptReactie(_geselecteerdeHulpopdracht,reactie.Vrijwilliger.Id);

            //Verwijder de reactie
            var contextreactie = new ReactieSQLContext();
            var rr = new ReactieRepository(contextreactie);
            rr.DeleteReactie(reactie.Id);

            //Herlaad opdrachtenlistview
            FillReactieOpOpdracht(_geselecteerdeHulpopdracht);
        }

        private void AfwijzenOpdracht(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Reactie reactie = b.CommandParameter as Reactie;

            //Hier via dal opdracht afwijzen
            var context = new ReactieSQLContext();
            var rr = new ReactieRepository(context);
            rr.DeleteReactie(reactie.Id);

            //Herlaad opdrachtenlistview
            FillReactieOpOpdracht(_geselecteerdeHulpopdracht);
            
        }

        private void imgAddHulpvraag_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var hulpvraag = new Hulpvraagxaml(_ingelogdeGebr);
            hulpvraag.Show();
        }

        private void lvMijnOpdrachten_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HulpOpdracht ho = (HulpOpdracht)lvMijnOpdrachten.SelectedItem;

            Opdracht scherm = new Opdracht(_ingelogdeGebr, ho);
            scherm.Show();
        }

        private void imgGebruiker_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var gegevenswijzigen = new GegevensWijzigen(_ingelogdeGebr);
            gegevenswijzigen.Show();
            this.Close();
        }
    }
}