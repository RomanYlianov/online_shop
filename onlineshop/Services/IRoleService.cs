using onlineshop.Services.DTO;
using System.Threading.Tasks;

namespace onlineshop.Services
{
    public interface IRoleService : ICrud<RoleDTO, string>
    {
        Task<bool> CheckName(string name);
    }
}