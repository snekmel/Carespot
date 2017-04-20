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
            lblNaam.Content = _hulpOpdracht.Hulpbehoevende.Naam;

            lblOpdrachtTitel.Content = _hulpOpdracht.Titel;
            tbOmschrijving.Text = _hulpOpdracht.Omschrijving;


            //client
            lblNaamCliënt.Content = _hulpOpdracht.Hulpbehoevende.Naam;
            lblTelefoonCliënt.Content = _hulpOpdracht.Hulpbehoevende.Telefoonnummer;
            lblEmailCliënt.Content = _hulpOpdracht.Hulpbehoevende.Email;


            //Vrijwilliger
            lblNaamVrijwilliger.Content = _hulpOpdracht.Vrijwilleger.Naam;
            lblTelefoonVrijwilliger.Content = _hulpOpdracht.Vrijwilleger.Telefoonnummer;
            lblEmailVrijwilliger.Content = _hulpOpdracht.Vrijwilleger.Email;


            //Profesionele begeleider
            lblNaamHulpverlener.Content = _hulpOpdracht.Hulpbehoevende.Hulpverlener.Naam;
            lblTelefoonHulpverlener.Content = _hulpOpdracht.Hulpbehoevende.Hulpverlener.Telefoonnummer;
           lblEmailHulpverlener.Content = _hulpOpdracht.Hulpbehoevende.Hulpverlener.Email;

        }


        private void imgSluitAf_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //'VrijwilligerHoofdscherm openen'
        }

        private void tabOmschrijving_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //laad omschrijvingstab
        }

        private void tabChat_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //laad chatberichten
        }

        private void tabContact_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //laad contacteninfo
        }

        private void RunTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Tick;
            timer.Start();
        }

        void Tick(object sender, EventArgs e)
        {
            //clear list view
            chatListbox.Items.Clear();





            //haal berichten op
            ChatSQLContext csc = new ChatSQLContext();
            ChatRepository cr = new ChatRepository(csc);
            List<ChatBericht> chatBerichten = cr.RetrieveAllChatBerichtenByOpdracht(_hulpOpdracht.Id);
            chatBerichten.Sort();

           GebruikerSQLContext gsc = new GebruikerSQLContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);
            
            foreach (ChatBericht chat in chatBerichten)
            {
                Gebruiker g = gr.RetrieveGebruiker(chat.GebruikerId);

                chatListbox.Items.Add("[" + chat.Tijd +" | " + g.Naam + "] : " + chat.Bericht);
            }


        }

        private void btnSendChat_Click(object sender, RoutedEventArgs e)
        {
            ChatSQLContext csc = new ChatSQLContext();
            ChatRepository cr = new ChatRepository(csc);
            cr.CreateChatBericht(DateTime.Now, tbChatBericht.Text, _loggedInUser.Id, _hulpOpdracht.Id);
            tbChatBericht.Text = "";
        }
    }
}
