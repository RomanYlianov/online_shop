namespace onlineshop.Services.DTO
{
    public class UserSearchDTO
    {
        //main parameter
        public string Email { get; set; }

        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public string[] RoleIds { get; set; }
    }
}