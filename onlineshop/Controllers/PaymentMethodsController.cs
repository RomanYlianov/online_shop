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
    [Route("paymentmethods")]
    public class PaymentMethodsController : Controller
    {
        private readonly IPaymentMethodService PMService;

        private readonly IBasketService BService;

        private readonly ILogger logger;

        public PaymentMethodsController(IPaymentMethodService service, IBasketService bService)
        {
            this.PMService = service;
            BService = bService;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<PaymentMethodsController>();
        }

        [HttpGet("Index")]
        [Authorize(Roles = "BUYER, SELLER, ADMIN, OWNER")]
        public async Task<IActionResult> Index()
        {
            logger.LogInformation(GetType().Name + " : Index");

            await Inicialize();

            List<PaymentMethodDTO> list = new List<PaymentMethodDTO>();

            bool isExists = true;

            try
            {
                list = await PMService.GetAll(User);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.PaymentMethod>)
            {
                isExists = false;
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                string message = "error : " + ex.Code.ToString() + ", message " + ex.Message;
                ViewBag.error = message;
                return RedirectToAction("Error", "Home");
            }

            ViewBag.flag = isExists;

            return View(list);
        }

        [Authorize(Roles = "BUYER, SELLER, ADMIN, OWNER")]
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            logger.LogInformation(GetType().Name + " : Details");

            await Inicialize();

            try
            {
                PaymentMethodDTO dto = await PMService.GetById(User, id);

                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.PaymentMethod> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        
        [Authorize(Roles = "BUYER, SELLER, ADMIN, OWNER")]
        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            logger.LogInformation(GetType().Name + " : Create (GET)");

            await Inicialize();

            return View();
        }

        [Authorize(Roles = "BUYER, SELLER, ADMIN, OWNER")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(PaymentMethodDTO dto)
        {
            logger.LogInformation(GetType().Name + " : Create (POST)");

            await Inicialize();

            bool flag = ValidateData(dto);

            if (ModelState.IsValid && flag)
            {
                try
                {
                    dto = await PMService.Add(User, dto);

                    ModelState.Clear();

                    return RedirectToAction("Index");
                }
                catch (onlineshop.Models.HttpException<onlineshop.Models.PaymentMethod> ex)
                {
                    return ExceptionHandler(ex.Message, ex.Code);
                }
                catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
                {
                    return ExceptionHandler(ex.Message, ex.Code);
                }
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles = "BUYER, SELLER, ADMIN, OWNER")]
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            logger.LogInformation(GetType().Name + " : Edit (GET)");

            await Inicialize();

            try
            {
                PaymentMethodDTO dto = await PMService.GetById(User, id);

                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.PaymentMethod> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "BUYER, SELLER, ADMIN, OWNER")]
        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(string id, PaymentMethodDTO dto)
        {
            logger.LogInformation(GetType().Name + " : Edit (POST)");

            await Inicialize();

            bool flag = ValidateData(dto, false);

            if (ModelState.IsValid && flag)
            {
                ModelState.Clear();

                try
                {
                    dto = await PMService.Update(User, dto);

                    return RedirectToAction("Index");
                }
                catch (onlineshop.Models.HttpException<onlineshop.Models.PaymentMethod> ex)
                {
                    return ExceptionHandler(ex.Message, ex.Code);
                }
                catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
                {
                    return ExceptionHandler(ex.Message, ex.Code);
                }
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles = "BUYER, SELLER, ADMIN, OWNER")]
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            logger.LogInformation(GetType().Name + " : Delete (GET)");

            await Inicialize();

            try
            {
                PaymentMethodDTO dto = await PMService.GetById(User, id);

                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.PaymentMethod> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "BUYER, SELLER, ADMIN, OWNER")]
        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete(string id, PaymentMethodDTO dto)
        {
            logger.LogInformation(GetType().Name + " : Delete (POST)");

            try
            {
                await PMService.Delete(User, id);

                return RedirectToAction("Index");
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.PaymentMethod> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        private bool ValidateData(PaymentMethodDTO dto, bool iSAddAction = true)
        {
            logger.LogInformation(GetType().Name + " : validation");

            bool flag = true;

            if (dto.PaymentType != null)
            {
                if (dto.PaymentType == onlineshop.Models.PaymentType.BANK_CARD)
                {
                    if (dto.ExpirationDate == null)
                    {
                        ModelState.AddModelError("ExpirationDate", "ExpirationDate is required");
                        flag = false;
                    }

                    if (dto.CVV == null)
                    {
                        ModelState.AddModelError("CVV", "CVV is required");
                        flag = false;
                    }

                    if (iSAddAction)
                    {
                        if (dto.MoneyValue < 0)
                        {
                            ModelState.AddModelError("MoneyValue", "balance must be positive or zero");
                            flag = false;
                        }
                    }

                   
                }
            }

            logger.LogInformation(GetType().Name + " : validation result is " + flag);
            return flag;
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