using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carespot.DAL.Interfaces;
using Carespot.Models;

namespace Carespot.DAL.Repositorys
{
    public class HulpbehoevendeRepository
    {
        private IHulpbehoevendeContext _hulpbehoevendeContext;

        public HulpbehoevendeRepository(IHulpbehoevendeContext hulpbehoevendeContext)
        {
            this._hulpbehoevendeContext = hulpbehoevendeContext;
        }

        public Hulpverlener Hulpverlener(int id)
        {
            return _hulpbehoevendeContext.RetrieveHulpverlener(id);
        }

        public List<Hulpbehoevende> HulpbehoevendeList()
        {
            return _hulpbehoevendeContext.RetrieveAllHulpbehoevende();
        }

        public void DeleteHulpbehoevende(int id)
        {
            _hulpbehoevendeContext.DeleteHulpbehoevende(id);
        }

        public void UpdateHulpbehoevende(Hulpbehoevende hulpbehoevende)
        {
            _hulpbehoevendeContext.UpdateHulpbehoevende(hulpbehoevende);
        }
    }
}