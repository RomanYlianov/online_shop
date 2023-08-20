using onlineshop.Models;
using onlineshop.Services.DTO;

namespace onlineshop.Services.Mapper
{
    public interface ISupperFirmMapper
    {

        SupplerFirmDTO ToDTO(SupplerFirm entity);

        SupplerFirm ToEntity(SupplerFirmDTO dto);

    }
}
