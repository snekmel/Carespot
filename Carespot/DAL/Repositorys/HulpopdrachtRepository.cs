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

        public void AcceptReactie(int hulpopdrachtid, int vrijwilligerid)
        {
            _context.AcceptReactie(hulpopdrachtid,vrijwilligerid);
        }

        public bool IsGeacepteerd(int hulpopdrachtid)
        {
           return _context.IsGeacepteerd(hulpopdrachtid);
        }

        public List<HulpOpdracht> RetrieveHulpopdrachtenByHulpbehoevendeId(int id)
        {
            List<HulpOpdracht> returnList = new List<HulpOpdracht>();

            foreach (HulpOpdracht ho in this.GetAllHulpopdrachten())
            {
                if (ho.Hulpbehoevende.Id == id)
                {
                    returnList.Add(ho);
                }
            }
            return returnList;
        }

        public void VerwijderVrijwilligerVanHulpopdracht(int hulpopdrachtid)
        {
            _context.VerwijderVrijwilligerVanHulpopdracht(hulpopdrachtid);
        }


        public List<HulpOpdracht> RetrieveHulpopdrachtByVrijwilligerId(int id)
        {
            List<HulpOpdracht> returnList = new List<HulpOpdracht>();

            foreach (HulpOpdracht ho in this.GetAllHulpopdrachten())
            {
                if (ho.Vrijwilleger != null)
                {
                    if (ho.Vrijwilleger.Id == id)
                    {
                        returnList.Add(ho);
                    }
                }
              
            }
            return returnList;
        }

    }
}
