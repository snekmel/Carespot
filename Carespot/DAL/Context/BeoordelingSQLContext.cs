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
            new SqlConnection("Data Source=WIN-SRV-WEB.fhict.local;Initial Catalog=Carespot;User ID=carespot;Password=Test1234;Encrypt=False;TrustServerCertificate=True");

        public List<Beoordeling> RetrieveBeoordeling(int vrijwilligerId)
        {
            var lb = new List<Beoordeling>();
            try
            {
                _con.Open();
                var cmdString = "SELECT * FROM Beoordeling WHERE Id = @id";
                var command = new SqlCommand(cmdString, _con);
                command.Parameters.AddWithValue("@id", vrijwilligerId);
                var reader = command.ExecuteReader();
                Beoordeling b = null;
                while (reader.Read())
                {
                    b = new Beoordeling();
                    b.Id = reader.GetInt32(0);
                    b.Opmerking = reader.GetString(1);
                    b.Cijfer = reader.GetInt32(2);
                    if (reader.IsDBNull(3))
                    {
                    }
                    else
                    {
                        b.Reactie = reader.GetString(3);
                    }
                    b.VrijwilligerId = reader.GetInt32(4);
                    b.HulpbehoevendeId = reader.GetInt32(5);
                    lb.Add(b);
                }
                reader.Close();
                _con.Close();
                return lb;
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
            }
        }

        public void Create(Beoordeling obj)
        {
            try
            {
                _con.Open();
                var cmdString =
                    "INSERT INTO Beoordeling(opmerking, cijfer, reactie, vrijwilligerId, hulpbehoevendeId) VALUES(@opmerking, @cijfer, NULL, @vrijwilligerId, @hulpbehoevendeId);";
                var command = new SqlCommand(cmdString, _con);
                command.Parameters.AddWithValue("@opmerking", obj.Opmerking);
                command.Parameters.AddWithValue("@cijfer", obj.Cijfer);
                command.Parameters.AddWithValue("@vrijwilligerId", obj.VrijwilligerId);
                command.Parameters.AddWithValue("@hulpbehoevendeId", obj.HulpbehoevendeId);
                command.ExecuteNonQuery();
                _con.Close();
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _con.Open();
                var cmdString = "DELETE FROM Beoordeling WHERE id = @id";
                var command = new SqlCommand(cmdString, _con);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                _con.Close();
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
            }
        }
    }
}