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
   

        public List<Gebruiker> RetrieveAll()
        {
            //haal al de types.RetrieveAll op en voeg deze samen tot 1 lijst.
            return null;

        }

        public int CreateGebruiker(Gebruiker g)
        {
          
            return  _interface.CreateGebruiker(g);     
         
        }


        public void UpdateGebruiker(Gebruiker g)
        {
            _interface.UpdateGebruiker(g);
        }

        public Gebruiker RetrieveGebruiker(int id)
        {
            return _interface.RetrieveGebruiker(id);
        }
    }
}