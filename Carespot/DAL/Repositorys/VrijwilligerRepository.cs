using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carespot.DAL.Interfaces;
using Carespot.Models;

namespace Carespot.DAL.Repositorys
{
    class VrijwilligerRepository
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

        public void CreateVrijwilliger(Vrijwilliger v)
        {
            _interface.CreateVrijwilliger(v);
        }

        public void DeleteVrijwilliger(int id)
        {
            _interface.DeleteVrijwilliger(id);
        }

        public void UpdateVrijwilliger(Vrijwilliger v)
        {
            _interface.UpdateVrijwilliger(v);
        }
    }
}
