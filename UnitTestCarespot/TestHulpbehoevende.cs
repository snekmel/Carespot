using System;
using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCarespot
{
    [TestClass]
    public class TestHulpbehoevende
    {
        [TestMethod]
        public void TestMethod1()
        {
            var inf = new HulpbehoevendeSQLContext();
            var repo = new HulpbehoevendeRepository(inf);

            repo.Hulpverlener(3);

            Assert.AreEqual("Pietje", repo.Hulpverlener(3).Naam);
        }
    }
}