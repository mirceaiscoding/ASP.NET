using System;
using Microsoft.AspNetCore.Identity;
using ReservationsAPI.DAL.Entities;

namespace ReservationsAPI.DAL
{
    public class InitialSeed
    {
        private readonly RoleManager<Role> _roleManager;

        public InitialSeed(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async void CreateRoles()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            string[] roleNames =
            {
                "Admin",
                "Doctor",
                "Pacient"
            };
            foreach(var roleName in roleNames)
            {
                var role = new Role
                {
                    Name = roleName
                };

                _roleManager.CreateAsync(role).Wait();
            }
        }
    }
}
