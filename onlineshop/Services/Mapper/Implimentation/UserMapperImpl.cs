using Microsoft.Extensions.Logging;
using onlineshop.Models;
using onlineshop.Services.DTO;
using System;
using System.Collections.Generic;

namespace onlineshop.Services.Mapper.Implimentation
{
    public class UserMapperImpl : IUserMapper
    {
        private readonly ILogger logger;

        public UserMapperImpl()
        {
            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<UserMapperImpl>();
        }

        public User ToEntity(UserDTO dto)
        {
            logger.LogInformation(GetType().Name + " : convert DTO to entity");

            User entity = new User();

            try
            {
                if (dto != null)
                {
                    if (dto.Id != null)
                    {
                        entity.Id = Guid.Parse(dto.Id);
                    }

                    if (dto.UserName != null)
                    {
                        entity.UserName = dto.UserName;
                        entity.NormalizedUserName = dto.UserName.ToUpper();
                    }

                    if (dto.NormalizedUserName != null)
                    {
                        entity.NormalizedUserName = dto.NormalizedUserName;
                    }

                    if (dto.Email != null)
                    {
                        entity.Email = dto.Email;
                        entity.NormalizedEmail = dto.Email.ToUpper();
                    }

                    if (dto.NormailzedEmail != null)
                    {
                        entity.NormalizedEmail = dto.NormailzedEmail;
                    }

                    entity.EmailConfirmed = dto.EmailConfirmed;

                    if (dto.PasswordHash != null)
                    {
                        entity.PasswordHash = dto.PasswordHash;
                    }

                    if (dto.KeyWord != null)
                    {
                        entity.KeyWord = dto.KeyWord;
                    }

                    if (dto.FullName != null)
                    {
                        entity.FullName = dto.FullName;
                    }

                    entity.Birthday = dto.Birthday;

                    if (dto.Address != null)
                    {
                        entity.Address = dto.Address;
                    }

                    if (dto.Country != null)
                    {
                        entity.Country = dto.Country;
                    }

                    entity.IsVIP = dto.IsVIP;

                    entity.CreationTime = dto.CreationTime;

                    if (dto.SecurityStamp != null)
                    {
                        entity.SecurityStamp = dto.SecurityStamp;
                    }

                    if (dto.ConcurrencyStamp != null)
                    {
                        entity.ConcurrencyStamp = dto.ConcurrencyStamp;
                    }

                    if (dto.PhoneNumber != null)
                    {
                        entity.PhoneNumber = dto.PhoneNumber;
                    }

                    entity.PhoneNumberConfirmed = dto.PhoneNumberConfirmed;

                    entity.TwoFactorEnabled = dto.TwoFactorEnabled;

                    if (dto.LookOutEnd != null)
                    {
                        entity.LockoutEnd = dto.LookOutEnd.Value;
                    }

                    entity.LockoutEnabled = dto.LookOutEnabled;

                    entity.AccessFailedCount = dto.AccessFailedCount;
                }
            }
            catch (FormatException ex)
            {
                logger.LogError(GetType().Name + " : convert failed : " + ex.Message);
            }

            return entity;
        }

        public User ToEntity(User entity, UserUpdateDTO dto)
        {
            logger.LogInformation(GetType().Name + " : convert DTO to entity");

            if (dto != null)
            {
                if (dto.UserName != null)
                {
                    entity.UserName = dto.UserName;
                    entity.NormalizedUserName = dto.UserName.ToUpper();
                }

                if (dto.Email != null)
                {
                    entity.Email = dto.Email;
                    entity.NormalizedEmail = dto.Email.ToUpper();
                }

                if (dto.PhoneNumber != null)
                {
                    entity.PhoneNumber = dto.PhoneNumber;
                }

                if (dto.Password != null)
                {
                    entity.PasswordHash = dto.Password;
                }

                if (dto.KeyWord != null)
                {
                    entity.KeyWord = dto.KeyWord;
                }

                if (dto.FullName != null)
                {
                    entity.FullName = dto.FullName;
                }

                if (dto.Birthday != null)
                {
                    entity.Birthday = dto.Birthday;
                }

                if (dto.Address != null)
                {
                    entity.Address = dto.Address;
                }

                if (dto.Country != null)
                {
                    entity.Country = dto.Country;
                }

                entity.IsVIP = dto.IsVIP;
            }

            return entity;
        }

        public User ToEntity(UserLoginDTO dto, LoginType type)
        {
            logger.LogInformation(GetType().Name + " : convert LoginDTO to entity");

            User entity = new User();

            if (dto != null)
            {
                if (dto.Login != null)
                {
                    switch (type)
                    {
                        case LoginType.Email:
                            entity.Email = dto.Login;
                            break;

                        case LoginType.UserName:
                            entity.UserName = dto.Login;
                            break;

                        case LoginType.PhoneNumber:
                            entity.PhoneNumber = dto.Login;
                            break;
                    }
                }

                if (dto.Password != null)
                {
                    entity.PasswordHash = dto.Password;
                }
            }

            return entity;
        }

        public User ToEntity(UserRegisterDTO dto)
        {
            logger.LogInformation(GetType().Name + " : convert entity to RegisterDTO");

            User entity = new User();

            try
            {
                if (dto != null)
                {
                    if (dto.Id != null)
                    {
                        entity.Id = Guid.Parse(dto.Id);
                    }

                    if (dto.UserName != null)
                    {
                        entity.UserName = dto.UserName;
                        entity.NormalizedUserName = dto.UserName.ToUpper();
                    }

                    if (dto.Email != null)
                    {
                        entity.Email = dto.Email;
                        entity.NormalizedEmail = dto.Email.ToUpper();
                    }

                    if (dto.PhoneNumber != null)
                    {
                        entity.PhoneNumber = dto.PhoneNumber;
                    }

                    if (dto.Password != null)
                    {
                        entity.PasswordHash = dto.Password;
                    }

                    if (dto.KeyWord != null)
                    {
                        entity.KeyWord = dto.KeyWord;
                    }

                    if (dto.FullName != null)
                    {
                        entity.FullName = dto.FullName;
                    }

                    if (dto.Birthday != null)
                    {
                        entity.Birthday = dto.Birthday;
                    }

                    if (dto.Address != null)
                    {
                        entity.Address = dto.Address;
                    }

                    if (dto.Country != null)
                    {
                        entity.Country = dto.Country;
                    }

                    entity.IsVIP = dto.IsVIP;
                }
            }
            catch (FormatException ex)
            {
                logger.LogError(GetType().Name + " : convert failed : " + ex.Message);
            }

            return entity;
        }

        public UserDTO ToDTO(User entity)
        {
            logger.LogInformation(GetType().Name + " : convert entity to DTO");

            UserDTO dto = new UserDTO();

            if (entity != null)
            {
                if (entity.Id != null)
                {
                    dto.Id = entity.Id.ToString();
                }

                if (entity.UserName != null)
                {
                    dto.UserName = entity.UserName;
                }

                if (entity.NormalizedUserName != null)
                {
                    dto.NormalizedUserName = entity.NormalizedUserName;
                }

                if (entity.Email != null)
                {
                    dto.Email = entity.Email;
                }

                if (entity.NormalizedEmail != null)
                {
                    dto.NormailzedEmail = entity.NormalizedEmail;
                }

                dto.EmailConfirmed = entity.EmailConfirmed;

                if (entity.PasswordHash != null)
                {
                    dto.PasswordHash = entity.PasswordHash;
                }

                if (entity.KeyWord != null)
                {
                    dto.KeyWord = entity.KeyWord;
                }

                if (entity.FullName != null)
                {
                    dto.FullName = entity.FullName;
                }

                dto.Birthday = entity.Birthday;

                if (entity.Address != null)
                {
                    dto.Address = entity.Address;
                }

                if (entity.Country != null)
                {
                    dto.Country = entity.Country;
                }

                dto.IsVIP = entity.IsVIP;
                dto.CreationTime = entity.CreationTime;

                if (entity.SecurityStamp != null)
                {
                    dto.SecurityStamp = entity.SecurityStamp;
                }

                if (entity.ConcurrencyStamp != null)
                {
                    dto.ConcurrencyStamp = entity.ConcurrencyStamp;
                }

                if (entity.PhoneNumber != null)
                {
                    dto.PhoneNumber = entity.PhoneNumber;
                }

                dto.PhoneNumberConfirmed = entity.PhoneNumberConfirmed;

                dto.TwoFactorEnabled = entity.TwoFactorEnabled;

                if (entity.LockoutEnd != null)
                {
                    dto.LookOutEnd = entity.LockoutEnd.Value;
                }

                dto.LookOutEnabled = entity.LockoutEnabled;

                dto.AccessFailedCount = entity.AccessFailedCount;
            }

            return dto;
        }

        public UserLoginDTO ToLoginDTO(User entiny, LoginType type)
        {
            logger.LogInformation(GetType().Name + " : convert entity to LoginDTO");

            UserLoginDTO dto = new UserLoginDTO();

            if (entiny != null)
            {
                switch (type)
                {
                    case LoginType.Email:
                        dto.Login = entiny.Email;
                        break;

                    case LoginType.UserName:
                        dto.Login = entiny.UserName;
                        break;

                    case LoginType.PhoneNumber:
                        dto.Login = entiny.PhoneNumber;
                        break;
                }

                if (entiny.PasswordHash != null)
                {
                    dto.Password = entiny.PasswordHash;
                }
            }

            return dto;
        }

        public UserRegisterDTO ToRegisterDTO(User entity)
        {
            logger.LogInformation(GetType().Name + " : convert entity to RegisterDTO");

            UserRegisterDTO dto = new UserRegisterDTO();

            if (entity != null)
            {
                if (entity.UserName != null)
                {
                    dto.UserName = entity.UserName;
                }

                if (entity.Email != null)
                {
                    dto.Email = entity.Email;
                }

                if (entity.PhoneNumber != null)
                {
                    dto.PhoneNumber = entity.PhoneNumber;
                }

                if (entity.PasswordHash != null)
                {
                    dto.Password = dto.PasswordConfirm = entity.PasswordHash;
                }

                if (entity.KeyWord != null)
                {
                    dto.KeyWord = entity.KeyWord;
                }

                if (entity.FullName != null)
                {
                    dto.FullName = entity.FullName;
                }

                if (entity.Birthday != null)
                {
                    dto.Birthday = entity.Birthday;
                }

                if (entity.Address != null)
                {
                    dto.Address = entity.Address;
                }

                if (entity.Country != null)
                {
                    dto.Country = entity.Country;
                }

                dto.IsVIP = entity.IsVIP;
            }

            return dto;
        }

        public UserUpdateDTO ToUpdateDTO(UserDTO dto, List<RoleDTO> userRoles, List<RoleDTO> otherRoles)
        {
            logger.LogInformation(GetType().Name + "ToUpdateDTO");

            UserUpdateDTO updateDTO = new UserUpdateDTO();

            if (updateDTO != null)
            {
                if (dto.Id != null)
                {
                    updateDTO.Id = dto.Id;
                }

                if (dto.UserName != null)
                {
                    updateDTO.UserName = dto.UserName;
                }

                if (dto.Email != null)
                {
                    updateDTO.Email = dto.Email;
                }

                if (dto.PhoneNumber != null)
                {
                    updateDTO.PhoneNumber = dto.PhoneNumber;
                }

                if (dto.PasswordHash != null)
                {
                    updateDTO.Password = updateDTO.PasswordConfirm = dto.PasswordHash;
                }

                if (dto.KeyWord != null)
                {
                    updateDTO.KeyWord = dto.KeyWord;
                }

                if (dto.FullName != null)
                {
                    updateDTO.FullName = dto.FullName;
                }

                if (dto.Birthday != null)
                {
                    updateDTO.Birthday = dto.Birthday;
                }

                if (dto.Address != null)
                {
                    updateDTO.Address = dto.Address;
                }

                if (dto.Country != null)
                {
                    updateDTO.Country = dto.Country;
                }

                updateDTO.IsVIP = dto.IsVIP;

                //set roles

                if (userRoles != null)
                {
                    List<string> values = new List<string>();

                    foreach (var item in userRoles)
                    {
                        values.Add(item.Name);
                    }
                    updateDTO.UserRoles = values;
                }

                if (otherRoles != null)
                {
                    List<string> values = new List<string>();

                    foreach (var item in otherRoles)
                    {
                        values.Add(item.Name);
                    }

                    updateDTO.OtherRoles = values;
                }
            }
            return updateDTO;
        }
    }
}