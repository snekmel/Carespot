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
    public class HulpverlenerSQLContext : IHulpverlenerContext
    {

        private readonly SqlConnection _con =
           new SqlConnection(
               "Data Source=WIN-SRV-WEB.fhict.local;Initial Catalog=Carespot;User ID=carespot;Password=Test1234;Encrypt=False;TrustServerCertificate=True");

        public List<Hulpverlener> RetrieveAll()
        {
            throw new NotImplementedException();
        }

        public void CreateHulpverlener(int gebruikerId)
        {

            try
            {
                _con.Open();
                string query1 = "INSERT INTO Hulpverlener VALUES (@newID)";
                SqlCommand command1 = new SqlCommand(query1, _con);
                command1.Parameters.AddWithValue("@newID", gebruikerId);
                command1.ExecuteScalar();

                _con.Close();
            }
            catch
            {

                System.Windows.MessageBox.Show("woops");
            }


        }

        public Hulpverlener RetrieveHulpverlener(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateHulpverlener(Hulpverlener v)
        {
            throw new NotImplementedException();
        }

        public void DeleteHulpverlener(int id)
        {
            throw new NotImplementedException();
        }
    }
}
