using onlineshop.Models;
using onlineshop.Services.DTO;

namespace onlineshop.Services.Mapper
{
    public interface IProductMapper
    {

        Product ToEntity(ProductDTO dto);

        ProductDTO ToDTO(Product entity);

    }
}
