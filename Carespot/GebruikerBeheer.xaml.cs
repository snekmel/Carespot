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
    /// Interaction logic for GebruikerBeheer.xaml
    /// </summary>
    public partial class GebruikerBeheer : Window
    {
        public GebruikerBeheer()
        {
            InitializeComponent();
            //lijst van gebruikers ophalen in de listview
        }

        private void imgGebruiker_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //geselecteerde gebruiker verwijderen
        }

        private void imgSluitAf_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //als hulpverlener ingelogd is ga terug naar HulpverlenerHoofdscherm.
            //als beheerder ignelgod is ga tertug naar Beheerderscherm
        }
    }
}
