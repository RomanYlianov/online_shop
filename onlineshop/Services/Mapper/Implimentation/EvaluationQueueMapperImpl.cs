using Microsoft.Extensions.Logging;
using onlineshop.Models;
using onlineshop.Services.DTO;
using System;

namespace onlineshop.Services.Mapper.Implimentation
{
    public class EvaluationQueueMapperImpl : IEvaluationQueueMapper
    {
        private readonly IUserMapper UMapper;

        private readonly IProductMapper PMapper;

        private readonly IOrderMapper OMapper;

        private readonly ILogger logger;

        public EvaluationQueueMapperImpl(IUserMapper uMapper, IProductMapper pMapper, IOrderMapper oMapper)
        {
            this.UMapper = uMapper;
            this.PMapper = pMapper;
            this.OMapper = oMapper;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<EvaluationQueueMapperImpl>();
        }

        public EvaluationQueue ToEntity(EvaluationQueueDTO dto)
        {
            logger.LogInformation(GetType().Name + " : convert DTO to entity");

            EvaluationQueue entity = new EvaluationQueue();

            if (dto != null)
            {
                try
                {
                    if (dto.Id != null)
                    {
                        entity.Id = Guid.Parse(dto.Id);
                    }

                    if (dto.BuyerDTO != null)
                    {
                        entity.Buyer = UMapper.ToEntity(dto.BuyerDTO);
                    }

                    if (dto.BuyerDTOId != null)
                    {
                        entity.BuyerId = Guid.Parse(dto.BuyerDTOId);
                    }

                    if (dto.ProductDTO != null)
                    {
                        entity.Product = PMapper.ToEntity(dto.ProductDTO);
                    }

                    if (dto.ProductDTOId != null)
                    {
                        entity.ProductId = Guid.Parse(dto.ProductDTOId);
                    }

                    if (dto.OrderDTO != null)
                    {
                        entity.Order = OMapper.ToEntity(dto.OrderDTO);
                    }

                    if (dto.OrderDTOId != null)
                    {
                        entity.OrderId = Guid.Parse(dto.OrderDTOId);
                    }

                    entity.IsAddedComment = dto.IsAddedComment;
                    entity.IsRateProduct = dto.IsRateProduct;
                }
                catch (FormatException ex)
                {
                    logger.LogError(GetType().Name + " : convert failed : " + ex.Message);
                }
            }

            return entity;
        }

        public EvaluationQueueDTO ToDTO(EvaluationQueue entity)
        {
            logger.LogInformation(GetType().Name + " : Convert entity to DTO");

            EvaluationQueueDTO dto = new EvaluationQueueDTO();

            if (entity != null)
            {
                if (entity.Id != null)
                {
                    dto.Id = entity.Id.ToString();
                }
            }

            if (entity.Buyer != null)
            {
                dto.BuyerDTO = UMapper.ToDTO(entity.Buyer);
            }

            if (entity.BuyerId != null)
            {
                dto.BuyerDTOId = entity.BuyerId.ToString();
            }

            if (entity.Product != null)
            {
                dto.ProductDTO = PMapper.ToDTO(entity.Product);
            }

            if (entity.ProductId != null)
            {
                dto.ProductDTOId = entity.ProductId.ToString();
            }

            if (entity.Order != null)
            {
                dto.OrderDTO = OMapper.ToDTO(entity.Order);
            }

            if (entity.OrderId != null)
            {
                dto.OrderDTOId = entity.OrderId.ToString();
            }

            dto.IsAddedComment = entity.IsAddedComment;
            dto.IsRateProduct = entity.IsRateProduct;

            return dto;
        }
    }
}