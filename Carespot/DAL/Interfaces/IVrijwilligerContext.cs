using System.Collections.Generic;
using Carespot.Models;

namespace Carespot.DAL.Interfaces
{
    public interface IVrijwilligerContext
    {
        List<Vrijwilliger> RetrieveAll();

        void CreateVrijwilliger(Vrijwilliger v);

        Vrijwilliger RetrieveVrijwilliger(int id);

        void UpdateVrijwilliger(Vrijwilliger v);

        void DeleteVrijwilliger(int id);
    }
}