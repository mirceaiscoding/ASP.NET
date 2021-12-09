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

        Task<bool> RegisterAsPacient(RegisterModel registerModel, PacientDTO pacientDTO);

        Task<LoginResult> Login(LoginModel loginModel);

        Task<string> Refresh(RefreshModel refreshModel);
    }
}
