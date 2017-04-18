using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
using Carespot.Models;

namespace Carespot
{
    /// <summary>
    /// Interaction logic for HulpverlenerHoofdscherm.xaml
    /// </summary>
    ///
    public partial class HulpverlenerHoofdscherm : Window
    {
        public HulpverlenerHoofdscherm()
        {
            InitializeComponent();
            SetProfielImg();
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

        public static ImageSource ByteToImage(byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }

        private void SetProfielImg()
        {
            //  profielImg.Source = ByteToImage(g().Foto);
        }
    }
}