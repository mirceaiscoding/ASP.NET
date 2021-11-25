using System;
using ReservationsAPI.DAL.Entities;

namespace ReservationsAPI.DAL.Interfaces
{
    public interface IProceduresRepository : IGenericRepository<Procedure>
    {
        void UpdateCost(long id, int newCost);
    }
}
