using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carespot.DAL.Interfaces
{
    public interface IChatContext
    {
        void CreateChatBericht(DateTime tijd, string bericht);

        void RetrieveAllChatBerichtenByOpdracht(int id);

        void DeleteChatBericht(int id);
    }
}