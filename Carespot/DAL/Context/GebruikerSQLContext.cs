using System;
using System.Data.SqlClient;
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
            var returnId = 0;
            try
            {
                using (_con)
                {
                    var query =
                        "INSERT INTO Gebruiker (naam, wachtwoord, geslacht, straat, huisnummer, postcode, plaats, land, email, telefoonnummer, foto) VALUES(@naam,@wachtwoord,@geslacht,@straat,@huisnummer,@postcode,@plaats,@land,@email,@telefoonnummer,@foto);SELECT CAST(scope_identity() AS int)";
                    var cmd = new SqlCommand(query, _con);

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
                    cmd.Parameters.AddWithValue("@foto", g.Foto);
                    returnId = (int)cmd.ExecuteScalar();
                    _con.Close();
                    return returnId;
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
            }
        }

        public void UpdateGebruiker(Gebruiker g)
        {
            try
            {
                using (_con)
                {
                    var query =
                        "UPDATE Gebruiker SET naam = @naam, wachtwoord = @wachtwoord, geslacht = @geslacht, straat = @straat, huisnummer = @huisnummer, postcode = @postcode, plaats = @plaats, land = @land, email = @email, telefoonnummer = @telefoonnummer, foto = @foto WHERE id =" + g.Id;
                    var cmd = new SqlCommand(query, _con);

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
                    cmd.Parameters.AddWithValue("@foto", g.Foto);
                    cmd.ExecuteNonQuery();
                    _con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
            }
        }

        public Gebruiker RetrieveGebruiker(int id)
        {
            try
            {
                using (_con)
                {
                    _con.Open();
                    var cmdString = "SELECT * FROM Gebruiker g WHERE id = @id";
                    var command = new SqlCommand(cmdString, _con);
                    command.Parameters.AddWithValue("@id", id);
                    var reader = command.ExecuteReader();

                    var g = new Gebruiker();

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
                            g.Foto = (byte[])reader[11];
                    }
                    _con.Close();
                    return g;
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
            }
        }
    }
}