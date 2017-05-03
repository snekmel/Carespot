using System;
using System.Windows;
using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Carespot.Models;

namespace Carespot
{
    /// <summary>
    ///     Interaction logic for BeoordelingScherm.xaml
    /// </summary>
    public partial class BeoordelingScherm : Window
    {
        private readonly Gebruiker ingelogdeGebr;
        private readonly Gebruiker ontvangGebr;

        public BeoordelingScherm(Gebruiker ingelogdeGebuiker, Gebruiker ontvangGebruiker)
        {
            InitializeComponent();
            SldCijfer.ValueChanged += SldCijfer_ValueChanged;
            ingelogdeGebr = ingelogdeGebuiker;
            ontvangGebr = ontvangGebruiker;
        }

        private void SldCijfer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> routedPropertyChangedEventArgs)
        {
            LblCijfer.Content = SldCijfer.Value;
        }

        private void BtnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            if (TbTitel.Text != "" && TbBeoordelingTekst.Text != "")
            {
                MessageBox.Show(TbTitel.Text + " - " + TbBeoordelingTekst.Text + " - " + SldCijfer.Value);

                var beoordeling = new Beoordeling(TbBeoordelingTekst.Text, Convert.ToInt32(SldCijfer.Value), ontvangGebr.Id, ingelogdeGebr.Id);

                var beoordelingSqlContext = new BeoordelingSQLContext();
                var beoordelingRepository = new BeoordelingRepository(beoordelingSqlContext);

                try
                {
                    beoordelingRepository.Create(beoordeling);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Er is iets mis gegaan. Foutomschrijving: " + ex.Message);
                }
            }
        }
    }
}