using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carespot.Models
{
    public class ChatBericht : IComparable<ChatBericht>
    {
        public int Id { get; set; }
        public DateTime Tijd { get; private set; }
        public string Bericht { get; private set; }
        public int HulpopdrachtId { get; private set; }

        public int GebruikerId { get; private set; }

        public ChatBericht(DateTime tijd, string bericht, int gebruikerId, int hulpopdrachtId)
        {
            this.GebruikerId = gebruikerId;
            this.Tijd = tijd;
            this.Bericht = bericht;
            this.HulpopdrachtId = hulpopdrachtId;
        }

        public int CompareTo(ChatBericht other)
        {
           return this.Tijd.CompareTo(other.Tijd);
        }
    }
}