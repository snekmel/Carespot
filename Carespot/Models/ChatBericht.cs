using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carespot.Models
{
    public class ChatBericht
    {
        public int Id { get; private set; }
        public DateTime Tijd { get; private set; }
        public string Bericht { get; private set; }

        public ChatBericht(int gebruikerId, DateTime tijd, string bericht)
        {
            this.Id = gebruikerId;
            this.Tijd = tijd;
            this.Bericht = bericht;
        }
    }
}