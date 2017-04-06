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
        private SqlConnection _con = new SqlConnection("Data Source=WIN-SRV-WEB.fhict.local;Initial Catalog=Carespot;User ID=carespot;Password=Test1234;Encrypt=False;TrustServerCertificate=True");

        public void CreateHulpbehoevende(string naam, string wachtwoord, string geslacht, string straat, string huisnummer, string postcode, string plaats, string land, string email, string telefoon, string gebruikertype)
        {
            throw new NotImplementedException();
        }

        public void DeleteHulpbehoevende(int id)
        {
            _con.Open();
            string cmdString = "DELETE FROM Gebruiker WHERE id = '" + id + "'";
            SqlCommand command = new SqlCommand(cmdString, _con);
            command.ExecuteNonQuery();
            _con.Close();
        }

        public List<Hulpbehoevende> RetrieveAllHulpbehoevende()
        {
            throw new NotImplementedException();
        }

        public Hulpverlener RetrieveHulpverlener(int hulpverlenerId)
        {
            _con.Open(); string cmdString = "SELECT * FROM Gebruiker AS g WHERE g.id = '" + hulpverlenerId + "'";
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

            _con.Close();
            reader.Close();
            return hulpverlener;
        }

        public void UpdateHulpbehoevende(Hulpbehoevende hulpbehoevende)
        {
            throw new NotImplementedException();
        }
    }
}