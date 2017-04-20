using System.Windows;
using Carespot.DAL.Repositorys;
using Carespot.Models;

namespace Carespot
{
    /// <summary>
    ///     Interaction logic for Inlogscherm.xaml
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
            var aanmaken = new GebruikerAanmaken();
            aanmaken.Show();
            Close();
        }

        private void btInloggen_Click(object sender, RoutedEventArgs e)
        {
            //Controleer gegevens en log in, indien er meerdere soorten gebruik binnen die persoon mogelijk zijn, opent eerst het scherm 'Keuzescherm'
            Gebruiker g;
            Gebruiker gebrVrijwilliger = null;
            Gebruiker gebrHulpbehoevende = null;
            var i = 0;

            g = AuthRepository.CheckAuth(tbEmail.Text, pbWachtwoord.Password);
            if (g != null)
            {
                var gr = new GebruikerRepository();
                var gebruikers = gr.RetrieveAll();
                foreach (var gebr in gebruikers)
                    if (gebr.Id == g.Id)
                    {
                        i++;
                        if (gebr.GetType() == typeof(Vrijwilliger))
                        {
                            MessageBox.Show("Vrijwilliger");
                            gebrVrijwilliger = gebr;
                        }
                        else if (gebr.GetType() == typeof(Hulpbehoevende))
                        {
                            MessageBox.Show("Hulpbehoevende");
                            gebrHulpbehoevende = gebr;
                        }
                    }
                if (i == 1)
                {
                }
                else if (i > 1)
                {
                    var keuzescherm = new Keuzescherm(gebrVrijwilliger, gebrHulpbehoevende);
                    keuzescherm.Show();
                }
                //MessageBox.Show(i + "  " + g);
            }
            else
            {
                MessageBox.Show("Foute inloggegevens.");
            }
        }
    }
}