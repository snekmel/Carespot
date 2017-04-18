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
    public class HulpverlenerSQLContext : IHulpverlenerContext
    {
        private readonly SqlConnection _con =
           new SqlConnection(
               "Data Source=WIN-SRV-WEB.fhict.local;Initial Catalog=Carespot;User ID=carespot;Password=Test1234;Encrypt=False;TrustServerCertificate=True");

        public List<Hulpverlener> RetrieveAll()
        {
            throw new NotImplementedException();
        }

        public void CreateHulpverlener(int gebruikerId)
        {
            try
            {
                _con.Open();
                string query1 = "INSERT INTO Hulpverlener (gebruikerId) VALUES (@newID)";
                SqlCommand command1 = new SqlCommand(query1, _con);
                command1.Parameters.AddWithValue("@newID", gebruikerId);
                command1.ExecuteScalar();

                _con.Close();
            }
            catch
            {
                System.Windows.MessageBox.Show("woops");
            }
        }

        public Hulpverlener RetrieveHulpverlener(int id)
        {
         GebruikerSQLContext gsc = new GebruikerSQLContext();
         GebruikerRepository gr = new GebruikerRepository(gsc);
         Gebruiker g = gr.RetrieveGebruiker(id);

          Hulpverlener h = new Hulpverlener();
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
                using (_con)
                {
                    _con.Open();
                    var cmdString = "DELETE FROM Hulpverlener WHERE gebruikerId =" + id;
                    var command = new SqlCommand(cmdString, _con);
                    command.ExecuteNonQuery();
                    _con.Close();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e + "");
            }
       
        }
    }
}