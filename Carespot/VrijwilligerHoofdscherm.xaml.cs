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
    /// Interaction logic for VrijwilligerHoofdscherm.xaml
    /// </summary>
    public partial class VrijwilligerHoofdscherm : Window
    {
        public VrijwilligerHoofdscherm()
        {
            InitializeComponent();
            //laad naam gebruiker
            //laad functie gebruiker
            //lijst actieve opdrachten ophalen en in listbox zetten
        }



        private void imgLogout_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //gebruiker uitloggen en terug naar Inlogscherm
        }

        private void btOpgeven_Click(object sender, RoutedEventArgs e)
        {
            //open scherm: VrijwilligerOpdrachtAannemen
        }
    }
}
