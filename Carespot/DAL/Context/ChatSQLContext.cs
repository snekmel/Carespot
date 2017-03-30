using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carespot.DAL.Interfaces;

namespace Carespot.DAL.Context
{
    public class ChatSQLContext : IChatContext
    {
        void IChatContext.CreateChatBericht(DateTime tijd, string bericht)
        {
            throw new NotImplementedException();
        }

        void IChatContext.DeleteChatBericht(int id)
        {
            throw new NotImplementedException();
        }

        void IChatContext.RetrieveAllChatBerichtenByOpdracht(int id)
        {
            throw new NotImplementedException();
        }
    }
}