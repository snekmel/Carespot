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
        public void TestCreeërHulpopdracht()
        {
            var context = new ReactieSQLContext();
            var rp = new ReactieRepository();

            List<Reactie> reacties = new List<Reactie>();

            reacties = rp.GetAllReactiesByHulopdrachtID(1);

            Assert.AreEqual(1, reacties[0].Vrijwilliger.Id);

        }
    }
}
