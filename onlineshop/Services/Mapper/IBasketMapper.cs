using Microsoft.Extensions.Logging;
using onlineshop.Models;
using onlineshop.Services.DTO;
using onlineshop.Services.Mapper.Implimentation;

namespace onlineshop.Services.Mapper
{
    public interface IBasketMapper
    {
        Basket ToEntity(BasketDTO dto);

        BasketDTO ToDTO(Basket entity);

    }
}
