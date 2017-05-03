using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Carespot.DAL.Interfaces;
using Carespot.Models;

namespace Carespot.DAL.Context
{
    public class ChatSQLContext : IChatContext
    {
        private readonly SqlConnection _con = new SqlConnection("Data Source=WIN-SRV-WEB.fhict.local;Initial Catalog=Carespot;User ID=carespot;Password=Test1234;Encrypt=False;TrustServerCertificate=True");

        public void CreateChatBericht(DateTime tijd, string bericht, int gebruikerId, int hulpopdrachtId)
        {
            try
            {
                _con.Open();
                var cmdString = "INSERT INTO ChatBericht (datum, bericht, gebruikerId, hulpopdrachtId) VALUES (@datum, @bericht, @gebruikerId, @hulpopdrachtId)";
                var command = new SqlCommand(cmdString, _con);
                command.Parameters.AddWithValue("@datum", DateTime.Now);
                command.Parameters.AddWithValue("@bericht", bericht);
                command.Parameters.AddWithValue("@gebruikerId", gebruikerId);
                command.Parameters.AddWithValue("@hulpopdrachtId", hulpopdrachtId);
                command.ExecuteNonQuery();
                _con.Close();
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
            }
        }

        public void DeleteChatBericht(int id)
        {
            try
            {
                _con.Open();
                var cmdString = "DELETE FROM ChatBericht WHERE id = @id";
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

        public List<ChatBericht> RetrieveAllChatBerichtenByOpdracht(int id)
        {
            try
            {
                _con.Open();
                var cmdString = "SELECT * FROM ChatBericht WHERE hulpopdrachtId = @id";
                var command = new SqlCommand(cmdString, _con);
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();
                var ReturnList = new List<ChatBericht>();

                while (reader.Read())
                {
                    var c = new ChatBericht(reader.GetDateTime(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4));
                    c.Id = reader.GetInt32(0);

                    ReturnList.Add(c);
                }

                _con.Close();
                reader.Close();
                return ReturnList;
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
            }
        }
    }
}