using Microsoft.Extensions.Logging;
using onlineshop.Models;
using onlineshop.Services.DTO;
using onlineshop.Services.Mapper.Implimentation;

namespace onlineshop.Services.Mapper
{
    public interface ICategoryMapper
    {

        CategoryDTO ToDTO(Category entity);

        Category ToEntity(CategoryDTO dto);

    }
}
