using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Carespot.Models;

namespace Carespot
{
    /// <summary>
    ///     Interaction logic for HulpverlenerHoofdscherm.xaml
    /// </summary>
    public partial class HulpverlenerHoofdscherm : Window
    {
        private Gebruiker _ingelogdeGebruiker;

        public HulpverlenerHoofdscherm()
        {
            InitializeComponent();
            SetProfielImg();
            //laad naam
            //laad functie
        }

        public HulpverlenerHoofdscherm(Gebruiker ingelogdeGebruiker)
        {
            InitializeComponent();
            SetProfielImg();
            _ingelogdeGebruiker = ingelogdeGebruiker;
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
            var biImg = new BitmapImage();
            var ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg;

            return imgSrc;
        }

        private void SetProfielImg()
        {
            var inf = new GebruikerSQLContext();
            var repo = new GebruikerRepository(inf);
            profielImg.Source = ByteToImage(repo.RetrieveGebruiker(1039).Foto);
        }
    }
}