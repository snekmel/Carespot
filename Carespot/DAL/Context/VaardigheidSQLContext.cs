using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Carespot.DAL.Interfaces;
using Carespot.Models;

namespace Carespot.DAL.Context
{
    internal class VaardigheidSQLContext : IVaardigheidContext
    {
        private readonly SqlConnection _con =
            new SqlConnection(
                "Data Source=WIN-SRV-WEB.fhict.local;Initial Catalog=Carespot;User ID=carespot;Password=Test1234;Encrypt=False;TrustServerCertificate=True");

        public void Create(Vaardigheid obj)
        {
            throw new NotImplementedException();
        }

        public Vaardigheid Retrieve(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}