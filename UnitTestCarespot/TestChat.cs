using System;
using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCarespot
{
    [TestClass]
    public class TestChat
    {
        [TestMethod]
        public void TestMethod1()
        {
            var inf = new ChatSQLContext();
            var cr = new ChatRepository(inf);

            cr.CreateChatBericht(DateTime.Now, "Ik heb egt heel snel hulp nodig", 1, 3);

            var lijst = cr.RetrieveAllChatBerichtenByOpdracht(3);

            Assert.AreEqual("Ik heb egt heel snel hulp nodig", lijst[0].Bericht);
        }
    }
}