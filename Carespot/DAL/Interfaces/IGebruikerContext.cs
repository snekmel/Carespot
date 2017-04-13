using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carespot.Models;

namespace Carespot.DAL.Interfaces
{
    public interface IGebruikerContext
    {
        void Create(Gebruiker obj);

        Gebruiker Retrieve(int id);

        List<Gebruiker> RetrieveAll();

        void Update(int id, Gebruiker obj);

        void Delete(int id);
    }
}