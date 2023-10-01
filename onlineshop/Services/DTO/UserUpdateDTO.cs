using System;
using System.Collections.Generic;

namespace onlineshop.Services.DTO
{
    public class UserUpdateDTO : UserRegisterDTO
    {
        public DateTime CreationTime { get; set; }

        public List<string> OtherRoles { get; set; }

        public List<string> OtherSupplerFirms { get; set; }

    }
}