using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Carespot.Models;
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

        [TestMethod]
        public void Create()
        {
            var vsc = new VaardigheidSQLContext();
            var vr = new VaardigheidRepository(vsc);

            var v = new Vaardigheid("testUnit");
            vr.CreateVaardigheid(v);
        }

        [TestMethod]
        public void Remove()
        {
            var vsc = new VaardigheidSQLContext();
            var vr = new VaardigheidRepository(vsc);

            vr.DeleteVaardigheid(2);
        }
    }
}