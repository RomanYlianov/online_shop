using onlineshop.Services.DTO;
using System.Threading.Tasks;

namespace onlineshop.Services
{
    public interface ISupplerFirmService : ICrud<SupplerFirmDTO, string>
    {

        Task<SupplerFirmDTO> CalculateRating(string id);

    }
}