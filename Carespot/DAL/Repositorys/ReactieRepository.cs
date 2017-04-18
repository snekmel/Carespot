using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carespot.DAL.Interfaces;
using Carespot.Models;

namespace Carespot.DAL.Repositorys
{
    public class ReactieRepository
    {
        private IReactieContext _context;

        public List<Reactie> GetAllReactiesByHulopdrachtID(int hulpopdrachtid)
        {
            return _context.GetAllReactiesByHulopdrachtID(hulpopdrachtid);
        }
    }
}