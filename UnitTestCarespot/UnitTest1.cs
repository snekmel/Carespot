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

            GebruikerSQLContext gsc = new GebruikerSQLContext();
            GebruikerRepository gr =  new GebruikerRepository(gsc);
            Gebruiker g = gr.RetrieveGebruiker(1);

            g.Huisnummer = g.Huisnummer + "aangepast";


            gr.UpdateGebruiker(g);
        }
    }
}