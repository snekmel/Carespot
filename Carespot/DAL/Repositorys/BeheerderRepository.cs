using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carespot.DAL.Interfaces;

namespace Carespot.DAL.Repositorys
{
   public class BeheerderRepository
   {
       private IBeheerderContext _interface;
        public BeheerderRepository(IBeheerderContext i)
        {
            _interface = i;
        }



       public void CreateBeheerder(int gebruikerId)
       {
           
            _interface.CreateBeheerder(gebruikerId);
       }
    }
}
