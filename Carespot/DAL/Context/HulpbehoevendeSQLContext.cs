using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Carespot.DAL.Interfaces;
using Carespot.Models;

namespace Carespot.DAL.Context
{
    public class HulpbehoevendeSQLContext : IHulpbehoevendeContext
    {
        private readonly SqlConnection _con = new SqlConnection("Data Source=WIN-SRV-WEB.fhict.local;Initial Catalog=Carespot;User ID=carespot;Password=Test1234;Encrypt=False;TrustServerCertificate=True;MultipleActiveResultSets=true");

        public void CreateHulpbehoevende(int gebruikerId, int hulpverlenerId)
        {
            try
            {
                using (_con)
                {
                    _con.Open();
                    var query1 = "INSERT INTO Hulpbehoevende (gebruikerId, hulpverlenerId) VALUES (@newID,@hulpverlenerId)";
                    var command1 = new SqlCommand(query1, _con);
                    command1.Parameters.AddWithValue("@newID", gebruikerId);
                    command1.Parameters.AddWithValue("@hulpverlenerId", hulpverlenerId);

                    command1.ExecuteScalar();
                    _con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
            }
        }

        public void DeleteHulpbehoevende(int id)
        {
            try
            {
                using (_con)
                {
                    _con.Open();
                    var cmdString = "DELETE FROM Hulpbehoevende WHERE gebruikerId = @id";
                    var command = new SqlCommand(cmdString, _con);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    command.CommandText = "DELETE FROM Gebruiker WHERE id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    _con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
            }
        }

        public List<Hulpbehoevende> RetrieveAll()
        {
            try
            {
                using (_con)
                {
                    _con.Open();
                    var cmdString = "SELECT Gebruiker.*, Hulpbehoevende.hulpverlenerId FROM Gebruiker INNER JOIN Hulpbehoevende ON Gebruiker.id = Hulpbehoevende.gebruikerId";
                    var command = new SqlCommand(cmdString, _con);
                    var reader = command.ExecuteReader();
                    var hulpbehoevendeList = new List<Hulpbehoevende>();

                    while (reader.Read())
                    {
                        var hulpBehoevende = new Hulpbehoevende();
                        hulpBehoevende.Id = reader.GetInt32(0);
                        hulpBehoevende.Naam = reader.GetString(1);
                        hulpBehoevende.Wachtwoord = reader.GetString(2);
                        hulpBehoevende.Geslacht = (Gebruiker.GebruikerGeslacht)Enum.Parse(typeof(Gebruiker.GebruikerGeslacht), reader.GetString(3));
                        hulpBehoevende.Straat = reader.GetString(4);
                        hulpBehoevende.Huisnummer = reader.GetString(5);
                        hulpBehoevende.Postcode = reader.GetString(6);
                        hulpBehoevende.Plaats = reader.GetString(7);
                        hulpBehoevende.Land = reader.GetString(8);
                        hulpBehoevende.Email = reader.GetString(9);
                        hulpBehoevende.Telefoonnummer = reader.GetString(10);
                        if (!reader.IsDBNull(11))
                        {
                            hulpBehoevende.Foto = (byte[])reader[11];
                        }

                        hulpBehoevende.Hulpverlener = RetrieveHulpverlener(reader.GetInt32(13));
                        hulpbehoevendeList.Add(hulpBehoevende);
                    }

                    reader.Close();
                    _con.Close();

                    return hulpbehoevendeList;
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
            }
        }

        public Hulpverlener RetrieveHulpverlener(int hulpverlenerId)
        {
            try
            {
                var cmdString = "SELECT * FROM Gebruiker AS g WHERE g.id = @id";
                var command = new SqlCommand(cmdString, _con);
                command.Parameters.AddWithValue("@id", hulpverlenerId);
                var reader = command.ExecuteReader();
                var hulpverlener = new Hulpverlener();

                while (reader.Read())
                {
                    hulpverlener.Email = reader.GetString(9);
                    hulpverlener.Telefoonnummer = reader.GetString(10);
                    if (!reader.IsDBNull(11))
                        hulpverlener.Foto = (byte[])reader[11];
                    hulpverlener.Geslacht =
                        (Gebruiker.GebruikerGeslacht)Enum.Parse(typeof(Gebruiker.GebruikerGeslacht), reader.GetString(3));
                    hulpverlener.Huisnummer = reader.GetString(5);
                    hulpverlener.Straat = reader.GetString(4);
                    hulpverlener.Id = reader.GetInt32(0);
                    hulpverlener.Land = reader.GetString(8);
                    hulpverlener.Naam = reader.GetString(1);
                    hulpverlener.Plaats = reader.GetString(7);
                    hulpverlener.Postcode = reader.GetString(6);
                }

                reader.Close();

                return hulpverlener;
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
            }
        }

        public void UpdateHulpbehoevende(Hulpbehoevende hulpbehoevende)
        {
            try
            {
                using (_con)
                {
                    _con.Open();
                    //naam, wachtwoord, geslacht, straat, huisnummer, postcode, plaats, land, e-mail, telefoonnummer, foto
                    var cmdString = "UPDATE Gebruiker SET naam = @naam, wachtwoord = @wachtwoord, geslacht = @geslacht, straat = @straat, huisnummer = @huisnummer, postcode = @postcode, plaats = @plaats, land = @land, email = @email, telefoonnummer = @telefoonnummer, foto = @foto  WHERE id = @id";
                    var command = new SqlCommand(cmdString, _con);
                    command.Parameters.AddWithValue("@naam", hulpbehoevende.Naam);
                    command.Parameters.AddWithValue("@wachtwoord", hulpbehoevende.Wachtwoord);
                    command.Parameters.AddWithValue("@geslacht", hulpbehoevende.Geslacht.ToString());
                    command.Parameters.AddWithValue("@straat", hulpbehoevende.Straat);
                    command.Parameters.AddWithValue("@huisnummer", hulpbehoevende.Huisnummer);
                    command.Parameters.AddWithValue("@postcode", hulpbehoevende.Postcode);
                    command.Parameters.AddWithValue("@plaats", hulpbehoevende.Plaats);
                    command.Parameters.AddWithValue("@land", hulpbehoevende.Land);
                    command.Parameters.AddWithValue("@email", hulpbehoevende.Email);
                    command.Parameters.AddWithValue("@telefoonnummer", hulpbehoevende.Telefoonnummer);
                    command.Parameters.AddWithValue("@foto", hulpbehoevende.Foto);
                    command.Parameters.AddWithValue("@id", hulpbehoevende.Id);
                    command.ExecuteNonQuery();
                    _con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
            }
        }

        public Hulpbehoevende RetrieveHulpbehoevendeById(int id)
        {
            try
            {
                using (_con)
                {
                    _con.Open();
                    var cmdString = "SELECT Gebruiker.*, Hulpbehoevende.hulpverlenerId FROM Gebruiker INNER JOIN Hulpbehoevende ON Gebruiker.id = Hulpbehoevende.gebruikerId WHERE Gebruiker.id = @id";
                    var command = new SqlCommand(cmdString, _con);
                    command.Parameters.AddWithValue("@id", id);
                    var reader = command.ExecuteReader();
                    var hulpbehoevende = new Hulpbehoevende();

                    while (reader.Read())
                    {
                        hulpbehoevende.Email = reader.GetString(9);
                        hulpbehoevende.Wachtwoord = reader.GetString(2);
                        hulpbehoevende.Geslacht =
                            (Gebruiker.GebruikerGeslacht)Enum.Parse(typeof(Gebruiker.GebruikerGeslacht), reader.GetString(3));
                        hulpbehoevende.Huisnummer = reader.GetString(5);
                        hulpbehoevende.Id = reader.GetInt32(0);
                        hulpbehoevende.Straat = reader.GetString(4);
                        hulpbehoevende.Land = reader.GetString(8);
                        hulpbehoevende.Naam = reader.GetString(1);
                        hulpbehoevende.Plaats = reader.GetString(7);
                        hulpbehoevende.Postcode = reader.GetString(6);
                        hulpbehoevende.Telefoonnummer = reader.GetString(10);
                        if (!reader.IsDBNull(11))
                        {
                            hulpbehoevende.Foto = (byte[])reader[11];
                        }
                        if (!reader.IsDBNull(12))
                        {
                            hulpbehoevende.Rfid = reader.GetString(12);
                        }
                        hulpbehoevende.Hulpverlener = RetrieveHulpverlener(reader.GetInt32(13));
                    }

                    reader.Close();
                    _con.Close();
                    return hulpbehoevende;
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
            }
        }

        public int BepaalHulpverlener()
        {
            try
            {
                using (_con)
                {
                    var id = 0;
                    _con.Open();
                    var cmdString = "SELECT TOP 1 Gebruiker.id FROM Gebruiker LEFT JOIN Hulpverlener ON Hulpverlener.gebruikerId = Gebruiker.id LEFT JOIN Hulpbehoevende ON Hulpbehoevende.hulpverlenerId = Hulpverlener.gebruikerId WHERE Gebruiker.id IN(SELECT Hulpverlener.gebruikerId FROM Hulpverlener) GROUP BY Gebruiker.id ORDER BY COUNT(Hulpbehoevende.gebruikerId) ASC";
                    var command = new SqlCommand(cmdString, _con);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        id = reader.GetInt32(0);
                    reader.Close();
                    _con.Close();
                    return id;
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
            }
        }
    }
}