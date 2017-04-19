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
    public class ReactieRepository
    {
        private IReactieContext _context;

        public ReactieRepository(ReactieSQLContext context)
        {
            _context = context;
        }

        public List<Reactie> GetAllReactiesByHulopdrachtID(int hulpopdrachtid)
        {
            return _context.GetAllReactiesByHulopdrachtID(hulpopdrachtid);
        }

        public void CreateReactie(int vrijwilligerid, int hulpopdrachtid,string bericht)
        {
            _context.CreateReactie(vrijwilligerid, hulpopdrachtid, bericht);
        }
    }
}