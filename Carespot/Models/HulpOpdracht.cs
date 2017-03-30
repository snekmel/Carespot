using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carespot.Models
{
    public class HulpOpdracht
    {
        public int Id { get; set; }
        public string Titel { get; private set; }
        public string Omschrijving { get; private set; }
        public DateTime AanmaakDatum { get; private set; }
        public DateTime OpdrachtDatum { get; private set; }
        public Hulpverlener Hulpverlener { get; private set; }
        public Hulpbehoevende Hulpbehoevende { get; private set; }
        public Vrijwilliger Vrijwilleger { get; private set; }

        public HulpOpdracht(int id, string titel)
        {
            Id = id;
            Titel = titel;
        }
    }
}