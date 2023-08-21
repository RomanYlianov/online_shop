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
    [Route("Roles")]
    public class RolesController : Controller
    {
        private readonly IRoleService RService;

        private readonly IBasketService BService;

        private readonly ILogger logger;

        public RolesController(IRoleService service, IBasketService bService)
        {
            this.RService = service;
            BService = bService;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<RolesController>();
        }

        [Authorize(Roles = "ADMIN, OWNER")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            logger.LogInformation(GetType().Name + " : Index");

            await Inicialize();

            List<RoleDTO> list = new List<RoleDTO>();

            bool isExists = true;

            try
            {
                list = await RService.GetAll();
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Role>)
            {
                isExists = false;
            }

            ViewBag.flag = isExists;

            return View(list);
        }

        [Authorize(Roles = "ADMIN, OWNER")]
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            logger.LogInformation(GetType().Name + " : Details");

            await Inicialize();

            try
            {
                RoleDTO dto = await RService.GetById(id);
                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Role> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "ADMIN, OWNER")]
        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            logger.LogInformation(GetType().Name + " : Create (GET)");

            await Inicialize();

            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(RoleDTO dto)
        {
            logger.LogInformation(GetType().Name + " : Create (POST)");

            await Inicialize();

            if (ModelState.IsValid)
            {
                try
                {
                    bool flag = await RService.CheckName(dto.Name);

                    if (flag)
                    {
                        ModelState.AddModelError("Name", "name is already used");
                        return View();
                    }
                    else
                    {
                        dto = await RService.Add(dto);

                        ModelState.Clear();

                        return RedirectToAction("Index");
                    }
                }
                catch (onlineshop.Models.HttpException<onlineshop.Models.Role> ex)
                {
                    return ExceptionHandler(ex.Message, ex.Code);
                }
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles = "ADMIN, OWNER")]
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            logger.LogInformation(GetType().Name + " Edit (GET)");

            await Inicialize();

            try
            {
                RoleDTO dto = await RService.GetById(id);

                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Role> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "ADMIN, OWNER")]
        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(string id, RoleDTO dto)
        {
            logger.LogInformation(GetType().Name + " : Edit (POST)");

            await Inicialize();

            if (ModelState.IsValid)
            {
                try
                {
                    bool flag = await RService.CheckName(dto.Name);

                    if (flag)
                    {
                        ModelState.AddModelError("Name", "name is already used");
                        return View();
                    }
                    else
                    {
                        ModelState.Clear();

                        dto = await RService.Update(dto);

                        return RedirectToAction("Index");
                    }
                }
                catch (onlineshop.Models.HttpException<onlineshop.Models.Role> ex)
                {
                    return ExceptionHandler(ex.Message, ex.Code);
                }
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles = "ADMIN, OWNER")]
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            logger.LogInformation(GetType().Name + " : Delete (GET)");

            await Inicialize();

            try
            {
                RoleDTO dto = await RService.GetById(id);

                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Role> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "ADMIN, OWNER")]
        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete(string id, RoleDTO dto)
        {
            logger.LogInformation(GetType().Name + " : Delete (POST)");

            try
            {
                await RService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Role> ex)
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

        //[AcceptVerbs("Get", "Post")]
        //public async Task<IActionResult> CheckName(string name)
        //{
        //    logger.LogInformation(GetType().Name + " : Checkname");

        //    bool flag = false;

        //    try
        //    {
        //        flag = await RService.CheckName(name);

        //        return Json(data: !flag);
        //    }
        //    catch (HttpException<Role> ex)
        //    {
        //        string message = "error : " + ex.Code.ToString() + ", message " + ex.Message;
        //        ViewBag.error = message;
        //        return RedirectToAction("Error", "Home");
        //    }

        //}
    }
}