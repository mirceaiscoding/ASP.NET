using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI
{
    public class PacientDataAuthorizationHandler : AuthorizationHandler<SameUserRequirement, PacientDTO>
    {
        private readonly UserManager<User> _userManager;

        PacientDataAuthorizationHandler()
        {
            
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SameUserRequirement requirement, PacientDTO resource)
        {

            if (resource.Id == _userManager.GetUserId(context.User))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
