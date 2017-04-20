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
    /// Interaction logic for ReactieOpHulpvraag.xaml
    /// </summary>
    public partial class ReactieOpHulpvraag : Window
    {
        public ReactieOpHulpvraag()
        {
            InitializeComponent();
        }

        private void btInsturen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tbReactie_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (tbReactie.Text == "Schrijf een bericht...")
            {
                tbReactie.Text = "";
            }
        }
    }
}
