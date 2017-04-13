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
    public class HulpbehoevendeSQLContext : IHulpbehoevendeContext
    {
        private SqlConnection _con = new SqlConnection("Data Source=WIN-SRV-WEB.fhict.local;Initial Catalog=Carespot;User ID=carespot;Password=Test1234;Encrypt=False;TrustServerCertificate=True;MultipleActiveResultSets=true");

        public void CreateHulpbehoevende(int gebruikerId, int hulpverlenerId)
        {

            try
            {
                _con.Open();
                string query1 = "INSERT INTO Hulpbehoevende (gebruikerId, hulpverlenerId) VALUES (@newID,@hulpverlenerId)";
                SqlCommand command1 = new SqlCommand(query1, _con);
                command1.Parameters.AddWithValue("@newID", gebruikerId);
                command1.Parameters.AddWithValue("@hulpverlenerId", hulpverlenerId);


                
                command1.ExecuteScalar();
                _con.Close();
            }
            catch
            {

                System.Windows.MessageBox.Show("woops");
            }

        }

        public void DeleteHulpbehoevende(int id)
        {
            _con.Open();
            string cmdString = "DELETE FROM Gebruiker WHERE id = '" + id + "'";
            SqlCommand command = new SqlCommand(cmdString, _con);
            command.ExecuteNonQuery();
            command.CommandText = "DELETE FROM Hulpbehoevende WHERE = '" + id + "'";
            command.ExecuteNonQuery();
            _con.Close();
        }

        public List<Hulpbehoevende> RetrieveAllHulpbehoevende()
        {
            _con.Open(); string cmdString = "SELECT Gebruiker.*, Hulpbehoevende.hulpverlenerId FROM Gebruiker INNER JOIN Hulpbehoevende ON Gebruiker.id = Hulpbehoevende.gebruikerId WHERE gebruikerType = 'Hulpbehoevende'";
            SqlCommand command = new SqlCommand(cmdString, _con);
            SqlDataReader reader = command.ExecuteReader();
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
            string cmdString = "SELECT * FROM Gebruiker AS g WHERE g.id = '" + hulpverlenerId + "'";
            SqlCommand command = new SqlCommand(cmdString, _con);
            SqlDataReader reader = command.ExecuteReader();
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
            string cmdString = "UPDATE Gebruiker SET naam = '" + hulpbehoevende.Naam + "', wachtwoord = '" + hulpbehoevende.Wachtwoord + "', geslacht = '" + hulpbehoevende.Geslacht + "', straat = '" + hulpbehoevende.Straat + "', huisnummer = '" + hulpbehoevende.Huisnummer + "', postcode = '" + hulpbehoevende.Postcode + "', plaats = '" + hulpbehoevende.Plaats + "', land = '" + hulpbehoevende.Land + "', email = '" + hulpbehoevende.Email + "', telefoonnummer = '" + hulpbehoevende.Telefoonnummer + "', foto = '" + hulpbehoevende.Foto + "'  WHERE id = '" + hulpbehoevende.Id + "'";
            SqlCommand command = new SqlCommand(cmdString, _con);
            command.ExecuteNonQuery();
            _con.Close();
        }

        public Hulpbehoevende RetrieveHulpbehoevendeById(int id)
        {
            _con.Open();
            string cmdString = "SELECT Gebruiker.*, Hulpbehoevende.hulpverlenerId FROM Gebruiker INNER JOIN Hulpbehoevende ON Gebruiker.id = Hulpbehoevende.gebruikerId WHERE Gebruiker.id = '" + id + "'";
            SqlCommand command = new SqlCommand(cmdString, _con);
            SqlDataReader reader = command.ExecuteReader();
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
    }
}