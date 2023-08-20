using System;
using System.ComponentModel.DataAnnotations;

namespace onlineshop.Services.DTO
{
    public class CommentDTO
    {
        
        public string Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Title must be between 4 and 50")]
        public string Title { get; set; }

        public UserDTO AuthorDTO { get; set; }

        [Required(ErrorMessage = "Author is requred")]
        //[StringLength(50, MinimumLength = 4, ErrorMessage = "Author must be between 4 and 50")]
        public string AuthorDTOId { get; set; }

        //[Required(ErrorMessage = "ProductDTO is required")]
        public ProductDTO ProductDTO { get; set; }

        [Required(ErrorMessage = "ProductDTOId is required")]
        //[Range(1 , int.MaxValue, ErrorMessage = "ProductDTOId must be positive")]
        public string ProductDTOId { get; set; }

        [Required(ErrorMessage = "Text is required")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "text must be between 10 and 1000")]
        public string Text { get; set; }

        [Required(ErrorMessage = "CreationTime is required")]
        public DateTime CreationTime { get; set; }

        //[Required(ErrorMessage = "ModificationTime is required")]
        public DateTime? ModificationTime { get; set; }  

    }
}
