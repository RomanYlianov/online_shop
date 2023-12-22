using onlineshop.Models;
using onlineshop.Services.DTO;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace onlineshop.Services
{
    public interface ISupplerFirmService : ICrud<SupplerFirmDTO, string>
    {

        Task<PaymentResult> ChangeBalance(ClaimsPrincipal currentUser, String sfId, double val, bool isIncrement = true);

    }
}