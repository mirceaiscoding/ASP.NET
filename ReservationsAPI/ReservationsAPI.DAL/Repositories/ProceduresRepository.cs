using System;
using System.Linq;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Interfaces;

namespace ReservationsAPI.DAL.Repositories
{
    public class ProceduresRepository : GenericRepository<Procedure>, IProceduresRepository
    {
        public ProceduresRepository(ReservationsContext context) : base(context) { }

        public void UpdateCost(long id, int newCost)
        {
            var procedure = new Procedure()
            {
                Id = id,
                Cost = newCost
            };
            _context.Procedures.Attach(procedure);
            _context.Entry(procedure).Property(x => x.Cost).IsModified = true;
            _context.SaveChanges();
        }
    }
}
