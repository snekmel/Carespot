using Carespot.DAL.Context;
using Carespot.DAL.Repositorys;
using Carespot.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            HulpOpdracht h = new HulpOpdracht("Testopdracht", "Testomschrijving");
            

            hr.CreateHulpopdracht(h);
        }
    }
}