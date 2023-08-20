using Microsoft.Extensions.Logging;
using onlineshop.Models;
using onlineshop.Services.DTO;
using System;

namespace onlineshop.Services.Mapper.Implimentation
{
    public class RoleMapperImpl : IRoleMapper
    {

        private readonly ILogger logger;

        public RoleMapperImpl()
        {
            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<RoleMapperImpl>();
        }

        public RoleDTO ToDTO(Role entity)
        {
          
            logger.LogInformation(GetType().Name + " : convert entity to DTO");

            RoleDTO dto = new RoleDTO();

            if (entity!=null)
            {

                if (entity.Id != null)
                {
                    dto.Id = entity.Id.ToString();
                }

                if (entity.Name != null)
                {
                    dto.Name = entity.Name;
                }

                if (entity.Description != null)
                {
                    dto.Description = entity.Description;
                }

            }

            return dto;
        }

        public Role ToEntity(RoleDTO dto)
        {
            
            logger.LogInformation(GetType().Name + " : convert DTO to entity");

            Role entity = new Role();

            try
            {
                if (dto != null)
                {

                    if (dto.Id != null)
                    {
                        entity.Id = Guid.Parse(dto.Id);
                    }

                    entity = AssignData(entity, dto);

                }
            }
            catch (FormatException ex)
            {
                logger.LogError(GetType().Name + " : convert failed : " + ex.Message);
            }
          

            return entity;
        }


        public Role ToEntity(Role entity, RoleDTO dto)
        {

            logger.LogInformation(GetType().Name + " : convert DTO to entity");

            entity = AssignData(entity, dto);

            return entity;

        }

        private Role AssignData(Role entity, RoleDTO dto)
        {

            logger.LogInformation(GetType().Name + " : AssignData");

            if (entity != null && dto != null)
            {
                if (dto.Name != null)
                {
                    entity.Name = dto.Name.ToUpper();
                    entity.NormalizedName = dto.Name.ToUpper();
                }

                if (dto.Description != null)
                {
                    entity.Description = dto.Description;
                }

                
            }

            return entity;
        }

    }
}
