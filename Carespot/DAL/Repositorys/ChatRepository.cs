using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carespot.DAL.Interfaces;

namespace Carespot.DAL.Repositorys
{
    public class ChatRepository
    {
        private IChatContext _chatContext;

        public ChatRepository(IChatContext IchatContext)
        {
            this._chatContext = IchatContext;
        }

        public void CreateChatBericht()
        {
        }

        public void RetrieveAllChatBerichtenByOpdracht()
        {
        }

        public void DeleteChatBericht()
        {
        }
    }
}