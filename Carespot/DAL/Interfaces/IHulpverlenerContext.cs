using System.Collections.Generic;
using Carespot.Models;

namespace Carespot.DAL.Interfaces
{
    public interface IHulpverlenerContext
    {

        List<Hulpverlener> RetrieveAll();
        void CreateHulpverlener(int gebruikerId);

        Hulpverlener RetrieveHulpverlener(int id);

        void DeleteHulpverlener(int id);

    }
}