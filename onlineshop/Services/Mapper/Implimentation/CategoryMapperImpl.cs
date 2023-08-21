using Microsoft.Extensions.Logging;
using onlineshop.Models;
using onlineshop.Services.DTO;
using System;

namespace onlineshop.Services.Mapper.Implimentation
{
    public class CategoryMapperImpl : ICategoryMapper
    {
        private readonly ILogger logger;

        public CategoryMapperImpl()
        {
            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<CategoryMapperImpl>();
        }

        public Category ToEntity(CategoryDTO dto)
        {
            logger.LogInformation(GetType().Name + " : convert DTO to entity");

            Category entity = new Category();

            try
            {
                if (dto != null)
                {
                    if (dto.Id != null)
                    {
                        entity.Id = Guid.Parse(dto.Id);
                    }

                    if (dto.Name != null)
                    {
                        entity.Name = dto.Name;
                    }

                    if (dto.Description != null)
                    {
                        entity.Description = dto.Description;
                    }
                }
            }
            catch (FormatException ex)
            {
                logger.LogError(GetType().Name + " : convert failed : " + ex.Message);
            }

            return entity;
        }

        public CategoryDTO ToDTO(Category entity)
        {
            logger.LogInformation(GetType().Name + " : convert entity to DTO");

            CategoryDTO dto = new CategoryDTO();

            if (entity != null)
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
    }
}