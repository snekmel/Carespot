using Carespot.DAL.Interfaces;
using Carespot.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq.Expressions;
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
<<<<<<< HEAD
            try
            {
                using (connection)
                {
                    connection.Open();
                    var cmdString = "SELECT * FROM Hulpopdracht";
                    var command = new SqlCommand(cmdString, connection);
                    var reader = command.ExecuteReader();
=======
            /*            try
                        { */
            using (connection)
            {
                connection.Open();
                var cmdString = "SELECT * FROM Hulpopdracht";
                var command = new SqlCommand(cmdString, connection);
                var reader = command.ExecuteReader();
>>>>>>> 03d0950771d54d24939d25b77f96814ae123956c

                while (reader.Read())
                {
                    HulpOpdracht ho = new HulpOpdracht(reader.GetString(2))
                    {
<<<<<<< HEAD

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
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
 
=======
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

>>>>>>> 03d0950771d54d24939d25b77f96814ae123956c
            return returnList;
        }

        public List<HulpOpdracht> GetAllHulpopdrachtenByHulpbehoevendeID(int hbid)
        {
            var returnList = new List<HulpOpdracht>();
            try
            {
                using (connection)
                {
                    connection.Open();
                    var cmdString = "SELECT * FROM Hulpopdracht WHERE hulpbehoevendeid = " + hbid + ";";
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
                }
            }

            catch (Exception e)
            {
                throw e;
            }

            finally
            {
                connection.Close();
            }

            return returnList;
        }

        public HulpOpdracht GetHulpopdrachtByID(int id)
        {
            HulpOpdracht h;

            try
            {
                using (connection)
                {
                    connection.Open();
                    var cmdString = "SELECT * FROM Hulpopdracht WHERE id = " + id + ";";
                    var command = new SqlCommand(cmdString, connection);
                    var reader = command.ExecuteReader();

                     h = new HulpOpdracht(reader.GetString(2))
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
                        h.Vrijwilleger = vr.RetrieveById(reader.GetInt32(6));

                    }


                    //Hulppbehoevendeophalen
                    if (!reader.IsDBNull(8))
                    {

                        HulpbehoevendeSQLContext hsc = new HulpbehoevendeSQLContext();
                        HulpbehoevendeRepository hr = new HulpbehoevendeRepository(hsc);

                        h.Hulpbehoevende = hr.RetrieveHulpbehoevendeById(reader.GetInt32(8));

<<<<<<< HEAD
                    }

                }
=======
                reader.Close();
>>>>>>> 03d0950771d54d24939d25b77f96814ae123956c
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