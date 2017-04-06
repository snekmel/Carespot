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
            "Data Source=WIN-SRV-WEB.fhict.local;Initial Catalog=Carespot;User ID=carespot;Password=Test1234;Encrypt=False;TrustServerCertificate=True";

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

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int opdrachtid = reader.GetInt32(0);
                    bool isGeaccepteerd = HulpOpdracht.ConvertIntToBool(reader.GetInt32(1));
                    string titel = reader.GetString(2);
                    DateTime aanmaakDatum = Convert.ToDateTime(reader.GetString(3));
                    string omschrijving = reader.GetString(4);
                    DateTime opdrachtDatum = Convert.ToDateTime(reader.GetString(5));

                    HulpOpdracht h = new HulpOpdracht(opdrachtid, isGeaccepteerd, titel, aanmaakDatum, omschrijving, opdrachtDatum);
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

                reader = cmd.ExecuteReader();

                reader.Read();

                int opdrachtid = reader.GetInt32(0);
                bool isGeaccepteerd = HulpOpdracht.ConvertIntToBool(reader.GetInt32(1));
                string titel = reader.GetString(2);
                DateTime aanmaakDatum = Convert.ToDateTime(reader.GetString(3));
                string omschrijving = reader.GetString(4);
                DateTime opdrachtDatum = Convert.ToDateTime(reader.GetString(5));

                h = new HulpOpdracht(opdrachtid, isGeaccepteerd, titel, aanmaakDatum, omschrijving, opdrachtDatum);

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

            return h;
        }

        public void CreateHulpopdracht(HulpOpdracht hulpopdracht)
        {
            try
            {
                connection.Open();

                //Converteer datums naar string
                string aanmaakDatum = hulpopdracht.AanmaakDatum.ToString("yyyy-MM-dd");
                string opdrachtDatum = hulpopdracht.OpdrachtDatum.ToString("yyyy-MM-dd");

                SqlCommand cmd = new SqlCommand();

                //Let op: De koppeltabellen worden niet aangepast
                cmd.CommandText =
                    "INSERT INTO Hulpopdracht (isGeaccepteerd, titel, omschrijving, aanmaakDatum, opdrachtDatum, vrijwilligerId, hulpverlenerId, hulpbehoevendeId) VALUES (0, '" + hulpopdracht.Titel + "', '" + hulpopdracht.Omschrijving + "', '" + aanmaakDatum + "', '" + opdrachtDatum + "', '2', '3', '4')";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;

                cmd.ExecuteReader();

                //cmd.ExecuteNonQuery();
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