using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using onlineshop.Data;
using onlineshop.Models;
using onlineshop.Services.DTO;
using onlineshop.Services.Mapper;
using onlineshop.Services.Mapper.Implimentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace onlineshop.Services.Implimentation
{
    public class DeliveryMethodServiceImpl : IDeliveryMethodService
    {

        private readonly ApplicationDbContext context;

        private readonly IDeliveryMethodMapper DmMapper;

        private readonly ILogger logger;

        public DeliveryMethodServiceImpl(ApplicationDbContext ctx, IDeliveryMethodMapper DMMApper)
        {
            context = ctx;
            this.DmMapper = DMMApper;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<DeliveryMethodServiceImpl>();
        }

        public async Task<List<DeliveryMethodDTO>> GetAll()
        {
            
            logger.LogInformation(GetType().Name + " : GetAll");
           
            List<DeliveryMethod> list = await context.DeliveryMethodsCtx.ToListAsync();

            List<DeliveryMethodDTO> result = new List<DeliveryMethodDTO>();

            string message = string.Empty;

            if (list != null)
            {
                if (list.Count == 0)
                {
                    message = "deliverymethods entity is empty";
                }
               
            }
            else
            {
                message = "deliverymethods entity is empty";
                
            }

            if (string.IsNullOrEmpty(message))
            {
                foreach (var item in list)
                {
                    result.Add(DmMapper.ToDTO(item));
                }
            }
            else
            {
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<DeliveryMethod>("GeAll", message, HttpStatusCode.NotFound);
            }

            return result;
        }

        public async Task<DeliveryMethodDTO> GetById(string id)
        {
           
            logger.LogInformation(GetType().Name + " : GetById");

            if (id != null)
            {

                try
                {
                    DeliveryMethod entity = await context.DeliveryMethodsCtx.FindAsync(Guid.Parse(id));
                    if (entity != null)
                    {
                        return DmMapper.ToDTO(entity);
                    }
                    else
                    {
                        string message = "deliverymethod with id " + id + " was not found";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<DeliveryMethod>("GetById", message, HttpStatusCode.NotFound);

                    }
                  
                }
                catch (FormatException ex)
                {
                    string message = "convert id " + id + " failed : " + ex.Message;
                    logger.LogError(GetType().Name + " : : " + message);
                    throw new HttpException<DeliveryMethod>("GetById", message, HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                string message = "id parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<DeliveryMethod>("GetById", message, HttpStatusCode.BadRequest);
            }

        }

        public async Task<DeliveryMethodDTO> Add(DeliveryMethodDTO item)
        {
            
            logger.LogInformation(GetType().Name + " : Add");
            
            if (item != null)
            {
                
                DeliveryMethod entity = DmMapper.ToEntity(item);

                await context.DeliveryMethodsCtx.AddAsync(entity);

                await context.SaveChangesAsync();

                item = DmMapper.ToDTO(entity);

                return item;
            }
            else
            {
                string message = "item parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<DeliveryMethod>("Add", message, HttpStatusCode.BadRequest);
            }

          
        }

        public async Task<DeliveryMethodDTO> Update(DeliveryMethodDTO item)
        {

            logger.LogInformation(GetType().Name + " : Update");

            if (item != null)
            {
                DeliveryMethod entity = DmMapper.ToEntity(item);
                
                try
                {
                    if (await context.DeliveryMethodsCtx.FindAsync(Guid.Parse(item.Id)) != null)
                    {
                        context.DeliveryMethodsCtx.Update(entity);

                        await context.SaveChangesAsync();

                        item = DmMapper.ToDTO(entity);

                        return item;
                    }
                    else
                    {
                        string message = "deliverymethod with id " + item.Id + " was not found";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<DeliveryMethod>("Update", message, HttpStatusCode.NotFound);
                    }
                }
                catch (FormatException ex)
                {
                    string message = "convert id " + item.Id + " failed : " + ex.Message;
                    logger.LogError(GetType().Name + " : : " + message);
                    throw new HttpException<DeliveryMethod>("Update", message, HttpStatusCode.InternalServerError);
                }
               
                
            }
            else
            {
                string message = "item parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<DeliveryMethod>("Update", message, HttpStatusCode.BadRequest);
            }

        }

        public async Task Delete(string id)
        {
           
            logger.LogInformation(GetType().Name + " : Delete");

            if (id != null)
            {
                try
                {
                    DeliveryMethod entity = await context.DeliveryMethodsCtx.FindAsync(Guid.Parse(id));
                    if (entity != null)
                    {
                        context.DeliveryMethodsCtx.Remove(entity);

                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        string message = "deliverymethod with id " + id + " was not found";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<DeliveryMethod>("Delete", message, HttpStatusCode.NotFound);
                    }

                }
                catch (FormatException ex)
                {
                    string message = "convert id " + id + " failed : " + ex.Message;
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<DeliveryMethod>("Delete", message, HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                string message = "id parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<DeliveryMethod>("Delete", message, HttpStatusCode.BadRequest);
            }
                
        }
        
    }
}
