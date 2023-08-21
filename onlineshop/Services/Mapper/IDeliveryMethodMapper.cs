using onlineshop.Models;
using onlineshop.Services.DTO;

namespace onlineshop.Services.Mapper
{
    public interface IDeliveryMethodMapper
    {
        DeliveryMethod ToEntity(DeliveryMethodDTO dto);

        DeliveryMethodDTO ToDTO(DeliveryMethod entity);
    }
}