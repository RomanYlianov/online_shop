using onlineshop.Models;
using onlineshop.Services.DTO;

namespace onlineshop.Services.Mapper
{
    public interface IOrderMapper
    {
        Order ToEntity(OrderDTO dto);

        Order ToEntity(Order entity, OrderDTO dto);

        OrderDTO ToDTO(Order entity);
    }
}