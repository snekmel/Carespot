using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Carespot.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestCarespot
{
    /// <summary>
    /// Summary description for ReactieTest
    /// </summary>
    [TestClass]
    public class ReactieTest
    {
        [TestMethod]
        public void CreateReactie()
        {
            var context = new ReactieSQLContext();
            var rr = new ReactieRepository(context);

            rr.CreateReactie(14, 2, "Heb je nog hulp nodig??");
        }

        [TestMethod]
        public void GetAllReactiesByHulopdrachtID()
        {
            var context = new ReactieSQLContext();
            var rr = new ReactieRepository(context);

            List<Reactie> reactielijst = new List<Reactie>();
           reactielijst =  rr.GetAllReactiesByHulopdrachtID(3);

            Assert.AreEqual(2 , reactielijst.Count);
           
        }

        [TestMethod]
        public void DeleteReactie()
        {
            var context = new ReactieSQLContext();
            var rr = new ReactieRepository(context);

            rr.DeleteReactie(2);
        }
    }
}
