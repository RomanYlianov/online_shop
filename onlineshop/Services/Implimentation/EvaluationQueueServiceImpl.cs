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
    public class EvaluationQueueServiceImpl : IEvaluationQueueService
    {

        private readonly ApplicationDbContext context;

        private readonly IEvaluationQueueMapper EQMapper;

        private readonly SignInManager<User> SINManager;

        private readonly ILogger logger;

        public EvaluationQueueServiceImpl(ApplicationDbContext context, SignInManager<User> sINManager,  IEvaluationQueueMapper mapper)
        {

            this.context = context;

            this.SINManager = sINManager;

            this.EQMapper = mapper;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());

            logger = logFactory.CreateLogger<EvaluationQueueServiceImpl>();


        }

        //select * where buyer_id = cuid
        /*
         * в контроллере в методе Index имеются кнопки: Details, Add Comment (1), Mark Product (2)
         * 
         * изначально флаги is_added_comment и is_rate_product равны false
         * 
         * Dictionary: eq_id = evaluationqueue_id
         * 
         * (1): ведет в comments/add/{eq_id}
         * 
         * в данном методе происходит добавление комментария, после чего происходит поиск в EvaluationQueue по eq_id,
         * флаг is_added_comment - true => add in comment
         * 
         * call (after)
         * 
         * (2): ведет в /products/mark_product/{eq_id}
         * 
         * в данном методе происходит оценка товара (rating = (rating+added_rating)/(marks_count+), merks_count = marks_count+1, после чего происходит
         * поиск в EvaluationQueue по eq_id,
         * флаг is_rate_product - true  => update in product
         * 
         * call (after)
         * 
         * (after): происходит поиск в EvaluationQueue по eq_id и, если флаги is_added_comment == true &&  is_rate_product == true, 
         *  найденные записи удаляются
         */
        public async Task<List<EvaluationQueueDTO>> GetAll(ClaimsPrincipal currentUser)
        {

            logger.LogInformation(GetType().Name + " : GetAll");

            List<EvaluationQueueDTO> result = new List<EvaluationQueueDTO>();
            
            if (SINManager.IsSignedIn(currentUser))
            {

                string uid = currentUser.FindFirstValue(ClaimTypes.NameIdentifier);

                List<EvaluationQueue> list = await context.EvaluationQueueCtx.Include(eq => eq.Buyer).Include(eq => eq.Order).Include(eq => eq.Product).Where(eq => eq.BuyerId.Equals(Guid.Parse(uid)) ).ToListAsync();

                string message = string.Empty;

                if (list != null)
                {
                    if (list.Count == 0)
                    {
                        message = "evaluationqueue entity is empty";
                    }
                }
                else
                {
                    message = "evaluationqueue entity is empty";
                }

                if (string.IsNullOrEmpty(message))
                {

                    foreach (var item in list)
                    {
                        if (item.Order.OrderStatus.Equals(OrderStatus.RECEIVED))
                        {
                            EvaluationQueueDTO dto = EQMapper.ToDTO(item);
                            result.Add(dto);
                        }                      
                    }

                }
                else
                {
                    logger.LogError(GetType().Name + " : " + message);
                    throw new HttpException<EvaluationQueue>("GetAll", message, HttpStatusCode.NotFound);
                }

            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("GetAll", message, HttpStatusCode.Forbidden);
            }

            return result;

        }

        public async Task<EvaluationQueueDTO> GetById(ClaimsPrincipal currentUser, string id)
        {

            logger.LogError(GetType().Name + " : GetById");

            if (SINManager.IsSignedIn(currentUser))
            {

                try
                {

                    EvaluationQueue entity = await context.EvaluationQueueCtx.Include(eq => eq.Order).Include(eq => eq.Buyer).Include(eq => eq.Product).Where(eq => eq.Id.Equals(Guid.Parse(id))).FirstOrDefaultAsync();
                    
                    if (entity != null)
                    {

                        EvaluationQueueDTO dto = EQMapper.ToDTO(entity);
                        
                        return dto;

                    }
                    else
                    {
                        string message = "evaluationqueue with id " + id + " was not found";
                        logger.LogError(GetType().Name + " : " + message);
                        throw new HttpException<EvaluationQueue>("GetById", message, HttpStatusCode.NotFound);
                    }

                }
                catch (FormatException ex)
                {
                    string message = "convert id " + id + " failed : " + ex.Message;
                    logger.LogError(GetType().Name + " : : " + message);
                    throw new HttpException<EvaluationQueue>("GetById", message, HttpStatusCode.InternalServerError);
                }

            }
            else
            {
                string message = "user is not authorized";
                logger.LogError(GetType().Name + " : " + message);
                throw new HttpException<User>("GetById", message, HttpStatusCode.Forbidden);
            }

        }
       
    }
}
