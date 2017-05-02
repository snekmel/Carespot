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
using Phidgets.Events;
using Phidgets;

namespace Carespot
{
    /// <summary>
    /// Interaction logic for RFIDLogin.xaml
    /// </summary>
    public partial class RFIDLogin : Window
    {
        private DispatcherTimer _timer;
        private Manager _manager = new Manager();
        private static string _tag;

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
            lblRfid.Content = "Scan uw tag.";
            Scan();
            if (_tag != null)
            {
                //MessageBox.Show(_tag);
                g = AuthRepository.CheckAuthRFID(_tag);

                if (g != null)
                {
                    lblRfid.Content = "U wordt ingelogd.";
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
                else
                {
                    lblRfid.Content = "Geen gebruiker gevonden met deze tag.";
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Inlogscherm scherm = new Inlogscherm();
            scherm.Show();
            this.Close();
        }

        private void Scan()
        {
            try
            {
                RFID rfid = new RFID(); //Declare an RFID object

                //initialize our Phidgets RFID reader and hook the event handlers
                rfid.Attach += new AttachEventHandler(rfid_Attach);
                rfid.Detach += new DetachEventHandler(rfid_Detach);
                rfid.Error += new ErrorEventHandler(rfid_Error);

                rfid.Tag += new TagEventHandler(rfid_Tag);
                rfid.TagLost += new TagEventHandler(rfid_TagLost);
                rfid.open();

                //Wait for a Phidget RFID to be attached before doing anything with
                //the object
                Console.WriteLine("waiting for attachment...");
                rfid.waitForAttachment();

                //turn on the antenna and the led to show everything is working
                rfid.Antenna = true;
                rfid.LED = true;

                //keep waiting and outputting events until keyboard input is entered
                Console.WriteLine("Press any key to end...");
                Console.Read();

                //turn off the led
                rfid.LED = false;

                //close the phidget and dispose of the object
                rfid.close();
                rfid = null;
                Console.WriteLine("ok");
            }
            catch (PhidgetException ex)
            {
                Console.WriteLine(ex.Description);
            }
        }

        private static void rfid_Attach(object sender, AttachEventArgs e)
        {
            Console.WriteLine("RFIDReader {0} attached!",
                                    e.Device.SerialNumber.ToString());
        }

        //detach event handler...display the serial number of the detached RFID phidget
        private static void rfid_Detach(object sender, DetachEventArgs e)
        {
            Console.WriteLine("RFID reader {0} detached!",
                                    e.Device.SerialNumber.ToString());
        }

        //Error event handler...display the error description string
        private static void rfid_Error(object sender, ErrorEventArgs e)
        {
            Console.WriteLine(e.Description);
        }

        //Print the tag code of the scanned tag

        private static void rfid_Tag(object sender, TagEventArgs e)
        {
            // Console.WriteLine("Tag {0} scanned", e.Tag);
            // MessageBox.Show(e.Tag);
            _tag = e.Tag;
        }

        private static void rfid_TagLost(object sender, TagEventArgs e)
        {
            Console.WriteLine("Tag {0} lost", e.Tag);
        }
    }
}