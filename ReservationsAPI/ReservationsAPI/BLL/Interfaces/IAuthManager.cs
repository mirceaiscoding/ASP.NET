﻿using System;
using System.Threading.Tasks;
using ReservationsAPI.DAL.Models;

namespace ReservationsAPI.BLL.Interfaces
{
    public interface IAuthManager
    {
        Task<bool> Register(RegisterModel registerModel);
        Task<string> Login(LoginModel loginModel);
    }
}
