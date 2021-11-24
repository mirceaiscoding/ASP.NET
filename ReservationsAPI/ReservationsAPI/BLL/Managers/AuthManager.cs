using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ReservationsAPI.BLL.Interfaces;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Models;

namespace ReservationsAPI.BLL.Managers
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(UserManager<User> userManager,
            SignInManager<User> signInManager,
            ITokenHelper tokenHelper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHelper = tokenHelper;
        }

        public Task<string> Login(LoginModel loginModel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Register(RegisterModel registerModel)
        {
            var user = new User
            {
                Email = registerModel.Email,
                UserName = registerModel.Email,
            };

            // Encrypt password
            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, registerModel.Role);
                return true;
            }
            return false;
        }
    }
}
