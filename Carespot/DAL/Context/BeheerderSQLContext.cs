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
    public class BeheerderSQLContext : IBeheerderContext
    {
        private readonly SqlConnection _con = new SqlConnection("Data Source=WIN-SRV-WEB.fhict.local;Initial Catalog=Carespot;User ID=carespot;Password=Test1234;Encrypt=False;TrustServerCertificate=True");

        public List<Beheerder> RetrieveAll()
        {
            throw new NotImplementedException();
        }

        public void CreateBeheerder(int gebruikerId)
        {
            try
            {
                _con.Open();
                string query1 = "INSERT INTO Beheerder (gebruikerId) VALUES (@newID)";
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

        public Beheerder RetrieveBeheerder(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBeheerder(Beheerder b)
        {
            throw new NotImplementedException();
        }

        public void DeleteBeheerder(int id)
        {
            throw new NotImplementedException();
        }
    }
}