using System;
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
            GebruikerSQLContext inf = new GebruikerSQLContext();
            GebruikerRepository gr = new GebruikerRepository(inf);

            List<Gebruiker> lijstje = gr.RetrieveAll();

            Assert.AreEqual("Luc", lijstje[0].Naam);
        }
    }
}