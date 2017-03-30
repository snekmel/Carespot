using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCarespot
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void GetAllVaardigheden()
        {
            var vsc = new VaardigheidSQLContext();
            var vr = new VaardigheidRepository(vsc);
            Assert.IsTrue(vr.RetrieveAll().Count > 0);
        }
    }
}