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
    /// Interaction logic for ProfielVrijwilliger.xaml
    /// </summary>
    public partial class ProfielVrijwilliger : Window
    {
        public ProfielVrijwilliger()
        {
            InitializeComponent();
            //laad lijst van recensies 
            //laad naam
            //laad functie
            //laadt profielfoto
        }

        private void imgSluitAf_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //terug naar vorige scherm
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
