using System;
using System.Collections.Generic;
using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Carespot.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCarespot
{
    [TestClass]
    public class VrijwilligerTests
    {

        [TestMethod]
        public void UpdateVrijwilliger()
        {


            var vsc = new VrijwilligerSQLContext();
            var vr = new VrijwilligerRepository(vsc);
            Vrijwilliger v = vr.RetrieveById(7);
            v.Naam = v.Naam + "aangepast";


            vr.UpdateVrijwilliger(v);

        }
        [TestMethod]
        public void VrijwilligerALL()
        {

            var vsc = new VrijwilligerSQLContext();
            var vr = new VrijwilligerRepository(vsc);
            List<Vrijwilliger> lijst = vr.RetrieveAll();
            Assert.IsTrue(lijst.Count > 0);

        }

        [TestMethod]
        public void GetVrijwilligerByID()
        {
            var vsc = new VrijwilligerSQLContext();
            var vr = new VrijwilligerRepository(vsc);

            Assert.AreEqual("Kees", vr.RetrieveById(2).Naam);


        }

        [TestMethod]
        public void CreateVrijwilligerTest()
        {
            var vsc = new VrijwilligerSQLContext();
            var vr = new VrijwilligerRepository(vsc);
            Vrijwilliger v = vr.RetrieveById(2);
            v.Naam = "testasdfasdfasdfasdf";

            
            vr.CreateVrijwilliger(v);


        }

        [TestMethod]
        public void DeleteVrijwilliger()
        {
            var vsc = new VrijwilligerSQLContext();
            var vr = new VrijwilligerRepository(vsc);

            vr.DeleteVrijwilliger(6);


        }
    }
}
