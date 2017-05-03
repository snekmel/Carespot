﻿using System;
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
using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Carespot.Models;

namespace Carespot
{
    /// <summary>
    /// Interaction logic for Opdracht.xaml
    /// </summary>
    public partial class Opdracht : Window
    {
        private Gebruiker _loggedInUser;
        private HulpOpdracht _hulpOpdracht;

        public Opdracht()
        {
            InitializeComponent();
        }

        public Opdracht(Gebruiker g, HulpOpdracht h)
        {
            InitializeComponent();
            _loggedInUser = g;
            _hulpOpdracht = h;
            RunTimer();
            ViewLoader();
        }

        private void ViewLoader()
        {
            lblNaam.Content = _loggedInUser.Naam;

            lblOpdrachtTitel.Content = _hulpOpdracht.Titel;
            tbOmschrijving.Text = _hulpOpdracht.Omschrijving;

            //client
            lblNaamCliënt.Content = _hulpOpdracht.Hulpbehoevende.Naam;
            lblTelefoonCliënt.Content = _hulpOpdracht.Hulpbehoevende.Telefoonnummer;
            lblEmailCliënt.Content = _hulpOpdracht.Hulpbehoevende.Email;
            imgGebruiker_Hulpbehoevende.Source = FunctionRepository.ByteToImage(_loggedInUser.Foto);

            //Vrijwilliger
            if (_hulpOpdracht.Vrijwilleger != null)
            {
                lblNaamVrijwilliger.Content = _hulpOpdracht.Vrijwilleger.Naam;
                lblTelefoonVrijwilliger.Content = _hulpOpdracht.Vrijwilleger.Telefoonnummer;
                lblEmailVrijwilliger.Content = _hulpOpdracht.Vrijwilleger.Email;
                imgGebruiker_Vrijwilliger.Source = FunctionRepository.ByteToImage(_hulpOpdracht.Vrijwilleger.Foto);
            }

            //Profesionele begeleider
            lblNaamHulpverlener.Content = _hulpOpdracht.Hulpbehoevende.Hulpverlener.Naam;
            lblTelefoonHulpverlener.Content = _hulpOpdracht.Hulpbehoevende.Hulpverlener.Telefoonnummer;
            lblEmailHulpverlener.Content = _hulpOpdracht.Hulpbehoevende.Hulpverlener.Email;
            imgGebruiker_Hulpverlener.Source =
                FunctionRepository.ByteToImage(_hulpOpdracht.Hulpbehoevende.Hulpverlener.Foto);
        }

        private void imgSluitAf_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void RunTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Tick;
            timer.Start();
        }

        private void Tick(object sender, EventArgs e)
        {
            //clear list view
            chatListbox.Items.Clear();

            if (CheckAuth())
            {
                ChatSQLContext csc = new ChatSQLContext();
                ChatRepository cr = new ChatRepository(csc);
                try
                {
                    List<ChatBericht> chatBerichten = cr.RetrieveAllChatBerichtenByOpdracht(_hulpOpdracht.Id);

                    chatBerichten.Sort();
                    GebruikerSQLContext gsc = new GebruikerSQLContext();
                    GebruikerRepository gr = new GebruikerRepository(gsc);

                    foreach (ChatBericht chat in chatBerichten)
                    {
                        Gebruiker g = gr.RetrieveGebruiker(chat.GebruikerId);

                        chatListbox.Items.Add("[" + chat.Tijd + " | " + g.Naam + "] : " + chat.Bericht);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Er is iets mis gegaan. Foutomschrijving: " + ex.Message);
                }
            }
            else
            {
                chatListbox.Items.Add("U heeft geen rechten voor deze chat");
                btnSendChat.IsEnabled = false;
            }
        }

        private void btnSendChat_Click(object sender, RoutedEventArgs e)
        {
            ChatSQLContext csc = new ChatSQLContext();
            ChatRepository cr = new ChatRepository(csc);

            try
            {
                cr.CreateChatBericht(DateTime.Now, tbChatBericht.Text, _loggedInUser.Id, _hulpOpdracht.Id);
                tbChatBericht.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is iets mis gegaan. Foutomschrijving: " + ex.Message);
            }
        }

        private void imgBeoordeling_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_hulpOpdracht.Vrijwilleger != null)
            {
                BeoordelingScherm beoordelingScherm = new BeoordelingScherm(_loggedInUser, _hulpOpdracht.Vrijwilleger);
                beoordelingScherm.Show();
            }
        }

        private bool CheckAuth()
        {
            if (_loggedInUser.GetType() == typeof(Beheerder))
            {
                return true;
            }

            if (_hulpOpdracht.Vrijwilleger != null)
            {
                if (_loggedInUser.Id == _hulpOpdracht.Vrijwilleger.Id)
                {
                    return true;
                }
            }

            if (_loggedInUser.Id == _hulpOpdracht.Hulpbehoevende.Id)
            {
                return true;
            }

            if (_loggedInUser.Id == _hulpOpdracht.Hulpbehoevende.Hulpverlener.Id)
            {
                return true;
            }

            return false;
        }

        private void tbChatBericht_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSendChat.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                e.Handled = true;
            }
        }

        private bool CheckAuthDelete()
        {
            if (_loggedInUser.GetType() == typeof(Beheerder))
            {
                return true;
            }

            if (_loggedInUser.Id == _hulpOpdracht.Hulpbehoevende.Hulpverlener.Id)
            {
                return true;
            }

            return false;
        }

        private void imgTrash_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (CheckAuthDelete())
            {
                var context = new HulpopdrachtSQLContext();
                var repo = new HulpopdrachtRepository(context);
                try
                {
                    repo.VerwijderVrijwilligerVanHulpopdracht(_hulpOpdracht.Id);

                    MessageBox.Show("Vrijwilliger is van de opdracht verwijderd.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Er is iets mis gegaan. Foutomschrijving: " + ex.Message);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("U kunt de vrijwilliger niet verwijderen.");
            }
        }
    }
}