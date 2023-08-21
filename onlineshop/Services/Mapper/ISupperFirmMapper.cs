using onlineshop.Models;
using onlineshop.Services.DTO;

namespace onlineshop.Services.Mapper
{
    public interface ISupperFirmMapper
    {
        SupplerFirm ToEntity(SupplerFirmDTO dto);

        SupplerFirmDTO ToDTO(SupplerFirm entity);
    }
}