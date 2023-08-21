using onlineshop.Services.DTO;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace onlineshop.Services
{
    public interface IPaymentMethodService
    {
        Task<List<PaymentMethodDTO>> GetAll(ClaimsPrincipal currentUser);

        Task<PaymentMethodDTO> GetById(ClaimsPrincipal currentUser, string id);

        Task<PaymentMethodDTO> Add(ClaimsPrincipal currentUser, PaymentMethodDTO item);

        Task<PaymentMethodDTO> Update(ClaimsPrincipal currentUser, PaymentMethodDTO item);

        Task Delete(ClaimsPrincipal currentUser, string id);
    }
}