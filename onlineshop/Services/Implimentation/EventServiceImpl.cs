using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using onlineshop.Data;
using onlineshop.Models;
using onlineshop.Services.DTO;
using onlineshop.Services.Mapper;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using System.Security.Claims;
using System.Diagnostics.SymbolStore;
using System.Linq;

namespace onlineshop.Services.Implimentation
{
    public class EventServiceImpl : IEventService
    {

        private readonly ApplicationDbContext context;

        private readonly IEventMapper EMapper;

        private readonly IProductService PService;

        private readonly IProductMapper Pmapper;
        
        private readonly ILogger logger;

        public EventServiceImpl(ApplicationDbContext context, IEventMapper eMapper, IProductService pService, IProductMapper pmapper)
        {

            this.context = context;

            this.EMapper = eMapper;
            this.PService = pService;
            this.Pmapper = pmapper;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<EventServiceImpl>();

        }

        public async Task<List<EventDTO>> GetAll()
        {

            logger.LogInformation(GetType().Name + " : GetAll");

            List<Event> list = await context.EventsCtx.Include(e => e.Product).ToListAsync();

            List<EventDTO> result = new List<EventDTO>();

            string message = string.Empty;

            if (list != null)
            {
                if (list.Count == 0)
                {
                    message = "event entity is empty";
                }
            }
            else
            {
                message = "event entity is empty";
            }

            if (string.IsNullOrEmpty(message))
            {
                foreach (var item in list)
                {
                    result.Add(EMapper.ToDTO(item));
                }
            }
            else
            {
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Event>("GetAll", message, HttpStatusCode.NotFound);
            }

            return result;

        }

        public  async Task<EventDTO> GetById(string id)
        {

            logger.LogInformation(GetType().Name + " : GetById");

            if (id != null)
            {
                try
                {
                
                    Event entity = await context.EventsCtx.Include(e => e.Product).FirstOrDefaultAsync(e => e.Id.Equals(Guid.Parse(id)));
                
                    if (entity != null)
                    {

                        return EMapper.ToDTO(entity);

                    }
                    else
                    {
                        string message = "event with id " + id + " was not found";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<Event>("GetById", message, HttpStatusCode.NotFound);
                    }
                
                }
                catch (FormatException ex)
                {
                    string message = "convert id " + id + " failed: " + ex.Message;
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Event>("GetById", message, HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                string message = "id parameter is required";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Event>("GetById", message, HttpStatusCode.BadRequest);
            }

        }

        /*
         * дата создания указывает на текущую дату,
         * дата истечения может не содержаться для создания акции с безлимитным сроком действия;
         * например, акция "пенсионерам скидки"
         */
        public async Task<EventDTO> Add(EventDTO item)
        {

            logger.LogInformation(GetType().Name + " : Add");

            if (item != null)
            {

                Event entity = EMapper.ToEntity(item);
                //set creation time

                
                entity.CreationTime = DateTime.Now;

                await context.EventsCtx.AddAsync(entity);
                await context.SaveChangesAsync();

                item = EMapper.ToDTO(entity);
                return item;

            }
            else
            {
                string message = "item parameter is required";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Event>("Add", message, HttpStatusCode.BadRequest);
            }

        }

        public async Task<EventDTO> Update(EventDTO item)
        {

            logger.LogInformation(GetType().Name + " : Update");

            if (item != null)
            {                
                try
                {

                    Event entity = await context.EventsCtx.Include(e => e.Product).FirstOrDefaultAsync(e => e.Id.Equals(Guid.Parse(item.Id)));


                    if (entity != null)
                    {
                        entity = EMapper.ToEntity(item);

                        entity.Product = null;

                        context.EventsCtx.Update(entity);
                        await context.SaveChangesAsync();

                        item = EMapper.ToDTO(entity);

                        return item;
                    }
                    else
                    {
                        string message = "event with id " + item.Id + " was not found";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<Event>("Update", message, HttpStatusCode.NotFound);
                    }


                    

                }
                catch (FormatException ex)
                {
                    string message = "convert id " + item.Id + " failed: " + ex.Message;
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Event>("GetById", message, HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                string message = "item parameter is required";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Event>("Update", message, HttpStatusCode.BadRequest);
            }

        }

        public async Task Delete(string id)
        {

            logger.LogInformation(GetType().Name + " : Delete");

            if (id != null)
            {

                try
                {

                    Event entity = await context.EventsCtx.FindAsync(Guid.Parse(id));

                    if (entity != null)
                    {

                        context.EventsCtx.Remove(entity);
                        await context.SaveChangesAsync();

                    }
                    else
                    {
                        string message = "event with id " + id + " was not foud";
                        logger.LogError("Delete", message, HttpStatusCode.NotFound);
                        throw new HttpException<Event>("Delete", message, HttpStatusCode.NotFound);
                    }


                }
                catch (FormatException ex)
                {
                    string message = "convert id " + id + " failed: " + ex.Message;
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Event>("GetById", message, HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                string message = "id parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Event>("Delete", message, HttpStatusCode.BadRequest);
            }
            

        }

        

    }
}
