using System;
using System.Data.SqlClient;
using Carespot.DAL.Interfaces;
using Carespot.Models;

namespace Carespot.DAL.Context
{
    internal class BeoordelingSQLContext : IBeoordelingContext
    {
        private readonly SqlConnection _con =
            new SqlConnection(
                "Data Source=WIN-SRV-WEB.fhict.local;Initial Catalog=Carespot;User ID=carespot;Password=Test1234;Encrypt=False;TrustServerCertificate=True");

        public Beoordeling RetrieveBeoordeling(int vrijwilligerId)
        {
            try
            {
                _con.Open();
                var cmdString = "SELECT * FROM Producten WHERE Id = @id";
                var command = new SqlCommand(cmdString, _con);
                command.Parameters.AddWithValue("@id", vrijwilligerId);
                var reader = command.ExecuteReader();
                Beoordeling b = null;
                while (reader.Read())
                    b = new Beoordeling(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3),
                        reader.GetInt32(4), reader.GetInt32(5));
                reader.Close();
                _con.Close();
                return b;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public void Create(Beoordeling obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}