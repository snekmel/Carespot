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

            rr.CreateReactie(5, 3, "Moet ik je komen helpen ?");
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
    }
}
