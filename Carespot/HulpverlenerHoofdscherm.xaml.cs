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
        private readonly SqlConnection _con =
            new SqlConnection(
                "Data Source=WIN-SRV-WEB.fhict.local;Initial Catalog=Carespot;User ID=carespot;Password=Test1234;Encrypt=False;TrustServerCertificate=True");

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

        private Gebruiker g()
        {
            try
            {
                _con.Open();
                var cmdString = "SELECT * FROM Gebruiker g WHERE id='1036'";
                var command = new SqlCommand(cmdString, _con);
                var reader = command.ExecuteReader();

                Gebruiker g = new Gebruiker();

                while (reader.Read())
                {
                    g.Id = reader.GetInt32(0);
                    g.Naam = reader.GetString(1);
                    g.Wachtwoord = reader.GetString(2);
                    g.Geslacht = (Gebruiker.GebruikerGeslacht)Enum.Parse(typeof(Gebruiker.GebruikerGeslacht), reader.GetString(3));
                    g.Straat = reader.GetString(4);
                    g.Huisnummer = reader.GetString(5);
                    g.Postcode = reader.GetString(6);
                    g.Plaats = reader.GetString(7);
                    g.Land = reader.GetString(8);
                    g.Email = reader.GetString(9);
                    g.Telefoonnummer = reader.GetString(10);

                    g.Foto = (byte[])reader[11];

                }
                _con.Close();
                return g;
            }
            catch
            {
                // System.Windows.MessageBox.Show("Woops");
            }
            return null;
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
            profielImg.Source = ByteToImage(g().Foto);
        }
    }
}