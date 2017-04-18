using System.Collections.Generic;
using Carespot.Models;

namespace Carespot.DAL.Interfaces
{
    public interface IVrijwilligerContext
    {
        List<Vrijwilliger> RetrieveAll();

        void CreateVrijwilliger(int gebruikerId);

        Vrijwilliger RetrieveVrijwilliger(int id);

        void DeleteVrijwilliger(int id);
    }
}