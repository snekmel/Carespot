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
    /// Interaction logic for GebruikerAanmaken.xaml
    /// </summary>
    public partial class GebruikerAanmaken : Window
    {
       
        public GebruikerAanmaken()
        {
            InitializeComponent();
            //cbGeslacht krijgt Enum Geslacht {man, vrouw} 
        }


        private void btGebruikerAanmaken_Click(object sender, RoutedEventArgs e)
        {
            //gebruiker aanmaken
        }

        private void imgSluiten_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Inlogscherm inlog = new Inlogscherm();
            inlog.Show();
            this.Close();
        }

        private void btUploaden_Click(object sender, RoutedEventArgs e)
        {
            //foto uploaden
        }

    }
}
