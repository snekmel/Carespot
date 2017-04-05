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
    }
}