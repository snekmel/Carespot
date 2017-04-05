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

        public enum GebruikerType
        {
            Beheerder,
            Hulpverlener,
            Hulpbehoevende,
            Vrijwilliger

        }

        public enum GebruikerGeslacht
        {
            Man,
            Vrouw
        }
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
        public GebruikerType Type { get; protected set; }
        public GebruikerGeslacht Geslacht { get; protected set; }

        protected Gebruiker(string naam, string wachtwoord, string email)
        {
            Naam = naam;
            Wachtwoord = wachtwoord;
            Email = email;
        }
    }
}