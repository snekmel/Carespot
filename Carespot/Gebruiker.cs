using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Carespot
{
    public abstract class Gebruiker
    {
        //Fields / properties
        public int Id { get; private set; }
        public string Naam { get; private set; }
        public string Wachtwoord { get; private set; }
        public string Straat { get; private set; }
        public string Huisnummer { get; private set; }
        public string Postcode { get; private set; }
        public string Land { get; private set; }
        public string Email { get; private set; }
        public string Telefoonnummer { get; private set; }
        public string Foto { get; private set; }
        //public Geslacht Geslacht { get; private set; }


        //Constructor
        Gebruiker(int id, string naam, string wachtwoord, string straat, string huisnummer, string postcode, string plaats, string land, string email, string telefoonnummer, string foto)
        {
            
        }
    }
}
