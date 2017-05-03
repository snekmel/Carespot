using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using Carespot.DAL.Interfaces;
using Carespot.DAL.Repositorys;
using Carespot.Models;

namespace Carespot.DAL.Context
{
    public class VrijwilligerSQLContext : IVrijwilligerContext
    {
        private readonly SqlConnection _con = new SqlConnection("Data Source=WIN-SRV-WEB.fhict.local;Initial Catalog=Carespot;User ID=carespot;Password=Test1234;Encrypt=False;TrustServerCertificate=True");

        public List<Vrijwilliger> RetrieveAll()
        {
            var returnList = new List<Vrijwilliger>();
            try
            {
                _con.Open();
                var cmdString = "SELECT * FROM Gebruiker INNER JOIN Vrijwilliger ON Gebruiker.id = Vrijwilliger.gebruikerId WHERE Gebruiker.id IN (SELECT gebruikerId FROM Vrijwilliger)";
                var command = new SqlCommand(cmdString, _con);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var g = new Vrijwilliger(reader.GetString(1), reader.GetString(2), reader.GetString(9));
                    g.Id = reader.GetInt32(0);
                    g.Geslacht = (Gebruiker.GebruikerGeslacht)Enum.Parse(typeof(Gebruiker.GebruikerGeslacht), reader.GetString(3));
                    g.Straat = reader.GetString(4);
                    g.Huisnummer = reader.GetString(5);
                    g.Postcode = reader.GetString(6);
                    g.Plaats = reader.GetString(7);
                    g.Land = reader.GetString(8);
                    g.Telefoonnummer = reader.GetString(10);
                    if (!reader.IsDBNull(11))
                        g.Foto = (byte[])reader[11];

                    if (!reader.IsDBNull(12))
                        g.Rfid = reader.GetString(12);
                    returnList.Add(g);
                }
                _con.Close();
            }
            catch
            {
                MessageBox.Show("VrijwilligerSqlContext -> Retrieve all");
            }
            return returnList;
        }

        public void CreateVrijwilliger(int gebruikerId)
        {
            try
            {
                _con.Open();
                var query1 = "INSERT INTO Vrijwilliger (gebruikerId) VALUES (@newID)";
                var command1 = new SqlCommand(query1, _con);
                command1.Parameters.AddWithValue("@newID", gebruikerId);
                command1.ExecuteScalar();
                _con.Close();
            }
            catch
            {
                MessageBox.Show("VrijwilligerSqlContext -> Create Vrijwilliger");
            }
        }

        public Vrijwilliger RetrieveVrijwilliger(int id)
        {
            var gsc = new GebruikerSQLContext();
            var gr = new GebruikerRepository(gsc);
            var g = gr.RetrieveGebruiker(id);

            if (g != null)
            {
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
            return null;
        }

        public void DeleteVrijwilliger(int id)
        {
            _con.Open();
            var cmdString = "DELETE FROM Vrijwilliger WHERE gebruikerId =" + id;
            var command = new SqlCommand(cmdString, _con);
            command.ExecuteNonQuery();
            _con.Close();
        }
    }
}