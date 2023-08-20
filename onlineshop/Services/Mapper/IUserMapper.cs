using onlineshop.Models;
using onlineshop.Services.DTO;
using System.Collections.Generic;

namespace onlineshop.Services.Mapper
{
    public interface IUserMapper
    {
        UserDTO ToDTO(User entity);

        UserRegisterDTO ToRegisterDTO(User entity);

        UserLoginDTO ToLoginDTO(User entiny, LoginType type);

        UserUpdateDTO ToUpdateDTO(UserDTO dto, List<RoleDTO> userRoles, List<RoleDTO> otherRoles);

        User ToEntity(UserDTO dto);

        User ToEntity(User entity, UserUpdateDTO dto);

        User ToEntity(UserLoginDTO dto, LoginType type);

        User ToEntity(UserRegisterDTO dto);

    }
}
