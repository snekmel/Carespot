using Carespot.DAL.Interfaces;
using Carespot.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows;
using Carespot.DAL.Repositorys;

namespace Carespot.DAL.Context
{
    public class HulpopdrachtSQLContext : IHulpopdrachtContext
    {
        private static string connectionString =
            "Data Source=WIN-SRV-WEB.fhict.local;Initial Catalog=Carespot;User ID=carespot;Password=Test1234;Encrypt=False;TrustServerCertificate=True";

        private readonly SqlConnection connection = new SqlConnection(connectionString);

        public List<HulpOpdracht> GetAllHulpopdrachten()
        {
            var returnList = new List<HulpOpdracht>();
/*            try
            { */
                using (connection)
                {
                    connection.Open();
                    var cmdString = "SELECT * FROM Hulpopdracht";
                    var command = new SqlCommand(cmdString, connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                      
                        HulpOpdracht ho = new HulpOpdracht(reader.GetString(2))
                        {
                            Id = reader.GetInt32(0),
                            IsGeaccepteerd = Convert.ToBoolean(reader.GetInt32(1)),
                            AanmaakDatum = reader.GetDateTime(3),
                            Omschrijving = reader.GetString(4),
                            OpdrachtDatum = reader.GetDateTime(5)
                                                   
                        };
           
                        //Vrijwilliger ophalen
                        if (!reader.IsDBNull(6))
                        {

                         VrijwilligerSQLContext vsc = new VrijwilligerSQLContext();
                         VrijwilligerRepository vr = new VrijwilligerRepository(vsc);
                         ho.Vrijwilleger = vr.RetrieveById(reader.GetInt32(6));

                        }


                        //Hulppbehoevendeophalen
                        if (!reader.IsDBNull(8))
                        {

                        HulpbehoevendeSQLContext hsc = new HulpbehoevendeSQLContext();
                        HulpbehoevendeRepository hr = new HulpbehoevendeRepository(hsc);

                        ho.Hulpbehoevende = hr.RetrieveHulpbehoevendeById(reader.GetInt32(8));

                        }

                        returnList.Add(ho);

                    }
                    connection.Close();
                }

        /*    }

            catch (Exception e)
            {

                throw e;
            } */
       

            return returnList;
        }

        public List<HulpOpdracht> GetAllHulpopdrachtenByHulpbehoevendeID(int hbid)
        {
            List<HulpOpdracht> _hulpopdrachten = new List<HulpOpdracht>();

            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT * FROM Hulpopdracht WHERE Hulpbehoevendeid =" + hbid + ";";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int opdrachtid = reader.GetInt32(0);
                    bool isGeaccepteerd = HulpOpdracht.ConvertIntToBool(reader.GetInt32(1));
                    string titel = reader.GetString(2);
                    DateTime aanmaakDatum = reader.GetDateTime(3);
                    string omschrijving = reader.GetString(4);
                    DateTime opdrachtDatum = reader.GetDateTime(5);
                    int vrijwillegerid = 0;
                    int hulpbehoevendeid = reader.GetInt32(8);

                    //Controleer of vrijwillegerid niet nul is, anders vul vrijwillegerid
                    if (!reader.IsDBNull(6))
                    {
                        vrijwillegerid = reader.GetInt32(6);
                    }

                    HulpOpdracht h = new HulpOpdracht(opdrachtid, isGeaccepteerd, titel, aanmaakDatum, omschrijving, opdrachtDatum);
                    _hulpopdrachten.Add(h);

                    //Haal de passende vrijwilleger op en voeg deze toe aan de hulpopdracht
                    if (vrijwillegerid > 0)
                    {
                        var vsc = new VrijwilligerSQLContext();
                        var vr = new VrijwilligerRepository(vsc);

                        Vrijwilliger v = vr.RetrieveById(vrijwillegerid);
                        h.Vrijwilleger = v;
                    }

                    //Haal de passende hulpbehoevende (incl hulpverlener) op en voeg deze toe aan de hulpopdracht
                    var inf = new HulpbehoevendeSQLContext();
                    var repo = new HulpbehoevendeRepository(inf);

                    Hulpbehoevende hb = repo.RetrieveHulpbehoevendeById(hulpbehoevendeid);
                    h.Hulpbehoevende = hb;
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
                DateTime aanmaakDatum = reader.GetDateTime(3);
                string omschrijving = reader.GetString(4);
                DateTime opdrachtDatum = reader.GetDateTime(5);
                int vrijwillegerid = 0;
                int hulpbehoevendeid = reader.GetInt32(8);

                //Controleer of vrijwillegerid niet nul is, anders vul vrijwillegerid
                if (!reader.IsDBNull(6))
                {
                    vrijwillegerid = reader.GetInt32(6);
                }

                h = new HulpOpdracht(opdrachtid, isGeaccepteerd, titel, aanmaakDatum, omschrijving, opdrachtDatum);

                //Haal de passende vrijwilleger op en voeg deze toe aan de hulpopdracht
                if (vrijwillegerid > 0)
                {
                    var vsc = new VrijwilligerSQLContext();
                    var vr = new VrijwilligerRepository(vsc);

                    Vrijwilliger v = vr.RetrieveById(vrijwillegerid);
                    h.Vrijwilleger = v;
                }

                //Haal de passende hulpbehoevende (incl hulpverlener) op en voeg deze toe aan de hulpopdracht
                var inf = new HulpbehoevendeSQLContext();
                var repo = new HulpbehoevendeRepository(inf);

                Hulpbehoevende hb = repo.RetrieveHulpbehoevendeById(hulpbehoevendeid);
                h.Hulpbehoevende = hb;


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

                cmd.CommandText =
                    "INSERT INTO Hulpopdracht (isGeaccepteerd, titel, omschrijving, aanmaakDatum, opdrachtDatum, hulpbehoevendeId) VALUES (0, '" + hulpopdracht.Titel + "', '" + hulpopdracht.Omschrijving + "', '" + aanmaakDatum + "', '" + opdrachtDatum + "', '" + hulpopdracht.Hulpbehoevende.Id + "')";
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