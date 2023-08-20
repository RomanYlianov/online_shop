using Microsoft.AspNetCore.Mvc.ViewFeatures;
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
using System.Threading.Tasks;

namespace onlineshop.Services.Implimentation
{
    public class CategoryServiceImpl : ICategoryService
    {

        private readonly ApplicationDbContext context;

        private readonly ICategoryMapper CtMapper;

        private readonly ILogger logger;

        public CategoryServiceImpl(ApplicationDbContext context, ICategoryMapper mapper)
        {
            this.context = context;
            CtMapper = mapper;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<CategoryServiceImpl>();
        }

        public async Task<List<CategoryDTO>> GetAll()
        {
            
            logger.LogInformation(GetType().Name + " : GetAll");

            List<Category> list = await context.CategoriesCtx.ToListAsync();

            List<CategoryDTO> result = new List<CategoryDTO>();

            string message = string.Empty;

            if (list != null)
            {

                if (list.Count == 0)
                {
                    message = "categories entity is emplty";
                }               
            }
            else
            {
                message = "categories entity is emplty";
            }


            if (string.IsNullOrEmpty(message))
            {
                foreach (var item in list)
                {
                    if (!item.Name.Equals("root category"))
                        result.Add(CtMapper.ToDTO(item));
                }
            }
            else
            {
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Category>("GetAll", message, HttpStatusCode.NotFound);
            }
            return result;
        }

        public async Task<CategoryDTO> GetById(string id)
        {
            
            logger.LogInformation(GetType().Name + " : GetById");

            if (id!=null)
            {
                try
                {
                    Category entity = await context.CategoriesCtx.FindAsync(Guid.Parse(id));
                    
                    if (entity != null)
                    {
                        return CtMapper.ToDTO(entity);
                    }
                    else
                    {
                        string message = "category with id " + id + " was not found";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<Category>("GetById", message, System.Net.HttpStatusCode.NotFound);
                    }
                   
                }
                catch (FormatException ex)
                {
                    string message = "convert id " + id + " failed: " + ex.Message;
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Category>("GetById", message, HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                string message = "id parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Category>("GetById", message, HttpStatusCode.BadRequest);
            }

        }

        public async Task<CategoryDTO> Add(CategoryDTO item)
        {
            
            logger.LogInformation(GetType().Name + " : Add");

            if (item != null)
            {
                Category entity = CtMapper.ToEntity(item);
                
                if (!entity.Name.Equals("root category"))
                {
                    await context.CategoriesCtx.AddAsync(entity);
                    await context.SaveChangesAsync();

                    item = CtMapper.ToDTO(entity);
                    return item;
                }
                else
                {
                    string message = "invalid cantegory name";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Category>("Add", message, HttpStatusCode.BadRequest);
                }

               
            }
            else
            {
                string message = "item parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Category>("Add", message, HttpStatusCode.BadRequest);
            }
        }

        public async Task<CategoryDTO> Update(CategoryDTO item)
        {
            
            logger.LogInformation(GetType().Name + " : Update");

            if (item != null)
            {
                //Category entity = CtMapper.ToEntity(item);
                
                try
                {

                    Category entity = await context.CategoriesCtx.FindAsync(Guid.Parse(item.Id));

                    if (entity != null)
                    {
                        if (!entity.Name.Equals("root category"))
                        {
                            entity = CtMapper.ToEntity(item);

                            context.CategoriesCtx.Update(entity);
                            await context.SaveChangesAsync();

                            item = CtMapper.ToDTO(entity);

                            return item;
                        }
                        else
                        {
                            string message = "category with name \"root name\" cant be modify";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<Category>("Update", message, HttpStatusCode.Forbidden);
                        }
                    }
                    else
                    {
                        string message = "category with id " + item.Id + " was not found";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<Category>("Update", message, HttpStatusCode.NotFound);
                    }
                    
                }
                catch (FormatException ex)
                {
                    string message = "convert id " + item.Id + " failed : " + ex.Message;
                    logger.LogError(GetType().Name + " : : " + message);
                    throw new HttpException<Category>("Update", message, HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                string message = "item parameter is mandatory";
                logger.LogError(GetType().Name+" : "+ message);
                throw new HttpException<Category>("Update", message, HttpStatusCode.BadRequest);
            }

        }

        public async Task Delete(string id)
        {
             
            logger.LogInformation(GetType().Name + " : Delete");

            if (id != null)
            {
                try
                {
                    Category entity = await context.CategoriesCtx.FindAsync(Guid.Parse(id));

                    if (entity != null)
                    {

                        if (!entity.Name.Equals("root category"))
                        {
                            context.CategoriesCtx.Remove(entity);

                            await context.SaveChangesAsync();
                        }
                        else
                        {
                            string message = "category with name \"root name\" cant be removed";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<Category>("Delete", message, HttpStatusCode.Forbidden);
                        }                  

                    }
                    else
                    {
                        string message = "category with id " + id + " was not found";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<Category>("Delete", message, HttpStatusCode.NotFound);
                    }

                }
                catch (FormatException ex)
                {
                    string message = "convert id " + id + " failed : " + ex.Message;
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Category>("Delete", message, HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                string message = "id parameter id mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Category>("Delete", message, HttpStatusCode.BadRequest);
            }
        }

    }
}
