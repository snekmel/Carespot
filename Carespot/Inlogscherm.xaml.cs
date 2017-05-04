using System.Windows;
using System.Windows.Controls;
using Carespot.DAL.Repositorys;
using Carespot.Models;
using System.Windows.Input;

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
            try
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
                                gebrVrijwilliger = gebr;
                            }
                            else if (gebr.GetType() == typeof(Hulpbehoevende))
                            {
                                gebrHulpbehoevende = gebr;
                            }
                            else if (gebr.GetType() == typeof(Hulpverlener))
                            {
                                var hulpverlenerhoofdscherm = new HulpverlenerHoofdscherm(gebr);
                                hulpverlenerhoofdscherm.Show();
                                Close();
                            }
                            else if (gebr.GetType() == typeof(Beheerder))
                            {
                                var beheerderscherm = new GebruikerBeheer(gebr);
                                beheerderscherm.Show();
                                Close();
                            }
                        }
                    if (i == 1)
                    {
                        if (gebrHulpbehoevende == null && gebrVrijwilliger != null)
                        {
                            var vrijwilligerscherm = new VrijwilligerHoofdscherm(gebrVrijwilliger);
                            vrijwilligerscherm.Show();
                            Close();
                        }
                        else if (gebrHulpbehoevende != null && gebrVrijwilliger == null)
                        {
                            var hulpbehoevendescherm = new CliëntOverzicht(gebrHulpbehoevende);
                            hulpbehoevendescherm.Show();
                            Close();
                        }
                    }
                    else if (i > 1)
                    {
                        var keuzescherm = new Keuzescherm(gebrVrijwilliger, gebrHulpbehoevende);
                        keuzescherm.Show();
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Foute inloggegevens.");
                }
            }
            catch (DatabaseException)
            {
                MessageBox.Show("Er is geen connectie met de database");
            }
        }

        private void BtRfid_OnClick(object sender, RoutedEventArgs e)
        {
            RFIDLogin scherm = new RFIDLogin();
            scherm.Show();
            this.Close();
        }

        private void pbWachtwoord_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btInloggen.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                e.Handled = true;
            }
        }
    }
}