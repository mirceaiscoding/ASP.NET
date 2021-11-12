using System;
using System.Threading.Tasks;
using ReservationsAPI.DAL.Entities;

namespace ReservationsAPI.BLL.Interfaces
{
    public interface ITokenHelper
    {
        Task<String> CreateAccessToke(User user);
    }
}
