using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Carespot.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCarespot
{
    [TestClass]
    public class BeoordelingTest
    {
        [TestMethod]
        public void TestSelectBeoordeling()
        {
            var bsc = new BeoordelingSQLContext();
            var br = new BeoordelingRepository(bsc);

            var b = br.RetrieveBeoordeling(1);
        }

        [TestMethod]
        public void TestCreateBeoordeling()
        {
            var bsc = new BeoordelingSQLContext();
            var br = new BeoordelingRepository(bsc);

            var b = new Beoordeling("Testopmerking", 7, 2, 4);
            br.Create(b);
        }
    }
}