using Carespot.DAL.Interfaces;
using Carespot.Models;

namespace Carespot.DAL.Repositorys
{
    public class BeoordelingRepository
    {
        private readonly IBeoordelingContext _context;

        public BeoordelingRepository(IBeoordelingContext context)
        {
            _context = context;
        }

        public Beoordeling RetrieveBeoordeling(int vrijwilligerId)
        {
            return _context.RetrieveBeoordeling(vrijwilligerId);
        }

        public void Create(Beoordeling beoordeling)
        {
            _context.Create(beoordeling);
        }

        public void Delete(int id)
        {
            _context.Delete(id);
        }
    }
}