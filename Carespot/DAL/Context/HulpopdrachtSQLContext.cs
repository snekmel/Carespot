using Carespot.DAL.Interfaces;
using Carespot.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Carespot.DAL.Context
{
    public class HulpopdrachtSQLContext : IHulpopdrachtContext
    {
        private static string connectionString =
            "Data Source = 'WIN-SRV-WEB.fhict.local, 1433'; Integrated Security = False; User ID = carespot; Password=Test1234;Connect Timeout = 15; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private readonly SqlConnection connection = new SqlConnection(connectionString);

        public List<HulpOpdracht> GetAllHulpopdrachten()
        {
            List<HulpOpdracht> _hulpopdrachten = new List<HulpOpdracht>();

            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT * FROM Hulpopdracht";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;

                connection.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string titel = reader.GetString(2);

                    HulpOpdracht h = new HulpOpdracht(id, titel);
                    _hulpopdrachten.Add(h);
                }

                reader.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }

            return _hulpopdrachten;
        }

        public HulpOpdracht GetHulpopdrachtByID(int id)
        {
            HulpOpdracht h;

            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT * FROM Hulpopdracht WHERE id = " + id + ";";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;

                connection.Open();

                reader = cmd.ExecuteReader();

                int opdrachtid = reader.GetInt32(0);
                string titel = reader.GetString(2);

                h = new HulpOpdracht(opdrachtid, titel);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }

            return h;
        }

        public void CreateHulpopdracht(HulpOpdracht hulopdracht)
        {
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();

                //Let op: De koppeltabellen worden niet aangepast
                cmd.CommandText =
                    "INSERT INTO hulpopdracht (titel, omschrijving) VALUES ('" +
                    hulopdracht.Titel + "', '" + hulopdracht.Omschrijving + "');";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;

                cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}