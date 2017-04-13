using System;

namespace Carespot.Models
{
    public class HulpOpdracht
    {
        public int Id { get; private set; }
        public string Titel { get; private set; }
        public bool IsGeaccepteerd { get; private set; }
        public string Omschrijving { get; private set; }
        public DateTime AanmaakDatum { get; private set; }
        public DateTime OpdrachtDatum { get; private set; }
        public Hulpbehoevende Hulpbehoevende { get; set; }
        public Vrijwilliger Vrijwilleger { get; set; }

        public HulpOpdracht(int id, bool isGeaccepteerd, string titel, DateTime aanmaakDatum, string omschrijving, DateTime opdrachtDatum)
        {
            Id = id;
            IsGeaccepteerd = isGeaccepteerd;
            Titel = titel;
            AanmaakDatum = aanmaakDatum;
            Omschrijving = omschrijving;
            OpdrachtDatum = opdrachtDatum;
        }

        public HulpOpdracht(bool isGeaccepteerd, string titel, DateTime aanmaakDatum, string omschrijving, DateTime opdrachtDatum, Hulpbehoevende hulpbehoevende)
        {
            IsGeaccepteerd = isGeaccepteerd;
            Titel = titel;
            AanmaakDatum = aanmaakDatum;
            Omschrijving = omschrijving;
            OpdrachtDatum = opdrachtDatum;
            Hulpbehoevende = hulpbehoevende;
        }

        public static bool ConvertIntToBool(int i)
        {
            if (i == 1)
            {
                return true;
            }

            return false;
        }
    }
}