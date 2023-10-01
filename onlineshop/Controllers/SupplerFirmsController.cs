using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using onlineshop.Services;
using onlineshop.Services.DTO;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace onlineshop.Controllers
{
    [Route("supplerfirms")]
    public class SupplerFirmsController : Controller
    {
        private readonly ISupplerFirmService SFService;

        private readonly IBasketService BService;

        private readonly ICountryService CService;

        private readonly ILogger logger;

        public SupplerFirmsController(ISupplerFirmService SFService, ICountryService CService, IBasketService bService)
        {
            this.SFService = SFService;
            this.CService = CService;
            this.BService = bService;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<SupplerFirmsController>();
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            logger.LogInformation(GetType().Name + " : Index");

            await Inicialize();

            List<SupplerFirmDTO> list = new List<SupplerFirmDTO>();

            bool isExists = true;

            try
            {
                list = await SFService.GetAll();
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.SupplerFirm>)
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
                SupplerFirmDTO dto = await SFService.GetById(id);

                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.SupplerFirm> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "OWNER")]
        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            logger.LogInformation(GetType().Name + " : Create (GET)");

            await Inicialize();

            List<SelectListItem> items = InitSelectList();

            ViewBag.Countries = new SelectList(items, "Value", "Text");

            return View();
        }

        [Authorize(Roles = "OWNER")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(SupplerFirmDTO dto)
        {
            logger.LogInformation(GetType().Name + " : Create (POST)");

            await Inicialize();

            List<SelectListItem> items = InitSelectList();

            ViewBag.Countries = new SelectList(items, "Value", "Text");

            dto.MoneyValue = 0;
            dto.Rating = 0;

            // dto.Country = dto.Item.Text;

            if (ModelState.IsValid)
            {
                if (Validate(dto))
                {
                    ModelState.Clear();

                    try
                    {
                        dto = await SFService.Add(dto);

                        return RedirectToAction("Index");
                    }
                    catch (onlineshop.Models.HttpException<onlineshop.Models.SupplerFirm> ex)
                    {
                        return ExceptionHandler(ex.Message, ex.Code);
                    }
                }
                else
                {
                    ModelState.AddModelError("Name", "supplerfirm with name \"root supplerfirm\" not allowed");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles = "OWNER")]
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            logger.LogInformation(GetType().Name + " : Edit (GET)");

            await Inicialize();

            try
            {
                SupplerFirmDTO dto = await SFService.GetById(id);

                List<SelectListItem> items = InitSelectList(dto.Country);

                ViewBag.Countries = new SelectList(items, "Value", "Text");

                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.SupplerFirm> ex)
            {
                
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "OWNER")]
        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(string id, SupplerFirmDTO dto)
        {
            logger.LogInformation(GetType().Name + " : Edit (POST)");

            await Inicialize();

            List<SelectListItem> items = InitSelectList(dto.Country);

            ViewBag.Countries = new SelectList(items, "Value", "Text");

            if (ModelState.IsValid)
            {
                if (Validate(dto))
                {

                    if (dto.MoneyValue < 0)
                    {
                        ModelState.AddModelError("MoneyValue", "balanse must be positive or zero");
                    }

                    ModelState.Clear();

                    try
                    {
                        dto = await SFService.Update(dto);

                        return RedirectToAction("Index");
                    }
                    catch (onlineshop.Models.HttpException<onlineshop.Models.SupplerFirm> ex)
                    {
                        return ExceptionHandler(ex.Message, ex.Code);
                    }
                }
                else
                {
                    ModelState.AddModelError("Name", "supplerfirm with name \"root supplerfirm\" not allowed");
                    return View(dto);
                }
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles = "OWNER")]
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            logger.LogInformation(GetType().Name + " : Delete (GET)");

            await Inicialize();

            try
            {
                SupplerFirmDTO dto = await SFService.GetById(id);

                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.SupplerFirm> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "OWNER")]
        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete(string id, SupplerFirmDTO dto)
        {
            logger.LogInformation(GetType().Name + " : Delete (POST)");

            try
            {
                await SFService.Delete(id);

                return RedirectToAction("Index");
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.SupplerFirm> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        private List<SelectListItem> InitSelectList(string selected = null)
        {
            logger.LogInformation(GetType().Name + " : InitSelectList");

            List<string> countries = CService.GetCountriesList();

            List<SelectListItem> items = new List<SelectListItem>();

            if (selected != null)
            {
                foreach (string item in countries)
                {
                    if (selected.Equals(item))
                    {
                        items.Add(new SelectListItem(text: item, value: item, selected: true));
                    }
                    else
                    {
                        items.Add(new SelectListItem(text: item, value: item));
                    }
                }
            }
            else
            {
                foreach (string item in countries)
                {
                    items.Add(new SelectListItem(text: item, value: item));
                }
            }

            return items;
        }

        private bool Validate(SupplerFirmDTO dto)
        {
            logger.LogInformation(GetType().Name + " : Validate");

            bool flag = !dto.Name.Equals("root supplerfirm");
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