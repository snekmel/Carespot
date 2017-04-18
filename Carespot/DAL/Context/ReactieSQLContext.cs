using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carespot.DAL.Interfaces;
using Carespot.Models;
using System.Data.SqlClient;
using Carespot.DAL.Repositorys;

namespace Carespot.DAL.Context
{
    public class ReactieSQLContext : IReactieContext
    {
        private static string connectionString =
           "Data Source=WIN-SRV-WEB.fhict.local;Initial Catalog=Carespot;User ID=carespot;Password=Test1234;Encrypt=False;TrustServerCertificate=True";
        private readonly SqlConnection connection = new SqlConnection(connectionString);

        public void CreateReactie(int vrijwillegerid, int hulpaanvraagid, string bericht)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText =
                    "INSERT INTO Reactie (vrijwilligerid, hulpopdrachtid, bericht) VALUES ("+ vrijwillegerid +", "+ hulpaanvraagid +", '"+ bericht +"');";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;

                cmd.ExecuteNonQuery();
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

        public List<Reactie> GetAllReactiesByHulopdrachtID(int hulpopdrachtid)
        {
            List<Reactie> _reacties = new List<Reactie>();

            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT * FROM Reactie WHERE hulpopdrachtid =" + hulpopdrachtid + ";";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int reactieid = reader.GetInt32(0);
                    int vrijwilligerid = reader.GetInt32(1);
                    string bericht = reader.GetString(3);

                    var vsc = new VrijwilligerSQLContext();
                    var vr = new VrijwilligerRepository(vsc);

                    Vrijwilliger v = vr.RetrieveById(vrijwilligerid);

                    Reactie r = new Reactie(v, bericht);

                    _reacties.Add(r);
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

            return _reacties;
        }

    }
}

