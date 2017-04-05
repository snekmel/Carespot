using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carespot.Models;

namespace Carespot.DAL.Interfaces
{
    interface IHulpopdrachtContext
    {
        List<HulpOpdracht> GetAllHulpopdrachten();
        HulpOpdracht GetHulpopdrachtByID(int id);
        void CreateHulpopdracht(HulpOpdracht hulpodracht);
    }
}
