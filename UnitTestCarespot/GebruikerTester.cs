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

            g.Naam = "test";
            g.Wachtwoord = "t";
            g.Geslacht = Gebruiker.GebruikerGeslacht.Man;
            g.Straat = "De";
            g.Huisnummer = "ultieme";
            g.Postcode = "test";
            g.Plaats = "eindje";
            g.Land = "t";
            g.Email = "t";
            g.Telefoonnummer = "234";

            int id = gr.CreateGebruiker(g);
                

            BeheerderSQLContext bsc = new BeheerderSQLContext();
            BeheerderRepository br = new BeheerderRepository(bsc);

          
            br.CreateBeheerder(id);

        }

        [TestMethod]

        public void RetrieveGebruiker()
        {
            GebruikerSQLContext gsc = new GebruikerSQLContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);
            Gebruiker g = gr.RetrieveGebruiker(1);
            Assert.IsTrue(g.Naam == "Luc");
        }
    }
}
