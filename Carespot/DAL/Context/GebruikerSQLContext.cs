using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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
                        "INSERT INTO Gebruiker (naam, wachtwoord, geslacht, straat, huisnummer, postcode, plaats, land, email, telefoonnummer, foto) VALUES(@naam,@wachtwoord,@geslacht,@straat,@huisnummer,@postcode,@plaats,@land,@email,@telefoonnummer,NULL);SELECT CAST(scope_identity() AS int)";
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
                 
                    returnId = (int) cmd.ExecuteScalar();
                    _con.Close();
                }

            }
            catch
            {
                System.Windows.MessageBox.Show("GEBRUIKERSQL CONTEXT -> CREATE GEBRUIKER");
            }
            return returnId;

        }

        public void UpdateGebruiker(Gebruiker g)
        {
            try
            {
                using (_con)
                {

                    string query =
                        "UPDATE Gebruiker SET naam = @naam, wachtwoord = @wachtwoord, geslacht = @geslacht, straat = @straat, huisnummer = @huisnummer, postcode = @postcode, plaats = @plaats, land = @land, email = @email, telefoonnummer = @telefoonnummer WHERE id =" + g.Id;
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
                    //foto
                    cmd.ExecuteNonQuery();
                   _con.Close();             
                }
            }
            catch
            {
                System.Windows.MessageBox.Show("GEBRUIKERSQLCONTEXT -> Update Gebruiker");
            }
        }

        public Gebruiker RetrieveGebruiker(int id)
        {
            try
            {
                _con.Open();
                var cmdString = "SELECT * FROM Gebruiker g WHERE id=" + id;
                var command = new SqlCommand(cmdString, _con);
                var reader = command.ExecuteReader();

                Gebruiker g = new Gebruiker();

                while (reader.Read())
                {
                    g.Id = reader.GetInt32(0);
                    g.Naam = reader.GetString(1);
                    g.Wachtwoord = reader.GetString(2);
                    g.Geslacht = (Gebruiker.GebruikerGeslacht)Enum.Parse(typeof(Gebruiker.GebruikerGeslacht), reader.GetString(3));
                    g.Straat = reader.GetString(4);
                    g.Huisnummer = reader.GetString(5);
                    g.Postcode = reader.GetString(6);
                    g.Plaats = reader.GetString(7);
                    g.Land = reader.GetString(8);
                    g.Email = reader.GetString(9);
                    g.Telefoonnummer = reader.GetString(10);
                    if (reader[11] != null)
                    {
                        g.Foto = (byte[])reader[11];
                    }

                }
                _con.Close();
                return g;

            }
            catch
            {
                System.Windows.MessageBox.Show("GEBRUIKERSQLCONTEXT -> RETRIEVE GEBRUIKER");
            }
            return null;
        }


    }
}
