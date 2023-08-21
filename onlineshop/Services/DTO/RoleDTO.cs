using System.ComponentModel.DataAnnotations;

namespace onlineshop.Services.DTO
{
    public class RoleDTO
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(256, MinimumLength = 4, ErrorMessage = "Name must be between 4 and 256")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(256, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 256")]
        public string Description { get; set; }
    }
}