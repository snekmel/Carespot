using System;
using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Carespot.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCarespot
{
    [TestClass]
    public class GebruikerTesten
    {
        [TestMethod]
        public void CreateGebruiker()
        {
            GebruikerSQLContext gsc = new GebruikerSQLContext();
            GebruikerRepository gr  = new GebruikerRepository(gsc);

            Gebruiker g = new Gebruiker();

            gr.CreateGebruiker(g,false,false,false,false);

        }
    }
}
