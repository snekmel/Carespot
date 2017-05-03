using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Carespot.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestCarespot
{
    [TestClass]
    public class HulpOpdrachtTest
    {
        [TestMethod]
        public void TestCreeërHulpopdracht()
        {
            var context = new HulpopdrachtSQLContext();
            var hr = new HulpopdrachtRepository(context);

            DateTime aanmaakDatum = DateTime.Today;
            DateTime opdrachDatum = DateTime.Today;

            var inf = new HulpbehoevendeSQLContext();
            var repo = new HulpbehoevendeRepository(inf);

            var hulpList = repo.RetrieveAll();

            Hulpbehoevende hb = (Hulpbehoevende)hulpList[0];

            HulpOpdracht h = new HulpOpdracht(false, "test", aanmaakDatum, "test", opdrachDatum, hb);

            hr.CreateHulpopdracht(h);
        }

        [TestMethod]
        public void TestGetHulpOpdrachtById()
        {
            var context = new HulpopdrachtSQLContext();
            var hr = new HulpopdrachtRepository(context);

            HulpOpdracht h = hr.GetHulpopdrachtByID(3);

            Assert.AreEqual(h.Titel, "HELP");

            Assert.IsNotNull(h.Vrijwilleger);
            Assert.AreEqual(2, h.Vrijwilleger.Id);
            Assert.AreEqual(4, h.Hulpbehoevende.Id);
            Assert.AreEqual(3, h.Hulpbehoevende.Hulpverlener.Id);
        }

        [TestMethod]
        public void TestGetAllHulpopdrachten()
        {
            var context = new HulpopdrachtSQLContext();
            var hr = new HulpopdrachtRepository(context);

            List<HulpOpdracht> lijstje = new List<HulpOpdracht>();

            lijstje = hr.GetAllHulpopdrachten();

            Assert.AreEqual("HELP", lijstje[0].Titel);
        }

        [TestMethod]
        public void TestAcceptReactie()
        {
            var context = new HulpopdrachtSQLContext();
            var hr = new HulpopdrachtRepository(context);

          hr.AcceptReactie(3,6);
        }


        [TestMethod]

        public void TestbyHulpbehoevendeid()
        {
            
        }
    }
}