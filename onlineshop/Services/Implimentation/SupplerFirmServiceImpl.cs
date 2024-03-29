﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using onlineshop.Data;
using onlineshop.Models;
using onlineshop.Services.DTO;
using onlineshop.Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace onlineshop.Services.Implimentation
{
    public class SupplerFirmServiceImpl : ISupplerFirmService
    {
        private readonly ApplicationDbContext context;

        private readonly ISupperFirmMapper SFMapper;

        private readonly SignInManager<User> SINManager;

        private readonly ILogger logger;

        public SupplerFirmServiceImpl(ApplicationDbContext context, SignInManager<User> sINManager, ISupperFirmMapper mapper)
        {
            this.context = context;
            this.SFMapper = mapper;

            this.SINManager = sINManager;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<SupplerFirmServiceImpl>();
        }

        public async Task<List<SupplerFirmDTO>> GetAll()
        {
            logger.LogInformation(GetType().Name + " : GetAll");

            List<SupplerFirm> list = await context.SupplerFirmsCtx.ToListAsync();

            List<SupplerFirmDTO> result = new List<SupplerFirmDTO>();

            string message = string.Empty;

            if (list != null)
            {
                if (list.Count == 0)
                {
                    message = "supperfirm enitiy is empty";
                }
            }
            else
            {
                message = "supperfirm enitiy is empty";
            }

            if (string.IsNullOrEmpty(message))
            {
                foreach (var item in list)
                {
                    if (!item.Name.Equals("root supplerfirm"))
                        result.Add(SFMapper.ToDTO(item));
                }
            }
            else
            {
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<SupplerFirm>("GetAll", message, HttpStatusCode.NotFound);
            }

            return result;
        }

        public async Task<SupplerFirmDTO> GetById(string id)
        {
            logger.LogInformation(GetType().Name + " : GetById");

            if (id != null)
            {
                try
                {
                    SupplerFirm entity = await context.SupplerFirmsCtx.FindAsync(Guid.Parse(id));

                    if (entity != null)
                    {
                        return SFMapper.ToDTO(entity);
                    }
                    else
                    {
                        string message = "supplerfirm with id " + id + " was not found";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<SupplerFirm>("GetById", message, HttpStatusCode.NotFound);
                    }
                }
                catch (FormatException ex)
                {
                    string message = "convert id " + id + " failes : " + ex.Message;
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<SupplerFirm>("GetById", message, HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                string message = "id parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<SupplerFirm>("GetById", message, HttpStatusCode.BadRequest);
            }
        }

        public async Task<SupplerFirmDTO> Add(SupplerFirmDTO item)
        {
            logger.LogInformation(GetType().Name + " : Add");

            if (item != null)
            {
                SupplerFirm entity = SFMapper.ToEntity(item);

                if (!entity.Name.Equals("root supplerfirm"))
                {
                    await context.SupplerFirmsCtx.AddAsync(entity);

                    await context.SaveChangesAsync();

                    item = SFMapper.ToDTO(entity);

                    return item;
                }
                else
                {
                    string message = "invalid supplerfirm name";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<SupplerFirm>("Add", message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                string message = "item parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<SupplerFirm>("Add", message, HttpStatusCode.BadRequest);
            }
        }

        public async Task<SupplerFirmDTO> Update(SupplerFirmDTO item)
        {
            logger.LogInformation(GetType().Name + " : Update");

            if (item != null)
            {
                
                try
                {
                    SupplerFirm entity = await context.SupplerFirmsCtx.FindAsync(Guid.Parse(item.Id));

                    if (entity != null)
                    {
                        if (!entity.Name.Equals("root supplerfirm"))
                        {

                            if (item.MoneyValue < 0)
                            {
                                string message = "balanse must be positive or zero";
                                logger.LogError(GetType().Name + " : " + message);
                                throw new HttpException<SupplerFirm>("Update", message, HttpStatusCode.BadRequest);
                            }
                            else
                            {
                                entity = SFMapper.ToEntity(item);
                                context.SupplerFirmsCtx.Update(entity);
                                await context.SaveChangesAsync();

                                item = SFMapper.ToDTO(entity);

                                return item;
                            }
                        }
                        else
                        {
                            string message = "supplerfirm with name \"root supplerfirm\" cant be modify";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<SupplerFirm>("Update", message, HttpStatusCode.Forbidden);
                        }
                    }
                    else
                    {
                        string message = "supplerfirm with id " + item.Id + " was not found";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<SupplerFirm>("Update", message, HttpStatusCode.NotFound);
                    }
                }
                catch (FormatException ex)
                {
                    string message = "convert id " + item.Id + " failed : " + ex.Message;
                    logger.LogError(GetType().Name + " : : " + message);
                    throw new HttpException<SupplerFirm>("Update", message, HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                string message = "item parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<SupplerFirm>("Update", message, HttpStatusCode.BadRequest);
            }
        }

        public async Task Delete(string id)
        {
            logger.LogInformation(GetType().Name + " : Delete");

            if (id != null)
            {
                try
                {
                    SupplerFirm entity = await context.SupplerFirmsCtx.FindAsync(Guid.Parse(id));

                    if (entity != null)
                    {
                        if (!entity.Name.Equals("root supplerfirm"))
                        {
                            context.SupplerFirmsCtx.Remove(entity);
                            await context.SaveChangesAsync();
                        }
                        else
                        {
                            string message = "supplerfirm with name \"root supplerfirm\" cant be removed";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<SupplerFirm>("Delete", message, HttpStatusCode.Forbidden);
                        }
                    }
                    else
                    {
                        string message = "supplerfirm with id " + id + " was not found";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<SupplerFirm>("Delete", message, HttpStatusCode.NotFound);
                    }
                }
                catch (FormatException ex)
                {
                    string message = "convert id " + id + " failed : " + ex.Message;
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<SupplerFirm>("Delete", message, HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                string message = "id parameter id mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<SupplerFirm>("Delete", message, HttpStatusCode.BadRequest);
            }
        }

        public async Task<PaymentResult> ChangeBalance(ClaimsPrincipal currentUser, String supplerFirmId, double money, bool isIncrement)
        {
            logger.LogInformation(GetType().Name + " : ChangeBalance");

            if (SINManager.IsSignedIn(currentUser))
            {
                if (supplerFirmId != null && money > 0)
                {
                    try
                    {
                        SupplerFirm entity = await context.SupplerFirmsCtx.Where(sf => sf.Id.Equals(Guid.Parse(supplerFirmId))).FirstOrDefaultAsync();
                        if (entity != null)
                        {

                            PaymentResult result = PaymentResult.OKAY;

                            if (isIncrement)
                            {
                                entity.MoneyValue += money;
                            }
                            else
                            {
                                entity.MoneyValue -= money;
                            }
                            if (entity.MoneyValue < 0)
                            {
                                result = PaymentResult.INSUFFICIENT_MONEY;
                            }

                            //string query = "update supplerfirm set money_value = "+entity.MoneyValue+" where id = '"+supplerFirmId+"'";
                           

                            //int q_result  = context.Database.ExecuteSqlCommand(query);

                            //context.Entry(entity).State = EntityState.Detached;
                            //context.Set<SupplerFirm>().Update(entity);
                            await context.SaveChangesAsync();

                            return result;

                        }
                        else
                        {
                            string message = "supplerfirm with id " + supplerFirmId + " was not found";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<SupplerFirm>("Changebalance", message, HttpStatusCode.NotFound);
                        }
                    }
                    catch (FormatException ex)
                    {
                        
                        string message = "convert id " + supplerFirmId + " failed : " + ex.Message;
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<SupplerFirm>("ChangeBalance", message, HttpStatusCode.InternalServerError);
                    }
                   
                }
                else
                {
                    string message = "input parameters are invalid";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<SupplerFirm>("ChangeBalance", message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("Delete", message, HttpStatusCode.Forbidden);
            }
        }
    }
}