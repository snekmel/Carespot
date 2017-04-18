using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                using (_con)
                {
                    _con.Open();
                    var cmdString = "SELECT * FROM Gebruiker INNER JOIN Vrijwilliger ON Gebruiker.id = Vrijwilliger.gebruikerId WHERE Gebruiker.id IN (SELECT gebruikerId FROM Vrijwilliger)";
                    var command = new SqlCommand(cmdString, _con);
                    var reader = command.ExecuteReader();
                   
                    while (reader.Read())
                    {
                        Vrijwilliger g = new Vrijwilliger(reader.GetString(1), reader.GetString(2), reader.GetString(9));
                        g.Id = reader.GetInt32(0);
                        g.Geslacht = (Gebruiker.GebruikerGeslacht)Enum.Parse(typeof(Gebruiker.GebruikerGeslacht), reader.GetString(3));
                        g.Straat = reader.GetString(4);
                        g.Huisnummer = reader.GetString(5);
                        g.Postcode = reader.GetString(6);
                        g.Plaats = reader.GetString(7);
                        g.Land = reader.GetString(8);                     
                        g.Telefoonnummer = reader.GetString(10);                                       
                        if (reader[11] != null)
                        {
                            g.Foto = (byte[])reader[11];
                        }
                        returnList.Add(g);
                    }
                    _con.Close();
                }
                
            }
            catch
            {
                System.Windows.MessageBox.Show("VrijwilligerSqlContext -> Retrieve all");
            }
            return returnList;

        }

        public void CreateVrijwilliger(int gebruikerId)
        {
            try
            {
                _con.Open();
                string query1 = "INSERT INTO Vrijwilliger (gebruikerId) VALUES (@newID)";
                SqlCommand command1 = new SqlCommand(query1, _con);
                command1.Parameters.AddWithValue("@newID", gebruikerId);
                command1.ExecuteScalar();
                _con.Close();
            }
            catch
            {
                System.Windows.MessageBox.Show("VrijwilligerSqlContext -> Create Vrijwilliger");
            }
        }

        public Vrijwilliger RetrieveVrijwilliger(int id)
        {
            GebruikerSQLContext gsc = new GebruikerSQLContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);
            Gebruiker g = gr.RetrieveGebruiker(id);

            Vrijwilliger v = new Vrijwilliger();
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