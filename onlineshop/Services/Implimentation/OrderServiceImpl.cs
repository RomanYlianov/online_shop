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
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace onlineshop.Services.Implimentation
{
    public class OrderServiceImpl : IOrderService
    {

        private readonly ApplicationDbContext context;

        private readonly IOrderMapper OMapper;

        private readonly IBasketService BService;

        private readonly IProductService PService;

        private readonly IProductMapper PMapper;

        private readonly IUserService UService;

        private readonly SignInManager<User> SINManager;

        private readonly ILogger logger;

        public OrderServiceImpl(ApplicationDbContext context, SignInManager<User> sINManager, IBasketService bService,IProductService pService, IUserService uService ,IOrderMapper oMapper, IProductMapper pMapper)
        {

            this.SINManager = sINManager;

            this.context = context;

            this.UService = uService;
            this.PService = pService;
            this.BService = bService;

            this.OMapper = oMapper;
            this.PMapper = pMapper;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<OrderServiceImpl>();
        }

        public async Task<List<OrderDTO>> GetAll()
        {

            logger.LogInformation(GetType().Name + " : GetAll");

            List<Order> list = await context.OrdersCtx.Include(o => o.Buyer).Include(o => o.DeliveryMethod).Include(o => o.PaymentMethod).ToListAsync();

            List<OrderDTO> result = new List<OrderDTO>();

            try
            {
               result = await InitOrderList(list);

            }
            catch (HttpException<Order> ex)
            {
                throw ex;
            }
            

            return result;
        }

        public async Task<List<OrderDTO>> GetOrdersForUser(ClaimsPrincipal currentUser)
        {

            logger.LogInformation(GetType().Name + " : GetOrdersForUser");

            List<OrderDTO> result = new List<OrderDTO>();

            if (SINManager.IsSignedIn(currentUser))
            {

                string uid = currentUser.FindFirstValue(ClaimTypes.NameIdentifier);

                List<Order> list = await context.OrdersCtx.Include(o => o.Buyer).Include(o => o.DeliveryMethod).Include(o => o.PaymentMethod).Where(o => o.BuyerId.Equals(Guid.Parse(uid))).ToListAsync();

                result = await InitOrderList(list);

            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("GetOrdersForUser", message, HttpStatusCode.Forbidden);
            }

            return result;

        }

        public async Task<List<OrderDTO>> Search(ClaimsPrincipal currentUser, OrderSearchDTO dto)
        {

            logger.LogInformation(GetType().Name + " : Search");

            if (SINManager.IsSignedIn(currentUser))
            {

                if (dto != null)
                {
                    List<Order> list = new List<Order>();

                    if (!string.IsNullOrEmpty(dto.Cipher))
                    {
                        logger.LogInformation(GetType().Name + " : #0 - search by Cipher parameter (is main) ");

                        list = await context.OrdersCtx.Include(o => o.Buyer).Include(o => o.DeliveryMethod).Include(o => o.PaymentMethod).Where(o => o.Cipher.Contains(dto.Cipher)).ToListAsync();

                    }
                    else
                    {
                        logger.LogInformation(GetType().Name + " : #0 - get all records (is main)");

                        list = await context.OrdersCtx.Include(o => o.Buyer).Include(o => o.DeliveryMethod).Include(o => o.PaymentMethod).ToListAsync();

                    }



                    //working for seller/admin
                    if (!string.IsNullOrEmpty(dto.BuyerEmail))
                    {

                        logger.LogInformation(GetType().Name + " : #1 search by BuyerEmail");

                        if (currentUser.IsInRole("SELLER") || currentUser.IsInRole("OWNER"))
                        {
                            List<Order> temp = new List<Order>();

                            foreach (var item in list)
                            {
                                if (item.Buyer.NormalizedEmail.Contains(dto.BuyerEmail.ToUpper()))
                                {
                                    temp.Add(item);
                                }
                            }

                            list = temp;

                        }
                        else
                        {
                            string message = "you dont have permissions to serach by BuyerEmail parameter";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<User>("Search", message, HttpStatusCode.Forbidden);
                        }

                    }

                    if (!string.IsNullOrEmpty(dto.DeliveryMethodId))
                    {

                        logger.LogInformation(GetType().Name + " : #2 - search by DeliveryMethodName parameter");

                        List<Order> temp = new List<Order>();

                        foreach (var item in list)
                        {
                            if (item.DeliveryMethod.Id.ToString().Equals(dto.DeliveryMethodId))
                            {
                                temp.Add(item);
                            }
                        }

                        list = temp;

                    }

                    if (dto.PaymentType != null)
                    {

                        logger.LogInformation(GetType().Name + " : #3 - search by PaymentTypeName");

                        List<Order> temp = new List<Order>();

                        foreach (var item in list)
                        {
                            if (item.PaymentMethod.PaymentType.Equals(dto.PaymentType.Value))
                            {
                                temp.Add(item);
                            }
                            
                        }

                        list = temp;

                    }

                    if (dto.OrderStatus != null)
                    {

                        logger.LogInformation(GetType().Name + " : #4 - serach by OrderStatus parameter");

                        List<Order> temp = new List<Order>();

                        foreach (var item in list)
                        {
                            if (item.OrderStatus.Equals(dto.OrderStatus.Value))
                            {
                                temp.Add(item);
                            }
                        }

                        list = temp;

                    }

                    if (dto.CreationTimeStart != null)
                    {

                        logger.LogInformation(GetType().Name + " : #5 - search by CreationTimeStart parameter");

                        List<Order> temp = new List<Order>();

                        foreach (var item in list)
                        {
                            if (item.CreationTime >= dto.CreationTimeStart)
                            {
                                temp.Add(item);
                            }
                        }

                        list = temp;

                    }

                    if (dto.CreationTimeEnd != null)
                    {

                        logger.LogInformation(GetType().Name + " : #6 - search by CreationTimeEnd parameter");

                        List<Order> temp = new List<Order>();

                        foreach (var item in list)
                        {
                            if (item.CreationTime <= dto.CreationTimeEnd)
                            {
                                temp.Add(item);
                            }
                        }

                        list = temp;

                    }

                    if (list.Count > 0)
                    {
                        List<OrderDTO> result = new List<OrderDTO>();

                        foreach (var item in list)
                        {
                            result.Add(OMapper.ToDTO(item));
                        }

                        return result;
                    }
                    else
                    {
                        string message = "search results is empty";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<Order>("Search", message, HttpStatusCode.NotFound);
                    }
                }
                else
                {
                    string message = "dto parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Order>("Search", message, HttpStatusCode.BadRequest);
                }

            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("Search", message, HttpStatusCode.Forbidden);
            }           

        }

        public async Task<List<ProductDTO>> GetProductsFromOrder(ClaimsPrincipal currentUser, string id)
        {

            logger.LogInformation(GetType().Name + " : GetProductsFromOrder");

            if (SINManager.IsSignedIn(currentUser))
            {

                if (id != null)
                {

                    List<ProductDTO> list = new List<ProductDTO>();

                    try
                    {

                        Order entity = await context.OrdersCtx.FindAsync(Guid.Parse(id));

                        if (entity != null)
                        {

                            string message = string.Empty;

                            if (CheckPermissions(currentUser, id))
                            {

                                List<OrderProduct> opList = await context.OrderProductCtx.Where(op => op.OrderId.Equals(entity.Id)).ToListAsync();



                                if (opList != null)
                                {

                                    if (opList.Count == 0)
                                    {
                                        message = "OrderProduct entity is not contains sought rows";
                                    }

                                }
                                else
                                {
                                    message = "OrderProduct entity is not contains sought rows";
                                }

                                if (string.IsNullOrEmpty(message))
                                {
                                    foreach (var item in opList)
                                    {
                                        Product pEntity = await context.ProductsCtx.Include(p => p.SupplerFirm).Include(p => p.Category).Where(p => p.Id.Equals(item.ProductId)).FirstOrDefaultAsync();
                                        pEntity.CountThis = item.ProductsCount;
                                        list.Add(PMapper.ToDTO(pEntity));

                                    }
                                }
                                else
                                {
                                    logger.LogError(GetType().Name + " : " + message);
                                    throw new HttpException<Order>("GetProductsFromOrder", message, HttpStatusCode.NotFound);
                                }

                            }
                            else
                            {
                                message = "you don't have permissions to view data";
                                logger.LogError(GetType().Name + " : " + message);
                                throw new HttpException<Order>("GetProductsFromOrder", message, HttpStatusCode.Forbidden);
                            }

                            
                        }
                        else
                        {
                            string message = "order with id " + id + " was not found";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<Order>("GetProductsFromOrder", message, HttpStatusCode.NotFound);
                        }

                    }
                    catch (FormatException ex)
                    {
                        string message = "convert id " + id + " failed : " + ex.Message;
                        logger.LogError(GetType().Name + " : : " + message);
                        throw new HttpException<Order>("GetProductsFromOrder", message, HttpStatusCode.InternalServerError);
                    }

                    return list;

                }
                else
                {
                    string message = "id parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Order>("GetProductsFromOrder", message, HttpStatusCode.BadRequest);
                }

            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("GetProductsFromOrder", message, HttpStatusCode.Forbidden);
            }

        }

        public async Task<OrderDTO> GetById(ClaimsPrincipal currentUser, string id)
        {

            logger.LogInformation(GetType().Name + " : GetById");

            if (SINManager.IsSignedIn(currentUser))
            {

                if (id != null)
                {

                    try
                    {

                        Order entity = await context.OrdersCtx.Include(o => o.Buyer).Include(o => o.DeliveryMethod).Include(o => o.PaymentMethod).Where(o => o.Id.Equals(Guid.Parse(id))).FirstOrDefaultAsync();

                        if (entity != null)
                        {
                            if (CheckPermissions(currentUser, entity.BuyerId.ToString()))
                            {
                                

                                List<OrderProduct> temp = await context.OrderProductCtx.Include(op => op.Product).Where(op => op.OrderId.Equals(entity.Id)).ToListAsync();

                                List<ProductDTO> products = new List<ProductDTO>();

                                if (temp != null)
                                {
                                    if (temp.Count > 0)
                                    {
                                        foreach (var opEntity in temp)
                                        {
                                            products.Add(PMapper.ToDTO(opEntity.Product));
                                        }
                                      
                                    }
                                }

                                OrderDTO dto = OMapper.ToDTO(entity);

                                dto.ProductDTOs = products;

                                return dto;
                            }
                            else
                            {
                                string message = "you don't have permissions to view data";
                                logger.LogError(GetType().Name + " : " + message);
                                throw new HttpException<Order>("getById", message, HttpStatusCode.Forbidden);
                            }

                        }
                        else
                        {

                            string message = "order with id " + id + " was not foud";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<Order>("GetById", message, HttpStatusCode.NotFound);

                        }

                    }
                    catch (FormatException ex)
                    {
                        string message = "convert id " + id + " failed : " + ex.Message;
                        logger.LogError(GetType().Name + " : : " + message);
                        throw new HttpException<Order>("GetById", message, HttpStatusCode.InternalServerError);
                    }
                }
                else
                {
                    string message = "id parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Order>("GetById", message, HttpStatusCode.BadRequest);
                }

            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("GetById", message, HttpStatusCode.Forbidden);
            }           

        }

        public async Task<OrderDTO> Add(ClaimsPrincipal currentUser, OrderDTO item, List<string> basketIds, List<int> productCounts)
        {

            logger.LogInformation(GetType().Name + " : Add");

            if (SINManager.IsSignedIn(currentUser))
            {

                string message = string.Empty;

                if (basketIds != null && productCounts != null)
                {
                    if (basketIds.Count > 0 && productCounts.Count > 0)
                    {
                        if (basketIds.Count != productCounts.Count)
                        {
                            message = "count of basketIds and productCounts must be equals";
                        }
                    }
                    else
                    {
                        message = "basketIds and productCounts must be positive";
                    }
                }
                else
                {
                    message = "basketIds and productCounts parameters are required";
                }

                if (string.IsNullOrEmpty(message))
                {

                    try
                    {

                        if (item != null)
                        {

                            string oid = string.Empty;



                            for (int i = 0; i < basketIds.Count; i++)
                            {

                                string bid = basketIds[i];
                                int pCount = productCounts[i];

                                Basket bEntity = await context.BasketCtx.AsNoTracking().Include(b => b.Product).FirstOrDefaultAsync(b => b.Id.Equals(Guid.Parse(bid)));

                                //формируем заказ
                                //в первый раз: создать заказ, получить id созданного заказа

                                if (string.IsNullOrEmpty(oid))
                                {
                                    Order entity = OMapper.ToEntity(item);


                                    entity.Cipher = GenerateOrderCipher();
                                    entity.CreationTime = DateTime.Now;

                                    entity.OrderStatus = OrderStatus.IN_QUEUE;

                                    entity.TrackNumber = GenerateTrackNumber();
                                    entity.ReceiptCode = GenerateReceiptCode();

                                    context.Entry(entity).State = EntityState.Added;
                                    await context.Set<Order>().AddAsync(entity);

                                    //await context.OrdersCtx.AddAsync(entity);

                                    await context.SaveChangesAsync();

                                    item = OMapper.ToDTO(entity);

                                    oid = item.Id;
                                }

                                //уменьшить текущее количество товаров на количество заказанных

                                Product pEntity = await context.ProductsCtx.AsNoTracking().FirstOrDefaultAsync(p => p.Id.Equals(bEntity.ProductId));

                                pEntity.CountThis -= pCount;

                                context.Entry(pEntity).State = EntityState.Detached;

                                context.Set<Product>().Update(pEntity);


                                //context.ProductsCtx.Update(pEntity);
                                await context.SaveChangesAsync();

                                //уменьшить количество в строке сущности "корзина" или удалить запись, если количество равно 0

                                if (pCount - bEntity.Count > 0)
                                {

                                    bEntity.Count -= pCount;

                                    context.Entry(bEntity).State = EntityState.Detached;

                                    context.Set<Basket>().Update(bEntity);

                                    //context.BasketCtx.Update(bEntity);
                                    await context.SaveChangesAsync();

                                }
                                else
                                {
                                    context.Entry(bEntity).State = EntityState.Deleted;
                                    context.Set<Basket>().Remove(bEntity);
                                   // context.BasketCtx.Remove(bEntity);
                                    await context.SaveChangesAsync();

                                }

                                //в сущность OrderProduct добавить записи: id товара и id заказа

                                OrderProduct opEntity = new OrderProduct();
                                opEntity.ProductId = pEntity.Id;
                                opEntity.OrderId = Guid.Parse(oid);
                                opEntity.ProductsCount = pCount;
                                context.Entry(opEntity).State = EntityState.Added;
                                await context.Set<OrderProduct>().AddAsync(opEntity);

                                //await context.OrderProductCtx.AddAsync(opEntity);
                                await context.SaveChangesAsync();

                            }

                            return item;

                        }
                        else
                        {
                            message = "item parameter is mandatory";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<Order>("Add", message, HttpStatusCode.BadRequest);
                        }

                    }
                    catch (HttpException<Product> ex)
                    {
                        throw ex;
                    }
                    catch (HttpException<Basket> ex)
                    {
                        throw ex;
                    }
                    catch (HttpException<Order> ex)
                    {
                        throw ex;
                    }

                }
                else
                {
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Order>("Add", message, HttpStatusCode.BadRequest);
                }


               
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("Add", message, HttpStatusCode.Forbidden);
            }

        }

        //buyer can edit rating, seller | owner - orderstatus
        public async Task<OrderDTO> Update(ClaimsPrincipal currentUser, OrderDTO item, bool iSRoot = false)
        {

            logger.LogInformation(GetType().Name + " : Update");

            if (SINManager.IsSignedIn(currentUser))
            {
                if (item != null)
                {

                    

                    try
                    {
                        Order entity = await context.OrdersCtx.FindAsync(Guid.Parse(item.Id));

                        if (entity != null)
                        {
                            //entity = OMapper.ToEntity(entity, item);

                            if (CheckPermissions(currentUser, item.Id))
                            {

                                if (!iSRoot)
                                {
                                    if (entity.Mark == 0)
                                    {
                                        entity.Mark = item.Mark;
                                    }
                                    else
                                    {
                                        string message = "you already rated the order";
                                        logger.LogError(GetType().Name + " : " + message);
                                        throw new HttpException<Order>("Update", message, HttpStatusCode.Forbidden);
                                    }

                                }

                                if (currentUser.IsInRole("SELLER") || currentUser.IsInRole("OWNER"))
                                {
                                    if (item.OrderStatus.HasValue)
                                    {
                                        entity.OrderStatus = item.OrderStatus.Value;
                                    }
                                    
                                }

                                context.Entry(entity).State = EntityState.Detached;
                                context.Set<Order>().Update(entity);

                               

                                await context.SaveChangesAsync();

                                item = OMapper.ToDTO(entity);

                                return item;

                            }
                            else
                            {
                                string message = "you don't have permissions to view data";
                                logger.LogError(GetType().Name + " : " + message);
                                throw new HttpException<Order>("Update", message, HttpStatusCode.Forbidden);
                            }

                           

                        }
                        else
                        {
                            string message = "order with id" + item.Id + " was not found";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<Order>("Update", message, HttpStatusCode.NotFound);
                        }

                    }
                    catch (FormatException ex)
                    {
                        string message = "convert id " + item.Id + " failed : " + ex.Message;
                        logger.LogError(GetType().Name + " : : " + message);
                        throw new HttpException<Order>("Update", message, HttpStatusCode.InternalServerError);
                    }

                }
                else
                {
                    string message = "item parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Order>("Update", message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("Update", message, HttpStatusCode.Forbidden);
            }

        }

        public async Task Delete(ClaimsPrincipal currentUser, string id,  List<ProductDTO> products)
        {

            logger.LogInformation(GetType().Name + " : Delete");

            if (SINManager.IsSignedIn(currentUser))
            {

                Guid oid;

                string message = string.Empty;

                try
                {

                    oid = Guid.Parse(id);

                    Order oEntity = await context.OrdersCtx.FindAsync(oid);

                    if (oEntity != null)
                    {

                        if (oEntity.CreationTime.AddDays(90) >= DateTime.Now)
                        {

                            if (products != null)
                            {
                                if (products.Count == 0)
                                {
                                    message = "products parameter is mandatory";
                                }
                            }
                            else
                            {
                                message = "products parameter is mandatory";
                            }

                            

                            if (string.IsNullOrEmpty(message))
                            {

                                string pid = string.Empty;

                                try
                                {

                                    for (int i = 0; i < products.Count; i++)
                                    {

                                        pid = products[i].Id;
                                        int count = products[i].CountThis;

                                        OrderProduct opEntity = await context.OrderProductCtx.Where(op => op.OrderId.Equals(oid) && op.ProductId.Equals(Guid.Parse(pid))).FirstOrDefaultAsync();

                                        if (opEntity.ProductsCount > count)
                                        {

                                            message = "You cannot return more items than ordered";
                                            logger.LogError(GetType().Name + " : " + message);
                                            throw new HttpException<Order>("Delete", message, HttpStatusCode.InternalServerError);

                                        }                                       
                                    }

                                    for (int i = 0; i < products.Count; i++)
                                    {

                                        pid = products[i].Id;
                                        int count = products[i].CountThis;

                                        try
                                        {
                                            Product entity = await context.ProductsCtx.FindAsync(Guid.Parse(pid));

                                            if (entity != null)
                                            {

                                                //вернули количество товаров
                                                entity.CountThis += count;

                                                context.Entry(entity).State = EntityState.Detached;
                                                context.Set<Product>().Update(entity);

                                                await context.SaveChangesAsync();

                                                //получили сущность OrderProduct

                                                OrderProduct opEntity = await context.OrderProductCtx.Where(op => op.OrderId.Equals(oid) && op.ProductId.Equals(entity.Id)).FirstOrDefaultAsync();

                                                if (opEntity != null)
                                                {


                                                    if (opEntity.ProductsCount == count)
                                                    {
                                                        context.Entry(opEntity).State = EntityState.Deleted;
                                                        context.Set<OrderProduct>().Remove(opEntity);
                                                    }
                                                    else
                                                    {
                                                        opEntity.ProductsCount -= count;
                                                        context.Entry(opEntity).State = EntityState.Detached;
                                                        context.Set<OrderProduct>().Update(opEntity);

                                                    }

                                                    await context.SaveChangesAsync();



                                                }
                                                else
                                                {
                                                    message = $"OrderProduct entity with orderId={oid} and productId {entity.Id} was not found";
                                                    logger.LogWarning(GetType().Name + " : " + message);
                                                    //уведомить о неуспешной попытке найти запись в служебной сущности
                                                }

                                            }
                                            else
                                            {
                                                message = "product with id " + pid + " was not found";
                                                logger.LogWarning(GetType().Name + " : " + message);
                                                //уведомить о неуспешной попытке найти товар
                                            }

                                        }
                                        catch (FormatException ex)
                                        {
                                            ExceptionHandler(pid, ex.Message);
                                            //уведомить о неуспешном возвращении товара 
                                        }

                                    }

                                    //проверить, имеет ли заказ товары, если нет - удалить

                                    List<OrderProduct> opList = await context.OrderProductCtx.Where(op => op.OrderId.Equals(oid)).ToListAsync();

                                    bool isNeedToRemove = false;

                                    if (opList != null)
                                    {
                                        isNeedToRemove = opList.Count == 0;
                                    }
                                    else
                                    {
                                        isNeedToRemove = true;
                                    }

                                    if (isNeedToRemove)
                                    {

                                        context.Entry(oEntity).State = EntityState.Deleted;
                                        context.Set<Order>().Remove(oEntity);



                                        await context.SaveChangesAsync();

                                    }



                                }
                                catch (FormatException ex)
                                {
                                     ExceptionHandler(pid, ex.Message);
                                    //уведомить о неуспешном возвращении товара 
                                }






                            }
                            else
                            {
                                logger.LogError(GetType().Name + " : " + message);
                                throw new HttpException<Order>("Delete", message, HttpStatusCode.BadRequest);
                            }

                        }
                        else
                        {
                            message = "Orders can be returned within 90 days";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<Order>("Delete", message, HttpStatusCode.Forbidden);
                            
                        }

                    }
                    else
                    {
                        message = "order with id " + id + " was not foud";
                        logger.LogError(GetType().Name);
                        throw new HttpException<Order>("Delete", message, HttpStatusCode.BadRequest);
                    }

                }
                catch (FormatException ex)
                {
                    message = "convert id " + id + " failed : " + ex.Message;
                    logger.LogError(GetType().Name + " : : " + message);
                    throw new HttpException<Order>("Delete", message, HttpStatusCode.InternalServerError);
                }

            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("Delete", message, HttpStatusCode.Forbidden);
            }

            void ExceptionHandler(string pid, string message)
            {
                message = "convert id " + pid + " failed : " + message;
                logger.LogWarning(GetType().Name + " : " + message);
            }

        }

        public async Task<OrderDTO> InicializeOrder(ClaimsPrincipal currentUser, List<string> basketIds, List<int> productCounts)
        {

            logger.LogInformation(GetType().Name + " : InicializeOrder");

            if (SINManager.IsSignedIn(currentUser))
            {

                string message = string.Empty;

                if (basketIds != null && productCounts != null)
                {
                    if (basketIds.Count > 0 && productCounts.Count > 0)
                    {
                        if (basketIds.Count != productCounts.Count)
                        {
                            message = "count of basketIds and productCounts must be equals";
                        }
                    }
                    else
                    {
                        message = "basketIds and productCounts must be positive";
                    }
                }
                else
                {
                    message = "basketIds and productCounts parameters are required";
                }               

                if (string.IsNullOrEmpty(message))
                {

                    OrderDTO dto = new OrderDTO();

                    int count = 0;

                    double price = 0;

                    List<ProductDTO> products = new List<ProductDTO>();                  

                    try
                    {

                        for (int i=0; i<basketIds.Count; i++)
                        {
                            
                            string bid = basketIds[i];

                            BasketDTO basketDTO = await BService.GetById(currentUser, bid);

                            if (basketDTO != null)
                            {
                                
                                int pCount = productCounts[i];

                                if (basketDTO.ProductDTO.CountThis > 0)
                                {

                                    if (basketDTO.ProductDTO.CountThis < pCount)
                                    {
                                        message = "the number of products in the basket exceeds the available quantity";
                                        logger.LogWarning(GetType().Name + " : " + message);
                                        pCount = basketDTO.ProductDTO.CountThis;
                                    }

                                    price += basketDTO.ProductDTO.Price * pCount;
                                    count += pCount;

                                    products.Add(basketDTO.ProductDTO);

                                }
                                else
                                {
                                    message = "product " + basketDTO.ProductDTO.Cipher + " is out of stock";
                                    logger.LogError(GetType().Name + " : " + message);
                                    throw new HttpException<Order>("InicializeOrder", message, HttpStatusCode.BadRequest);
                                }

                            }
                            else
                            {
                                message = "basket with id " + basketIds[i] + " was not found";
                                logger.LogError(GetType().Name + " : " + message);
                                throw new HttpException<Order>("InicializeOrder", message, HttpStatusCode.NotFound);
                            }

                        }

                        dto.ProductDTOs = products;
                       
                        dto.Count = count;
                        dto.Price = price;

                        string uid = currentUser.FindFirstValue(ClaimTypes.NameIdentifier);

                        UserDTO userDTO = await UService.GetById(currentUser, uid);

                        dto.BuyerDTO = userDTO;
                        dto.BuyerDTOId = uid;

                        return dto;

                    }
                    catch (HttpException<Basket> ex)
                    {
                        throw ex;
                    }
                    catch (HttpException<Product> ex)
                    {
                        throw ex;
                    }
                    catch (HttpException<User> ex)
                    {
                        throw ex;
                    }

                }
                else
                {
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Order>("InicializeOrder", message, HttpStatusCode.NotFound);
                }               
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("InicializeOrder", message, HttpStatusCode.Forbidden);
            }
            
        }

        private async Task<List<OrderDTO>> InitOrderList(List<Order> list)
        {

            logger.LogInformation(GetType().Name + " : InitOrdersList");

            List<OrderDTO> result = new List<OrderDTO>();

            string message = string.Empty;

            if (list != null)
            {
                if (list.Count == 0)
                {
                    message = "orders entity is empty";
                }
            }
            else
            {
                message = "orders entity is empty";
            }

            if (string.IsNullOrEmpty(message))
            {

                foreach (var item in list)
                {

                    List<OrderProduct> temp = await context.OrderProductCtx.Include(op => op.Product).Where(op => op.OrderId.Equals(item.Id)).ToListAsync();

                    List<ProductDTO> products = new List<ProductDTO>();

                    if (temp != null)
                    {
                        if (list.Count > 0)
                        {

                            foreach (var opEntity in temp)
                            {

                                products.Add(PMapper.ToDTO(opEntity.Product));
                            }

                        }
                    }


                    OrderDTO dto = OMapper.ToDTO(item);

                    dto.ProductDTOs = products;

                    result.Add(dto);

                }

            }
            else
            {
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Order>("InitOrderList", message, HttpStatusCode.NotFound);
            }

            return result;

        }

        private bool CheckPermissions(ClaimsPrincipal currentUser, string id)
        {

            logger.LogInformation(GetType().Name + " : CheckPermissions");

            bool flag = false;

            if (SINManager.IsSignedIn(currentUser))
            {

                string uid = currentUser.FindFirstValue(ClaimTypes.NameIdentifier);

                flag = currentUser.IsInRole("SELLER") || currentUser.IsInRole("OWNER") || uid.Equals(id);
            }

            return flag;

        }

        private string GenerateTrackNumber()
        {
            logger.LogInformation(GetType().Name + " : GenereateTrackNumber");

            string track = "";             

            for (int i=0; i<20; i++)
            {
                int arg0 = RandomNumberGenerator.GetInt32(2);

                int arg1 = -1;

                switch (arg0)
                {
                    case 0:
                        arg1 = RandomNumberGenerator.GetInt32(97, 123);
                        break;
                    case 1:
                        arg1 = RandomNumberGenerator.GetInt32(48, 58);
                        break;
                }
               
                track+= Convert.ToChar(arg1);
            }

            return track;

        }

        private Int16 GenerateReceiptCode()
        {

            logger.LogInformation(GetType().Name + " : GenerateReceiptCode");

            Random rand = new Random();

            Int16 code =  Int16.Parse(rand.Next(1000, 9999).ToString());

            return code;

        }

        private string GenerateOrderCipher()
        {

            logger.LogInformation(GetType().Name + " : GenerateOrderCipher");

            string result = "O#";
            DateTime date = DateTime.Now;

            result += date.ToString("yyyy-MM-dd") + "#";

            for (int i = 0; i < 30; i++)
            {

                int arg0 = 1;
                if (i > 6)
                {
                    arg0 = RandomNumberGenerator.GetInt32(3);
                }


                int rand = -1;
                switch (arg0)
                {
                    case 0:
                        {
                            //0-9
                            rand = RandomNumberGenerator.GetInt32(48, 58);

                        }
                        break;
                    case 1:
                        {
                            rand = RandomNumberGenerator.GetInt32(65, 91);
                        }
                        //A-Z
                        break;
                    case 2:
                        {

                            rand = RandomNumberGenerator.GetInt32(97, 123);
                        }
                        //a-z
                        break;
                }
                result += Convert.ToChar(rand);

            }
            return result;
        }

       
    }
}
