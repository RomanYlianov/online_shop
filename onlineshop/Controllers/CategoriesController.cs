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
    [Route("categories")]
    public class CategoriesController : Controller
    {

        private readonly ICategoryService CtService;

        private readonly IBasketService BService;

        private readonly ILogger logger;

        public CategoriesController(ICategoryService service, IBasketService bService)
        {

            CtService = service;
            BService = bService;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<CategoriesController>();
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {

            logger.LogInformation(GetType().Name + " : Index");

            await Inicialize();

            List<CategoryDTO> list = new List<CategoryDTO>();

            bool isExists = true;

            try
            {
                 list = await CtService.GetAll();

            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Category>)
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
                CategoryDTO dto = await CtService.GetById(id);
                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Category> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "SELLER, OWNER")]
        [HttpGet("Create")]
        public IActionResult Create()
        {

            logger.LogInformation(GetType().Name + " : Create (GET)");

            return View();
        }

        [Authorize(Roles = "SELLER, OWNER")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CategoryDTO dto)
        {
            
            logger.LogInformation(GetType().Name + " : Create (POST)");

            await Inicialize();

            if (ModelState.IsValid)
            {
                try
                {
                    if (Validate(dto))
                    {

                        ModelState.Clear();

                        dto = await CtService.Add(dto);                        

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("Name", "category with name \"root category\" not allowed");
                        return View();
                    }                 

                }
                catch (onlineshop.Models.HttpException<onlineshop.Models.Category> ex)
                {
                    string message = "error : " + ex.Code.ToString() + ", message " + ex.Message;

                    ViewBag.error = ex.Code;

                    return RedirectToAction("Error", "Home");
                    
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
                CategoryDTO dto = await CtService.GetById(id);

                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Category> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }

        }

        [Authorize(Roles = "SELLER, OWNER")]
        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(string id, CategoryDTO dto)
        {

            logger.LogInformation(GetType().Name + " : Edit(POST)");

            await Inicialize();

            if (ModelState.IsValid)
            {
                try
                {

                    if (Validate(dto))
                    {

                        ModelState.Clear();

                        dto = await CtService.Update(dto);

                        return RedirectToAction("Index");

                    }
                    else
                    {
                        ModelState.AddModelError("Name", "name \"root category\" not allowed");
                        return View();
                    }

                }
                catch (onlineshop.Models.HttpException<onlineshop.Models.Category> ex)
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

                CategoryDTO dto = await CtService.GetById(id);

                return View(dto);

            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Category> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "SELLER, OWNER")]
        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete(string id, CategoryDTO dto)
        {

            logger.LogInformation(GetType().Name + " : Delete (POST)");

            try
            {

                await CtService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Category> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }

        }
        
        private bool Validate(CategoryDTO dto)
        {

            logger.LogInformation(GetType().Name + " : Validate");
            
            bool flag = !dto.Name.Equals("root category");
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
