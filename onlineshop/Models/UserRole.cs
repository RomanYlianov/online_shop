using Microsoft.AspNetCore.Identity;
using System;

namespace onlineshop.Models
{
    public class UserRole : IdentityUserRole<Guid>
    {

        public UserRole() { }

        public UserRole(Guid uid, Guid rid)
        {
            this.UserId = uid;
            this.RoleId = rid;
        }

    }
}
