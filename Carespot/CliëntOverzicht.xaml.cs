﻿using System;
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

        public CliëntOverzicht(Gebruiker ingelogdegebr)
        {
            InitializeComponent();
            _ingelogdeGebr = ingelogdegebr;
            FillLists();
        }

        public CliëntOverzicht()
        {
            InitializeComponent();
            FillLists();
        }

        //Geef lijst van mogelijke vrijwilligers bij specifieke hulpvraag
        private void imgVoegHulpvraagToe_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //'Hulpvraag' openen
        }

        private void FillLists()
        {
            var context = new HulpopdrachtSQLContext();
            var hr = new HulpopdrachtRepository(context);

            //Vul lijst met mijn hulpopdrachten
            List<HulpOpdracht> mijnOpdrachten = new List<HulpOpdracht>();
            mijnOpdrachten = hr.GetAllHulpopdrachtenByHulpbehoevendeID(_ingelogdeGebr.Id);

            foreach (var hulpopdracht in mijnOpdrachten)
            {
                //Voeg toe aan listview
                lvMijnOpdrachten.Items.Add(hulpopdracht);
            }
        }
    }
}
