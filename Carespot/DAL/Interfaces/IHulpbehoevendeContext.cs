using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carespot.Models;

namespace Carespot.DAL.Interfaces
{
    public interface IHulpbehoevendeContext
    {
        void CreateHulpbehoevende(string naam, string wachtwoord, string geslacht, string straat, string huisnummer, string postcode, string plaats, string land, string email, string telefoon, string gebruikertype);

        Hulpverlener RetrieveHulpverlener(int hulpverlenerId);

        void DeleteHulpbehoevende(int id);

        void UpdateHulpbehoevende(Hulpbehoevende hulpbehoevende);

        List<Hulpbehoevende> RetrieveAllHulpbehoevende();
    }
}