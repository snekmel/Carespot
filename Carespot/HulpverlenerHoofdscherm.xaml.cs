using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Carespot.Models;

namespace Carespot
{
    /// <summary>
    ///     Interaction logic for HulpverlenerHoofdscherm.xaml
    /// </summary>
    public partial class HulpverlenerHoofdscherm : Window
    {
        private readonly Gebruiker _ingelogdeGebruiker;

        public HulpverlenerHoofdscherm(Gebruiker ingelogdeGebruiker)
        {
            InitializeComponent();
            _ingelogdeGebruiker = ingelogdeGebruiker;
            profielImg.Source = FunctionRepository.ByteToImage(_ingelogdeGebruiker.Foto);
            lblNaam.Content = ingelogdeGebruiker.Naam;
            ViewLoader();
        }

        private void ViewLoader()
        {
            this.lvCliënten.Items.Clear();

            //Haal al de hulpbehoevende die bij de user horen.
            HulpbehoevendeSQLContext hsc = new HulpbehoevendeSQLContext();
            HulpbehoevendeRepository hr = new HulpbehoevendeRepository(hsc);

            foreach (Hulpbehoevende hb in hr.RetrieveAllHulpbehoevendeByHulpverlenerId(_ingelogdeGebruiker.Id))
            {
                lvCliënten.Items.Add(hb);
            }
        }

        private void imgHulpverlenerToevoegen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var hulpverlenerToevoegen = new HulpverlenerToevoegen(_ingelogdeGebruiker);
            hulpverlenerToevoegen.Show();
            this.Close();
        }

        private void imgUitloggen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var inlog = new Inlogscherm();
            inlog.Show();
            this.Close();
        }

        private void profielImg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var gegevenswijzigen = new GegevensWijzigen(_ingelogdeGebruiker);
            gegevenswijzigen.Show();
            this.Close();
        }

        private void lvCliënten_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this.lvOpdrachten.Items.Clear();
            if ((Hulpbehoevende)lvCliënten.SelectedItem != null)
            {
                HulpopdrachtSQLContext hs = new HulpopdrachtSQLContext();
                HulpopdrachtRepository hor = new HulpopdrachtRepository(hs);

                //Haal de opdrachten op bij de geselecteerde hulpbehoevende
                Hulpbehoevende hulpbehoevende = (Hulpbehoevende)lvCliënten.SelectedItem;

                foreach (HulpOpdracht opdracht in hor.GetAllHulpopdrachtenByHulpbehoevendeID(hulpbehoevende.Id))
                {
                    lvOpdrachten.Items.Add(opdracht);
                }
            }
        }

        private void lvOpdrachten_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HulpOpdracht ho = (HulpOpdracht)lvOpdrachten.SelectedItem;

            Opdracht scherm = new Opdracht(_ingelogdeGebruiker, ho);
            scherm.Show();
        }
    }
}