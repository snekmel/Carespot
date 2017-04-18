using System;
using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCarespot
{
    [TestClass]
    public class TestBeheerder
    {
        [TestMethod]
        public void TestAllBeheerder()
        {
            var inf = new BeheerderSQLContext();
            var repo = new BeheerderRepository(inf);
            var list = repo.RetrieveAll();

            Assert.AreEqual("De", list[0].Straat);
        }
    }
}