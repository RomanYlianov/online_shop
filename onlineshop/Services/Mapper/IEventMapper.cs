using onlineshop.Models;
using onlineshop.Services.DTO;

namespace onlineshop.Services.Mapper
{
    public interface IEventMapper
    {
        Event ToEntity(EventDTO dto);

        EventDTO ToDTO(Event entity);
    }
}