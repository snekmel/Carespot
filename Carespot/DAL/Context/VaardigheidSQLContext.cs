using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Carespot.DAL.Interfaces;
using Carespot.Models;

namespace Carespot.DAL.Context
{
    public class VaardigheidSQLContext : IVaardigheidContext
    {
        private readonly SqlConnection _con =
            new SqlConnection(
                "Data Source=WIN-SRV-WEB.fhict.local;Initial Catalog=Carespot;User ID=carespot;Password=Test1234;Encrypt=False;TrustServerCertificate=True");

        public void Create(Vaardigheid obj)
        {
            _con.Open();
            var cmdString = "INSERT INTO Vaardigheid (vaardigheid)VALUES('" + obj.VaardigheidText + "'); ";
            var command = new SqlCommand(cmdString, _con);
            var reader = command.ExecuteReader();
            _con.Close();
        }

        public Vaardigheid Retrieve(int id)
        {
            _con.Open();
            var cmdString = "SELECT * FROM Vaardigheid WHERE id = " + id;
            var command = new SqlCommand(cmdString, _con);
            var reader = command.ExecuteReader();
            Vaardigheid v = null;
            while (reader.Read())
            {
                v = new Vaardigheid(reader.GetString(1));
                v.Id = reader.GetInt32(0);
            }

            _con.Close();
            return v;
        }

        public List<Vaardigheid> RetrieveAll()
        {
            _con.Open();
            var cmdString = "SELECT * FROM Vaardigheid";
            var command = new SqlCommand(cmdString, _con);
            var reader = command.ExecuteReader();
            var returnList = new List<Vaardigheid>();
            while (reader.Read())
            {
                var v = new Vaardigheid(reader.GetString(1));
                v.Id = reader.GetInt32(0);
                returnList.Add(v);
            }

            _con.Close();

            return returnList;
        }

        public void Update(int id, Vaardigheid obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            _con.Open();
            var cmdString = "DELETE FROM Vaardigheid WHERE id =" + id;
            var command = new SqlCommand(cmdString, _con);
            var reader = command.ExecuteReader();
            _con.Close();
        }
    }
}