using onlineshop.Models;
using onlineshop.Services.DTO;

namespace onlineshop.Services.Mapper
{
    public interface IBasketMapper
    {
        Basket ToEntity(BasketDTO dto);

        BasketDTO ToDTO(Basket entity);
    }
}