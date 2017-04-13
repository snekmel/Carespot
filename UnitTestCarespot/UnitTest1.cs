using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCarespot
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DalTester()
        {
            var inf = new GebruikerSQLContext();
            var gr = new GebruikerRepository(inf);

            var lijstje = gr.RetrieveAll();

            Assert.AreEqual("Luc", lijstje[0].Naam);
        }
    }
}