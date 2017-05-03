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
        List<HulpOpdracht> GetAllHulpopdrachtenByHulpbehoevendeID(int hbid);
        void AcceptReactie(int hulpopdrachtid, int vrijwilligerid);
        bool IsGeacepteerd(int hulpopdrachtid);

    }
}
