using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<Gebruiker> RetrieveAll()
        {
            return _interface.RetrieveAll();
        }
    }
}