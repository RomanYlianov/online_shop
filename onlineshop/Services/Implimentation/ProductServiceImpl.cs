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
    public class ProductServiceImpl : IProductService
    {
        private readonly ApplicationDbContext context;

        private readonly IProductMapper PMapper;

        private readonly ILogger logger;

        public ProductServiceImpl(ApplicationDbContext context, IProductMapper mapper)
        {
            this.context = context;
            this.PMapper = mapper;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<ProductServiceImpl>();
        }

        public async Task<List<ProductDTO>> GetAll()
        {
            logger.LogInformation(GetType().Name + " : GetAll");

            List<Product> list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).ToListAsync();

            List<ProductDTO> result = new List<ProductDTO>();

            string message = string.Empty;

            if (list != null)
            {
                if (list.Count == 0)
                {
                    message = "products entity is empty";
                }
            }
            else
            {
                message = "products entity is empty";
            }

            if (string.IsNullOrEmpty(message))
            {
                foreach (var item in list)
                {
                    if (!item.Name.Equals("removed product"))
                    {
                        ProductDTO dto = PMapper.ToDTO(item);

                        result.Add(dto);
                    }
                }
            }
            else
            {
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Product>("GetAll", message, HttpStatusCode.NotFound);
            }

            return result;
        }

        public async Task<List<ProductDTO>> GetProductsInCatalog()
        {
            logger.LogInformation(GetType().Name + " : GetProductsInCatalog");

            List<Product> list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.CountThis > 0).ToListAsync();

            List<ProductDTO> result = new List<ProductDTO>();

            string message = string.Empty;

            if (list != null)
            {
                if (list.Count == 0)
                {
                    message = "products entity is empty";
                }
            }
            else
            {
                message = "products entity is empty";
            }

            if (string.IsNullOrEmpty(message))
            {
                foreach (var item in list)
                {
                    if (!item.Name.Equals("removed product"))
                    {
                        ProductDTO dto = PMapper.ToDTO(item);

                        result.Add(dto);
                    }
                }
            }
            else
            {
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Product>("GetProductsInCatalog", message, HttpStatusCode.NotFound);
            }

            return result;
        }

        public async Task<List<ProductDTO>> GetProductsInBasket(string email)
        {
            logger.LogInformation(GetType().Name + " : GetProductsInBasket");

            if (email != null)
            {
                List<Guid> list = await context.BasketCtx.Include(b => b.Buyer).Include(b => b.Product).Where(b => b.Buyer.NormalizedEmail.Equals(email.ToUpper())).Select(b => b.Product.Id).ToListAsync();

                string message = string.Empty;

                if (list != null)
                {
                    if (list.Count == 0)
                    {
                        message = "products entity is empty";
                    }
                }
                else
                {
                    message = "products entity is empty";
                }

                if (string.IsNullOrEmpty(message))
                {
                    List<ProductDTO> result = new List<ProductDTO>();

                    foreach (var item in list)
                    {
                        Product entity = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).FirstOrDefaultAsync(p => p.Id.Equals(item));

                        result.Add(PMapper.ToDTO(entity));
                    }
                }
                else
                {
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Product>("GetProductsInBasket", message, HttpStatusCode.NotFound);
                }
            }
            else
            {
                string message = "email parameter is mandatort";
                logger.LogInformation(GetType().Name + " : " + message);
                throw new HttpException<Product>("GetProductsInBasket", message, HttpStatusCode.BadRequest);
            }

            throw new NotImplementedException();
        }

        public async Task<ProductDTO> GetById(string id)
        {
            logger.LogInformation(GetType().Name + " : GetById");

            if (id != null)
            {
                try
                {
                    Product entity = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).FirstOrDefaultAsync(p => p.Id.Equals(Guid.Parse(id)));

                    if (entity != null)
                    {
                        ProductDTO dto = PMapper.ToDTO(entity);

                        return dto;
                    }
                    else
                    {
                        string message = "products with id " + id + " was not found";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<Product>("GetById", message, HttpStatusCode.NotFound);
                    }
                }
                catch (FormatException ex)
                {
                    string message = "convert id " + id + " failed: " + ex.Message;
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Product>("GetById", message, HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                string message = "id parameter is mandatory";
                logger.LogInformation(GetType().Name + " : " + message);
                throw new HttpException<Product>("GetById", message, HttpStatusCode.BadRequest);
            }
        }

        public async Task<ProductDTO> LoadProduct(ClaimsPrincipal currentUser, string eqId)
        {
            logger.LogInformation(GetType().Name + " : LoadProduct");

            if (eqId != null)
            {
                try
                {
                    string uid = currentUser.FindFirstValue(ClaimTypes.NameIdentifier);
                    EvaluationQueue entity = await context.EvaluationQueueCtx.Include(eq => eq.Product).FirstOrDefaultAsync(eq => eq.Id.Equals(Guid.Parse(eqId)));

                    if (entity != null)
                    {
                        if (entity.BuyerId.ToString().Equals(uid))
                        {
                            ProductDTO dto = PMapper.ToDTO(entity.Product);

                            return dto;
                        }
                        else
                        {
                            string message = "trying to get a record owned by another user";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<EvaluationQueue>("LoadProduct", message, HttpStatusCode.Forbidden);
                        }
                    }
                    else
                    {
                        string message = "evaluationQueue with id " + eqId + " was not found";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<EvaluationQueue>("LoadProduct", message, HttpStatusCode.NotFound);
                    }
                }
                catch (FormatException ex)
                {
                    string message = "convert id " + eqId + " failed: " + ex.Message;
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<EvaluationQueue>("LoadProduct", message, HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                string message = "eqId partameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Product>("LoadProduct", message, HttpStatusCode.BadRequest);
            }
        }

        public async Task<ProductDTO> RateProduct(ClaimsPrincipal currentUser, string eqId, ProductDTO dto)
        {
            logger.LogInformation(GetType().Name + " : RateProduct");

            if (eqId != null)
            {
                if (dto != null)
                {
                    try
                    {
                        string uid = currentUser.FindFirstValue(ClaimTypes.NameIdentifier);

                        Product entity = await context.ProductsCtx.FindAsync(Guid.Parse(dto.Id));

                        EvaluationQueue eqEntity = await context.EvaluationQueueCtx.FindAsync(Guid.Parse(eqId));

                        if (entity != null)
                        {
                            if (eqEntity != null)
                            {
                                if (eqEntity.BuyerId.ToString().Equals(uid) && eqEntity.ProductId.ToString().Equals(dto.Id))
                                {
                                    entity.Rating = (entity.Rating + dto.Rating) / (entity.MarksCount + 1);
                                    entity.MarksCount++;

                                    context.Entry(entity).State = EntityState.Modified;
                                    context.Set<Product>().Update(entity);
                                    await context.SaveChangesAsync();

                                    if (eqEntity.IsAddedComment)
                                    {
                                        context.Entry(eqEntity).State = EntityState.Deleted;
                                        context.Set<EvaluationQueue>().Remove(eqEntity);
                                    }
                                    else
                                    {
                                        eqEntity.IsRateProduct = true;
                                        context.Entry(eqEntity).State = EntityState.Modified;
                                        context.Set<EvaluationQueue>().Update(eqEntity);
                                    }

                                    await context.SaveChangesAsync();

                                    return dto;
                                }
                                else
                                {
                                    string message = "you must order this product firstly";
                                    logger.LogError(GetType().Name + " : " + message);
                                    throw new HttpException<EvaluationQueue>("RateProduct", message, HttpStatusCode.Forbidden);
                                }
                            }
                            else
                            {
                                string message = "evaluationQueue with id " + eqId + " was not found";
                                logger.LogError(GetType().Name + " : " + message);
                                throw new HttpException<EvaluationQueue>("RateProduct", message, HttpStatusCode.NotFound);
                            }
                        }
                        else
                        {
                            string message = "product with id " + dto.Id + " was not found";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<Product>("RateProduct", message, HttpStatusCode.NotFound);
                        }
                    }
                    catch (FormatException ex)
                    {
                        string message = "convert id " + dto.Id + " or (and) " + eqId + " failed: " + ex.Message;
                        logger.LogInformation(GetType().Name + " : " + message);
                        throw new HttpException<Product>("Update", message, HttpStatusCode.InternalServerError);
                    }
                }
                else
                {
                    string message = "dto parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Product>("RateProduct", message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                string message = "eqId parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<EvaluationQueue>("RateProduct", message, HttpStatusCode.BadRequest);
            }
        }

        public async Task<ProductDTO> Add(ProductDTO item)
        {
            logger.LogInformation(GetType().Name + " : Add");

            if (item != null)
            {
                if (!item.Name.Equals("removed product"))
                {
                    //generate cipher
                    item.Cipher = GenerateProductCipher();
                    //set CountThis attribute
                    item.CountThis = item.CountAll;
                    //set ratng
                    item.Rating = 0;
                    //need to set CountOfRating as null
                    Product entity = PMapper.ToEntity(item);

                    await context.ProductsCtx.AddAsync(entity);

                    await context.SaveChangesAsync();

                    item = PMapper.ToDTO(entity);

                    return item;
                }
                else
                {
                    string message = "invalid product name";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Product>("Add", message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                string message = "item parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Product>("Add", message, HttpStatusCode.BadRequest);
            }
        }

        public async Task<ProductDTO> Update(ProductDTO item)
        {
            logger.LogInformation(GetType().Name + " : Update");

            if (item != null)
            {
                try
                {
                    Product entity = await context.ProductsCtx.FindAsync(Guid.Parse(item.Id));

                    if (entity != null)
                    {
                        if (!entity.Name.Equals("removed product"))
                        {
                            entity = PMapper.ToEntity(item);

                            //sync count
                            if (entity.CountAll < entity.CountThis)
                            {
                                entity.CountThis = entity.CountAll;
                            }

                            entity.Category = await context.CategoriesCtx.FindAsync(Guid.Parse(item.CategoryDTOId));

                            entity.SupplerFirm = await context.SupplerFirmsCtx.FindAsync(Guid.Parse(item.SupplerFirmDTOId));

                            context.ProductsCtx.Update(entity);

                            await context.SaveChangesAsync();

                            item = PMapper.ToDTO(entity);

                            return item;
                        }
                        else
                        {
                            string message = "product with name \"removed product\" cant be modify";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<Product>("Update", message, HttpStatusCode.Forbidden);
                        }
                    }
                    else
                    {
                        string message = "product with id " + item.Id + " was not found";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<Product>("Update", message, HttpStatusCode.NotFound);
                    }
                }
                catch (FormatException ex)
                {
                    string message = "convert id " + item.Id + " failed : " + ex.Message;
                    logger.LogError(GetType().Name + " : : " + message);
                    throw new HttpException<Product>("Update", message, HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                string message = "item parameter is mandatory";
                logger.LogError(GetType().Name + message);
                throw new HttpException<Product>("Update", message, HttpStatusCode.BadRequest);
            }
        }

        [Obsolete]
        public async Task Delete(string id)
        {
            logger.LogInformation(GetType().Name + " : Delete");

            if (id != null)
            {
                try
                {
                    Product entity = await context.ProductsCtx.FindAsync(Guid.Parse(id));

                    if (entity != null)
                    {
                        if (!entity.Name.Equals("removed product"))
                        {
                            //replace depends link
                            List<OrderProduct> list = await context.OrderProductCtx.Where(op => op.ProductId.Equals(entity.Id)).ToListAsync();

                            if (list != null)
                            {
                                Guid removedProductId = await context.ProductsCtx.Where(p => p.Name.Equals("removed product")).Select(p => p.Id).FirstOrDefaultAsync();                                

                                foreach (var item in list)
                                {
                                    string pid = removedProductId.ToString();
                                    string oid = item.OrderId.ToString();
                                    string oldProductId = item.ProductId.ToString();
                                    string query = $"update OrderProduct set product_id = '{pid}' where order_id = '{oid}' and product_id='{oldProductId}';";
                                    var res = await context.Database.ExecuteSqlCommandAsync(query);
                                    await context.SaveChangesAsync();
                                }

                                list = await context.OrderProductCtx.Where(op => op.ProductId.Equals(entity.Id)).ToListAsync();
                            }

                            context.ProductsCtx.Remove(entity);
                            await context.SaveChangesAsync();
                        }
                        else
                        {
                            string message = "product with name \"reomved product\" cant be removed";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<Product>("Delete", message, HttpStatusCode.Forbidden);
                        }
                    }
                    else
                    {
                        string message = "product with id " + id + " was not found";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<Product>("Delete", message, HttpStatusCode.NotFound);
                    }
                }
                catch (FormatException ex)
                {
                    string message = "convert id " + id + " failed : " + ex.Message;
                    logger.LogError(GetType().Name + " : : " + message);
                    throw new HttpException<Product>("Update", message, HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                string message = "id parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Product>("Delete", message, HttpStatusCode.BadRequest);
            }
        }

        public async Task<List<ProductDTO>> FindByName(string name, bool isRoot = false)
        {
            logger.LogInformation(GetType().Name + " : FindByname");

            if (name != null)
            {
                List<Product> list = new List<Product>();

                if (isRoot)
                {
                    list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.Name.ToUpper().Contains(name.ToUpper()) && !p.Name.Equals("removed product")).ToListAsync();
                }
                else
                {
                    list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.Name.ToUpper().Contains(name.ToUpper()) && p.CountThis > 0 && !p.Name.Equals("removed product")).ToListAsync();
                }

                string message = string.Empty;

                if (list != null)
                {
                    if (list.Count == 0)
                    {
                        message = "products entity is empty";
                    }
                }
                else
                {
                    message = "products entity is empty";
                }

                if (string.IsNullOrEmpty(message))
                {
                    List<ProductDTO> result = new List<ProductDTO>();

                    foreach (var item in list)
                    {
                        ProductDTO dto = PMapper.ToDTO(item);

                        result.Add(dto);
                    }

                    return result;
                }
                else
                {
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<User>("FindByName", message, HttpStatusCode.NotFound);
                }
            }
            else
            {
                string message = "name parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Product>("FindByName", message, HttpStatusCode.BadRequest);
            }
        }

        public async Task<List<ProductDTO>> FindByCategory(string category, bool isRoot = false)
        {
            logger.LogInformation(GetType().Name + " : FindByCategory");

            if (category != null)
            {
                Category cEntity = await context.CategoriesCtx.FirstOrDefaultAsync(c => c.Name.ToUpper().Contains(category.ToUpper()));

                if (cEntity != null)
                {
                    List<Product> list = new List<Product>();

                    if (isRoot)
                    {
                        list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.Category.Name.ToUpper().Contains(category.ToUpper()) && !p.Name.Equals("removed product")).ToListAsync();
                    }
                    else
                    {
                        list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.Category.Name.ToUpper().Contains(category.ToUpper()) && p.CountThis > 0 && !p.Name.Equals("removed product")).ToListAsync();
                    }

                    string message = string.Empty;

                    if (list != null)
                    {
                        if (list.Count == 0)
                        {
                            message = "products entity is empty";
                        }
                    }
                    else
                    {
                        message = "products entity is empty";
                    }

                    if (string.IsNullOrEmpty(message))
                    {
                        List<ProductDTO> result = new List<ProductDTO>();

                        foreach (var item in list)
                        {
                            ProductDTO dto = PMapper.ToDTO(item);

                            result.Add(dto);
                        }

                        return result;
                    }
                    else
                    {
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<User>("FindByCategory", message, HttpStatusCode.NotFound);
                    }
                }
                else
                {
                    string message = "category with name " + category + " was not found";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Product>("FindByCategory", message, HttpStatusCode.NotFound);
                }
            }
            else
            {
                string message = "category parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Product>("FindByCategory", message, HttpStatusCode.BadRequest);
            }
        }

        public async Task<List<ProductDTO>> FindBySupplerFirm(string firm, bool isRoot = false)
        {
            logger.LogInformation(GetType().Name + " : FindBySupplerFirm");

            if (firm != null)
            {
                SupplerFirm sfEntity = await context.SupplerFirmsCtx.FirstOrDefaultAsync(sf => sf.Name.ToUpper().Contains(firm.ToUpper()));

                if (sfEntity != null)
                {
                    List<Product> list = new List<Product>();

                    if (isRoot)
                    {
                        list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.SupplerFirm.Name.ToUpper().Contains(firm.ToUpper()) && !p.Name.Equals("removed product")).ToListAsync();
                    }
                    else
                    {
                        list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.SupplerFirm.Name.ToUpper().Contains(firm.ToUpper()) && p.CountThis > 0 && !p.Name.Equals("removed product")).ToListAsync();
                    }

                    string message = string.Empty;

                    if (list != null)
                    {
                        if (list.Count == 0)
                        {
                            message = "products entity is empty";
                        }
                    }
                    else
                    {
                        message = "products entity is empty";
                    }

                    if (string.IsNullOrEmpty(message))
                    {
                        List<ProductDTO> result = new List<ProductDTO>();

                        foreach (var item in list)
                        {
                            ProductDTO dto = PMapper.ToDTO(item);

                            result.Add(dto);
                        }

                        return result;
                    }
                    else
                    {
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<User>("FindBySupplerFirm", message, HttpStatusCode.NotFound);
                    }
                }
                else
                {
                    string message = "supplerfirm with name " + firm + " was not found";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Product>("FindByCategory", message, HttpStatusCode.NotFound);
                }
            }
            else
            {
                string message = "category parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Product>("FindByCategory", message, HttpStatusCode.BadRequest);
            }
        }

        public async Task<List<ProductDTO>> FindByPrice(double? lowestPrice, double? higestPrice, bool isRoot = false)
        {
            logger.LogInformation(GetType().Name + " : FindByPrice");

            if (lowestPrice == null && higestPrice == null)
            {
                string message = "at least one parameter (lowestPrice and higestPrice) must be not empty";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Product>("FindByPrice", message, HttpStatusCode.BadRequest);
            }
            else
            {
                List<ProductDTO> result = new List<ProductDTO>();

                bool flag = true;

                if (lowestPrice != null)
                {
                    List<Product> list = new List<Product>();

                    flag = false;

                    if (higestPrice != null)
                    {
                        if (isRoot)
                        {
                            list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.Price >= lowestPrice && p.Price <= higestPrice && !p.Name.Equals("removed product")).ToListAsync();
                        }
                        else
                        {
                            list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.Price >= lowestPrice && p.Price <= higestPrice && p.CountThis > 0 && !p.Name.Equals("removed product")).ToListAsync();
                        }
                    }
                    else
                    {
                        if (isRoot)
                        {
                            list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.Price >= lowestPrice && !p.Name.Equals("removed product")).ToListAsync();
                        }
                        else
                        {
                            list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.Price >= lowestPrice && p.CountThis > 0 && !p.Name.Equals("removed product")).ToListAsync();
                        }
                    }

                    if (list.Count > 0)
                    {
                        foreach (var item in list)
                        {
                            ProductDTO dto = PMapper.ToDTO(item);

                            result.Add(dto);
                        }

                        return result;
                    }
                    else
                    {
                        string message = "products was not found";
                        logger.LogError(GetType().Name + " :" + message);
                        throw new HttpException<Product>("FindByPrice", message, HttpStatusCode.NotFound);
                    }
                }

                if (higestPrice != null && flag)
                {
                    List<Product> list = new List<Product>();

                    if (higestPrice != null)
                    {
                        list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.Price >= lowestPrice && p.Price <= higestPrice && !p.Name.Equals("removed product")).ToListAsync();
                    }
                    else
                    {
                        list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.Price >= lowestPrice && !p.Name.Equals("removed product")).ToListAsync();
                    }

                    if (list.Count > 0)
                    {
                        foreach (var item in list)
                        {
                            ProductDTO dto = PMapper.ToDTO(item);

                            result.Add(dto);
                        }

                        return result;
                    }
                    else
                    {
                        string message = "products was not found";
                        logger.LogError(GetType().Name + " :" + message);
                        throw new HttpException<Product>("FindByPrice", message, HttpStatusCode.NotFound);
                    }
                }

                return result;
            }
        }

        public async Task<List<ProductDTO>> FindByRating(double? lowestRating, double? higestRating, bool isRoot = false)
        {
            logger.LogInformation(GetType().Name + " : FinbByRating");

            if (lowestRating == null && higestRating == null)
            {
                string message = "at least one parameter (lowestRating and higestRating) must be not empty";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Product>("FindByRating", message, HttpStatusCode.BadRequest);
            }
            else
            {
                List<ProductDTO> result = new List<ProductDTO>();

                bool flag = true;

                if (lowestRating != null)
                {
                    List<Product> list = new List<Product>();

                    flag = false;

                    if (higestRating != null)
                    {
                        if (isRoot)
                        {
                            list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.Rating >= lowestRating && p.Rating <= higestRating && !p.Name.Equals("removed product")).ToListAsync();
                        }
                        else
                        {
                            list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.Rating >= lowestRating && p.Rating <= higestRating && p.CountThis > 0 && !p.Name.Equals("removed product")).ToListAsync();
                        }
                    }
                    else
                    {
                        if (isRoot)
                        {
                            list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.Rating >= lowestRating && !p.Name.Equals("removed product")).ToListAsync();
                        }
                        else
                        {
                            list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.Rating >= lowestRating && p.CountThis > 0 && !p.Name.Equals("removed product")).ToListAsync();
                        }
                    }

                    if (list.Count > 0)
                    {
                        foreach (var item in list)
                        {
                            ProductDTO dto = PMapper.ToDTO(item);

                            result.Add(dto);
                        }

                        return result;
                    }
                    else
                    {
                        string message = "search results is empty";
                        logger.LogError(GetType().Name + " :" + message);
                        throw new HttpException<Product>("FindByRating", message, HttpStatusCode.NotFound);
                    }
                }

                if (higestRating != null && flag)
                {
                    List<Product> list = new List<Product>();

                    if (higestRating != null)
                    {
                        await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.Rating >= lowestRating && p.Rating <= higestRating && !p.Name.Equals("removed product")).ToListAsync();
                    }
                    else
                    {
                        list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.Rating >= lowestRating && !p.Name.Equals("removed product")).ToListAsync();
                    }

                    if (list.Count > 0)
                    {
                        foreach (var item in list)
                        {
                            ProductDTO dto = PMapper.ToDTO(item);

                            result.Add(dto);
                        }

                        return result;
                    }
                    else
                    {
                        string message = "psearch results is empty";
                        logger.LogError(GetType().Name + " :" + message);
                        throw new HttpException<Product>("FindByRating", message, HttpStatusCode.NotFound);
                    }
                }

                return result;
            }
        }

        public async Task<List<ProductDTO>> FindHot(bool isRoot = false)
        {
            logger.LogInformation(GetType().Name + " : FindHot");

            List<Product> list = new List<Product>();

            if (isRoot)
            {
                list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.IsHot == true && !p.Name.Equals("removed product")).ToListAsync();
            }
            else
            {
                list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.CountThis > 0 && (p.IsHot == true) && !p.Name.Equals("removed product")).ToListAsync();
            }

            string message = string.Empty;

            if (list != null)
            {
                if (list.Count == 0)
                {
                    message = "products entity is empty";
                }
            }
            else
            {
                message = "products entity is empty";
            }

            if (string.IsNullOrEmpty(message))
            {
                List<ProductDTO> result = new List<ProductDTO>();

                foreach (var item in list)
                {
                    ProductDTO dto = PMapper.ToDTO(item);

                    result.Add(dto);
                }

                return result;
            }
            else
            {
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Product>("FindHot", message, HttpStatusCode.NotFound);
            }
        }

        public async Task<List<ProductDTO>> Search(ProductSearchDTO dto, bool isRoot = false)
        {
            logger.LogInformation(GetType().Name + " : Search");

            if (dto != null)
            {
                //search by main parameter

                List<Product> list = new List<Product>();

                if (!string.IsNullOrEmpty(dto.Name))
                {
                    logger.LogInformation(GetType().Name + " : #0 - search by Name parameter (is main)");

                    if (isRoot)
                    {
                        list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.Name.ToUpper().Contains(dto.Name.ToUpper()) && !p.Name.Equals("removed product")).ToListAsync();
                    }
                    else
                    {
                        list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.Name.ToUpper().Contains(dto.Name.ToUpper()) && (p.CountThis > 0) && !p.Name.Equals("removed product")).ToListAsync();
                    }
                }
                else
                {
                    logger.LogInformation(GetType().Name + " : #0 - get all records (is main)");

                    if (isRoot)
                    {
                        list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).ToListAsync();
                    }
                    else
                    {
                        list = await context.ProductsCtx.Include(p => p.Category).Include(p => p.SupplerFirm).Where(p => p.CountThis > 0).ToListAsync();
                    }
                }

                if (!string.IsNullOrEmpty(dto.CategoryId))
                {
                    logger.LogInformation(GetType().Name + " : #1 - search by CategoryName parameter");

                    List<Product> temp = new List<Product>();

                    foreach (var item in list)
                    {
                        if (item.CategoryId.ToString().Equals(dto.CategoryId))
                        {
                            temp.Add(item);
                        }
                    }

                    list = temp;
                }

                if (dto.SupplerFirmIds != null)
                {
                    logger.LogInformation(GetType().Name + " : #2 - search by SupplerFirmName parameter");

                    List<Product> temp = new List<Product>();

                    foreach (var item in list)
                    {
                        foreach (string sfid in dto.SupplerFirmIds)
                        {
                            if (item.SupplerFirmId.ToString().Equals(sfid))
                            {
                                temp.Add(item);
                                break;
                            }
                        }

                        list = temp;
                    }
                }

                if (dto.LowestPrice != null)
                {
                    logger.LogInformation(GetType().Name + " : #3 - search by Price (lowest) parameter");

                    List<Product> temp = new List<Product>();

                    foreach (var item in list)
                    {
                        if (item.Price >= dto.LowestPrice)
                        {
                            temp.Add(item);
                        }

                        list = temp;
                    }
                }

                if (dto.HigestPrice != null)
                {
                    logger.LogInformation(GetType().Name + " : #4 - search by Price (higest) parameter");

                    List<Product> temp = new List<Product>();

                    foreach (var item in list)
                    {
                        if (item.Price <= dto.HigestPrice)
                        {
                            temp.Add(item);
                        }

                        list = temp;
                    }
                }

                if (dto.LowestRating != null)
                {
                    logger.LogInformation(GetType().Name + " : #5 - search by Rating (lowest) parameter");

                    List<Product> temp = new List<Product>();

                    foreach (var item in list)
                    {
                        if (item.Rating >= dto.LowestRating)
                        {
                            temp.Add(item);
                        }

                        list = temp;
                    }
                }

                if (dto.HigestRating != null)
                {
                    logger.LogInformation(GetType().Name + " : #6 - search by Rating (higest) parameter");

                    List<Product> temp = new List<Product>();

                    foreach (var item in list)
                    {
                        if (item.Rating <= dto.HigestRating)
                        {
                            temp.Add(item);
                        }

                        list = temp;
                    }
                }

                if (dto.IsHot != null)
                {
                    logger.LogInformation(GetType().Name + " : #7 - search by IsHot parameter");

                    List<Product> temp = new List<Product>();

                    foreach (var item in list)
                    {
                        if (item.IsHot)
                        {
                            temp.Add(item);
                        }

                        list = temp;
                    }
                }

                if (list.Count > 0)
                {
                    List<ProductDTO> result = new List<ProductDTO>();

                    foreach (var item in list)
                    {
                        result.Add(PMapper.ToDTO(item));
                    }
                    return result;
                }
                else
                {
                    string mesage = "search results is empty";
                    logger.LogError(GetType().Name + " : " + mesage);
                    throw new HttpException<Product>("Search", mesage, HttpStatusCode.NotFound);
                }
            }
            else
            {
                string message = "dto parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Product>("Search", message, HttpStatusCode.BadRequest);
            }
        }

        private string GenerateProductCipher()
        {
            logger.LogInformation(GetType().Name + " : GenerateProductCipher");

            string result = "P#";
            DateTime date = DateTime.Now;

            result += date.ToString("yyyy-MM-dd") + "#";

            for (int i = 0; i < 20; i++)
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