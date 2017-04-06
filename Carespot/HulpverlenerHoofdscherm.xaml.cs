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
    /// Interaction logic for HulpverlenerHoofdscherm.xaml
    /// </summary>
    public partial class HulpverlenerHoofdscherm : Window
    {
        public HulpverlenerHoofdscherm()
        {
            InitializeComponent();
            //laad naam
            //laad functie
        }
        //Geef lijst met gekoppelde cliënten
        //Geef lijst met de daarbijhorende hulpvragen

        private void imgHulpverlenerToevoegen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //'Hulpverlener toevoegen' openen
        }

        private void imgUitloggen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //hulpverlener uitloggen en terug naar inlogscherm
        }
    }
}
