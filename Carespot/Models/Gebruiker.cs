using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Carespot.Models
{
    public abstract class Gebruiker
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Wachtwoord { get; set; }
        public string Straat { get; protected set; }
        public string Huisnummer { get; protected set; }
        public string Postcode { get; protected set; }
        public string Plaats { get; protected set; }
        public string Land { get; protected set; }
        public string Email { get; set; }
        public string Telefoonnummer { get; protected set; }
        public string Foto { get; protected set; }
        //public Geslacht Geslacht { get; private set; }

        //Constructor
        protected Gebruiker(string naam, string wachtwoord, string email)
        {
            Naam = naam;
            Wachtwoord = wachtwoord;
            Email = email;
        }
    }
}