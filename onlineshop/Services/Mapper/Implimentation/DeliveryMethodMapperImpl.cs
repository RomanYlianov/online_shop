using Microsoft.Extensions.Logging;
using onlineshop.Models;
using onlineshop.Services.DTO;
using System;

namespace onlineshop.Services.Mapper.Implimentation
{
    public class DeliveryMethodMapperImpl : IDeliveryMethodMapper
    {

        private readonly ILogger logger;

        public DeliveryMethodMapperImpl()
        {
            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
           logger = logFactory.CreateLogger<DeliveryMethodMapperImpl>();
        }

        public DeliveryMethodDTO ToDTO(DeliveryMethod entity)
        {
         
            logger.LogInformation(GetType().Name + " : convert entity to DTO");

            DeliveryMethodDTO dto = new DeliveryMethodDTO();

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

        public DeliveryMethod ToEntity(DeliveryMethodDTO dto)
        {
            
            logger.LogInformation(GetType().Name + " : convert DTO to entity");

            DeliveryMethod entity = new DeliveryMethod();

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
    }
}
