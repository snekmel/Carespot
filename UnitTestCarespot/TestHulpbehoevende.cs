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
        public void TestMethodHulpverlener()
        {
            var inf = new HulpbehoevendeSQLContext();
            var repo = new HulpbehoevendeRepository(inf);

            repo.Hulpverlener(3);

            Assert.AreEqual("Pietje", repo.Hulpverlener(3).Naam);
        }

        [TestMethod]
        public void TestMethodHulbehoevende()
        {
            var inf = new HulpbehoevendeSQLContext();
            var repo = new HulpbehoevendeRepository(inf);

            var hulpList = repo.HulpbehoevendeList();

            Assert.AreEqual("Jan", hulpList[0].Naam);
        }
    }
}