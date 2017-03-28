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
    public class GebruikerSQLContext : IGebruikerContext
    {
        private SqlConnection _con = new SqlConnection("Data Source=WIN-SRV-WEB.fhict.local;Initial Catalog=Carespot;User ID=carespot;Password=Test1234;Encrypt=False;TrustServerCertificate=True");

        public void Create(Gebruiker obj)
        {
            throw new NotImplementedException();
        }

        public Gebruiker Retrieve(int id)
        {
            throw new NotImplementedException();
        }

        public List<Gebruiker> RetrieveAll()
        {
            _con.Open(); string cmdString = "SELECT * FROM Gebruiker";
            SqlCommand command = new SqlCommand(cmdString, _con);
            SqlDataReader reader = command.ExecuteReader();
            List<Gebruiker> ReturnList = new List<Gebruiker>();

            while (reader.Read())
            {
                var p = new Beheerder(reader.GetString(1), reader.GetString(2), reader.GetString(9));
                p.Id = reader.GetInt32(0);

                ReturnList.Add(p);
            }

            _con.Close();

            return ReturnList;
        }

        public void Update(int id, Gebruiker obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}