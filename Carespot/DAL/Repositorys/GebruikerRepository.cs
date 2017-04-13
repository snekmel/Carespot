using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carespot.DAL.Context;
using Carespot.DAL.Interfaces;
using Carespot.Models;

namespace Carespot.DAL.Repositorys
{
    public class GebruikerRepository
    {

        private IGebruikerContext _interface;
        public GebruikerRepository(IGebruikerContext i)
        {
            _interface = i;
        }

        public GebruikerRepository()
        {
            
        }
        //Haal alles op uit andere repos.
        public List<Gebruiker> RetrieveAll()
        {
         
            List<Gebruiker> returnList = new List<Gebruiker>();

            //Vrijwilliger
            var infVrijwilliger = new VrijwilligerSQLContext();
            var repoVrijwilliger = new VrijwilligerRepository(infVrijwilliger);


            foreach (var v in repoVrijwilliger.RetrieveAll())
            {
                returnList.Add(v);
            }


            //Hulpbehoevende
            var inf = new HulpbehoevendeSQLContext();
            var repo = new HulpbehoevendeRepository(inf);

            foreach (var hulpbehoevende in repo.HulpbehoevendeList())
            {
                returnList.Add(hulpbehoevende);
            }

            return returnList;

        }


        //Create gebruiker
        public void CreateGebruiker(Gebruiker g, bool vrijwilliger, bool beheerder, bool hulpverlener, bool hulpbehoevende)
        {
            //create gebruiker
            int id = _interface.CreateGebruiker(g);


            if (vrijwilliger)
            {
                
            }
            if (hulpverlener)
            {
                
            }
            if (hulpbehoevende)
            {
                
            }
            if (vrijwilliger)
            {
                
            }
        }
    }
}