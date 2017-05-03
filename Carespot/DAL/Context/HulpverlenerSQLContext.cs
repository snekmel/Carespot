using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Carespot.DAL.Interfaces;
using Carespot.DAL.Repositorys;
using Carespot.Models;

namespace Carespot.DAL.Context
{
    public class HulpverlenerSQLContext : IHulpverlenerContext
    {
        private readonly SqlConnection _con =
            new SqlConnection(
                "Data Source=WIN-SRV-WEB.fhict.local;Initial Catalog=Carespot;User ID=carespot;Password=Test1234;Encrypt=False;TrustServerCertificate=True");

        public List<Hulpverlener> RetrieveAll()
        {
            var returnList = new List<Hulpverlener>();
            try
            {
                _con.Open();
                var cmdString =
                    "SELECT * FROM Gebruiker INNER JOIN Hulpverlener ON Gebruiker.id = Hulpverlener.gebruikerId WHERE Gebruiker.id IN(SELECT gebruikerId FROM Hulpverlener)";
                var command = new SqlCommand(cmdString, _con);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var g = new Hulpverlener();

                    g.Naam = reader.GetString(1);
                    g.Wachtwoord = reader.GetString(2);
                    g.Email = reader.GetString(9);
                    g.Id = reader.GetInt32(0);
                    g.Geslacht =
                        (Gebruiker.GebruikerGeslacht)
                        Enum.Parse(typeof(Gebruiker.GebruikerGeslacht), reader.GetString(3));
                    g.Straat = reader.GetString(4);
                    g.Huisnummer = reader.GetString(5);
                    g.Postcode = reader.GetString(6);
                    g.Plaats = reader.GetString(7);
                    g.Land = reader.GetString(8);
                    g.Telefoonnummer = reader.GetString(10);
                    if (!reader.IsDBNull(11))
                    {
                        g.Foto = (byte[])reader[11];
                    }

                    if (!reader.IsDBNull(12))
                    {
                        g.Rfid = reader.GetString(12);
                    }

                    returnList.Add(g);
                }
                _con.Close();
                return returnList;
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
            }
        }

        public void CreateHulpverlener(int gebruikerId)
        {
            try
            {
                _con.Open();
                var query1 = "INSERT INTO Hulpverlener (gebruikerId) VALUES (@newID)";
                var command1 = new SqlCommand(query1, _con);
                command1.Parameters.AddWithValue("@newID", gebruikerId);
                command1.ExecuteScalar();

                _con.Close();
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
            }
        }

        public Hulpverlener RetrieveHulpverlener(int id)
        {
            var gsc = new GebruikerSQLContext();
            var gr = new GebruikerRepository(gsc);
            var g = gr.RetrieveGebruiker(id);

            var h = new Hulpverlener();
            h.Id = g.Id;
            h.Naam = g.Naam;
            h.Wachtwoord = g.Wachtwoord;
            h.Geslacht = g.Geslacht;
            h.Straat = g.Straat;
            h.Huisnummer = g.Huisnummer;
            h.Postcode = g.Postcode;
            h.Plaats = g.Plaats;
            h.Land = g.Land;
            h.Email = g.Email;
            h.Telefoonnummer = g.Telefoonnummer;
            h.Foto = g.Foto;

            return h;
        }

        public void DeleteHulpverlener(int id)
        {
            try
            {
                _con.Open();

                var cmdString = "UPDATE Hulpbehoevende SET hulpverlenerId = @hulpid WHERE hulpverlenerId = @id";
                var command = new SqlCommand(cmdString, _con);
                int hulpid = CheckHulpverlener(id);
                command.Parameters.AddWithValue("@hulpid", hulpid);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();

                var cmdStringOpdracht = "UPDATE Hulpopdracht SET hulpverlenerId = @hulpid WHERE hulpverlenerId = @id";
                var commandOpdracht = new SqlCommand(cmdStringOpdracht, _con);
                commandOpdracht.Parameters.AddWithValue("@hulpid", hulpid);
                commandOpdracht.Parameters.AddWithValue("@id", id);
                commandOpdracht.ExecuteNonQuery();

                var cmdString1 = "DELETE FROM Hulpverlener WHERE gebruikerId = @id";
                var command1 = new SqlCommand(cmdString1, _con);
                command1.Parameters.AddWithValue("@id", id);
                command1.ExecuteNonQuery();

                _con.Close();
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
            }
        }

        private int CheckHulpverlener(int id)
        {
            var idt = 0;
            // _con.Open();
            var cmdString = "SELECT TOP 1 Gebruiker.id FROM Gebruiker LEFT JOIN Hulpverlener ON Hulpverlener.gebruikerId = Gebruiker.id LEFT JOIN Hulpbehoevende ON Hulpbehoevende.hulpverlenerId = Hulpverlener.gebruikerId WHERE Gebruiker.id IN(SELECT Hulpverlener.gebruikerId FROM Hulpverlener) AND Gebruiker.id != @id  GROUP BY Gebruiker.id ORDER BY COUNT(Hulpbehoevende.gebruikerId) ASC";
            var command = new SqlCommand(cmdString, _con);
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            while (reader.Read())
                idt = reader.GetInt32(0);
            reader.Close();
            // _con.Close();
            return idt;
        }
    }
}