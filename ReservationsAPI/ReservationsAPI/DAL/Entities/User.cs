using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ReservationsAPI.DAL.Entities
{
    public class User : IdentityUser<int>
    {
        public string RefreshToken { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
