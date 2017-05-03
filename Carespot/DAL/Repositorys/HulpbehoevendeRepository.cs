using System.Collections.Generic;
using Carespot.DAL.Interfaces;
using Carespot.Models;

namespace Carespot.DAL.Repositorys
{
    public class HulpbehoevendeRepository
    {
        private readonly IHulpbehoevendeContext _hulpbehoevendeContext;

        public List<Hulpbehoevende> RetrieveAllHulpbehoevendeByHulpverlenerId(int id)
        {
            List<Hulpbehoevende> returnList = new List<Hulpbehoevende>();

            foreach (Hulpbehoevende hb in this.RetrieveAll())
            {
                if (hb.Hulpverlener.Id == id)
                {
                    returnList.Add(hb);
                }
            }

            return returnList;
        }


        public HulpbehoevendeRepository(IHulpbehoevendeContext hulpbehoevendeContext)
        {
            _hulpbehoevendeContext = hulpbehoevendeContext;
        }

        public Hulpverlener RetrieveHulpverlener(int id)
        {
            return _hulpbehoevendeContext.RetrieveHulpverlener(id);
        }

        public List<Hulpbehoevende> RetrieveAll()
        {
            return _hulpbehoevendeContext.RetrieveAll();
        }

        public void DeleteHulpbehoevende(int id)
        {
            _hulpbehoevendeContext.DeleteHulpbehoevende(id);
        }

        public void UpdateHulpbehoevende(Hulpbehoevende hulpbehoevende)
        {
            _hulpbehoevendeContext.UpdateHulpbehoevende(hulpbehoevende);
        }

        public void CreateHulpbehoevende(int gebruikerId, int hulpverlenerId)
        {
            _hulpbehoevendeContext.CreateHulpbehoevende(gebruikerId, hulpverlenerId);
        }

        public Hulpbehoevende RetrieveHulpbehoevendeById(int id)
        {
            return _hulpbehoevendeContext.RetrieveHulpbehoevendeById(id);
        }

        public int HulpverlenerId()
        {
            return _hulpbehoevendeContext.BepaalHulpverlener();
        }
    }
}