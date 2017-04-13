using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carespot.Models
{
    public class Hulpverlener : Gebruiker
    {
        public List<Hulpbehoevende> Hulpbehoevenden { get; private set; }

      
    }
}