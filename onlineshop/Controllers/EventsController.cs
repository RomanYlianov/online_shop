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
    [Route("events")]
    public class EventsController : Controller
    {
        private readonly IEventService EService;

        private readonly IProductService PService;

        private readonly IBasketService BService;

        private readonly ILogger logger;

        public EventsController(IEventService service, IBasketService bService, IProductService pService)
        {
            this.EService = service;
            this.BService = bService;
            this.PService = pService;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<EventsController>();
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            logger.LogInformation(GetType().Name + " : Index");

            await Inicialize();

            List<EventDTO> list = new List<EventDTO>();

            bool isExists = true;

            try
            {
                list = await EService.GetAll();
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Event>)
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
                EventDTO dto = await EService.GetById(id);

                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Event> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "SELLER, OWNER")]
        [HttpGet("Create/{id}")]
        public async Task<IActionResult> Create(string id)
        {
            logger.LogInformation(GetType().Name + " : Create (GET)");

            await Inicialize();

            try
            {
                ProductDTO dto = await PService.GetById(id);

                if (dto != null)
                {
                    EventDTO eventDTO = new EventDTO();
                    eventDTO.ProductDTO = dto;
                    eventDTO.ProductDTOId = dto.Id;
                    return View(eventDTO);
                }
                else
                {
                    string message = $"product with id {id} was not foud";
                    return ExceptionHandler(message, HttpStatusCode.NotFound);
                }
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Product> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Event> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "SELLER, OWNER")]
        [HttpPost("Create/{id}")]
        public async Task<IActionResult> Create(string id, EventDTO dto)
        {
            logger.LogInformation(GetType().Name + " : Create (POST)");

            await Inicialize();

            if (ModelState.IsValid)
            {
                await EService.Add(dto);

                return RedirectToAction("Index");
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
                EventDTO dto = await EService.GetById(id);

                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Event> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "SELLER, OWNER")]
        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(string id, EventDTO dto)
        {
            logger.LogInformation(GetType().Name + " : Edit (POST)");

            await Inicialize();

            try
            {
                await EService.Update(dto);
                return RedirectToAction("Index");
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Event> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
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
                EventDTO dto = await EService.GetById(id);
                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Event> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "SELLER, OWNER")]
        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete(string id, EventDTO dto)
        {
            logger.LogInformation(GetType().Name + " : Delete (POST)");

            try
            {
                await EService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Event> ex)
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