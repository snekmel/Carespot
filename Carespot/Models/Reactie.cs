using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carespot.Models
{
    public class Reactie
    {
        public int Id { get; set; }
        public Vrijwilliger Vrijwilliger { get; private set; }
        public string Bericht { get; private set; }

        public Reactie(Vrijwilliger vrijwilliger, string bericht)
        {
            Vrijwilliger = vrijwilliger;
            Bericht = bericht; 
        }
    }
}