using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using onlineshop.Services.DTO;
using onlineshop.Services;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authorization;

namespace onlineshop.Controllers
{
    [Route("comments")]
    public class CommentsController : Controller
    {
        private readonly ICommentService CService;

        private readonly IBasketService BService;

        private readonly ILogger logger;

        private static string productId = "";

        public CommentsController(ICommentService cService, IBasketService bService)
        {

            this.CService = cService;
            this.BService = bService;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<CommentsController>();

        }

        [HttpGet("Index/{pid}")]
        public async Task<IActionResult> Index(string pid)
        {

            logger.LogInformation(GetType().Name + " : Index");

            await Inicialize();

            productId = pid;

            List<CommentDTO> list = new List<CommentDTO>();

            bool isExists = true;

            try
            {
                list = await CService.GetAll(pid);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Comment>)
            {
                isExists = false;
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Product> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
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
                CommentDTO dto = await CService.GetById(id);

                ViewBag.rootId = productId;

                return View(dto);

            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Comment> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "BUYER")]
        [HttpGet("Create/{eqId}")]
        public async Task<IActionResult> Create(string eqId)
        {

            logger.LogInformation(GetType().Name + " : Create (GET)");

            await Inicialize();

            try
            {
                ModelState.Clear();
                CommentDTO dto = await CService.Inicialize(User, eqId);

                return View(dto);

            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Comment> ex)
            {

                return ExceptionHandler(ex.Message, ex.Code);
               
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Product> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.EvaluationQueue> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }

        }

        [Authorize(Roles = "BUYER")]
        [HttpPost("Create/{eqId}")]
        public async Task<IActionResult> Create(string eqId, CommentDTO dto)
        {

            logger.LogInformation(GetType().Name + " : Craeate (POST)");

            await Inicialize();

            try
            {
                if (ModelState.IsValid)
                {

                    await CService.Add(User, eqId, dto);

                    return RedirectToAction("Index", new { pid = dto.ProductDTOId });

                }
                else
                {
                    return View();
                }
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Comment> ex)
            {

                if (ex.Code == HttpStatusCode.Forbidden)
                {
                    ModelState.AddModelError("", ex.Message);
                    dto = await CService.Inicialize(User, eqId);
                    return View(dto);
                }
                else
                {
                    return ExceptionHandler(ex.Message, ex.Code);
                }


            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }

        }

        [Authorize(Roles = "BUYER")]
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {

            logger.LogInformation(GetType().Name + " : Edit (GET)");

            await Inicialize();

            try
            {
                CommentDTO dto = await CService.GetById(id);

                return View(dto);

            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Comment> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }

        }

        [Authorize(Roles = "BUYER")]
        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(string id, CommentDTO dto)
        {

            logger.LogInformation(GetType().Name + ": Edit (POST)");

            await Inicialize();

            try
            {

                if (ModelState.IsValid)
                {

                    dto = await CService.Update(User, dto);

                    return RedirectToAction("Index", new { pid = productId });

                }
                else
                {
                    dto = await CService.GetById(id);
                    return View(dto);
                }
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Comment> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }

        }

        [Authorize(Roles = "BUYER")]
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(string pid, string id)
        {

            logger.LogInformation(GetType().Name + " : Delete (GET)");

            await Inicialize();

            try
            {
                CommentDTO dto = await CService.GetById(id);

                return View(dto);

            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Comment> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }

        }

        [Authorize(Roles = "BUYER")]
        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Detele(string pid, string id, CommentDTO dto)
        {

            logger.LogInformation(GetType().Name + " : Delete (POST)");

            await Inicialize();

            try
            {

                await CService.Delete(User, id);



                return RedirectToAction("Index", new {pid = productId} );

            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Comment> ex)
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
