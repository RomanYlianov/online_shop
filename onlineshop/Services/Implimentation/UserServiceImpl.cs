using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using onlineshop.Data;
using onlineshop.Models;
using onlineshop.Services.DTO;
using onlineshop.Services.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace onlineshop.Services.Implimentation
{
    public class UserServiceImpl : IUserService
    {
        private readonly ApplicationDbContext context;

        private readonly IUserMapper USmapper;

        private readonly IRoleMapper RMapper;

        private readonly ISupplerFirmService SFService;

        private readonly ISupperFirmMapper SFMapper;

        private readonly UserManager<User> USManager;

        private readonly SignInManager<User> SINManager;

        private readonly ILogger logger;

        public UserServiceImpl(ApplicationDbContext context, UserManager<User> uManager, SignInManager<User> sinManeger, ISupplerFirmService sfService, ISupperFirmMapper sfMapper, IUserMapper uMapper, IRoleMapper rMapper)
        {
            this.context = context;
            this.USManager = uManager;
            this.SINManager = sinManeger;
            this.SFService = sfService;
            this.SFMapper = sfMapper;
            this.USmapper = uMapper;
            this.RMapper = rMapper;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<UserServiceImpl>();
        }

        public async Task<List<UserDTO>> GetAll()
        {
            logger.LogInformation(GetType().Name + " : GetAll");

            List<User> list = await context.Users.ToListAsync();

            List<UserDTO> result = new List<UserDTO>();

            string message = string.Empty;

            if (list != null)
            {
                if (list.Count == 0)
                {
                    message = "users entity is empty";
                }
            }
            else
            {
                message = "users entity is empty";
            }

            if (string.IsNullOrEmpty(message))
            {
                foreach (var item in list)
                {
                    result.Add(USmapper.ToDTO(item));
                }
            }
            else
            {
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("GetAll", message, HttpStatusCode.NotFound);
            }
            return result;
        }

        //currentUser = this.User from controller
        public async Task<UserDTO> GetById(ClaimsPrincipal currentUser, string id)
        {
            logger.LogInformation(GetType().Name + " : GetById");

            if (SINManager.IsSignedIn(currentUser))
            {
                if (id != null)
                {
                    try
                    {
                        User entity = await context.Users.FindAsync(Guid.Parse(id));

                        if (entity != null)
                        {
                            if (CheckPermissions(currentUser, entity))
                            {
                                return USmapper.ToDTO(entity);
                            }
                            else
                            {
                                string message = "you don't have permissions to change data";
                                logger.LogInformation(GetType().Name + " : " + message);
                                throw new HttpException<User>("Delete", message, HttpStatusCode.Forbidden);
                            }
                        }
                        else
                        {
                            string message = "user with id " + id + " was not found";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<User>("GetById", message, HttpStatusCode.NotFound);
                        }
                    }
                    catch (FormatException ex)
                    {
                        string message = "convert id " + id + " failed: " + ex.Message;
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<DeliveryMethod>("GetById", message, HttpStatusCode.InternalServerError);
                    }
                }
                else
                {
                    string message = "id parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<User>("GetById", message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("GetById", message, HttpStatusCode.Forbidden);
            }
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            logger.LogInformation(GetType().Name + " : GetByEmail");

            if (email != null)
            {
                User entity = await context.Users.FirstOrDefaultAsync(u => u.NormalizedEmail.Equals(email));

                if (entity != null)
                {
                    return USmapper.ToDTO(entity);
                }
                else
                {
                    string message = "user with email " + email + " was not found";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<User>("GetByEmail", message, HttpStatusCode.NotFound);
                }
            }
            else
            {
                string message = "email parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("GetByEmail", message, HttpStatusCode.BadRequest);
            }
        }

        public async Task<UserDTO> Add(UserRegisterDTO item)
        {
            logger.LogInformation(GetType().Name + " : Add");

            if (item != null)
            {
                User entity = USmapper.ToEntity(item);

                

                if (item.UserSupplerFirms != null)
                {
                    List<Role> roles = await context.Roles.ToListAsync();

                    bool flag = false;

                    foreach (var role in roles)
                    {
                        foreach (string rid in item.UserRoles)
                        {
                            if (rid.Equals(role.Id.ToString()))
                            {
                                flag = role.Name.Equals("SELLER");
                                if (flag)
                                {
                                    break;
                                }
                            }
                        }
                        if (flag)
                        {
                            break;
                        }    
                    }

                    if (!flag)
                    {
                        string message = "user must be have a role \"SELLER\" for bundig with supplerfirms";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<User>("Add", message, HttpStatusCode.Forbidden);
                    }                  
                }
                
                entity.PasswordHash = EncryptPassword(entity.PasswordHash);
                entity.KeyWord = GenerateKeyWord();
                entity.CreationTime = DateTime.Now;
                entity.SecurityStamp = Guid.NewGuid().ToString();



                //create new user
                await context.Users.AddAsync(entity);

                await context.SaveChangesAsync();

                entity = await context.Users.FirstOrDefaultAsync(u => u.UserName.Equals(entity.UserName));

                if (entity != null)
                {
                    if (item.UserRoles == null)
                    {
                        Role role = await context.Roles.FirstOrDefaultAsync(r => r.NormalizedName.Equals("BUYER"));
                        if (role != null)
                        {
                            UserRole ur = new UserRole();
                            ur.UserId = entity.Id;
                            ur.RoleId = role.Id;
                            await context.UserRoles.AddAsync(ur);
                            await context.SaveChangesAsync();
                        }
                        
                    }
                    else
                    {
                        List<UserRole> urList = new List<UserRole>();

                        foreach (string rid in item.UserRoles)
                        {
                            try
                            {
                                Role role = await context.Roles.FirstOrDefaultAsync(r => r.Id == Guid.Parse(rid));
                                if (role != null)
                                {
                                    UserRole ur = new UserRole(entity.Id, role.Id);
                                    urList.Add(ur);
                                  
                                }
                                else
                                {
                                    string message = "role with id " + rid + " doesn't exists";
                                    logger.LogError(GetType().Name + " : " + message);
                                    throw new HttpException<User>("Add", message, HttpStatusCode.NotFound);
                                }
                            }
                            catch (FormatException ex)
                            {
                                string message = "convert id " + rid + " failed : " + ex.Message;
                                logger.LogError(GetType().Name + " : " + message);
                                throw new HttpException<SupplerFirm>("Add", message, HttpStatusCode.InternalServerError);
                            }
                        }

                        if (urList.Count > 0)
                        {
                            await context.UserRoles.AddRangeAsync(urList);
                            await context.SaveChangesAsync();
                        }
                    }

                    if (item.UserSupplerFirms != null)
                    {
                        List<UserSupplerFirm> ufList = new List<UserSupplerFirm>();

                        foreach (string sfid in item.UserSupplerFirms)
                        {

                            try
                            {
                                SupplerFirm firm = await context.SupplerFirmsCtx.FirstOrDefaultAsync(sf => sf.Id == Guid.Parse(sfid));

                                if (firm != null)
                                {
                                    ufList.Add(new UserSupplerFirm(entity.Id, firm.Id));
                                }
                                else
                                {
                                    string message = "supplerFirm with id " + sfid + " doesn't exists";
                                    logger.LogError(GetType().Name + " : " + message);
                                    throw new HttpException<User>("Add", message, HttpStatusCode.NotFound);
                                }
                            }
                            catch (FormatException ex)
                            {
                                string message = "convert id " + sfid + " failed : " + ex.Message;
                                logger.LogError(GetType().Name + " : " + message);
                                throw new HttpException<SupplerFirm>("Add", message, HttpStatusCode.InternalServerError);
                            }
                            
                            if (ufList.Count > 0)
                            {
                                await context.UserSupplerFirmCtx.AddRangeAsync(ufList);
                                await context.SaveChangesAsync();
                            }

                        }
                    }

                }
                else
                {
                    string message = "user with UserName " + item.UserName + " was not found";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<User>("Add", message, HttpStatusCode.NotFound);
                }

                return USmapper.ToDTO(entity);
            }
            else
            {
                string message = "item parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Role>("Update", message, HttpStatusCode.BadRequest);
            }
        }

        public async Task<UserDTO> Update(ClaimsPrincipal currentUser, UserUpdateDTO item)
        {
            logger.LogInformation(GetType().Name + " : Update");

            if (SINManager.IsSignedIn(currentUser))
            {

                bool isHavingSellerRole = false;

                if (item != null)
                {
                    try
                    {
                        User old = await context.Users.FindAsync(Guid.Parse(item.Id));

                        if (old != null)
                        {
                            User entity = await context.Users.FirstOrDefaultAsync(u => u.UserName.Equals(old.UserName)); 

                            if (entity != null)
                            {
                                if (!entity.NormalizedEmail.Equals("ROOT@MAIL.RU"))
                                {
                                    if (CheckPermissions(currentUser, entity))
                                    {
                                        entity = USmapper.ToEntity(entity, item);

                                        //encrypt password

                                        entity.PasswordHash = EncryptPassword(entity.PasswordHash);

                                        context.Users.Update(entity);

                                        await context.SaveChangesAsync();

                                        //get user roles

                                        var list = await context.UserRoles.Where(ur => ur.UserId == entity.Id).ToListAsync();

                                        Role buyer = await context.Roles.FirstOrDefaultAsync(r => r.NormalizedName.Equals("BUYER"));

                                        List<string> rolesIds = new List<string>();

                                        if (list != null)
                                        {
                                            foreach (var temp in list)
                                            {
                                                rolesIds.Add(temp.RoleId.ToString());
                                            }

                                            context.UserRoles.RemoveRange(list);

                                            await context.SaveChangesAsync();
                                        }

                                        if (rolesIds != null)
                                        {
                                            if (item.UserRoles != null)
                                            {
                                                foreach (string rid in item.UserRoles)
                                                {
                                                    if (!rid.Equals(buyer.Id.ToString()))
                                                    {
                                                        rolesIds.Remove(rid);
                                                    }
                                                }
                                            }

                                            if (item.OtherRoles != null)
                                            {
                                                foreach (string rid in item.OtherRoles)
                                                {
                                                    if (!rolesIds.Contains(rid))
                                                    {
                                                        rolesIds.Add(rid);
                                                    }
                                                }
                                            }
                                        }

                                        

                                        if (rolesIds != null)
                                        {
                                            List<UserRole> urList = new List<UserRole>();

                                            foreach (string roleId in rolesIds)
                                            {
                                                Role role = await context.Roles.FindAsync(Guid.Parse(roleId));
                                                if (!isHavingSellerRole)
                                                    isHavingSellerRole = role.Name.Equals("SELLER");
                                                urList.Add(new UserRole(entity.Id, role.Id));
                                            }
                                            await context.UserRoles.AddRangeAsync(urList);
                                            await context.SaveChangesAsync();
                                        }
                                        else
                                        {
                                            await context.UserRoles.AddAsync(new UserRole(entity.Id, buyer.Id));
                                            await context.SaveChangesAsync();
                                        }

                                        if (item.UserSupplerFirms != null || item.OtherSupplerFirms != null)
                                        {
                                            if (isHavingSellerRole)
                                            {
                                                List<UserSupplerFirm> userSupplerFirms = await context.UserSupplerFirmCtx.Where(uf => uf.SellerId.Equals(entity.Id)).ToListAsync();

                                                

                                                if (userSupplerFirms != null)
                                                {
                                                    if (item.OtherSupplerFirms != null)
                                                    {
                                                        foreach (string firmId in item.OtherSupplerFirms)
                                                        {
                                                            SupplerFirm firm = await context.SupplerFirmsCtx.FirstOrDefaultAsync(sf => sf.Id.Equals(Guid.Parse(firmId)));
                                                            if (firm != null)
                                                            {
                                                                UserSupplerFirm userFirm = new UserSupplerFirm(entity.Id, firm.Id);
                                                                context.Entry(userFirm).State = EntityState.Added;
                                                                await context.Set<UserSupplerFirm>().AddAsync(userFirm);
                                                                await context.SaveChangesAsync();
                                                                userSupplerFirms.Add(userFirm);

                                                            }
                                                        }
                                                    }
                                                    
                                                    if (item.UserSupplerFirms != null)
                                                    {
                                                        foreach (string firmId in item.UserSupplerFirms)
                                                        {
                                                            SupplerFirm firm = await context.SupplerFirmsCtx.FirstOrDefaultAsync(sf => sf.Id.Equals(Guid.Parse(firmId)));
                                                            if (firm != null)
                                                            {
                                                                UserSupplerFirm userFirm = await context.UserSupplerFirmCtx.Where(uf => uf.SellerId.Equals(entity.Id) && uf.SupplerFirmId.Equals(firm.Id)).FirstOrDefaultAsync();
                                                                context.Entry(userFirm).State = EntityState.Deleted;
                                                                context.Set<UserSupplerFirm>().Remove(userFirm);
                                                                await context.SaveChangesAsync();
                                                                userSupplerFirms.Remove(userSupplerFirms.Where(uf => uf.SellerId.Equals(entity.Id) && uf.SupplerFirmId.Equals(firm.Id)).FirstOrDefault());

                                                            }
                                                        }
                                                    }
                                                    
                                                }
                                               

                                            }
                                            else
                                            {
                                                string message = "user must be have a role \"SELLER\" for bundig with supplerfirms";
                                                logger.LogError(GetType().Name + " : " + message);
                                                throw new HttpException<User>("Update", message, HttpStatusCode.Forbidden);
                                            }
                                        }
                                        
                                       

                                        

                                        return USmapper.ToDTO(entity);
                                    }
                                    else
                                    {
                                        string message = "you don't have permissions to change data";
                                        logger.LogInformation(GetType().Name + " : " + message);
                                        throw new HttpException<User>("Update", message, HttpStatusCode.Forbidden);
                                    }
                                }
                                else
                                {
                                    string message = "system user can't be changed";
                                    logger.LogError(GetType().Name + " : " + message); ;
                                    throw new HttpException<User>("Update", message, HttpStatusCode.Forbidden);
                                }
                            }
                            else
                            {
                                string message = "user with UserName " + old.UserName + " was not found";
                                logger.LogError(GetType().Name + " : " + message);
                                throw new HttpException<User>("Update", message, HttpStatusCode.NotFound);
                            }
                        }
                        else
                        {
                            string message = "user ith id " + item.Id + " was not found";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<Role>("Update", message, HttpStatusCode.NotFound);
                        }
                    }
                    catch (FormatException ex)
                    {
                        string message = "convert id " + item.Id + " failed: " + ex.Message;
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<Role>("Update", message, HttpStatusCode.InternalServerError);
                    }
                }
                else
                {
                    string message = "item parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Role>("Update", message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("Update", message, HttpStatusCode.Forbidden);
            }
        }

        public async Task Delete(ClaimsPrincipal currentUser, string id)
        {
            logger.LogInformation(GetType().Name + " : Delete");

            if (SINManager.IsSignedIn(currentUser))
            {
                if (id != null)
                {
                    try
                    {
                        User entity = await context.Users.FindAsync(Guid.Parse(id));

                        if (entity != null)
                        {
                            if (!entity.NormalizedEmail.Equals("ROOT@MAIL.RU"))
                            {
                                if (CheckPermissions(currentUser, entity))
                                {
                                    //remove depents orders

                                    List<Order> orders = await context.OrdersCtx.Where(o => o.BuyerId.Equals(entity.Id)).ToListAsync();

                                    if (orders != null)
                                    {
                                        context.OrdersCtx.RemoveRange(orders);
                                        await context.SaveChangesAsync();
                                    }

                                    context.Users.Remove(entity);
                                    await context.SaveChangesAsync();
                                }
                                else
                                {
                                    string message = "you don't have permissions to change data";
                                    logger.LogInformation(GetType().Name + " : " + message);
                                    throw new HttpException<User>("Delete", message, HttpStatusCode.Forbidden);
                                }
                            }
                            else
                            {
                                string message = "system user can't be changed";
                                logger.LogError(GetType().Name + " : " + message);
                                throw new HttpException<User>("Delete", message, HttpStatusCode.Forbidden);
                            }
                        }
                        else
                        {
                            string message = "user with id " + id + " was not found";
                            logger.LogError("Delete", message, HttpStatusCode.NotFound);
                            throw new HttpException<User>("Delete", message, HttpStatusCode.NotFound);
                        }
                    }
                    catch (FormatException ex)
                    {
                        string message = "convert id " + id + " failed : " + ex.Message;
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<Role>("Delete", message, HttpStatusCode.InternalServerError);
                    }
                }
                else
                {
                    string message = "id parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<User>("Delete", message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("Delete", message, HttpStatusCode.Forbidden);
            }
        }

        public async Task SignIn(string id, string login, LoginType type)
        {
            logger.LogInformation(GetType().Name + " : SignIn");

            try
            {
                List<Claim> claims = new List<Claim>();

                List<RoleDTO> roles = await GetRolesForUser(id);

                claims.Add(new Claim(ClaimTypes.NameIdentifier, login));
                claims.Add(new Claim(ClaimTypes.Name, login));

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Name));
                }

                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

                identity.AddClaims(claims);

                User entity = null;

                switch (type)
                {
                    case LoginType.Email:
                        {
                            entity = await context.Users.FirstOrDefaultAsync(u => u.NormalizedEmail.Equals(login.ToUpper()));
                        }
                        break;

                    case LoginType.PhoneNumber:
                        {
                            entity = await context.Users.FirstOrDefaultAsync(u => u.PhoneNumber.Equals(login));
                        }
                        break;

                    case LoginType.UserName:
                        {
                            entity = await context.Users.FirstOrDefaultAsync(u => u.NormalizedUserName.Equals(login.ToUpper()));
                        }
                        break;
                }

                AuthenticationProperties properties = new AuthenticationProperties();
                properties.IsPersistent = true;

                await SINManager.SignInWithClaimsAsync(entity, properties, claims);
            }
            catch (HttpException<User> ex)
            {
                throw ex;
            }
        }

        public async Task SignOut()
        {
            logger.LogInformation(GetType().Name + " : SignOut");

            await SINManager.SignOutAsync();
        }

        public async Task<List<RoleDTO>> GetRolesForUser(string id)
        {
            logger.LogInformation(GetType().Name + " : GetRolesForUser");

            List<RoleDTO> result = new List<RoleDTO>();

            if (id != null)
            {
                try
                {
                    User entity = await context.Users.FindAsync(Guid.Parse(id));

                    if (entity != null)
                    {
                        var roles = await USManager.GetRolesAsync(entity);
                        foreach (string role in roles)
                        {
                            Role item = await context.Roles.FirstOrDefaultAsync(r => r.Name.Equals(role));

                            if (item != null)
                            {
                                result.Add(RMapper.ToDTO(item));
                            }
                        }
                    }
                    else
                    {
                        string message = "user with id " + id + " was not found";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<User>("GetRolesForUser", message, HttpStatusCode.NotFound);
                    }
                }
                catch (FormatException ex)
                {
                    string message = "convert id " + id + " failed : " + ex.Message;
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Role>("GetRolesForUser", message, HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                string message = "id parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("GetRolesForUser", message, HttpStatusCode.BadRequest);
            }

            return result;
        }

        public async Task<List<SupplerFirmDTO>> GetDependentSupplerFirmsForUser(ClaimsPrincipal currentUser, string id)
        {

            logger.LogInformation(GetType().Name + " : GetSupplerFirmsForBuyer");

            List<SupplerFirmDTO> result = new List<SupplerFirmDTO>();

            if (id != null)
            {

                try
                {
                    User userEntity = await context.Users.FirstOrDefaultAsync(u => u.Id.Equals(Guid.Parse(id)));

                    if (userEntity != null)
                    {

                       

                        if (SINManager.IsSignedIn(currentUser))
                        {

                            List<RoleDTO> roles = await GetRolesForUser(id);

                            if (roles.Where(r => r.Name.Equals("OWNER")).FirstOrDefault() != null)
                            {
                                result = await SFService.GetAll();
                            }
                            else
                            {
                                if (roles.Where(r => r.Name.Equals("SELLER")).FirstOrDefault() != null)
                                {
                                    try
                                    {
                                        List<SupplerFirm> temp = await context.UserSupplerFirmCtx.Include(uf => uf.SupplerFirm).Where(uf => uf.SellerId.Equals(Guid.Parse(id))).Select(uf => uf.SupplerFirm).ToListAsync();
                                        if (temp != null)
                                        {
                                            foreach (var entity in temp)
                                            {
                                                result.Add(SFMapper.ToDTO(entity));
                                            }
                                        }
                                    }
                                    catch (FormatException ex)
                                    {
                                        string message = "convert id " + id + " failed : " + ex.Message;
                                        logger.LogError(GetType().Name + " : " + message);
                                        throw new HttpException<Role>("GetDependentSupplerFirmsForUser", message, HttpStatusCode.InternalServerError);
                                    }
                                }
                                else
                                {
                                    string message = "you dont have permissions to view this data";
                                    logger.LogError(GetType().Name + " : " + message);
                                    throw new HttpException<User>("GetDependentSupplerFirmsForUser", message, HttpStatusCode.Forbidden);
                                }
                            }

                        }
                        else
                        {
                            string message = "user is not authorized";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<User>("GetDependentSupplerFirmsForUser", message, HttpStatusCode.Forbidden);
                        }
                    }
                    else
                    {
                        string message = "user with id " + id + " was not found";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<User>("GetSupplerFirmsForBuyer", message, HttpStatusCode.NotFound);
                    }

                }
                catch (FormatException ex)
                {
                    string message = "convert id " + id + " failed : " + ex.Message;
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Role>("GetSupplerFirmsForBuyer", message, HttpStatusCode.InternalServerError);
                }
               


               
            }

            return result;

        }

        public async Task<bool> CheckEmail(ClaimsPrincipal currentUser, string email, string modifyId = null, bool isRegister = false)
        {
            logger.LogInformation(GetType().Name + " : CheckEmail");

            if (SINManager.IsSignedIn(currentUser) || isRegister)
            {
                bool flag = false;

                if (email != null)
                {
                    User entity = await context.Users.FirstOrDefaultAsync(u => u.NormalizedEmail.Equals(email.ToUpper()));

                    if (entity != null)
                    {
                        if (CheckPermissions(currentUser, entity))
                        {
                            if (modifyId != null)
                            {
                                if (!entity.Id.ToString().Equals(modifyId))
                                {
                                    flag = true;
                                }
                            }
                            else
                            {
                                flag = true;
                            }
                        }
                        else
                        {
                            string message = "you don't have permissions to change data";
                            logger.LogInformation(GetType().Name + " : " + message);

                            flag = false;
                        }
                    }
                    else
                    {
                        string message = "user with Email " + email + " was not found";
                        logger.LogInformation(GetType().Name + " : " + message);
                        flag = false;
                    }
                }
                else
                {
                    string message = "email parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<User>("CheckEmail", message, HttpStatusCode.BadRequest);
                }

                return flag;
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("CheckEmail", message, HttpStatusCode.Forbidden);
            }
        }

        

        public async Task<bool> CheckUserName(ClaimsPrincipal currentUser, string uName, string modifyId = null, bool isRegister = false)
        {
            logger.LogInformation(GetType().Name + " : CheckUserName");

            if (SINManager.IsSignedIn(currentUser) || isRegister)
            {
                bool flag = false;

                if (uName != null)
                {
                    User entity = await context.Users.FirstOrDefaultAsync(u => u.NormalizedUserName.Equals(uName.ToUpper()));

                    if (entity != null)
                    {
                        if (CheckPermissions(currentUser, entity))
                        {
                            if (modifyId != null)
                            {
                                if (!entity.Id.ToString().Equals(modifyId))
                                {
                                    flag = true;
                                }
                            }
                            else
                            {
                                flag = true;
                            }
                        }
                        else
                        {
                            string message = "you don't have permissions to change data";
                            logger.LogInformation(GetType().Name + " : " + message);

                            flag = false;
                        }
                    }
                    else
                    {
                        string message = "user with UserName " + uName + " was not found";
                        logger.LogInformation(GetType().Name + " : " + message);

                        flag = false;
                    }
                }
                else
                {
                    string message = "uName parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<User>("CheckUserName", message, HttpStatusCode.BadRequest);
                }

                return flag;
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("CheckUserName", message, HttpStatusCode.Forbidden);
            }
        }

        public async Task<bool> CheckPhoneNumber(ClaimsPrincipal currentUser, string phone, string modifyId = null, bool isRegister = false)
        {
            logger.LogInformation(GetType().Name + " : ChecPhoneNumber");

            if (SINManager.IsSignedIn(currentUser) || isRegister)
            {
                bool flag = false;

                if (phone != null)
                {
                    User entity = await context.Users.FirstOrDefaultAsync(u => u.PhoneNumber.Equals(phone));

                    if (entity != null)
                    {
                        if (CheckPermissions(currentUser, entity))
                        {
                            if (modifyId != null)
                            {
                                if (!entity.Id.ToString().Equals(modifyId))
                                {
                                    flag = true;
                                }
                            }
                            else
                            {
                                flag = true;
                            }
                        }
                        else
                        {
                            string message = "you don't have permissions to change data";
                            logger.LogInformation(GetType().Name + " : " + message);

                            flag = false;
                        }
                    }
                    else
                    {
                        string message = "user with PhoneNumber " + phone + " was not found";
                        logger.LogInformation(GetType().Name + " : " + message);

                        flag = false;
                    }
                }
                else
                {
                    string message = "phone parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<User>("CheckPhone", message, HttpStatusCode.BadRequest);
                }

                return flag;
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("CheckPhone", message, HttpStatusCode.Forbidden);
            }
        }

        public async Task<UserDTO> CheckUser(UserLoginDTO dto)
        {
            logger.LogInformation(GetType().Name + " : CheckUser");

            if (dto != null)
            {
                User entity = null;

                switch (dto.Type)
                {
                    case LoginType.Email:
                        {
                            entity = await context.Users.FirstOrDefaultAsync(u => u.Email.Equals(dto.Login));
                        }
                        break;

                    case LoginType.PhoneNumber:
                        {
                            entity = await context.Users.FirstOrDefaultAsync(u => u.PhoneNumber.Equals(dto.Login));
                        }
                        break;

                    case LoginType.UserName:
                        {
                            entity = await context.Users.FirstOrDefaultAsync(u => u.UserName.Equals(dto.Login));
                        }
                        break;
                }

                if (entity != null)
                {
                    return USmapper.ToDTO(entity);
                }
                else
                {
                    string message = $"user with {dto.Type} {dto.Login} was not found";
                    logger.LogError(GetType().Name + message);
                    throw new HttpException<User>("CheckUser", message, HttpStatusCode.NotFound);
                }
            }
            else
            {
                string message = "dto parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("CheckUser", message, HttpStatusCode.BadRequest);
            }
        }

        public async Task<List<UserDTO>> FindByEmail(ClaimsPrincipal currentUser, string email)
        {
            logger.LogInformation(GetType().Name + " : FindByEmail");

            if (SINManager.IsSignedIn(currentUser))
            {
                if (email != null)
                {
                    List<User> list = await context.Users.Where(u => u.NormalizedEmail.Contains(email.ToUpper())).ToListAsync();

                    string message = string.Empty;

                    if (list != null)
                    {
                        if (list.Count == 0)
                        {
                            message = "users entity is empty";
                        }
                    }
                    else
                    {
                        message = "users entity is empty";
                    }

                    if (string.IsNullOrEmpty(message))
                    {
                        List<UserDTO> result = new List<UserDTO>();

                        if (currentUser != null)
                        {
                            if (currentUser.IsInRole("admin"))
                            {
                                foreach (var item in list)
                                {
                                    result.Add(USmapper.ToDTO(item));
                                }
                            }
                            else
                            {
                                foreach (var item in list)
                                {
                                    if (item.Email.Equals(email))
                                    {
                                        result.Add(USmapper.ToDTO(item));
                                    }
                                }
                            }

                            if (result.Count == 0)
                            {
                                message = "users entity is empty";
                                logger.LogError(GetType().Name + " : " + message);
                                throw new HttpException<User>("FindByEmail", message, HttpStatusCode.NotFound);
                            }
                            else
                            {
                                return result;
                            }
                        }
                        else
                        {
                            message = "you don't have permissions to change data";
                            logger.LogInformation(GetType().Name + " : " + message);
                            throw new HttpException<User>("FindByEmail", message, HttpStatusCode.Forbidden);
                        }
                    }
                    else
                    {
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<User>("FindByEmail", message, HttpStatusCode.NotFound);
                    }
                }
                else
                {
                    string message = "email parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<User>("FindByEmail", message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("FindByEmail", message, HttpStatusCode.Forbidden);
            }
        }

        public async Task<List<UserDTO>> FindByUserName(ClaimsPrincipal currentUser, string uName)
        {
            logger.LogInformation(GetType().Name + " : FindByUserName");

            if (SINManager.IsSignedIn(currentUser))
            {
                if (uName != null)
                {
                    List<User> list = await context.Users.Where(u => u.NormalizedUserName.Contains(uName.ToUpper())).ToListAsync();

                    string message = string.Empty;

                    if (list != null)
                    {
                        if (list.Count == 0)
                        {
                            message = "users entity is empty";
                        }
                    }
                    else
                    {
                        message = "users entity is empty";
                    }

                    if (string.IsNullOrEmpty(message))
                    {
                        List<UserDTO> result = new List<UserDTO>();

                        if (currentUser != null)
                        {
                            if (currentUser.IsInRole("admin"))
                            {
                                foreach (var item in list)
                                {
                                    result.Add(USmapper.ToDTO(item));
                                }
                            }
                            else
                            {
                                foreach (var item in list)
                                {
                                    if (item.UserName.Equals(uName))
                                    {
                                        result.Add(USmapper.ToDTO(item));
                                    }
                                }
                            }

                            if (result.Count == 0)
                            {
                                message = "users entity is empty";
                                logger.LogError(GetType().Name + " : " + message);
                                throw new HttpException<User>("FindByUserName", message, HttpStatusCode.NotFound);
                            }
                            else
                            {
                                return result;
                            }
                        }
                        else
                        {
                            message = "you don't have permissions to change data";
                            logger.LogInformation(GetType().Name + " : " + message);
                            throw new HttpException<User>("FindByUserName", message, HttpStatusCode.Forbidden);
                        }
                    }
                    else
                    {
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<User>("FindByUserName", message, HttpStatusCode.NotFound);
                    }
                }
                else
                {
                    string message = "uName parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<User>("FindByUserName", message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("FindByUserName", message, HttpStatusCode.Forbidden);
            }
        }

        public async Task<List<UserDTO>> FindByPhoneNumber(ClaimsPrincipal currentUser, string phone)
        {
            logger.LogInformation(GetType().Name + " : FindByPhoneNumber");

            if (SINManager.IsSignedIn(currentUser))
            {
                if (phone != null)
                {
                    List<User> list = await context.Users.Where(u => u.PhoneNumber.Contains(phone)).ToListAsync();

                    string message = string.Empty;

                    if (list != null)
                    {
                        if (list.Count == 0)
                        {
                            message = "users entity is empty";
                        }
                    }
                    else
                    {
                        message = "users entity is empty";
                    }

                    if (string.IsNullOrEmpty(message))
                    {
                        List<UserDTO> result = new List<UserDTO>();

                        if (currentUser != null)
                        {
                            if (currentUser.IsInRole("admin"))
                            {
                                foreach (var item in list)
                                {
                                    result.Add(USmapper.ToDTO(item));
                                }
                            }
                            else
                            {
                                foreach (var item in list)
                                {
                                    if (item.PhoneNumber.Equals(phone))
                                    {
                                        result.Add(USmapper.ToDTO(item));
                                    }
                                }
                            }

                            if (result.Count == 0)
                            {
                                message = "users entity is empty";
                                logger.LogError(GetType().Name + " : " + message);
                                throw new HttpException<User>("FindByPhoneNumber", message, HttpStatusCode.NotFound);
                            }
                            else
                            {
                                return result;
                            }
                        }
                        else
                        {
                            message = "you don't have permissions to change data";
                            logger.LogInformation(GetType().Name + " : " + message);
                            throw new HttpException<User>("FindByPhoneNumber", message, HttpStatusCode.Forbidden);
                        }
                    }
                    else
                    {
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<User>("FindByPhoneNumber", message, HttpStatusCode.NotFound);
                    }
                }
                else
                {
                    string message = "phone parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<User>("FindByPhoneNumber", message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("FindByPhoneNumber", message, HttpStatusCode.Forbidden);
            }
        }

        public async Task<UserDTO> ResetPassword(UserResetPasswordDTO dto)
        {
            logger.LogInformation(GetType().Name + ": ResetPassword");

            if (dto != null)
            {
                User entity = await context.Users.FirstOrDefaultAsync(u => u.NormalizedUserName.Equals(dto.UserName.ToUpper()));

                if (entity != null)
                {
                    if (!entity.UserName.Equals(dto.UserName))
                    {
                        string message = "UserName field doesn't match";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<User>("ResetPassword", message, HttpStatusCode.Forbidden);
                    }

                    if (!entity.KeyWord.Equals(dto.KeyWord))
                    {
                        string message = "KeyWord field doesn't match";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<User>("ResetPassword", message, HttpStatusCode.Forbidden);
                    }

                    entity.PasswordHash = EncryptPassword(dto.Password);

                    context.Users.Update(entity);

                    await context.SaveChangesAsync();                 

                    return USmapper.ToDTO(entity);
                   
                }
                else
                {
                    string message = "user entity with Username " + dto.UserName + " was not found";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<User>("ResetPassword", message, HttpStatusCode.NotFound);
                }
            }
            else
            {
                string message = "dto parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("FindByPhoneNumber", message, HttpStatusCode.BadRequest);
            }
        }

        public async Task<List<UserDTO>> Search(UserSearchDTO dto)
        {
            logger.LogInformation(GetType().Name + " : Search");

            if (dto != null)
            {
                List<User> list = new List<User>();

                if (!string.IsNullOrEmpty(dto.UserName))
                {
                    logger.LogInformation(GetType().Name + " : #0 - search by UserName parameter (is main)");

                    list = await context.Users.Where(u => u.NormalizedUserName.Contains(dto.UserName.ToUpper())).ToListAsync();
                }
                else
                {
                    logger.LogInformation(GetType().Name + " : #0 - get all records (is main)");

                    list = await context.Users.ToListAsync();
                }

                if (!string.IsNullOrEmpty(dto.Email))
                {
                    logger.LogInformation(GetType().Name + " : #1 - search by Email parameter");

                    List<User> temp = new List<User>();

                    foreach (var item in list)
                    {
                        if (item.NormalizedEmail.Contains(dto.Email.ToUpper()))
                        {
                            temp.Add(item);
                        }
                    }

                    list = temp;
                }

                if (!string.IsNullOrEmpty(dto.PhoneNumber))
                {
                    logger.LogInformation(GetType().Name + " : #2 - search by PhoneNumber parameter");

                    List<User> temp = new List<User>();

                    foreach (var item in list)
                    {
                        if (item.PhoneNumber.Contains(dto.PhoneNumber))
                        {
                            temp.Add(item);
                        }
                    }

                    list = temp;
                }
                if (dto.RoleIds != null)
                {
                    logger.LogInformation(GetType().Name + " : #2 - search by PhoneNumber parameter");

                    List<User> temp = new List<User>();

                    foreach (var item in list)
                    {
                        List<RoleDTO> userRoles = await GetRolesForUser(item.Id.ToString());

                        bool flag = false;

                        foreach (var uRole in userRoles)
                        {
                            foreach (var rid in dto.RoleIds)
                            {
                                if (uRole.Id.Equals(rid))
                                {
                                    temp.Add(item);
                                    flag = true;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                break;
                            }
                        }
                    }

                    list = temp;
                }

                if (list.Count > 0)
                {
                    List<UserDTO> result = new List<UserDTO>();

                    foreach (var item in list)
                    {
                        result.Add(USmapper.ToDTO(item));
                    }

                    return result;
                }
                else
                {
                    string mesage = "search results is empty";
                    logger.LogError(GetType().Name + " : " + mesage);
                    throw new HttpException<User>("Search", mesage, HttpStatusCode.NotFound);
                }
            }
            else
            {
                string message = "dto parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("Search", message, HttpStatusCode.BadRequest);
            }
        }

        public string EncryptPassword(string password)
        {
            logger.LogInformation(GetType().Name + " : EncryptPassword");

            if (password != null)
            {
                string encryptPass = GetEncryptPassword(password);

                return encryptPass;
            }
            else
            {
                string message = "password is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("EncryptPassword", message, HttpStatusCode.BadRequest);
            }
        }

        public bool ValidatePassword(string hash, string password)
        {
            logger.LogInformation(GetType().Name + " : ValidatePassword");

            if (string.IsNullOrEmpty(hash))
            {
                string message = "hash is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("ValidatePassword", message, HttpStatusCode.BadRequest);
            }

            if (string.IsNullOrEmpty(password))
            {
                string message = "password is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("ValidatePassword", message, HttpStatusCode.BadRequest);
            }

            string encryptPass = GetEncryptPassword(password);

            return encryptPass.Equals(hash);
        }

        private string GetEncryptPassword(string password)
        {
            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string encryptPass = Convert.ToBase64String(KeyDerivation.Pbkdf2(password: password, salt: salt, prf: KeyDerivationPrf.HMACSHA256, iterationCount: 1000, numBytesRequested: 256 / 8));

            return encryptPass;
        }

        private bool CheckPermissions(ClaimsPrincipal currentUser, User user)
        {
            logger.LogInformation(GetType().Name + " : CheckPermissions");

            bool flag = false;

            if (currentUser != null && user != null)
            {
                string cUserName = currentUser.FindFirstValue(ClaimTypes.Name);

                flag = currentUser.IsInRole("ADMIN") || currentUser.IsInRole("OWNER") || user.UserName.Equals(cUserName);
            }

            return flag;
        }

        private string GenerateKeyWord()
        {
            logger.LogInformation(GetType().Name + " : GenerateKeyWord");

            string key = "";

            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                key += random.Next(10).ToString();
            }

            return key;
        }
    }
}