using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using onlineshop.Services;
using onlineshop.Services.DTO;
using onlineshop.Services.Implimentation;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace onlineshop.Controllers
{
    [Route("deliverymethods")]
    public class DeliveryMethodsController : Controller
    {

        private readonly IDeliveryMethodService DMService;

        private readonly IBasketService BService;

        private readonly ILogger logger;

        public DeliveryMethodsController(IDeliveryMethodService dmService, IBasketService bService)
        {

            this.DMService = dmService;
            this.BService = bService;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<DeliveryMethodsController>();
            
            
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
           
            logger.LogInformation(GetType().Name + " : Index");

            await Inicialize();

            List<DeliveryMethodDTO> list = new List<DeliveryMethodDTO>();
            
            bool isExists = true;

            try
            {
                list = await DMService.GetAll();
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.DeliveryMethod>)
            {
                isExists = false;
            }

            ViewBag.flag = isExists;

            return View(list);
        }


        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            
            logger.LogInformation(GetType().Name + " : Details");

            await Inicialize();

            try
            {
                DeliveryMethodDTO dto = await DMService.GetById(id);

                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.DeliveryMethod> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "SELLER, OWNER")]
        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            
            logger.LogInformation(GetType().Name + " : Create (GET)");

            await Inicialize();

            return View();
        }

        [Authorize(Roles = "SELLER, OWNER")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(DeliveryMethodDTO dto)
        {
           
            logger.LogInformation(GetType().Name + " : Create (POST)");

            await Inicialize();

            if (ModelState.IsValid)
            {
                try
                {
                                
                    dto = await DMService.Add(dto);

                    ModelState.Clear();

                    return RedirectToAction("Index");
                }
                catch (onlineshop.Models.HttpException<onlineshop.Models.DeliveryMethod> ex)
                {
                    return ExceptionHandler(ex.Message, ex.Code);
                }
            }
            else
            {
                return View();
            }
           
        }

        [Authorize(Roles = "SELLER, OWNER")]
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            
            logger.LogInformation(GetType().Name + " : Edit (GET)");

            await Inicialize();

            try
            {
                DeliveryMethodDTO dto = await DMService.GetById(id);
                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.DeliveryMethod> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "SELLER, OWNER")]
        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(string id, DeliveryMethodDTO dto)
        {
            
            logger.LogInformation(GetType().Name + " : Edit (POST)");

            await Inicialize();

            if (ModelState.IsValid)
            {
                ModelState.Clear();
                try
                {
                    dto = await DMService.Update(dto);
                    return RedirectToAction("Index");
                }
                catch (onlineshop.Models.HttpException<onlineshop.Models.DeliveryMethod> ex)
                {
                    return ExceptionHandler(ex.Message, ex.Code);
                }
            }
            else
            {
                return View();
            }
           
        }

        [Authorize(Roles = "SELLER, OWNER")]
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
           
            logger.LogInformation(GetType().Name + " : Delete (GET)");

            await Inicialize();

            try
            {
                DeliveryMethodDTO dto = await DMService.GetById(id);
                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.DeliveryMethod> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "SELLER, OWNER")]
        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete(string id, DeliveryMethodDTO dto)
        {
             
            logger.LogInformation(GetType().Name + " : Delete (POST)");

            try
            {
                await DMService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.DeliveryMethod> ex)
            {
                return ExceptionHandler(ex.MethodName, ex.Code);
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
