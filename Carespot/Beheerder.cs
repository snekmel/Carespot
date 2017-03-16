using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carespot
{
    public class Beheerder : Gebruiker
    {
        //Fields / properties

        //Constructor
        public Beheerder(int id, string naam, string wachtwoord, string straat, string huisnummer, string postcode, string plaats, string land, string email, string telefoonnummer, string foto) : base(id, naam, wachtwoord,straat,huisnummer,postcode,plaats,land,email,telefoonnummer,foto)
        {
            base.Id = id;
            base.Naam = naam;
            base.Wachtwoord = wachtwoord;
            base.Straat = straat;
            base.Huisnummer = huisnummer;
            base.Postcode = postcode;
            base.Plaats = plaats;
            base.Land = land;
            base.Email = email;
            base.Telefoonnummer = telefoonnummer;
            base.Foto = foto;
        }
    }
}
