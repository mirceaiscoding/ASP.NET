using System;
using System.Threading.Tasks;
using ReservationsAPI.DAL.Entities;

namespace ReservationsAPI.BLL.Interfaces
{
    public interface ITokenHelper
    {
        Task<string> CreateAccessToken(User user);
    }
}
