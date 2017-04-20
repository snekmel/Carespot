using System.Collections.Generic;
using Carespot.DAL.Context;
using Carespot.DAL.Interfaces;
using Carespot.Models;

namespace Carespot.DAL.Repositorys
{
    public class GebruikerRepository
    {
        private readonly IGebruikerContext _interface;

        public GebruikerRepository(IGebruikerContext i)
        {
            _interface = i;
        }

        public GebruikerRepository()
        {
        }

        public List<Gebruiker> RetrieveAll()
        {
            var bsc = new BeheerderSQLContext();
            var br = new BeheerderRepository(bsc);
            var hbsc = new HulpbehoevendeSQLContext();
            var hbr = new HulpbehoevendeRepository(hbsc);
            var hvsc = new HulpverlenerSQLContext();
            var hvr = new HulpverlenerRepository(hvsc);
            var vsc = new VrijwilligerSQLContext();
            var vr = new VrijwilligerRepository(vsc);

            var LsGebr = new List<Gebruiker>();
            LsGebr.AddRange(br.RetrieveAll());
            LsGebr.AddRange(hbr.RetrieveAll());
            LsGebr.AddRange(hvr.RetrieveAll());
            LsGebr.AddRange(vr.RetrieveAll());

            //haal al de types.RetrieveAll op en voeg deze samen tot 1 lijst.
            return LsGebr;
        }

        public int CreateGebruiker(Gebruiker g)
        {
            return _interface.CreateGebruiker(g);
        }

        public void UpdateGebruiker(Gebruiker g)
        {
            _interface.UpdateGebruiker(g);
        }

        public Gebruiker RetrieveGebruiker(int id)
        {
            return _interface.RetrieveGebruiker(id);
        }
    }
}