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
using System.Windows.Threading;
using Carespot.DAL.Repositorys;
using Carespot.Models;

namespace Carespot
{
    /// <summary>
    /// Interaction logic for RFIDLogin.xaml
    /// </summary>
    public partial class RFIDLogin : Window
    {

        private DispatcherTimer _timer;
        public RFIDLogin()
        {
            InitializeComponent();
            RunTimer();
        }

        private void RunTimer()
        {
           _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Tick;
            _timer.Start();
        }

        private void Tick(object sender, EventArgs e)
        {
            Gebruiker g;
            Gebruiker gebrVrijwilliger = null;
            Gebruiker gebrHulpbehoevende = null;
            var i = 0;

             g = AuthRepository.CheckAuthRFID(tbRfid.Text);
            if (g != null)
            {
                _timer.Stop();
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
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            Inlogscherm scherm = new Inlogscherm();
            scherm.Show();
            this.Close();

        }
    }
}
