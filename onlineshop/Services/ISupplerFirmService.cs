using onlineshop.Models;
using onlineshop.Services.DTO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace onlineshop.Services
{
    public interface ISupplerFirmService : ICrud<SupplerFirmDTO, string>
    {

        Task<PaymentResult> ChangeBalance(ClaimsPrincipal currentUser, string supplerFirmId, double val, bool isIncrement = true);

    }
}