using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Carespot.DAL.Interfaces;
using Carespot.Models;

namespace Carespot.DAL.Context
{
    public class BeoordelingSQLContext : IBeoordelingContext
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
            try
            {
                _con.Open();
                var cmdString = "INSERT INTO Beoordeling(opmerking, cijfer, reactie, hulpbehoevendeId, vrijwilligerId) VALUES(@opmerking, @cijfer, NULL, @hulpbehoevendeId, @vrijwilligerId);";
                var command = new SqlCommand(cmdString, _con);
                command.Parameters.AddWithValue("@opmerking", obj.Opmerking);
                command.Parameters.AddWithValue("@cijfer", obj.Cijfer);
                command.Parameters.AddWithValue("@hulpbehoevendeId", obj.HulpbehoevendeId);
                command.Parameters.AddWithValue("@vrijwilligerId", obj.VrijwilligerId);
                command.ExecuteNonQuery();
                _con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Beoordeling> GetBeoordelingenByGebruikerId(int gebruikersId)
        {
            return null;
        }
    }
}