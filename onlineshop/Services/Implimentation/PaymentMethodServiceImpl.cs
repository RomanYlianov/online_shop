using Microsoft.AspNetCore.Identity;
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
    public class PaymentMethodServiceImpl : IPaymentMethodService
    {
        private readonly ApplicationDbContext context;

        private readonly IPaymentMethodMapper PMMapper;

        private readonly SignInManager<User> SINManager;

        private ILogger logger;

        public PaymentMethodServiceImpl(ApplicationDbContext context, SignInManager<User> sINManager, IPaymentMethodMapper mapper)
        {
            this.context = context;

            this.SINManager = sINManager;

            this.PMMapper = mapper;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<PaymentMethodServiceImpl>();
        }

        public async Task<List<PaymentMethodDTO>> GetAll(ClaimsPrincipal currentUser)
        {
            logger.LogInformation(GetType().Name + " : GetAll");

            if (SINManager.IsSignedIn(currentUser))
            {
                string uid = currentUser.FindFirstValue(ClaimTypes.NameIdentifier);

                try
                {
                    List<PaymentMethod> list = await context.PaymentMethodsCtx.Include(p => p.User).Where(p => p.UserId.Equals(Guid.Parse(uid))).ToListAsync();

                    List<PaymentMethodDTO> result = new List<PaymentMethodDTO>();

                    string message = string.Empty;

                    if (list != null)
                    {
                        if (list.Count == 0)
                        {
                            message = "paymentmethods entity is empty";
                        }
                    }
                    else
                    {
                        message = "paymentmethods entity is empty";
                    }

                    if (string.IsNullOrEmpty(message))
                    {
                        foreach (var item in list)
                        {
                            result.Add(PMMapper.ToDTO(item));
                        }
                    }
                    else
                    {
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<PaymentMethod>("GetAll", message, HttpStatusCode.NotFound);
                    }

                    return result;
                }
                catch (FormatException ex)
                {
                    string message = "convert id " + uid + " failed : " + ex.Message;
                    logger.LogError(GetType().Name + " : : " + message);
                    throw new HttpException<User>("GetAll", message, HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("GetAll", message, HttpStatusCode.Forbidden);
            }
        }

        public async Task<PaymentMethodDTO> GetById(ClaimsPrincipal currentUser, string id)
        {
            logger.LogInformation(GetType().Name + " : GetById");

            if (SINManager.IsSignedIn(currentUser))
            {
                if (id != null)
                {
                    try
                    {
                        PaymentMethod entity = await context.PaymentMethodsCtx.FindAsync(Guid.Parse(id));

                        if (entity != null)
                        {
                            if (CheckPermissions(currentUser, entity.UserId.ToString()))
                            {
                                return PMMapper.ToDTO(entity);
                            }
                            else
                            {
                                string message = "you don't have permissions to view paymetmethod";
                                logger.LogError(GetType().Name + " : " + message);
                                throw new HttpException<User>("GetById", message, HttpStatusCode.Forbidden);
                            }
                        }
                        else
                        {
                            string message = "paymentmethod with id " + id + " was not found";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<PaymentMethod>("GetById", message, HttpStatusCode.NotFound);
                        }
                    }
                    catch (FormatException ex)
                    {
                        string message = "convert id " + id + " failed : " + ex.Message;
                        logger.LogError(GetType().Name + " : : " + message);
                        throw new HttpException<PaymentMethod>("GetById", message, HttpStatusCode.InternalServerError);
                    }
                }
                else
                {
                    string message = "id paramener is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<PaymentMethod>("GetById", message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("GetById", message, HttpStatusCode.Forbidden);
            }
        }

        public async Task<PaymentMethodDTO> Add(ClaimsPrincipal currentUser, PaymentMethodDTO item)
        {
            logger.LogInformation(GetType().Name + " : Add");

            if (SINManager.IsSignedIn(currentUser))
            {
                if (item != null)
                {
                    if (currentUser != null)
                    {
                        string uid = currentUser.FindFirstValue(ClaimTypes.NameIdentifier);

                        item.UserDTOId = uid;

                        PaymentMethod entity = PMMapper.ToEntity(item);

                        await context.PaymentMethodsCtx.AddAsync(entity);

                        await context.SaveChangesAsync();

                        item = PMMapper.ToDTO(entity);

                        return item;
                    }
                    else
                    {
                        string message = "user is not authorized";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<User>("Add", message, HttpStatusCode.Forbidden);
                    }
                }
                else
                {
                    string message = "item parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<PaymentMethod>("Add", message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("GetById", message, HttpStatusCode.Forbidden);
            }
        }

        public async Task<PaymentMethodDTO> Update(ClaimsPrincipal currentUser, PaymentMethodDTO item)
        {
            logger.LogInformation(GetType().Name + " : Update");

            if (SINManager.IsSignedIn(currentUser))
            {
                if (item != null)
                {
                    try
                    {
                        PaymentMethod entity = await context.PaymentMethodsCtx.FindAsync(Guid.Parse(item.Id));

                        if (entity != null)
                        {
                            if (CheckPermissions(currentUser, entity.UserId.ToString()))
                            {
                                entity = PMMapper.ToEntity(entity, item);

                                context.PaymentMethodsCtx.Update(entity);

                                await context.SaveChangesAsync();

                                item = PMMapper.ToDTO(entity);

                                return item;
                            }
                            else
                            {
                                string message = "you dont have permissions to change paymetmethod";
                                logger.LogError(GetType().Name + " : " + message);
                                throw new HttpException<User>("Update", message, HttpStatusCode.Forbidden);
                            }
                        }
                        else
                        {
                            string message = "paymentmethod with id " + item.Id + " was not found";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<PaymentMethod>("Update", message, HttpStatusCode.NotFound);
                        }
                    }
                    catch (FormatException ex)
                    {
                        string message = "convert id " + item.Id + " failed : " + ex.Message;
                        logger.LogError(GetType().Name + " : : " + message);
                        throw new HttpException<PaymentMethod>("Update", message, HttpStatusCode.InternalServerError);
                    }
                }
                else
                {
                    string message = "item parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<PaymentMethod>("Update", message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("Update", message, HttpStatusCode.Forbidden);
            }
        }

        public async Task Delete(ClaimsPrincipal currentUser, string id)
        {
            logger.LogInformation(GetType().Name + " : Delete");

            if (SINManager.IsSignedIn(currentUser))
            {
                if (id != null)
                {
                    try
                    {
                        PaymentMethod entity = await context.PaymentMethodsCtx.FindAsync(Guid.Parse(id));

                        if (entity != null)
                        {
                            if (CheckPermissions(currentUser, entity.UserId.ToString()))
                            {
                                context.PaymentMethodsCtx.Remove(entity);

                                await context.SaveChangesAsync();
                            }
                            else
                            {
                                string messaage = "you don't have permissions to remove paymentmethod";
                                logger.LogError(GetType().Name + " : " + messaage);
                                throw new HttpException<User>("Delete", messaage, HttpStatusCode.Forbidden);
                            }
                        }
                    }
                    catch (FormatException ex)
                    {
                        string message = "convert id " + id + " failed : " + ex.Message;
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<PaymentMethod>("Delete", message, HttpStatusCode.InternalServerError);
                    }
                }
                else
                {
                    string message = "id parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<PaymentMethod>("Delete", message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("Delete", message, HttpStatusCode.Forbidden);
            }
        }

        public async Task<PaymentResult> ChangeBalance(ClaimsPrincipal currentUser, string paymentMethodId, double money, bool isIncrement = true)
        {
            logger.LogInformation(GetType().Name + " : ChangeBalance");

            if (SINManager.IsSignedIn(currentUser))
            {
              

                if (paymentMethodId != null && money > 0)
                {

                    try
                    {
                        PaymentMethod entity = await context.PaymentMethodsCtx.Where(pm => pm.Id.Equals(Guid.Parse(paymentMethodId))).FirstOrDefaultAsync();

                        if (entity != null)
                        {

                            PaymentResult result = PaymentResult.OKAY;

                            if (entity.ExpirationDate < DateTime.Now)
                            {
                                string message = "paymentmethod with id " + paymentMethodId + " was expiried";
                                logger.LogError(GetType().Name + " : " + message);
                                throw new HttpException<PaymentMethod>("ChangeBalance", message, HttpStatusCode.Forbidden);
                            }
                            else
                            {
                                if (isIncrement)
                                {
                                    entity.MoneyValue += money;
                                    context.Entry(entity).State = EntityState.Detached;
                                    context.Set<PaymentMethod>().Update(entity);
                                    await context.SaveChangesAsync();
                                }
                                else
                                {
                                    if (entity.MoneyValue - money < 0)
                                    {
                                        result = PaymentResult.INSUFFICIENT_MONEY;
                                    }
                                    else
                                    {
                                        entity.MoneyValue -= money;
                                        context.Entry(entity).State = EntityState.Detached;
                                        context.Set<PaymentMethod>().Update(entity);
                                        await context.SaveChangesAsync();
                                    }

                                }
                                return result;
                            }

                        }
                        else
                        {
                            string message = "paymentmethod with id " + paymentMethodId + " was not found";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<PaymentMethod>("Changebalance", message, HttpStatusCode.NotFound);
                        }
                    }
                    catch (FormatException ex)
                    {
                        string message = "convert id " + paymentMethodId + " failed : " + ex.Message;
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<PaymentMethod>("Delete", message, HttpStatusCode.InternalServerError);
                    }

                    

                }
                else
                {
                    string message = "input parameters are invalid";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<PaymentMethod>("ChangeBalance", message, HttpStatusCode.BadRequest);
                }

                

            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("Delete", message, HttpStatusCode.Forbidden);
            }

           
        }

        private bool CheckPermissions(ClaimsPrincipal currentUser, string id)
        {
            logger.LogInformation(GetType().Name + " : CheckPermissions");

            bool flag = false;

            if (currentUser != null && id != null)
            {
                string cUid = currentUser.FindFirstValue(ClaimTypes.NameIdentifier);
                flag = id.Equals(cUid);
            }

            return flag;
        }
    }
}