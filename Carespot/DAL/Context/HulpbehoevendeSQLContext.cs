using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using Carespot.DAL.Interfaces;
using Carespot.DAL.Repositorys;
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
                _con.Open();
                var query1 = "INSERT INTO Hulpbehoevende (gebruikerId, hulpverlenerId) VALUES (@newID,@hulpverlenerId)";
                var command1 = new SqlCommand(query1, _con);
                command1.Parameters.AddWithValue("@newID", gebruikerId);
                command1.Parameters.AddWithValue("@hulpverlenerId", hulpverlenerId);

                command1.ExecuteScalar();
                _con.Close();
            }
            catch
            {
                MessageBox.Show("HulpbehoevendeSQLContext -> CreateHulpbehoevende");
            }
        }

        public void DeleteHulpbehoevende(int id)
        {
            _con.Open();
            var cmdString = "DELETE FROM Gebruiker WHERE id = '" + id + "'";
            var command = new SqlCommand(cmdString, _con);
            command.ExecuteNonQuery();
            command.CommandText = "DELETE FROM Hulpbehoevende WHERE gebruikerId = '" + id + "'";
            command.ExecuteNonQuery();
            _con.Close();
        }

        public List<Hulpbehoevende> RetrieveAllHulpbehoevende()
        {
            _con.Open();
            var cmdString = "SELECT Gebruiker.*, Hulpbehoevende.hulpverlenerId FROM Gebruiker INNER JOIN Hulpbehoevende ON Gebruiker.id = Hulpbehoevende.gebruikerId WHERE gebruikerType = 'Hulpbehoevende'";
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

                hulpBehoevende.Hulpverlener = RetrieveHulpverlener(reader.GetInt32(13));
                hulpbehoevendeList.Add(hulpBehoevende);
            }
            reader.Close();
            _con.Close();

            return hulpbehoevendeList;
        }

        public Hulpverlener RetrieveHulpverlener(int hulpverlenerId)
        {
            var cmdString = "SELECT * FROM Gebruiker AS g WHERE g.id = '" + hulpverlenerId + "'";
            var command = new SqlCommand(cmdString, _con);
            var reader = command.ExecuteReader();
            var hulpverlener = new Hulpverlener();

            while (reader.Read())
            {
                hulpverlener.Email = reader.GetString(9);

                hulpverlener.Geslacht =
                    (Gebruiker.GebruikerGeslacht)Enum.Parse(typeof(Gebruiker.GebruikerGeslacht), reader.GetString(3));
                hulpverlener.Huisnummer = reader.GetString(5);
                hulpverlener.Id = reader.GetInt32(0);
                hulpverlener.Land = reader.GetString(8);
                hulpverlener.Naam = reader.GetString(1);
                hulpverlener.Plaats = reader.GetString(7);
                hulpverlener.Postcode = reader.GetString(6);
            }

            reader.Close();

            return hulpverlener;
        }

        public void UpdateHulpbehoevende(Hulpbehoevende hulpbehoevende)
        {
            _con.Open();
            //naam, wachtwoord, geslacht, straat, huisnummer, postcode, plaats, land, e-mail, telefoonnummer, foto
            var cmdString = "UPDATE Gebruiker SET naam = '" + hulpbehoevende.Naam + "', wachtwoord = '" + hulpbehoevende.Wachtwoord + "', geslacht = '" + hulpbehoevende.Geslacht + "', straat = '" + hulpbehoevende.Straat + "', huisnummer = '" + hulpbehoevende.Huisnummer + "', postcode = '" + hulpbehoevende.Postcode + "', plaats = '" + hulpbehoevende.Plaats + "', land = '" + hulpbehoevende.Land + "', email = '" + hulpbehoevende.Email + "', telefoonnummer = '" + hulpbehoevende.Telefoonnummer + "', foto = '" + hulpbehoevende.Foto + "'  WHERE id = '" + hulpbehoevende.Id + "'";
            var command = new SqlCommand(cmdString, _con);
            command.ExecuteNonQuery();
            _con.Close();
        }

        public Hulpbehoevende RetrieveHulpbehoevendeById(int id)
        {
            _con.Open();
            var cmdString = "SELECT Gebruiker.*, Hulpbehoevende.hulpverlenerId FROM Gebruiker INNER JOIN Hulpbehoevende ON Gebruiker.id = Hulpbehoevende.gebruikerId WHERE Gebruiker.id = '" + id + "'";
            var command = new SqlCommand(cmdString, _con);
            var reader = command.ExecuteReader();
            var hulpbehoevende = new Hulpbehoevende();

            while (reader.Read())
            {
                hulpbehoevende.Email = reader.GetString(9);

                hulpbehoevende.Geslacht =
                    (Gebruiker.GebruikerGeslacht)Enum.Parse(typeof(Gebruiker.GebruikerGeslacht), reader.GetString(3));
                hulpbehoevende.Huisnummer = reader.GetString(5);
                hulpbehoevende.Id = reader.GetInt32(0);
                hulpbehoevende.Land = reader.GetString(8);
                hulpbehoevende.Naam = reader.GetString(1);
                hulpbehoevende.Plaats = reader.GetString(7);
                hulpbehoevende.Postcode = reader.GetString(6);
                hulpbehoevende.Hulpverlener = RetrieveHulpverlener(reader.GetInt32(13));
            }

            reader.Close();
            _con.Close();
            return hulpbehoevende;
        }

        public int BepaalHulpverlener()
        {
            var id = 0;
            _con.Open();
            var cmdString = "SELECT TOP 1 g.id FROM Hulpbehoevende AS hb INNER JOIN Hulpverlener AS hv ON hv.gebruikerId = hb.hulpverlenerId INNER JOIN Gebruiker AS g ON g.id = hv.gebruikerId GROUP BY g.id ORDER BY COUNT(hb.gebruikerId) ASC";
            var command = new SqlCommand(cmdString, _con);
            var reader = command.ExecuteReader();
            while (reader.Read())
                id = reader.GetInt32(0);
            reader.Close();
            _con.Close();
            return id;
        }

        public List<Hulpbehoevende> RetrieveAll()
        {
            var returnList = new List<Hulpbehoevende>();
            try
            {
                using (_con)
                {
                    _con.Open();
                    var cmdString = "SELECT * FROM Gebruiker INNER JOIN Hulpbehoevende ON Gebruiker.id = Hulpbehoevende.gebruikerId WHERE Gebruiker.id IN (SELECT gebruikerId FROM Hulpbehoevende)";
                    var command = new SqlCommand(cmdString, _con);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var g = new Hulpbehoevende(reader.GetString(1), reader.GetString(2), reader.GetString(9));
                        g.Id = reader.GetInt32(0);
                        g.Geslacht = (Gebruiker.GebruikerGeslacht)Enum.Parse(typeof(Gebruiker.GebruikerGeslacht), reader.GetString(3));
                        g.Straat = reader.GetString(4);
                        g.Huisnummer = reader.GetString(5);
                        g.Postcode = reader.GetString(6);
                        g.Plaats = reader.GetString(7);
                        g.Land = reader.GetString(8);
                        g.Telefoonnummer = reader.GetString(10);
                        if (reader[11] != null)
                            g.Foto = (byte[])reader[11];
                        returnList.Add(g);
                    }
                    _con.Close();
                }
            }
            catch
            {
                MessageBox.Show("HulpbehoevendeSQLContext -> Retrieve all");
            }
            return returnList;
        }

        public Vrijwilliger RetrieveVrijwilliger(int id)
        {
            var gsc = new GebruikerSQLContext();
            var gr = new GebruikerRepository(gsc);
            var g = gr.RetrieveGebruiker(id);

            var v = new Vrijwilliger();
            v.Id = g.Id;
            v.Naam = g.Naam;
            v.Wachtwoord = g.Wachtwoord;
            v.Geslacht = g.Geslacht;
            v.Straat = g.Straat;
            v.Huisnummer = g.Huisnummer;
            v.Postcode = g.Postcode;
            v.Plaats = g.Plaats;
            v.Land = g.Land;
            v.Email = g.Email;
            v.Telefoonnummer = g.Telefoonnummer;
            v.Foto = g.Foto;

            return v;
        }
    }
}