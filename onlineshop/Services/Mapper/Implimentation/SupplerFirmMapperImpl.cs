using Microsoft.Extensions.Logging;
using onlineshop.Models;
using onlineshop.Services.DTO;
using System;

namespace onlineshop.Services.Mapper.Implimentation
{
    public class SupplerFirmMapperImpl : ISupperFirmMapper
    {
        private readonly ILogger logger;

        public SupplerFirmMapperImpl()
        {
            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<SupplerFirmMapperImpl>();
        }

        public SupplerFirm ToEntity(SupplerFirmDTO dto)
        {
            logger.LogInformation(GetType().Name + " : convert DTO to entity");

            SupplerFirm entity = new SupplerFirm();

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

                    if (dto.Address != null)
                    {
                        entity.Address = dto.Address;
                    }

                    if (dto.Country != null)
                    {
                        entity.Country = dto.Country;
                    }

                    if (dto.RegisterDate != null)
                    {
                        entity.RegisterDate = dto.RegisterDate.Value;
                    }

                    if (dto.Rating >= 0 && dto.Rating <= 10)
                    {
                        entity.Rating = dto.Rating;
                    }

                    entity.MoneyValue = dto.MoneyValue;

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

        public SupplerFirmDTO ToDTO(SupplerFirm entity)
        {
            logger.LogInformation(GetType().Name + " : convert entity to DTO");

            SupplerFirmDTO dto = new SupplerFirmDTO();

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

                if (entity.Address != null)
                {
                    dto.Address = entity.Address;
                }

                if (entity.Country != null)
                {
                    dto.Country = entity.Country;
                }

                if (entity.RegisterDate != null)
                {
                    dto.RegisterDate = entity.RegisterDate;
                }

                if (entity.Rating >= 0 && entity.Rating <= 10)
                {
                    dto.Rating = entity.Rating;
                }

                dto.MoneyValue = entity.MoneyValue;

                if (entity.Description != null)
                {
                    dto.Description = entity.Description;
                }
            }

            return dto;
        }
    }
}