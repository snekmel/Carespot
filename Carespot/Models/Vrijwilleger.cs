using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carespot.Models
{
    public class Vrijwilleger : Gebruiker
    {
        //Fields / properties

        //Constructor
        public Vrijwilleger(string naam, string wachtwoord, string email) : base(naam, wachtwoord, email)
        {
        }
    }
}