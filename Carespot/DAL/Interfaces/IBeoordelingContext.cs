using System.Collections.Generic;
using Carespot.Models;

namespace Carespot.DAL.Interfaces
{
    public interface IBeoordelingContext
    {
        List<Beoordeling> RetrieveBeoordeling(int vrijwilligersId);

        void Create(Beoordeling obj);

        void Delete(int id);
    }
}