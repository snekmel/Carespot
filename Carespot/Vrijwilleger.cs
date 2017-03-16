using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carespot
{
    public class Vrijwilleger : Gebruiker
    {
        //Fields / properties

        //Constructor
        public Vrijwilleger(int id, string naam, string wachtwoord, string straat, string huisnummer, string postcode, string plaats, string land, string email, string telefoonnummer, string foto) : base(id, naam, wachtwoord, straat, huisnummer, postcode, plaats, land, email, telefoonnummer, foto)
        {

        }
    }
}
