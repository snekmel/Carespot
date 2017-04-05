using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carespot.Models;

namespace Carespot.DAL.Interfaces
{
    public interface IChatContext
    {
        void CreateChatBericht(DateTime tijd, string bericht, int gebruikerId, int hulpopdrachtId);

        List<ChatBericht> RetrieveAllChatBerichtenByOpdracht(int id);

        void DeleteChatBericht(int id);
    }
}