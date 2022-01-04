using System;
using System.Threading.Tasks;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Models;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI.BLL.Interfaces
{
    public interface IAuthManager
    {
        Task<bool> Register(RegisterModel registerModel);

        Task<int?> RegisterAsPacient(RegisterModel registerModel);

        Task<int?> RegisterAsDoctor(RegisterModel registerModel);

        Task<LoginResult> Login(LoginModel loginModel);

        Task<RefreshTokenResult> Refresh(RefreshModel refreshModel);
    }
}
