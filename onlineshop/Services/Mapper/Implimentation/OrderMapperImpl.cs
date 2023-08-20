using Microsoft.Extensions.Logging;
using onlineshop.Models;
using onlineshop.Services.DTO;
using System;

namespace onlineshop.Services.Mapper.Implimentation
{
    public class OrderMapperImpl : IOrderMapper
    {

        private readonly IDeliveryMethodMapper DmMapper;

        private readonly IPaymentMethodMapper PmMapper;

        private readonly IUserMapper UserMapper;

        private readonly ILogger logger;

        public OrderMapperImpl(IDeliveryMethodMapper DmMapper, IPaymentMethodMapper PmMapper, IUserMapper UsMapper)
        {
            this.DmMapper = DmMapper;
            this.PmMapper = PmMapper;
            this.UserMapper = UsMapper;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<BasketMapperImpl>();
        }

        public OrderDTO ToDTO(Order entity)
        {
           
            logger.LogInformation(GetType().Name + " : convert entity to DTO");

            OrderDTO dto = new OrderDTO();

            if (entity != null)
            {

                if (entity.Id != null)
                {
                    dto.Id = entity.Id.ToString();
                }

                if (entity.Cipher != null)
                {
                    dto.Cipher = entity.Cipher;
                }

               

                if (entity.Count > 0)
                {
                    dto.Count = entity.Count;
                }

                if (entity.Price > 0)
                {
                    dto.Price = entity.Price;
                }
                
                if (entity.DeliveryMethod != null)
                {
                    dto.DeliveryMethodDTO = DmMapper.ToDTO(entity.DeliveryMethod);
                }

                if (entity.DeliveryMethodId != null)
                {
                    dto.DeliveryMethodDTOId = entity.DeliveryMethodId.ToString();
                }


                if (entity.PaymentMethod != null)
                {
                    dto.PaymentMethodDTO = PmMapper.ToDTO(entity.PaymentMethod);
                }

                if (entity.PaymentMethodId != null)
                {
                    dto.PaymentMethodDTOId = entity.PaymentMethodId.ToString();
                }

                if (entity.Buyer != null)
                {
                    dto.BuyerDTO = UserMapper.ToDTO(entity.Buyer);
                }

                if (entity.BuyerId != null)
                {
                    dto.BuyerDTOId = entity.BuyerId.ToString();
                }

                dto.OrderStatus = entity.OrderStatus;

                if (entity.Mark >= 0 && entity.Mark <= 10)
                {
                    dto.Mark = entity.Mark;
                }

                if (entity.ReceiptCode >= 1000 && entity.ReceiptCode <= 9999)
                {
                    dto.ReceiptCode = entity.ReceiptCode;
                }

                if (entity.TrackNumber != null)
                {
                    dto.TrackNumber = entity.TrackNumber;
                }

                if (entity.CreationTime != null)
                {
                    dto.CreationTime = entity.CreationTime;
                }

            }

            return dto;
        }

        public Order ToEntity(OrderDTO dto)
        {

            logger.LogInformation(GetType().Name + " : convert DTO to entity");

            Order entity = new Order();

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


        public Order ToEntity(Order entity, OrderDTO dto)
        {

            logger.LogInformation(GetType().Name + " : convert DTO to entity");

            entity = AssignData(entity, dto);

            return entity;

        }

        private Order AssignData(Order entity, OrderDTO dto)
        {

            logger.LogInformation(GetType().Name + " : AssignData");

            try
            {

                if (entity != null && dto != null)
                {

                    if (dto.Cipher != null)
                    {
                        entity.Cipher = dto.Cipher;
                    }

                    

                    if (dto.Count > 0)
                    {
                        entity.Count = dto.Count;
                    }

                    if (dto.Price > 0)
                    {
                        entity.Price = dto.Price;
                    }

                    if (dto.DeliveryMethodDTO != null)
                    {
                        entity.DeliveryMethod = DmMapper.ToEntity(dto.DeliveryMethodDTO);
                    }

                    if (dto.DeliveryMethodDTOId != null)
                    {
                        entity.DeliveryMethodId = Guid.Parse(dto.DeliveryMethodDTOId);
                    }

                    if (dto.PaymentMethodDTO != null)
                    {
                        entity.PaymentMethod = PmMapper.ToEntity(dto.PaymentMethodDTO);
                    }

                    if (dto.PaymentMethodDTOId != null)
                    {
                        entity.PaymentMethodId = Guid.Parse(dto.PaymentMethodDTOId);
                    }

                    if (dto.BuyerDTO != null)
                    {
                        entity.Buyer = UserMapper.ToEntity(dto.BuyerDTO);
                    }

                    if (dto.BuyerDTOId != null)
                    {
                        entity.BuyerId = Guid.Parse(dto.BuyerDTOId);
                    }

                    if (dto.OrderStatus != null)
                    {
                        entity.OrderStatus = dto.OrderStatus.Value;
                    }

                   

                    if (dto.Mark >= 0 && dto.Mark <= 10)
                    {
                        entity.Mark = dto.Mark;
                    }

                    if (dto.ReceiptCode >= 1000 && dto.ReceiptCode <= 9999)
                    {
                        entity.ReceiptCode = dto.ReceiptCode;
                    }

                    if (dto.TrackNumber != null)
                    {
                        entity.TrackNumber = dto.TrackNumber;
                    }

                    if (dto.CreationTime != null)
                    {
                        entity.CreationTime = dto.CreationTime;
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
