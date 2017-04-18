using Carespot.Models;

namespace Carespot.DAL.Interfaces
{
    public interface IGebruikerContext
    {
        int CreateGebruiker(Gebruiker g);

        void UpdateGebruiker(Gebruiker g);

        Gebruiker RetrieveGebruiker(int id);
    }
}