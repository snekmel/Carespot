using System.Collections.Generic;
using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Carespot.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCarespot
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DalTester()
        {

            GebruikerRepository gr = new GebruikerRepository();

           List<Gebruiker> g = gr.RetrieveAll();
            Assert.IsTrue(g.Count > 10);

        }
    }
}