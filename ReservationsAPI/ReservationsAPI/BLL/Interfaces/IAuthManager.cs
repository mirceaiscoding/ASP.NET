using System;
using System.Threading.Tasks;
using ReservationsAPI.DAL.Models;

namespace ReservationsAPI.BLL.Interfaces
{
    public interface IAuthManager
    {
        Task<RegisterResult> Register(RegisterModel registerModel);

        Task<LoginResult> Login(LoginModel loginModel);

        Task<string> Refresh(RefreshModel refreshModel);
    }
}
