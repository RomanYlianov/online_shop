using Microsoft.Extensions.Logging;
using onlineshop.Models;
using onlineshop.Services.DTO;
using onlineshop.Services.Mapper.Implimentation;

namespace onlineshop.Services.Mapper
{
    public interface IDeliveryMethodMapper
    {

        DeliveryMethodDTO ToDTO(DeliveryMethod entity);

        DeliveryMethod ToEntity(DeliveryMethodDTO dto);

    }
}
