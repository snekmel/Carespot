using System;
using System.Collections.Generic;

namespace Carespot.Models
{
    public class HulpOpdracht
    {
        public int Id { get;  set; }
        public string Titel { get;  set; }
        public bool IsGeaccepteerd { get;  set; }
        public string Omschrijving { get;  set; }
        public DateTime AanmaakDatum { get;  set; }
        public DateTime OpdrachtDatum { get;  set; }
        public Hulpbehoevende Hulpbehoevende { get; set; }
        public Vrijwilliger Vrijwilleger { get; set; }


        public HulpOpdracht(string titel)
        {
            this.Titel = titel;
        }
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