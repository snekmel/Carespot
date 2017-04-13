using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carespot.DAL.Interfaces;

namespace Carespot.DAL.Repositorys
{
   public class HulpverlenerRepository
    {

        private IHulpverlenerContext _interface;

        public HulpverlenerRepository(IHulpverlenerContext i)
        {
            _interface = i;

        }


        public void CreateHulpverlener(int gebruikerId)
        {
            _interface.CreateHulpverlener(gebruikerId);
        }
    }
}
