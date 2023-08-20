using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using onlineshop.Services;
using onlineshop.Services.DTO;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace onlineshop.Controllers
{
    [Route("evaluationsqueue")]
    public class EvaluationsQueueController : Controller
    {

        private readonly IEvaluationQueueService EQService;

        private readonly IBasketService BService;

        private readonly ILogger logger;

        public EvaluationsQueueController(IEvaluationQueueService eQService, IBasketService bService)
        {

            this.EQService = eQService;
            this.BService = bService;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<EvaluationsQueueController>();

        }

        [Authorize(Roles = "BUYER")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {

            logger.LogInformation(GetType().Name + " : Index");

            List<EvaluationQueueDTO> list = new List<EvaluationQueueDTO>();

            bool isExists = true;

            try
            {
                list = await EQService.GetAll(User);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.EvaluationQueue>)
            {
                isExists = false;
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }

            ViewBag.flag = isExists;

            return View(list);

        }

        [Authorize(Roles = "BUYER")]
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {

            logger.LogInformation(GetType().Name + " : Details");

            await Inicialize();

            try
            {
                EvaluationQueueDTO dto = await EQService.GetById(User, id);

                return View(dto);

            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.EvaluationQueue> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }

        }

        private async Task<bool> Inicialize()
        {

            logger.LogInformation(GetType().Name + " : Inicializate");

            bool isSuccess = true;

            if (User != null)
            {

                logger.LogInformation(GetType().Name + " : user is authorized");

                string uid = User.FindFirstValue(ClaimTypes.NameIdentifier);

                try
                {

                    int pCount = await BService.GetCountOfProductsInBasket(User);

                    ViewData["CountProductsInBasket"] = pCount;

                    if (User.IsInRole("ADMIN"))
                    {
                        ViewData["rAdmin"] = true;
                    }

                    if (User.IsInRole("SELLER"))
                    {
                        ViewData["rSeller"] = true;
                    }

                    if (User.IsInRole("OWNER"))
                    {
                        ViewData["rOwner"] = true;
                    }

                    if (User.IsInRole("BUYER"))
                    {
                        ViewData["rBuyer"] = true;
                    }

                }
                catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
                {
                    HttpExceptionHandler(ex.ClassName, ex.Message, ex.Code);
                }
                catch (onlineshop.Models.HttpException<onlineshop.Models.Basket> ex)
                {
                    HttpExceptionHandler(ex.ClassName, ex.Message, ex.Code);
                }

                void HttpExceptionHandler(string className, string message, HttpStatusCode code)
                {
                    string outmsg = "class: " + className + "error : " + code + ", message " + message;
                    logger.LogError(GetType().Name + " : " + message);
                    isSuccess = false;
                }


            }
            else
            {

                logger.LogInformation(GetType().Name + " : user is not authorized");

            }

            return isSuccess;

        }

        private IActionResult ExceptionHandler(string message, HttpStatusCode code)
        {

            logger.LogInformation(GetType().Name + " : ExceptionHandler");

            message = "error : " + message + ", message " + message;
            logger.LogError(GetType().Name + " : " + message);
            ViewBag.error = code.ToString();
            return View("~/Views/Home/Error.cshtml");

        }

    }
}
