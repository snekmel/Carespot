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
        private SqlConnection _con = new SqlConnection("Data Source=WIN-SRV-WEB.fhict.local;Initial Catalog=Carespot;User ID=carespot;Password=Test1234;Encrypt=False;TrustServerCertificate=True");

        public void Create(Gebruiker obj)
        {
            throw new NotImplementedException();
        }

        public Gebruiker Retrieve(int id)
        {
            throw new NotImplementedException();
        }

        public List<Gebruiker> RetrieveAll()
        {
            _con.Open();
            string cmdString = "SELECT * FROM Gebruiker";
            SqlCommand command = new SqlCommand(cmdString, _con);
            SqlDataReader reader = command.ExecuteReader();
            List<Gebruiker> ReturnList = new List<Gebruiker>();

            while (reader.Read())
            {
                switch (reader.GetString(11))
                {

                    case "Hulpverlener":
                       Hulpverlener g = new Hulpverlener(reader.GetString(1), reader.GetString(2), reader.GetString(9));
                        g.Id = reader.GetInt32(0);
                        g.Naam = reader.GetString(1);
                        g.Wachtwoord = reader.GetString(2);              
                        
                        if (reader.GetString(3) == "Man" || reader.GetString(3) == "man")
                        {
                            g.Geslacht = Gebruiker.GebruikerGeslacht.Man;
                        }
                        else if (reader.GetString(3) == "Vrouw" || reader.GetString(3) == "vrouw")
                        {
                            g.Geslacht = Gebruiker.GebruikerGeslacht.Vrouw;
                        }
                        g.Straat = reader.GetString(4);
                        g.Huisnummer = reader.GetString(5);
                        g.Postcode = reader.GetString(6);
                        g.Plaats = reader.GetString(7);
                        g.Land = reader.GetString(8);
                        g.Email = reader.GetString(9);
                        g.Telefoonnummer = reader.GetString(10);
                        g.Type = (Gebruiker.GebruikerType)Enum.Parse(typeof(Gebruiker.GebruikerType), reader.GetString(11));
                        g.Foto = reader.GetString(12);
                        ReturnList.Add(g);
                     break;

                    case "Hulpbehoevende":
                      
                    case "Beheerder":
                        break;

                    case "Vrijwilliger":
                        break;

                }
            }

            _con.Close();

            return ReturnList;
        }

        public void Update(int id, Gebruiker obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}