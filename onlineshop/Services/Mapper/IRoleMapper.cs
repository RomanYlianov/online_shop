using onlineshop.Models;
using onlineshop.Services.DTO;

namespace onlineshop.Services.Mapper
{
    public interface IRoleMapper
    {
        Role ToEntity(RoleDTO dto);

        Role ToEntity(Role entity, RoleDTO dto);

        RoleDTO ToDTO(Role entity);
    }
}