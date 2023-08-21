using onlineshop.Models;
using onlineshop.Services.DTO;

namespace onlineshop.Services.Mapper
{
    public interface ICategoryMapper
    {
        CategoryDTO ToDTO(Category entity);

        Category ToEntity(CategoryDTO dto);
    }
}