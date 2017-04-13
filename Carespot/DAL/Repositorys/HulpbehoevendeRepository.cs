using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carespot.DAL.Interfaces;
using Carespot.Models;

namespace Carespot.DAL.Repositorys
{
    public class HulpbehoevendeRepository
    {
        private IHulpbehoevendeContext _hulpbehoevendeContext;

        public HulpbehoevendeRepository(IHulpbehoevendeContext hulpbehoevendeContext)
        {
            this._hulpbehoevendeContext = hulpbehoevendeContext;
        }

        public Hulpverlener RetrieveHulpverlener(int id)
        {
            return _hulpbehoevendeContext.RetrieveHulpverlener(id);
        }

        public List<Hulpbehoevende> HulpbehoevendeList()
        {
            return _hulpbehoevendeContext.RetrieveAllHulpbehoevende();
        }

        public void DeleteHulpbehoevende(int id)
        {
            _hulpbehoevendeContext.DeleteHulpbehoevende(id);
        }

        public void UpdateHulpbehoevende(Hulpbehoevende hulpbehoevende)
        {
            _hulpbehoevendeContext.UpdateHulpbehoevende(hulpbehoevende);
        }

        public void CreateHulpbehoevende(string naam, string wachtwoord, Gebruiker.GebruikerGeslacht geslacht, string straat,
            string huisnummer, string postcode, string plaats, string land, string email, string telefoon,
            Gebruiker.GebruikerType gebruikertype, string foto, int hulpverlenerId)
        {
            _hulpbehoevendeContext.CreateHulpbehoevende(naam, wachtwoord, geslacht.ToString(), straat, huisnummer, postcode, plaats, land, email, telefoon, gebruikertype.ToString(), foto, hulpverlenerId);
        }

        public Hulpbehoevende RetrieveHulpbehoevendeById(int id)
        {
            return _hulpbehoevendeContext.RetrieveHulpbehoevendeById(id);
        }
    }
}