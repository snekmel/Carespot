using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carespot.DAL.Interfaces;
using Carespot.Models;

namespace Carespot.DAL.Context
{
    class VrijwilligerSQLContext : IVrijwilligerContext
    {
        private readonly SqlConnection _con = new SqlConnection("Data Source=WIN-SRV-WEB.fhict.local;Initial Catalog=Carespot;User ID=carespot;Password=Test1234;Encrypt=False;TrustServerCertificate=True");

        public List<Vrijwilliger> RetrieveAll()
        {
            var returnList = new List<Vrijwilliger>();

            try
            {
                _con.Open();
                var cmdString = "SELECT * FROM Vrijwilliger";
                var command = new SqlCommand(cmdString, _con);
                var reader = command.ExecuteReader();               
         
            }
            catch(SqlException)
            {
               //
            }
            finally
            {
                _con.Close();
            }
            return returnList;
        }

        public void CreateVrijwilliger(Vrijwilliger v)
        {
            throw new NotImplementedException();
        }

        public Vrijwilliger RetrieveVrijwilliger(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateVrijwilliger(Vrijwilliger v)
        {
            throw new NotImplementedException();
        }

        public void DeleteVrijwilliger(int id)
        {
            throw new NotImplementedException();
        }
    }
}
