using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carespot.DAL.Interfaces;
using Carespot.Models;

namespace Carespot.DAL.Repositorys
{
    public class ChatRepository
    {
        private IChatContext _chatContext;

        public ChatRepository(IChatContext IchatContext)
        {
            this._chatContext = IchatContext;
        }

        public void CreateChatBericht(DateTime tijd, string bericht, int gebruikerId, int hulpopdrachtId)
        {
            _chatContext.CreateChatBericht(tijd, bericht, gebruikerId, hulpopdrachtId);
        }

        public List<ChatBericht> RetrieveAllChatBerichtenByOpdracht(int id)
        {
            return _chatContext.RetrieveAllChatBerichtenByOpdracht(id);
        }

        public void DeleteChatBericht(int id)
        {
            _chatContext.DeleteChatBericht(id);
        }
    }
}