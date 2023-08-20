using Microsoft.Extensions.Logging;
using onlineshop.Models;
using onlineshop.Services.DTO;
using System;

namespace onlineshop.Services.Mapper.Implimentation
{
    public class EventMapperImpl : IEventMapper
    {

        private readonly IProductMapper PrMapper;

        private readonly ILogger logger;

        public EventMapperImpl(IProductMapper mapper)
        {
            PrMapper = mapper;
            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<EventMapperImpl>();
        }

        public EventDTO ToDTO(Event entity)
        {

            logger.LogInformation(GetType().Name + " : convert entity to DTO");

            EventDTO dto = new EventDTO();

            if (entity != null) 
            {
                
                if (entity.Id != null)
                {
                    dto.Id = entity.Id.ToString();
                }

                if (entity.Tittle != null)
                {
                    dto.Title = entity.Tittle;
                }

                if (entity.Product != null)
                {
                    dto.ProductDTO = PrMapper.ToDTO(entity.Product);
                }

                if (entity.ProductId != null)
                {
                    dto.ProductDTOId = entity.ProductId.ToString();
                }

                if (entity.Text != null)
                {
                    dto.Text = entity.Text;
                }

                if (entity.CreationTime != null)
                {
                    dto.CreationTime = entity.CreationTime;
                }

                if (entity.ExpirationTime != null)
                {
                    dto.ExpirationTime = entity.ExpirationTime.Value;
                }

            }

            return dto;
        }

        public Event ToEntity(EventDTO dto)
        {
           
            logger.LogInformation(GetType().Name + " : convert DTO to entity");

            Event entity = new Event();

            try
            {
                if (dto != null)
                {

                    if (dto.Id != null)
                    {
                        entity.Id = Guid.Parse(dto.Id);
                    }

                    if (dto.Title != null)
                    {
                        entity.Tittle = dto.Title;
                    }

                    if (dto.ProductDTO != null)
                    {
                        entity.Product = PrMapper.ToEntity(dto.ProductDTO);
                    }

                    if (dto.ProductDTOId != null)
                    {
                        entity.ProductId = Guid.Parse(dto.ProductDTOId);
                    }

                    if (dto.Text != null)
                    {
                        entity.Text = dto.Text;
                    }

                    if (dto.CreationTime != null)
                    {
                        entity.CreationTime = dto.CreationTime.Value;
                    }

                    if (dto.ExpirationTime != null)
                    {
                        entity.ExpirationTime = dto.ExpirationTime.Value;
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
