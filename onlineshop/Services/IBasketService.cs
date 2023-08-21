using onlineshop.Services.DTO;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace onlineshop.Services
{
    public interface IBasketService
    {
        Task<Tuple<BasketDTO, List<BasketDTO>, List<BasketDTO>>> GetAll(ClaimsPrincipal currentUser);

        Task<List<BasketDTO>> GetAvaliableProducts(ClaimsPrincipal currentUser);

        Task<BasketDTO> GetById(ClaimsPrincipal currentUser, string id);

        Task<BasketDTO> AddProductToBasket(ClaimsPrincipal currentUser, BasketDTO item);

        Task<BasketDTO> Update(ClaimsPrincipal currentUser, BasketDTO item);

        Task Delete(ClaimsPrincipal currentUser, string id);

        Task<int> GetCountOfProductsInBasket(ClaimsPrincipal currentUser);
    }
}