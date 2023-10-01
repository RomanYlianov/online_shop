using onlineshop.Services.DTO;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace onlineshop.Services
{
    public interface IOrderService
    {
        Task<List<OrderDTO>> GetAll(ClaimsPrincipal currentUser);

        Task<List<OrderDTO>> GetOrdersForUser(ClaimsPrincipal currentUser);

        Task<List<OrderDTO>> Search(ClaimsPrincipal currentUser, OrderSearchDTO dto);

        Task<List<ProductDTO>> GetProductsFromOrder(ClaimsPrincipal currentUser, string id);

        Task<OrderDTO> GetById(ClaimsPrincipal currentUser, string id);

        Task<OrderDTO> Add(ClaimsPrincipal currentUser, OrderDTO dto, List<string> basketIds, List<int> productCounts);

        Task<OrderDTO> Update(ClaimsPrincipal currentUser, OrderDTO item, bool isRoot = false);

        Task Delete(ClaimsPrincipal currentUser, string id, string method, List<ProductDTO> products);

        Task<OrderDTO> InicializeOrder(ClaimsPrincipal currentUser, List<string> basketIds, List<int> productCounts);
    }
}