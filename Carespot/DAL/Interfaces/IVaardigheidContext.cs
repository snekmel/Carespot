using System.Collections.Generic;
using Carespot.Models;

namespace Carespot.DAL.Interfaces
{
    public interface IVaardigheidContext
    {
        void Create(Vaardigheid obj);

        Vaardigheid Retrieve(int id);

        List<Vaardigheid> RetrieveAll();

        void Update(int id, Vaardigheid obj);

        void Delete(int id);
    }
}