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
    public class ChatSQLContext : IChatContext
    {
        private SqlConnection _con = new SqlConnection("Data Source=WIN-SRV-WEB.fhict.local;Initial Catalog=Carespot;User ID=carespot;Password=Test1234;Encrypt=False;TrustServerCertificate=True");

        void IChatContext.CreateChatBericht(DateTime tijd, string bericht, int gebruikerId, int hulpopdrachtId)
        {
            _con.Open();
            string cmdString = "INSERT INTO ChatBericht (datum, bericht, gebruikerId, hulpopdrachtId) VALUES (@datum, '" + bericht + "', '" + gebruikerId + "', '" + hulpopdrachtId + "')";
            SqlCommand command = new SqlCommand(cmdString, _con);
            command.Parameters.AddWithValue("@datum", DateTime.Now);
            command.ExecuteNonQuery();
            _con.Close();
        }

        void IChatContext.DeleteChatBericht(int id)
        {
            _con.Open();
            var cmdString = "DELETE FROM ChatBericht WHERE id = '" + id + "'";
            var command = new SqlCommand(cmdString, _con);
            command.ExecuteNonQuery();
            _con.Close();
        }

        List<ChatBericht> IChatContext.RetrieveAllChatBerichtenByOpdracht(int id)
        {
            _con.Open(); string cmdString = "SELECT * FROM ChatBericht WHERE hulpopdrachtId = '" + id + "'";
            SqlCommand command = new SqlCommand(cmdString, _con);
            SqlDataReader reader = command.ExecuteReader();
            List<ChatBericht> ReturnList = new List<ChatBericht>();

            while (reader.Read())
            {
                var c = new ChatBericht(reader.GetDateTime(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4));
                c.Id = reader.GetInt32(0);

                ReturnList.Add(c);
            }

            _con.Close();

            return ReturnList;
        }
    }
}