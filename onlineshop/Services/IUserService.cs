using onlineshop.Services.DTO;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace onlineshop.Services
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAll();

        Task<UserDTO> GetById(ClaimsPrincipal currentUser, string id);

        Task<UserDTO> GetByEmail(string email);

        Task<UserDTO> Add(UserRegisterDTO item);

        Task<UserDTO> Update(ClaimsPrincipal currentUser, UserUpdateDTO item);

        Task Delete(ClaimsPrincipal currentUser, string id);

        Task<List<RoleDTO>> GetRolesForUser(string id);

        Task<List<SupplerFirmDTO>> GetDependentSupplerFirmsForUser(ClaimsPrincipal currentUser, string id);

        Task<UserDTO> ResetPassword(UserResetPasswordDTO dto);

        Task<List<UserDTO>> FindByEmail(ClaimsPrincipal currentUser, string email);

        Task<List<UserDTO>> FindByUserName(ClaimsPrincipal currentUser, string nick);

        Task<List<UserDTO>> FindByPhoneNumber(ClaimsPrincipal currentUser, string phone);

        Task<List<UserDTO>> Search(UserSearchDTO dto);

        Task<bool> CheckEmail(ClaimsPrincipal currentUser, string email, string modifyId = null, bool isRegisteer = false);

        Task<bool> CheckUserName(ClaimsPrincipal currentUser, string nick, string modifyId = null, bool isRegister = false);

        Task<bool> CheckPhoneNumber(ClaimsPrincipal currentUser, string phone, string modifyId = null, bool isRegister = false);

        Task<UserDTO> CheckUser(UserLoginDTO dto);

        string EncryptPassword(string password);

        bool ValidatePassword(string hash, string password);

        //Task<Models.User> GetUserEntity(string email);

        Task SignIn(string uid, string login, LoginType type);

        Task SignOut();
    }
}