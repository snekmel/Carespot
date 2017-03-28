using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carespot.Models
{
    public class Hulpverlener : Gebruiker
    {
        //Fields / properties

        //Constructor
        public Hulpverlener(string naam, string wachtwoord, string email) : base(naam, wachtwoord, email)
        {
        }
    }
}