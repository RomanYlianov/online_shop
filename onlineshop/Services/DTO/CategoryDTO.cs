using System.ComponentModel.DataAnnotations;

namespace onlineshop.Services.DTO
{
    public class CategoryDTO
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Description must be between 4 and 50")]
        public string Description { get; set; }
    }
}