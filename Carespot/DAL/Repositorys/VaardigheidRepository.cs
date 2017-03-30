using System.Collections.Generic;
using Carespot.DAL.Interfaces;
using Carespot.Models;

namespace Carespot.DAL.Repositorys
{
    public class VaardigheidRepository
    {
        private readonly IVaardigheidContext _interface;

        public VaardigheidRepository(IVaardigheidContext i)
        {
            _interface = i;
        }

        public List<Vaardigheid> RetrieveAll()
        {
            return _interface.RetrieveAll();
        }

        public void CreateVaardigheid(Vaardigheid v)
        {
            _interface.Create(v);
        }

        public void DeleteVaardigheid(int id)
        {
            _interface.Delete(id);
        }
    }
}