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
    public class GebruikerSQLContext : IGebruikerContext
    {
        private readonly SqlConnection _con =
            new SqlConnection(
                "Data Source=WIN-SRV-WEB.fhict.local;Initial Catalog=Carespot;User ID=carespot;Password=Test1234;Encrypt=False;TrustServerCertificate=True");

        public int CreateGebruiker(Gebruiker g)
        {
            int returnId = 0;
            try
            {
                using (_con)
                {

                    string query =
                        "INSERT INTO Gebruiker (naam, wachtwoord, geslacht, straat, huisnummer, postcode, plaats, land, email, telefoonnummer, gebruikerType, foto) VALUES(@naam,@wachtwoord,@geslacht,@straat,@huisnummer,@postcode,@plaats,@land,@email,@telefoonnummer,@gebruikerType,NULL);SELECT CAST(scope_identity() AS int)";
                    SqlCommand cmd = new SqlCommand(query, _con);

                    _con.Open();
                    cmd.Parameters.AddWithValue("@naam", g.Naam);
                    cmd.Parameters.AddWithValue("@wachtwoord", g.Wachtwoord);
                    cmd.Parameters.AddWithValue("@geslacht", g.Geslacht.ToString());
                    cmd.Parameters.AddWithValue("@straat", g.Straat);
                    cmd.Parameters.AddWithValue("@huisnummer", g.Huisnummer);
                    cmd.Parameters.AddWithValue("@postcode", g.Postcode);
                    cmd.Parameters.AddWithValue("@plaats", g.Plaats);
                    cmd.Parameters.AddWithValue("@land", g.Land);
                    cmd.Parameters.AddWithValue("@email", g.Email);
                    cmd.Parameters.AddWithValue("@telefoonnummer", g.Telefoonnummer);
                    cmd.Parameters.AddWithValue("@gebruikerType", g.Type.ToString());
                    returnId = (int) cmd.ExecuteScalar();
                    _con.Close();
                }

            }
            catch
            {
                System.Windows.MessageBox.Show("woops");
            }
            return returnId;

        }

        public void UpdateGebruiker(Gebruiker g)
        {
            throw new NotImplementedException();
        }
    }
}
