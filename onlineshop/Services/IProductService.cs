using onlineshop.Services.DTO;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace onlineshop.Services
{
    public interface IProductService : ICrud<ProductDTO, string>
    {
        Task<List<ProductDTO>> GetProductsInCatalog();

        Task<List<ProductDTO>> FindByName(string name, bool isRoot = false);

        Task<List<ProductDTO>> FindByCategory(string category, bool isRoot = false);

        Task<List<ProductDTO>> FindBySupplerFirm(string name, bool isRoot = false);

        Task<List<ProductDTO>> FindByPrice(double? lowestPrice, double? higestPrice, bool isRoot = false);

        Task<List<ProductDTO>> FindByRating(double? lowestRating, double? higestRating, bool isRoot = false);

        Task<List<ProductDTO>> FindHot(bool isRoot = false);

        Task<List<ProductDTO>> Search(ProductSearchDTO dto, bool isRoot = false);

        Task<List<ProductDTO>> GetProductsInBasket(string email);

        Task<ProductDTO> LoadProduct(ClaimsPrincipal currentUser, string eqId);

        Task<ProductDTO> RateProduct(ClaimsPrincipal currentUser, string eqId, ProductDTO dto);
    }
}