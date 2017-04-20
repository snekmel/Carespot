using System.Collections.Generic;
using Carespot.DAL.Interfaces;
using Carespot.Models;

namespace Carespot.DAL.Repositorys
{
    public class HulpverlenerRepository
    {
        private readonly IHulpverlenerContext _interface;

        public HulpverlenerRepository(IHulpverlenerContext i)
        {
            _interface = i;
        }

        public void CreateHulpverlener(int gebruikerId)
        {
            _interface.CreateHulpverlener(gebruikerId);
        }

        public List<Hulpverlener> RetrieveAll()
        {
            return _interface.RetrieveAll();
        }

        public Hulpverlener RetrieveHulpverlener(int id)
        {
            return _interface.RetrieveHulpverlener(id);
        }

        public void DeleteHulpverlener(int id)
        {
            _interface.DeleteHulpverlener(id);
        }
    }
}