using onlineshop.Models;
using onlineshop.Services.DTO;

namespace onlineshop.Services.Mapper
{
    public interface IOrderMapper
    {

        OrderDTO ToDTO(Order entity);

        Order ToEntity(OrderDTO dto);

        Order ToEntity(Order entity, OrderDTO dto);


    }
}
