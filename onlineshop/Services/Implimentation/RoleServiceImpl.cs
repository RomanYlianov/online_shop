using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using onlineshop.Data;
using onlineshop.Models;
using onlineshop.Services.DTO;
using onlineshop.Services.Mapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace onlineshop.Services.Implimentation
{
    public class RoleServiceImpl : IRoleService
    {
        private readonly ApplicationDbContext context;

        private readonly IRoleMapper RMapper;

        private RoleManager<Role> RManager;

        private readonly ILogger logger;

        public RoleServiceImpl(ApplicationDbContext context, RoleManager<Role> manager, IRoleMapper mapper)
        {
            this.context = context;
            this.RManager = manager;
            this.RMapper = mapper;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<RoleServiceImpl>();
        }

        public async Task<List<RoleDTO>> GetAll()
        {
            logger.LogInformation(GetType().Name + " : GetAll");

            List<Role> list = await context.Roles.ToListAsync();

            List<RoleDTO> result = new List<RoleDTO>();

            string message = string.Empty;

            if (list != null)
            {
                if (list.Count == 0)
                {
                    message = "roles entity is empty";
                }
            }
            else
            {
                message = "roles entity is empty";
            }

            if (string.IsNullOrEmpty(message))
            {
                foreach (var item in list)
                {
                    result.Add(RMapper.ToDTO(item));
                }
            }
            else
            {
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Role>("GetAll", message, HttpStatusCode.NotFound);
            }

            return result;
        }

        public async Task<RoleDTO> GetById(string id)
        {
            logger.LogInformation(GetType().Name + " : GetById");

            if (id != null)
            {
                try
                {
                    Role entity = await context.Roles.FindAsync(Guid.Parse(id));

                    if (entity != null)
                    {
                        return RMapper.ToDTO(entity);
                    }
                    else
                    {
                        string message = "role with id " + id + " was not found";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<Role>("GetById", message, HttpStatusCode.NotFound);
                    }
                }
                catch (Exception ex)
                {
                    string message = "convert id " + id + " failed: " + ex.Message;
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Role>("GetById", message, HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                string message = "id parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Role>("GetById", message, HttpStatusCode.BadRequest);
            }
        }

        public async Task<RoleDTO> Add(RoleDTO item)
        {
            logger.LogInformation(GetType().Name + " : Add");

            if (item != null)
            {
                Role entity = RMapper.ToEntity(item);

                await RManager.CreateAsync(entity);

                item = RMapper.ToDTO(entity);

                return item;
            }
            else
            {
                string message = "item parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Role>("Add", message, HttpStatusCode.BadRequest);
            }
        }

        public async Task<RoleDTO> Update(RoleDTO item)
        {
            logger.LogInformation(GetType().Name + " : Update");

            if (item != null)
            {
                try
                {
                    if (!IsSystemRole(item.Name))
                    {
                        if (await context.Roles.FindAsync(Guid.Parse(item.Id)) != null)
                        {
                            Role entity = await RManager.FindByIdAsync(item.Id);

                            entity = RMapper.ToEntity(entity, item);

                            await RManager.UpdateAsync(entity);

                            item = RMapper.ToDTO(entity);

                            return item;
                        }
                        else
                        {
                            string message = "role with id " + item.Id + " was not found";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<Role>("Update", message, HttpStatusCode.NotFound);
                        }
                    }
                    else
                    {
                        string message = "system role can't be changed";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<Role>("Add", message, HttpStatusCode.Forbidden);
                    }
                }
                catch (FormatException ex)
                {
                    string message = "convert id " + item.Id + " failed: " + ex.Message;
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Role>("GetById", message, HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                string message = "item parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Role>("Update", message, HttpStatusCode.BadRequest);
            }
        }

        public async Task Delete(string id)
        {
            logger.LogInformation(GetType().Name + " : Delete");

            if (id != null)
            {
                try
                {
                    Role entity = await context.Roles.FindAsync(Guid.Parse(id));

                    if (entity != null)
                    {
                        if (!IsSystemRole(entity.Name))
                        {
                            await RManager.DeleteAsync(entity);
                        }
                        else
                        {
                            string message = "system role can't be changed";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<Role>("Add", message, HttpStatusCode.Forbidden);
                        }
                    }
                    else
                    {
                        string message = "role with id" + id + " was not found";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<Role>("Delete", message, HttpStatusCode.NotFound);
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
                throw new HttpException<Role>("Delete", message, HttpStatusCode.BadRequest);
            }
        }

        public async Task<bool> CheckName(string name)
        {
            logger.LogInformation(GetType().Name + " : CheckName");

            if (name != null)
            {
                bool flag = await context.Roles.FirstOrDefaultAsync(r => r.Name.Equals(name)) != null;
                return flag;
            }
            else
            {
                string message = "name parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Role>("ChekName", message, HttpStatusCode.BadRequest);
            }
        }

        private bool IsSystemRole(string role)
        {
            return role.Equals("admin") || role.Equals("owner") || role.Equals("seller") || role.Equals("buyer");
        }
    }
}