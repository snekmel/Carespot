using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carespot.DAL.Interfaces;
using Carespot.Models;

namespace Carespot.DAL.Repositorys
{
    public class VrijwilligerRepository
    {

        private readonly IVrijwilligerContext _interface;

        public VrijwilligerRepository(IVrijwilligerContext i)
        {
            _interface = i;
        }

        public List<Vrijwilliger> RetrieveAll()
        {
            return _interface.RetrieveAll();
        }

        public Vrijwilliger RetrieveById(int id)
        {
            return _interface.RetrieveVrijwilliger(id);
        }

        public void CreateVrijwilliger(int gebruikerId)
        {
            _interface.CreateVrijwilliger(gebruikerId);
        }

        public void DeleteVrijwilliger(int id)
        {
            _interface.DeleteVrijwilliger(id);
        }

   
    }
}
