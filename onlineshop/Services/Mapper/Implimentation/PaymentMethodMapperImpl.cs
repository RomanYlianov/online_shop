using Microsoft.Extensions.Logging;
using onlineshop.Models;
using onlineshop.Services.DTO;
using System;

namespace onlineshop.Services.Mapper.Implimentation
{
    public class PaymentMethodMapperImpl : IPaymentMethodMapper
    {

        private readonly IUserMapper UMapper;

        private readonly ILogger logger;

        public PaymentMethodMapperImpl(IUserMapper uMapper)
        {

            UMapper = uMapper;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<PaymentMethodMapperImpl>();
        }

        public PaymentMethodDTO ToDTO(PaymentMethod entity)
        {

            logger.LogInformation(GetType().Name + " : convert entity to DTO");

            PaymentMethodDTO dto = new PaymentMethodDTO();

            if (entity != null)
            { 

                if (entity.Id != null)
                {
                    dto.Id = entity.Id.ToString();
                }

                if (entity.UserId != null)
                {
                    dto.UserDTOId = entity.UserId.ToString();
                }

                if (entity.User != null)
                {
                    dto.userDTO = UMapper.ToDTO(entity.User);
                }


                if (entity.Name != null)
                {
                    dto.Name = entity.Name;
                }

                dto.PaymentType = entity.PaymentType;

                if (entity.Provider != null)
                {
                    dto.Provider = entity.Provider;
                }

                if (entity.Number != null)
                {
                    dto.Number = entity.Number;
                }

                if (entity.ExpirationDate.HasValue)
                {
                    dto.ExpirationDate = entity.ExpirationDate.Value;
                }

                if (entity.CVV.HasValue)
                {
                    if (entity.CVV.Value > 0 && entity.CVV.Value <= 999)
                    {
                        dto.CVV = entity.CVV.Value;
                    }
                }

               
            }

            return dto;
        }

        public PaymentMethod ToEntity(PaymentMethod entity, PaymentMethodDTO dto)
        {

            logger.LogInformation(GetType().Name + " : convert DTO to entity");

            if (dto != null && entity != null)
            {
                entity = AssignData(entity, dto);
            }

            return entity;

        }

        public PaymentMethod ToEntity(PaymentMethodDTO dto)
        {
            
            logger.LogInformation((GetType().Name + " : convert DTO to entity"));

            PaymentMethod entity = new PaymentMethod();

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

        private PaymentMethod AssignData(PaymentMethod entity, PaymentMethodDTO dto)
        {

            logger.LogInformation(GetType().Name + " : AssignData");

            if (entity != null && dto!= null)
            {
                try
                {
                    if (dto.Name != null)
                    {
                        entity.Name = dto.Name;
                    }

                    if (dto.UserDTOId != null)
                    {
                        entity.UserId = Guid.Parse(dto.UserDTOId);
                    }

                    if (dto.userDTO != null)
                    {
                        entity.User = UMapper.ToEntity(dto.userDTO);
                    }

                    if (dto.PaymentType != null)
                    {
                        entity.PaymentType = dto.PaymentType.Value;
                    }


                    if (dto.Provider != null)
                    {
                        entity.Provider = dto.Provider;
                    }

                    if (dto.Number != null)
                    {
                        entity.Number = dto.Number;
                    }

                    if (dto.ExpirationDate != null)
                    {
                        entity.ExpirationDate = dto.ExpirationDate.Value;
                    }

                    if (dto.CVV != null)
                    {
                        if (dto.CVV.Value > 0 && dto.CVV.Value <= 999)
                        {
                            entity.CVV = dto.CVV.Value;
                        }
                    }
                }
                catch (FormatException ex)
                {
                    logger.LogError(GetType().Name + " : convert failed : " + ex.Message);
                }
            }

            return entity;

        }

    }
}
