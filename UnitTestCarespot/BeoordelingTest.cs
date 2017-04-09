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
        public void TestCreateBeoordeling()
        {
            var bsc = new BeoordelingSQLContext();
            var br = new BeoordelingRepository(bsc);

            var b = new Beoordeling("Ontzettend spontaan. Erg vriendelijk.", 7, 5, 8);
            br.Create(b);
        }

        [TestMethod]
        public void TestSelectBeoordeling()
        {
            var bsc = new BeoordelingSQLContext();
            var br = new BeoordelingRepository(bsc);

            var lb = br.RetrieveBeoordeling(2);
            Assert.IsTrue(lb.Count > 0);
        }

        //public void TestDeleteBeoordeling()

        //[TestMethod]
        //{
        //    var bsc = new BeoordelingSQLContext();
        //    var br = new BeoordelingRepository(bsc);

        //    br.Delete(2);
        //}
    }
}