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
        public void TestMethodHulbehoevende()
        {
            var inf = new HulpbehoevendeSQLContext();
            var repo = new HulpbehoevendeRepository(inf);

            var hulpList = repo.RetrieveAll();

            Assert.AreEqual("Jantje", hulpList[0].Naam);
        }

        [TestMethod]
        public void TestMethodHulpverlenerVanHulpbehoevende()
        {
            var inf = new HulpbehoevendeSQLContext();
            var repo = new HulpbehoevendeRepository(inf);

            var hulpList = repo.RetrieveAll();

            Assert.AreEqual("Pietje", hulpList[0].Hulpverlener.Naam);
        }

        [TestMethod]
        public void TestMethodUpdateHulpbehoevende()
        {
            var inf = new HulpbehoevendeSQLContext();
            var repo = new HulpbehoevendeRepository(inf);

            var hulpb = repo.RetrieveAll()[0];
            hulpb.Naam = "Jantje";
            repo.UpdateHulpbehoevende(hulpb);

            Assert.AreEqual("Jantje", hulpb.Naam);
        }

        [TestMethod]
        public void TestMethodCreateHulpbehoevende()
        {
            var inf = new HulpbehoevendeSQLContext();
            var repo = new HulpbehoevendeRepository(inf);

            var hulpverlener = repo.RetrieveAll()[0].Hulpverlener;

           // repo.CreateHulpbehoevende("Lance", "Test1234", Gebruiker.GebruikerGeslacht.Man, "Rachelsmolen", "55A", "6587LL", "Eindhoven", "Nederland", "neppe@email.com", "0612345678", Gebruiker.GebruikerType.Hulpbehoevende, "", hulpverlener.Id);

            Assert.AreEqual("Lance", repo.RetrieveAll()[1].Naam);
        }

        [TestMethod]
        public void TestMethodHulpbehoevendeById()
        {
            var inf = new HulpbehoevendeSQLContext();
            var repo = new HulpbehoevendeRepository(inf);

            var hulpbehoevende = repo.RetrieveHulpbehoevendeById(8);
            var hulpverlener = hulpbehoevende.Hulpverlener;
            Assert.AreEqual("Pietje", hulpverlener.Naam);
        }
    }
}