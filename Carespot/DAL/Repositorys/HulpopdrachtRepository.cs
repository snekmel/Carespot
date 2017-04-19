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
    public class HulpopdrachtRepository
    {
        private IHulpopdrachtContext _context;

        public HulpopdrachtRepository(HulpopdrachtSQLContext context)
        {
            _context = context;
        }

        public List<HulpOpdracht> GetAllHulpopdrachten()
        {
            return _context.GetAllHulpopdrachten();
        }
        public List<HulpOpdracht> GetAllHulpopdrachtenByHulpbehoevendeID(int hbid)
        {
            return _context.GetAllHulpopdrachtenByHulpbehoevendeID(hbid);
        }

        public HulpOpdracht GetHulpopdrachtByID(int id)
        {
            return _context.GetHulpopdrachtByID(id);
        }

        public void CreateHulpopdracht(HulpOpdracht hulpopdracht)
        {
            _context.CreateHulpopdracht(hulpopdracht);
        }

    }
}
