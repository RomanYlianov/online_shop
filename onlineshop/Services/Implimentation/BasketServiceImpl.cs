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
    public class BasketServiceImpl : IBasketService
    {
        private readonly ApplicationDbContext context;

        private readonly IBasketMapper BMapper;

        private readonly IUserService UService;

        private readonly IProductService PService;

        private readonly SignInManager<User> SINManager;

        private readonly ILogger logger;

        public BasketServiceImpl(ApplicationDbContext context, SignInManager<User> sINManager, IBasketMapper bMapper, IProductService pService, IUserService uService)
        {
            this.context = context;

            this.SINManager = sINManager;

            this.BMapper = bMapper;
            this.UService = uService;

            this.PService = pService;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<BasketServiceImpl>();
        }

        public async Task<Tuple<BasketDTO, List<BasketDTO>, List<BasketDTO>>> GetAll(ClaimsPrincipal currentUser)
        {
            logger.LogInformation(GetType().Name + " : GetAll");

            if (SINManager.IsSignedIn(currentUser))
            {
                string uid = GetCurrentUserId(currentUser);

                if (uid != null)
                {
                    try
                    {
                        UserDTO currentDTO = await UService.GetById(currentUser, uid);

                        List<Basket> list = await context.BasketCtx.Include(b => b.Product).Include(b => b.Buyer).Where(b => b.Buyer.Id.Equals(Guid.Parse(uid))).ToListAsync();

                        List<BasketDTO> avaliableItems = new List<BasketDTO>();

                        List<BasketDTO> notAvaliableItems = new List<BasketDTO>();

                        string message = string.Empty;

                        if (list != null)
                        {
                            if (list.Count == 0)
                            {
                                message = "basket entity is empty";
                            }
                        }
                        else
                        {
                            message = "basket entity is empty";
                        }

                        if (string.IsNullOrEmpty(message))
                        {
                            foreach (var item in list)
                            {
                                Basket temp = item;
                                //synchronize count with current count in product and check products avaliable
                                if (temp.Product.CountAll > 0)
                                {
                                    bool isModify = false;
                                    if (temp.Product.CountAll < item.Count)
                                    {
                                        temp.Count = temp.Product.CountAll;
                                        temp.IntermediateCost = CalculatePrice(item.Count, item.Product.Price);
                                        isModify = true;
                                    }
                                    if (item.IntermediateCost == CalculatePrice(item.Count, item.Product.Price))
                                    {
                                        temp.IntermediateCost = CalculatePrice(item.Count, item.Product.Price);
                                        isModify = true;
                                    }

                                    if (isModify)
                                    {
                                        await context.SaveChangesAsync();
                                    }

                                    avaliableItems.Add(BMapper.ToDTO(item));
                                }
                                else
                                {
                                    notAvaliableItems.Add(BMapper.ToDTO(item));
                                }
                            }
                        }
                        else
                        {
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<Basket>("GetAll", message, HttpStatusCode.NotFound);
                        }

                        Tuple<BasketDTO, List<BasketDTO>, List<BasketDTO>> tuple = new Tuple<BasketDTO, List<BasketDTO>, List<BasketDTO>>(new BasketDTO(), avaliableItems, notAvaliableItems);
                        return tuple;
                    }
                    catch (HttpException<User> ex)
                    {
                        throw ex;
                    }
                    catch (FormatException ex)
                    {
                        string message = "convert id " + uid + " failed: " + ex.Message;
                        logger.LogError(GetType().Name + " : " + message);
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
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("GetAll", message, HttpStatusCode.Forbidden);
            }
        }

        public async Task<List<BasketDTO>> GetAvaliableProducts(ClaimsPrincipal currentUser)
        {
            logger.LogInformation(GetType().Name + " : GetAvaliableProducts");

            if (SINManager.IsSignedIn(currentUser))
            {
                string uid = GetCurrentUserId(currentUser);

                if (uid != null)
                {
                    try
                    {
                        UserDTO currentDTO = await UService.GetById(currentUser, uid);

                        List<Basket> list = await context.BasketCtx.Include(b => b.Product).Include(b => b.Buyer).Where(b => b.Buyer.Id.Equals(Guid.Parse(uid))).ToListAsync();

                        List<BasketDTO> avaliableProducts = new List<BasketDTO>();

                        string message = string.Empty;

                        if (list != null)
                        {
                            if (list.Count == 0)
                            {
                                message = "basket entity is empty";
                            }
                        }
                        else
                        {
                            message = "basket entity is empty";
                        }

                        if (string.IsNullOrEmpty(message))
                        {
                            foreach (var item in list)
                            {
                                if (item.Count > 0)
                                {
                                    Basket temp = item;
                                    bool isModify = false;
                                    if (temp.Product.CountAll < item.Count)
                                    {
                                        temp.Count = temp.Product.CountAll;
                                        temp.IntermediateCost = CalculatePrice(item.Count, item.Product.Price);
                                        isModify = true;
                                    }
                                    if (item.IntermediateCost == CalculatePrice(item.Count, item.Product.Price))
                                    {
                                        temp.IntermediateCost = CalculatePrice(item.Count, item.Product.Price);
                                        isModify = true;
                                    }

                                    if (isModify)
                                    {
                                        await context.SaveChangesAsync();
                                    }

                                    avaliableProducts.Add(BMapper.ToDTO(temp));
                                }
                            }

                            return avaliableProducts;
                        }
                        else
                        {
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<Basket>("GetAvaliableProducts", message, HttpStatusCode.NotFound);
                        }
                    }
                    catch (HttpException<User> ex)
                    {
                        throw ex;
                    }
                    catch (FormatException ex)
                    {
                        string message = "convert id " + uid + " failed: " + ex.Message;
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<User>("GetAll", message, HttpStatusCode.InternalServerError);
                    }
                }
                else
                {
                    string message = "user is not authorized";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<User>("GetAvaliableProducts", message, HttpStatusCode.Forbidden);
                }
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("GetAvaliableProducts", message, HttpStatusCode.Forbidden);
            }
        }

        public async Task<BasketDTO> GetById(ClaimsPrincipal currentUser, string id)
        {
            logger.LogInformation(GetType().Name + " : GetById");

            if (SINManager.IsSignedIn(currentUser))
            {
                if (id != null)
                {
                    string uid = GetCurrentUserId(currentUser);

                    if (uid != null)
                    {
                        try
                        {
                            Basket entity = await context.BasketCtx.Include(b => b.Product).Include(b => b.Buyer).FirstOrDefaultAsync(b => b.Id == Guid.Parse(id));

                            if (entity != null)
                            {
                                if (entity.Buyer.Id.Equals(Guid.Parse(uid)))
                                {
                                    BasketDTO dto = BMapper.ToDTO(entity);
                                    return dto;
                                }
                                else
                                {
                                    string message = "you do not have permission to view other people's items in the cart";
                                    logger.LogError(GetType().Name + " : " + message);
                                    throw new HttpException<Basket>("GetById", message, HttpStatusCode.Forbidden);
                                }
                            }
                            else
                            {
                                string message = "basket with id " + id + " was not found";
                                logger.LogError(GetType().Name + " : " + message);
                                throw new HttpException<Basket>("GetById", message, HttpStatusCode.NotFound);
                            }
                        }
                        catch (FormatException ex)
                        {
                            string message = "convert id " + uid + " failed: " + ex.Message;
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<User>("GetById", message, HttpStatusCode.InternalServerError);
                        }
                    }
                    else
                    {
                        string message = "user is not authorized";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<User>("GetbyId", message, HttpStatusCode.Forbidden);
                    }
                }
                else
                {
                    string message = "id parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Basket>("GetById", message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("GetById", message, HttpStatusCode.Forbidden);
            }
        }

        public async Task<BasketDTO> AddProductToBasket(ClaimsPrincipal currentUser, BasketDTO item)
        {
            logger.LogInformation(GetType().Name + " : AddProductToBasket");

            if (SINManager.IsSignedIn(currentUser))
            {
                if (item != null)
                {
                    string uid = GetCurrentUserId(currentUser);

                    if (uid != null)
                    {
                        try
                        {
                            ProductDTO productDTO = await PService.GetById(item.ProductDTO.Id);

                            UserDTO userDTO = await UService.GetById(currentUser, uid);

                            //check exists product

                            Basket entity = await context.BasketCtx.Where(b => b.BuyerId.Equals(Guid.Parse(userDTO.Id)) && b.ProductId.Equals(Guid.Parse(productDTO.Id))).FirstOrDefaultAsync();

                            if (entity != null)
                            {
                                entity.Count += item.Count;
                                entity.IntermediateCost = productDTO.Price * entity.Count;

                                context.Update(entity);
                                await context.SaveChangesAsync();
                            }
                            else
                            {
                                //creating new basket row
                                item.ProductDTOId = productDTO.Id;
                                item.ProductDTO = null;
                                //set buyer

                                item.BuyerDTOId = userDTO.Id;

                                //calculate intermediate cost
                                item.IntermediateCost = productDTO.Price * item.Count;

                                entity = BMapper.ToEntity(item);

                                //Basket entity = BMapper.ToEntity(item);

                                await context.BasketCtx.AddAsync(entity);

                                await context.SaveChangesAsync();
                            }

                            item = BMapper.ToDTO(entity);

                            return item;
                        }
                        catch (HttpException<Product> ex)
                        {
                            throw ex;
                        }
                        catch (HttpException<User> ex)
                        {
                            throw ex;
                        }
                        catch (FormatException ex)
                        {
                            string message = "convert id " + item.Id + " failed: " + ex.Message;
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<Basket>("AddProductTobasket", message, HttpStatusCode.InternalServerError);
                        }
                    }
                    else
                    {
                        string message = "user is not authorized";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<User>("AddProductToBasket", message, HttpStatusCode.Forbidden);
                    }
                }
                else
                {
                    string message = "dto parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Basket>("AddProductToBasket", message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("AddProductToBasket", message, HttpStatusCode.Forbidden);
            }
        }

        public async Task<BasketDTO> Update(ClaimsPrincipal currentUser, BasketDTO item)
        {
            logger.LogInformation(GetType().Name + " : Update");

            if (SINManager.IsSignedIn(currentUser))
            {
                if (item != null)
                {
                    string uid = GetCurrentUserId(currentUser);

                    if (uid != null)
                    {
                        try
                        {
                            Basket entity = await context.BasketCtx.Include(b => b.Product).Include(b => b.Buyer).FirstOrDefaultAsync(b => b.Id.Equals(Guid.Parse(item.Id)));

                            if (entity != null)
                            {
                                if (item.Count == 0)
                                {
                                    context.BasketCtx.Remove(entity);
                                    await context.SaveChangesAsync();
                                    entity = null;
                                }
                                else
                                {
                                    entity.Count = item.Count;
                                    entity.IntermediateCost = item.Count * entity.Product.Price;

                                    context.Update(entity);

                                    await context.SaveChangesAsync();
                                }

                                item = BMapper.ToDTO(entity);
                                return item;
                            }
                            else
                            {
                                string message = "basket with id " + item.Id + " was not found";
                                logger.LogError(GetType().Name + " : " + message);
                                throw new HttpException<Basket>("Update", message, HttpStatusCode.NotFound);
                            }
                        }
                        catch (FormatException ex)
                        {
                            string message = "convert id " + item.Id + " failed: " + ex.Message;
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<Basket>("Update", message, HttpStatusCode.InternalServerError);
                        }
                    }
                    else
                    {
                        string message = "user is not authorized";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<User>("Update", message, HttpStatusCode.Forbidden);
                    }
                }
                else
                {
                    string message = "item parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Basket>("Update", message, HttpStatusCode.BadRequest);
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
                    string uid = GetCurrentUserId(currentUser);

                    if (uid != null)
                    {
                        try
                        {
                            Basket entity = await context.BasketCtx.FirstOrDefaultAsync(b => b.Id.Equals(Guid.Parse(id)));

                            if (entity != null)
                            {
                                if (entity.BuyerId.Equals(Guid.Parse(uid)))
                                {
                                    context.BasketCtx.Remove(entity);
                                    await context.SaveChangesAsync();
                                }
                                else
                                {
                                    string message = "you do not have permission to view other people's items in the cart";
                                    logger.LogError(GetType().Name + " : " + message);
                                    throw new HttpException<Basket>("Delete", message, HttpStatusCode.Forbidden);
                                }
                            }
                            else
                            {
                                string message = "basket with id " + id + " was not found";
                                logger.LogError(GetType().Name + " : " + message);
                                throw new HttpException<Basket>("Delete", message, HttpStatusCode.NotFound);
                            }
                        }
                        catch (FormatException ex)
                        {
                            string message = "convert id " + id + " failed: " + ex.Message;
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<Basket>("Delete", message, HttpStatusCode.InternalServerError);
                        }
                    }
                    else
                    {
                        string message = "user is not authorized";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<User>("Delete", message, HttpStatusCode.Forbidden);
                    }
                }
                else
                {
                    string message = "id parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Basket>("Delete", message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("Delete", message, HttpStatusCode.Forbidden);
            }
        }

        public async Task<int> GetCountOfProductsInBasket(ClaimsPrincipal currentUser)
        {
            logger.LogInformation(GetType().Name + " : GetCountOfProductsInBasket");

            int count = 0;

            if (SINManager.IsSignedIn(currentUser))
            {
                string uid = GetCurrentUserId(currentUser);

                try
                {
                    List<Basket> list = await context.BasketCtx.Where(b => b.BuyerId.Equals(Guid.Parse(uid))).ToListAsync();

                    string message = string.Empty;

                    if (list != null)
                    {
                        if (list.Count == 0)
                        {
                            message = "basket entity is empty";
                        }
                    }
                    else
                    {
                        message = "basket entity is empty";
                    }

                    if (string.IsNullOrEmpty(message))
                    {
                        count = list.Count;
                    }
                    else
                    {
                        logger.LogWarning(GetType().Name + " : " + message);
                    }
                }
                catch (FormatException ex)
                {
                    string message = "convert id " + uid + " failed: " + ex.Message;
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Basket>("GetCountOfProductsInBasket", message, HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                string message = "user is not authorized";
                logger.LogWarning(GetType().Name + " : " + message);
            }

            return count;
        }

        private double CalculatePrice(int count, double price)
        {
            logger.LogInformation(GetType().Name + " : CalculatePrice");

            return count * price;
        }

        private string GetCurrentUserId(ClaimsPrincipal currentUser)
        {
            logger.LogInformation(GetType().Name + " : GetCurrentUserId");

            if (currentUser != null)
            {
                string uid = currentUser.FindFirstValue(ClaimTypes.NameIdentifier);
                return uid;
            }
            else
            {
                return null;
            }
        }
    }
}