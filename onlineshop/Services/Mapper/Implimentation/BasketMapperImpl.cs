using Microsoft.Extensions.Logging;
using onlineshop.Models;
using onlineshop.Services.DTO;
using System;
using System.Runtime.CompilerServices;

namespace onlineshop.Services.Mapper.Implimentation
{
    public class BasketMapperImpl : IBasketMapper
    {
        
        private readonly IProductMapper PrMapper;

        private readonly IUserMapper UserMapper;

        private readonly ILogger logger;


        public BasketMapperImpl(IProductMapper PrMapper, IUserMapper UserMapper)
        {
            this.PrMapper = PrMapper;
            this.UserMapper = UserMapper;
            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<BasketMapperImpl>();
        }

        public BasketDTO ToDTO(Basket entity)
        {

            logger.LogInformation(GetType().Name + " : convert entity to DTO");

            BasketDTO dto = new BasketDTO();

            if (entity!=null)
            {

                if (entity.Id != null)
                {
                    dto.Id = entity.Id.ToString();
                }

                if (entity.Product != null)
                {
                    dto.ProductDTO = PrMapper.ToDTO(entity.Product);
                }

                if (entity.ProductId != null)
                {
                    dto.ProductDTOId = entity.ProductId.ToString();
                }

                if (entity.Buyer != null)
                {
                    dto.BuyerDTO = UserMapper.ToDTO(entity.Buyer);
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
                        entity.Product = PrMapper.ToEntity(dto.ProductDTO);
                    }

                    if (dto.ProductDTOId != null)
                    {

                        entity.ProductId = Guid.Parse(dto.ProductDTOId);
                    }

                    if (dto.BuyerDTO != null)
                    {
                        entity.Buyer = UserMapper.ToEntity(dto.BuyerDTO);
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
    }
}
