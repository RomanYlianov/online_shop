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
    public class CommentServiceImpl : ICommentService
    {
        private readonly ApplicationDbContext context;

        private readonly ICommentMapper CMapper;

        private readonly IUserService UService;

        private readonly IUserMapper UMapper;

        private readonly IProductService PService;

        private readonly SignInManager<User> SINManager;

        private readonly ILogger logger;

        public CommentServiceImpl(ApplicationDbContext context, SignInManager<User> sINManager, ICommentMapper cMapper, IUserService uService, IUserMapper uMapper, IProductService pService)
        {
            this.context = context;

            this.SINManager = sINManager;

            this.CMapper = cMapper;
            this.UService = uService;

            this.UMapper = uMapper;
            this.PService = pService;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<CommentServiceImpl>();
        }

        public async Task<List<CommentDTO>> GetAll(string productId)
        {
            logger.LogInformation(GetType().Name + " : GetAll");

            if (productId != null)
            {
                try
                {
                    List<Comment> list = await context.CommentsCtx.Include(c => c.Product).Where(c => c.ProductId.Equals(Guid.Parse(productId))).ToListAsync();

                    List<CommentDTO> result = new List<CommentDTO>();

                    string message = string.Empty;

                    if (list != null)
                    {
                        if (list.Count == 0)
                        {
                            message = "comment entity is empty";
                        }
                    }
                    else
                    {
                        message = "comment entity is empty";
                    }

                    if (string.IsNullOrEmpty(message))
                    {
                        foreach (var item in list)
                        {
                            CommentDTO dto = CMapper.ToDTO(item);

                            if (item.AuthorId != null)
                            {
                                User uEntity = await context.Users.FirstOrDefaultAsync(u => u.Id.Equals(item.AuthorId));

                                dto.AuthorDTO = UMapper.ToDTO(uEntity);
                            }

                            result.Add(dto);
                        }

                        return result;
                    }
                    else
                    {
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<Comment>("GetAll", message, HttpStatusCode.NotFound);
                    }
                }
                catch (FormatException ex)
                {
                    string message = "convert id " + productId + " failed: " + ex.Message;
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Product>("GetAll", message, HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                string message = "productId parameter is mandatory";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<Product>("GetAll", message, HttpStatusCode.BadRequest);
            }
        }

        public async Task<CommentDTO> GetById(string id)
        {
            logger.LogInformation(GetType().Name + " : GetById");

            if (id != null)
            {
                try
                {
                    Comment entity = await context.CommentsCtx.Include(p => p.Product).FirstOrDefaultAsync(c => c.Id.Equals(Guid.Parse(id)));

                    if (entity != null)
                    {
                        if (entity.AuthorId != null)
                        {
                            entity.Author = await context.Users.FindAsync(entity.AuthorId);
                        }

                        return CMapper.ToDTO(entity);
                    }
                    else
                    {
                        string message = "comment with id " + id + " was not found";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<Comment>("GetById", message, HttpStatusCode.NotFound);
                    }
                }
                catch (FormatException ex)
                {
                    string message = "convert id " + id + " failed: " + ex.Message;
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Comment>("GetById", message, HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                string message = "id parameter is mandatory";
                logger.LogInformation(GetType().Name + " : " + message);
                throw new HttpException<Comment>("GetById", message, HttpStatusCode.BadRequest);
            }
        }

        public async Task<CommentDTO> Inicialize(ClaimsPrincipal currentUser, string eqId)
        {
            logger.LogInformation(GetType().Name + " : Inicialize");

            if (SINManager.IsSignedIn(currentUser))
            {
                string uid = currentUser.FindFirstValue(ClaimTypes.NameIdentifier);

                try
                {
                    EvaluationQueue entity = await context.EvaluationQueueCtx.FindAsync(Guid.Parse(eqId));

                    if (entity != null)
                    {
                        CommentDTO dto = new CommentDTO();

                        ProductDTO pDTO = await PService.GetById(entity.ProductId.ToString());

                        UserDTO uDTO = await UService.GetById(currentUser, entity.BuyerId.ToString());

                        dto.AuthorDTO = uDTO;
                        dto.AuthorDTOId = entity.BuyerId.ToString();

                        dto.ProductDTO = pDTO;
                        dto.ProductDTOId = entity.ProductId.ToString();

                        return dto;
                    }
                    else
                    {
                        string message = "evaluationQueue with id " + eqId + " was not found";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<EvaluationQueue>("Inicialize", message, HttpStatusCode.NotFound);
                    }
                }
                catch (FormatException ex)
                {
                    string message = "convert id " + eqId + " failed: " + ex.Message;
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<EvaluationQueue>("Inicialize", message, HttpStatusCode.InternalServerError);
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
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("Inicialize", message, HttpStatusCode.Forbidden);
            }
        }

        //can be added/changed/removed, if row exists in table evaluationQueue
        //author = null -> user was removed
        public async Task<CommentDTO> Add(ClaimsPrincipal currentUser, string eqId, CommentDTO item)
        {
            logger.LogInformation(GetType().Name + " : Add");

            if (SINManager.IsSignedIn(currentUser))
            {
                if (item != null)
                {
                    try
                    {
                        EvaluationQueue entity = await context.EvaluationQueueCtx.FindAsync(Guid.Parse(eqId));

                        if (entity != null)
                        {
                            if (!entity.IsAddedComment)
                            {
                                Comment commentEntity = CMapper.ToEntity(item);

                                if (currentUser != null)
                                {
                                    string uid = currentUser.FindFirstValue(ClaimTypes.NameIdentifier);
                                    commentEntity.AuthorId = Guid.Parse(uid);
                                    commentEntity.CreationTime = DateTime.Now;

                                    context.Entry(commentEntity).State = EntityState.Added;
                                    await context.Set<Comment>().AddAsync(commentEntity);
                                    await context.SaveChangesAsync();

                                    if (entity.IsRateProduct)
                                    {
                                        context.Entry(entity).State = EntityState.Deleted;
                                        context.Set<EvaluationQueue>().Remove(entity);

                                        await context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        entity.IsAddedComment = true;
                                        context.Entry(entity).State = EntityState.Modified;
                                        context.Set<EvaluationQueue>().Update(entity);

                                        await context.SaveChangesAsync();
                                    }

                                    item = CMapper.ToDTO(commentEntity);
                                    return item;
                                }
                                else
                                {
                                    string message = "user is not authorized";
                                    logger.LogError(GetType().Name + " : " + message);
                                    throw new HttpException<Comment>("Add", message, HttpStatusCode.Forbidden);
                                }
                            }
                            else
                            {
                                string message = "you already added a comment";
                                logger.LogError(GetType().Name + " : " + message);
                                throw new HttpException<Comment>("Add", message, HttpStatusCode.Forbidden);
                            }
                        }
                        else
                        {
                            string message = "you must order a product to write a comment";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<Comment>("Add", message, HttpStatusCode.Forbidden);
                        }
                    }
                    catch (FormatException ex)
                    {
                        string message = "convert id " + eqId + " failed: " + ex.Message;
                        logger.LogInformation(GetType().Name + " : " + message);
                        throw new HttpException<Comment>("Add", message, HttpStatusCode.InternalServerError);
                    }
                }
                else
                {
                    string message = "item parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Comment>("Add", message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("Add", message, HttpStatusCode.Forbidden);
            }
        }

        public async Task<CommentDTO> Update(ClaimsPrincipal currentUser, CommentDTO item)
        {
            logger.LogInformation(GetType().Name + " : Update");

            if (SINManager.IsSignedIn(currentUser))
            {
                if (item != null)
                {
                    try
                    {
                        Comment entity = await context.CommentsCtx.FindAsync(Guid.Parse(item.Id));

                        if (entity != null)
                        {
                            if (CheckPermissions(currentUser, entity.AuthorId.ToString()))
                            {
                                //change fields : title, text
                                entity = CMapper.ToEntity(item);
                                entity.ModificationTime = DateTime.Now;

                                context.CommentsCtx.Update(entity);
                                await context.SaveChangesAsync();

                                item = CMapper.ToDTO(entity);
                                return item;
                            }
                            else
                            {
                                string message = "you don't have permissions to change comment";
                                logger.LogError(GetType().Name + " : " + message);
                                throw new HttpException<Comment>("Update", message, HttpStatusCode.Forbidden);
                            }
                        }
                        else
                        {
                            string message = "comment with id " + item.Id + " was not found";
                            logger.LogError(GetType().Name + " : " + message);
                            throw new HttpException<Comment>("Update", message, HttpStatusCode.NotFound);
                        }
                    }
                    catch (FormatException ex)
                    {
                        string message = "convert id " + item.Id + " failed: " + ex.Message;
                        logger.LogInformation(GetType().Name + " : " + message);
                        throw new HttpException<Comment>("Update", message, HttpStatusCode.InternalServerError);
                    }
                }
                else
                {
                    string message = "item parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Comment>("Update", message, HttpStatusCode.BadRequest);
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
                        Comment entity = await context.CommentsCtx.FindAsync(Guid.Parse(id));

                        if (entity != null)
                        {
                            if (CheckPermissions(currentUser, entity.AuthorId.ToString()))
                            {
                                context.CommentsCtx.Remove(entity);
                                await context.SaveChangesAsync();
                            }
                            else
                            {
                                string message = "you dont't have permissions to change comment";
                                logger.LogError(GetType().Name + " : " + message);
                                throw new HttpException<Comment>("Delete", message, HttpStatusCode.Forbidden);
                            }
                        }
                        else
                        {
                            string message = "comment with id " + id + " was not found";
                            logger.LogInformation(GetType().Name + " : " + message);
                            throw new HttpException<Comment>("Delete", message, HttpStatusCode.NotFound);
                        }
                    }
                    catch (FormatException ex)
                    {
                        string message = "convert id " + id + " failed: " + ex.Message;
                        logger.LogInformation(GetType().Name + " : " + message);
                        throw new HttpException<Comment>("Delete", message, HttpStatusCode.InternalServerError);
                    }
                }
                else
                {
                    string message = "id parameter is mandatory";
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<Comment>("Delete", message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("Delete", message, HttpStatusCode.Forbidden);
            }
        }

        private bool CheckPermissions(ClaimsPrincipal currentUser, string uid)
        {
            logger.LogInformation(GetType().Name + " : CheckPermissions");

            bool flag = false;

            if (currentUser != null && uid != null)
            {
                string currentUid = currentUser.FindFirstValue(ClaimTypes.NameIdentifier);
                flag = uid.Equals(currentUid) || currentUser.IsInRole("OWNER");
            }

            return flag;
        }
    }
}