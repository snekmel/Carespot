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
using Microsoft.Win32;

namespace Carespot
{
    /// <summary>
    /// Interaction logic for HulpverlenerToevoegen.xaml
    /// </summary>
    public partial class HulpverlenerToevoegen : Window
    {
        public HulpverlenerToevoegen()
        {
            InitializeComponent();
            //cbGeslacht krijgt enum Geslacht {man, vrouw} 
        }

        private void imgSluiten_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            HulpverlenerHoofdscherm hhs = new HulpverlenerHoofdscherm();
            hhs.Show();
            this.Close();
        }

        private void btUploaden_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select a picture";
            ofd.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (ofd.ShowDialog() == true)
            {
                ImageSource imageSource = new BitmapImage(new Uri(ofd.FileName));
                imgProfielfoto.Source = imageSource;
            }
        }

        private void btOpslaan_Click(object sender, RoutedEventArgs e)
        {
            //gebruiker wordt toegevoegd met ingevulde gegevens
        }
    }
}
