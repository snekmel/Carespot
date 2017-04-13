using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Carespot.Models
{
    public  class Gebruiker
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
        public string Straat { get; set; }
        public string Huisnummer { get; set; }
        public string Postcode { get; set; }
        public string Plaats { get; set; }
        public string Land { get; set; }
        public string Email { get; set; }
        public string Telefoonnummer { get; set; }
        public string Foto { get; set; }
        public GebruikerType Type { get; set; }
        public GebruikerGeslacht Geslacht { get; set; }

        public Gebruiker(string naam, string wachtwoord, string email)
        {
            Naam = naam;
            Wachtwoord = wachtwoord;
            Email = email;
        }

        public Gebruiker()
        {
        }
    }
}