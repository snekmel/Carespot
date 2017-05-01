using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carespot.Models;

namespace Carespot.DAL.Interfaces
{
    public interface IReactieContext
    {
        List<Reactie> GetAllReactiesByHulopdrachtID(int hulpopdrachtid);
        void CreateReactie(int vrijwillegerid, int hulpaanvraagid, string bericht);
        void DeleteReactie(int reactieid);
    }
}