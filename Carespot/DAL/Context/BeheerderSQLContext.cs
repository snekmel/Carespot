using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Carespot.DAL.Interfaces;
using Carespot.DAL.Repositorys;
using Carespot.Models;

namespace Carespot.DAL.Context
{
    public class BeheerderSQLContext : IBeheerderContext
    {
        private readonly SqlConnection _con = new SqlConnection("Data Source=WIN-SRV-WEB.fhict.local;Initial Catalog=Carespot;User ID=carespot;Password=Test1234;Encrypt=False;TrustServerCertificate=True");

        public List<Beheerder> RetrieveAll()
        {
            var returnList = new List<Beheerder>();
            try
            {
                using (_con)
                {
                    _con.Open();
                    var cmdString = "SELECT * FROM Gebruiker INNER JOIN Beheerder ON Gebruiker.id = Beheerder.gebruikerId WHERE Gebruiker.id IN(SELECT gebruikerId FROM Beheerder)";
                    var command = new SqlCommand(cmdString, _con);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var g = new Beheerder(reader.GetString(1), reader.GetString(2), reader.GetString(9));
                        g.Id = reader.GetInt32(0);
                        g.Geslacht = (Gebruiker.GebruikerGeslacht) Enum.Parse(typeof(Gebruiker.GebruikerGeslacht), reader.GetString(3));
                        g.Straat = reader.GetString(4);
                        g.Huisnummer = reader.GetString(5);
                        g.Postcode = reader.GetString(6);
                        g.Plaats = reader.GetString(7);
                        g.Land = reader.GetString(8);
                        g.Telefoonnummer = reader.GetString(10);
                        if (!reader.IsDBNull(11))
                            g.Foto = (byte[]) reader[11];
                        returnList.Add(g);
                    }
                    _con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
            }
            return returnList;
        }

        public void CreateBeheerder(int gebruikerId)
        {
            try
            {
                using (_con)
                {
                    _con.Open();
                    var query1 = "INSERT INTO Beheerder (gebruikerId) VALUES (@newID)";
                    var command1 = new SqlCommand(query1, _con);
                    command1.Parameters.AddWithValue("@newID", gebruikerId);
                    command1.ExecuteScalar();

                    _con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
            }
        }

        public Beheerder RetrieveBeheerder(int id)
        {
            var gsc = new GebruikerSQLContext();
            var gr = new GebruikerRepository(gsc);
            var g = gr.RetrieveGebruiker(id);

            var b = new Beheerder();
            b.Id = g.Id;
            b.Naam = g.Naam;
            b.Wachtwoord = g.Wachtwoord;
            b.Geslacht = g.Geslacht;
            b.Straat = g.Straat;
            b.Huisnummer = g.Huisnummer;
            b.Postcode = g.Postcode;
            b.Plaats = g.Plaats;
            b.Land = g.Land;
            b.Email = g.Email;
            b.Telefoonnummer = g.Telefoonnummer;
            b.Foto = g.Foto;

            return b;
        }

        public void DeleteBeheerder(int id)
        {
            try
            {
                using (_con)
                {
                    _con.Open();
                    var cmdString = "DELETE FROM Beheerder WHERE gebruikerId =" + id;
                    var command = new SqlCommand(cmdString, _con);
                    command.ExecuteNonQuery();
                    _con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
            }
        }
    }
}