using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carespot.Models;

namespace Carespot.DAL.Interfaces
{
    public interface IHulpbehoevendeContext
    {
        void CreateHulpbehoevende(int gebruikerId, int hulpverlenerId);

        Hulpverlener RetrieveHulpverlener(int hulpverlenerId);

        void DeleteHulpbehoevende(int id);

        void UpdateHulpbehoevende(Hulpbehoevende hulpbehoevende);

        List<Hulpbehoevende> RetrieveAllHulpbehoevende();

        Hulpbehoevende RetrieveHulpbehoevendeById(int id);

        int BepaalHulpverlener();
    }
}