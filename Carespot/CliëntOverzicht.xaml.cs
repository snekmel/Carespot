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
        public CliëntOverzicht()
        {
            InitializeComponent();
            //laad naam
            //laad functie
            FillLists();
        }
        //Geef lijst van mijn hulpvragen
        //Geef lijst van mogelijke vrijwilligers bij specifieke hulpvraag
        private void imgVoegHulpvraagToe_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //'Hulpvraag' openen
        }

        private void FillLists()
        {
            var context = new HulpopdrachtSQLContext();
            var hr = new HulpopdrachtRepository(context);

            lvMijnOpdrachten.DataContext = hr.GetAllHulpopdrachtenByHulpbehoevendeID(4);

          
        }
    }
}
