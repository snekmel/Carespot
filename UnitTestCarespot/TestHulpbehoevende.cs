using System;
using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Carespot.Models;
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

        [TestMethod]
        public void TestMethodHulpverlenerVanHulpbehoevende()
        {
            var inf = new HulpbehoevendeSQLContext();
            var repo = new HulpbehoevendeRepository(inf);

            var hulpList = repo.HulpbehoevendeList();

            Assert.AreEqual("Pietje", hulpList[0].Hulpverlener.Naam);
        }

        [TestMethod]
        public void TestMethodUpdateHulpbehoevende()
        {
            var inf = new HulpbehoevendeSQLContext();
            var repo = new HulpbehoevendeRepository(inf);

            var hulpb = repo.HulpbehoevendeList()[0];
            hulpb.Naam = "Jantje";
            repo.UpdateHulpbehoevende(hulpb);

            Assert.AreEqual("Jantje", hulpb.Naam);
        }
    }
}