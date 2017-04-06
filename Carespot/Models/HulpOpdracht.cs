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
        public Hulpverlener Hulpverlener { get; private set; }
        public Hulpbehoevende Hulpbehoevende { get; private set; }
        public Vrijwilliger Vrijwilleger { get; private set; }

        public HulpOpdracht(int id, bool isGeaccepteerd, string titel, DateTime aanmaakDatum, string omschrijving, DateTime opdrachtDatum)
        {
            Id = id;
            IsGeaccepteerd = isGeaccepteerd;
            Titel = titel;
            AanmaakDatum = aanmaakDatum;
            Omschrijving = omschrijving;
            OpdrachtDatum = opdrachtDatum;

            //Haal hier ook de gebruikers op aan de hand van de ID's
        }

        public HulpOpdracht(string titel, string omschrijving, DateTime aanmaakDatum, DateTime opdrachtDatum)
        {
            Titel = titel;
            Omschrijving = omschrijving;
            AanmaakDatum = aanmaakDatum;
            OpdrachtDatum = opdrachtDatum;
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