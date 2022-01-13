using System;
using System.Security.Claims;
using System.Threading.Tasks;
using ReservationsAPI.DAL.Entities;

namespace ReservationsAPI.BLL.Interfaces
{
    public interface ITokenHelper
    {
        Task<string> CreateAccessToken(User user);

        public string CreateRefreshToken();

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string _Token);
    }
}
