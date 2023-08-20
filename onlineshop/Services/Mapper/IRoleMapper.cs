using onlineshop.Models;
using onlineshop.Services.DTO;

namespace onlineshop.Services.Mapper
{
    public interface IRoleMapper
    {

        RoleDTO ToDTO(Role entity);

        Role ToEntity(RoleDTO dto);

        Role ToEntity(Role entity, RoleDTO dto);

    }
}
