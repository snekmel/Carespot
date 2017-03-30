using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carespot.Models
{
    public class Vrijwilliger : Gebruiker
    {
        //Fields / properties

        //Constructor
        public Vrijwilliger(string naam, string wachtwoord, string email) : base(naam, wachtwoord, email)
        {
        }
    }
}