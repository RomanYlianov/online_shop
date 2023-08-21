using Microsoft.Extensions.Logging;
using onlineshop.Models;
using onlineshop.Services.DTO;
using System;

namespace onlineshop.Services.Mapper.Implimentation
{
    public class BasketMapperImpl : IBasketMapper
    {
        private readonly IProductMapper PMapper;

        private readonly IUserMapper UMapper;

        private readonly ILogger logger;

        public BasketMapperImpl(IProductMapper pMapper, IUserMapper uMapper)
        {
            this.PMapper = pMapper;
            this.UMapper = uMapper;
            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<BasketMapperImpl>();
        }

        public Basket ToEntity(BasketDTO dto)
        {
            logger.LogInformation(this.GetType().Name + " : convert DTO to entity");

            Basket entity = new Basket();

            try
            {
                if (dto != null)
                {
                    if (dto.Id != null)
                    {
                        entity.Id = Guid.Parse(dto.Id);
                    }

                    if (dto.ProductDTO != null)
                    {
                        entity.Product = PMapper.ToEntity(dto.ProductDTO);
                    }

                    if (dto.ProductDTOId != null)
                    {
                        entity.ProductId = Guid.Parse(dto.ProductDTOId);
                    }

                    if (dto.BuyerDTO != null)
                    {
                        entity.Buyer = UMapper.ToEntity(dto.BuyerDTO);
                    }

                    if (dto.BuyerDTOId != null)
                    {
                        entity.BuyerId = Guid.Parse(dto.BuyerDTOId);
                    }

                    if (dto.Count > 0)
                    {
                        entity.Count = dto.Count;
                    }

                    if (dto.IntermediateCost > 0)
                    {
                        entity.IntermediateCost = dto.IntermediateCost;
                    }
                }
            }
            catch (FormatException ex)
            {
                logger.LogError(GetType().Name + " : convert failed : " + ex.Message);
            }

            return entity;
        }

        public BasketDTO ToDTO(Basket entity)
        {
            logger.LogInformation(GetType().Name + " : convert entity to DTO");

            BasketDTO dto = new BasketDTO();

            if (entity != null)
            {
                if (entity.Id != null)
                {
                    dto.Id = entity.Id.ToString();
                }

                if (entity.Product != null)
                {
                    dto.ProductDTO = PMapper.ToDTO(entity.Product);
                }

                if (entity.ProductId != null)
                {
                    dto.ProductDTOId = entity.ProductId.ToString();
                }

                if (entity.Buyer != null)
                {
                    dto.BuyerDTO = UMapper.ToDTO(entity.Buyer);
                }

                if (entity.BuyerId != null)
                {
                    dto.BuyerDTOId = entity.BuyerId.ToString();
                }

                if (entity.Count > 0)
                {
                    dto.Count = entity.Count;
                }

                if (entity.IntermediateCost > 0)
                {
                    dto.IntermediateCost = entity.IntermediateCost;
                }
            }

            return dto;
        }
    }
}