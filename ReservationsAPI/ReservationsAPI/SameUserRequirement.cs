using System;
using Microsoft.AspNetCore.Authorization;

namespace ReservationsAPI
{
    public class SameUserRequirement : IAuthorizationRequirement
    {

    }
}
