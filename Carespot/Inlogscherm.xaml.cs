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
    /// Interaction logic for Inlogscherm.xaml
    /// </summary>
    public partial class Inlogscherm : Window
    {
        public Inlogscherm()
        {
            InitializeComponent();
        }

        private void btAanmelden_Click(object sender, RoutedEventArgs e)
        {
            //'GebruikerAanmaken' openen
        }

        private void btInloggen_Click(object sender, RoutedEventArgs e)
        {
            //Controleer gegevens en log in, indien er meerdere soorten gebruik binnen die persoon mogelijk zijn, opent eerst het scherm 'Keuzescherm'
        }
    }
}
