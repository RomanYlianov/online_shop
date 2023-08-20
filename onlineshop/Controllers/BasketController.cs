using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using onlineshop.Services;
using onlineshop.Services.DTO;
using onlineshop.Services.Mapper;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;

namespace onlineshop.Controllers
{
    [Route("basket")]
    public class BasketController : Controller
    {

        private readonly IBasketService BService;

        private readonly IOrderService OService;

        private readonly ILogger logger;

        public BasketController(IBasketService bService, IOrderService oService)
        {
            this.BService = bService;
            this.OService = oService;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<BasketController>();
        }

        [Authorize(Roles = "BUYER")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {

            logger.LogInformation(GetType().Name + " : Index");

            await Inicialize();

            bool isAvaliableExists = true;
            bool isNotAvaliableExists = true;

            Tuple<BasketDTO, List<BasketDTO>, List<BasketDTO>> tuple = new Tuple<BasketDTO, List<BasketDTO>, List<BasketDTO>>(new BasketDTO(), new List<BasketDTO>(), new List<BasketDTO>());

            try
            {
                tuple = await BService.GetAll(User);
                isAvaliableExists = tuple.Item2.Count > 0;
                isNotAvaliableExists = tuple.Item3.Count > 0;
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Basket>)
            {
                isAvaliableExists = isNotAvaliableExists = false;
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {  
                return ExceptionHandler(ex.Message, ex.Code);
            }
            ViewBag.flag1 = isAvaliableExists;
            ViewBag.flag2 = isNotAvaliableExists;
            return View(tuple);

        }

        [Authorize(Roles = "BUYER")]
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {

            logger.LogInformation(GetType().Name + " : Details");

            await Inicialize();

            try
            {
                BasketDTO dto = await BService.GetById(User, id);

                return View(dto);

            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Basket> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
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
                BasketDTO dto = await BService.GetById(User, id);

                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Basket> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }

           
        }

        [Authorize(Roles = "BUYER")]
        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(string id, BasketDTO dto)
        {

            logger.LogInformation(GetType().Name + " : edit (POST)");

            await Inicialize();

            bool isValid = await ValidateItem(dto);

            if (isValid)
            {
                try
                {

                    ModelState.Clear();

                    dto = await BService.Update(User, dto);

                    return RedirectToAction("Index");
                }
                catch (onlineshop.Models.HttpException<onlineshop.Models.Basket> ex)
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

        [Authorize(Roles = "BUYER")]
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {

            logger.LogInformation(GetType().Name + " : Delete (GET)");

            await Inicialize();

            try
            {
                BasketDTO dto = await BService.GetById(User, id);

                return View(dto);

            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Basket> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }

            
        }

        [Authorize(Roles = "BUYER")]
        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete(string id, BasketDTO dto)
        {

            logger.LogInformation(GetType().Name + " : Delete(POST)");

            try
            {
                await BService.Delete(User, id);

                return RedirectToAction("Index");

            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Basket> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }

          

        }

        [Authorize(Roles = "BUYER")]
        [HttpGet("Checkout")]
        public async Task<IActionResult> Checkout()
        {

            logger.LogInformation(GetType().Name + " : Chechout (GET)");

            await Inicialize();

            List<BasketDTO> list = new List<BasketDTO>();

            bool isExists = true;

            try
            {

                list = await BService.GetAvaliableProducts(User);

            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Basket>)
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
        [HttpPost("Checkout")]
        public async Task<IActionResult> Checkout(List<BasketDTO> list)
        {

            logger.LogInformation(GetType().Name + " : Checkout (POST)");

            await Inicialize();

            ViewBag.flag = list != null ? true : false;

            try
            {
                

                await ValidateItem(list);                


                int t = 0;

                List<string> basketIds = new List<string>();

                List<int> productCounts = new List<int>();

                foreach (var item in list)
                {
                    productCounts.Add(item.Count);
                    basketIds.Add(item.Id);
                }



                string par1 = SerializeList<string>(basketIds);

                string par2 = SerializeList<int>(productCounts);

                TempData.Clear();
                TempData.Add("arg0", par1);
                TempData.Add("arg1", par2);
               
                return RedirectToAction("Create", "Orders");

            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Basket> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
            catch (onlineshop.Models.HttpException<BasketDTO> ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(list);

            }

        }

        private string SerializeList<T>(List<T> list, char divider = '$')
        {

            logger.LogInformation(GetType().Name + " : SerializeListOfString");

            string result = "";

            if (list != null)
            {
                foreach (T arg in list)
                {
                    result += arg.ToString() + divider;
                }

                if (!string.IsNullOrEmpty(result))
                {
                    result = result.Substring(0, result.Length - 1);
                }
            }
            else
            {
                logger.LogWarning(GetType().Name + " : list parameter is mandatory");
            }

            return result;

        }

       

        private async Task<bool> ValidateItem(List<BasketDTO> list)
        {

            logger.LogInformation(GetType().Name + ": validateItem");

            bool flag = true;

            if (list != null)
            {
                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        if (item.Count <= 0)
                        {
                            flag = false;
                            string message = "count of products must be positive";
                            logger.LogInformation(GetType().Name + " : " + message);
                            throw new onlineshop.Models.HttpException<BasketDTO>("ValidateItem", message, HttpStatusCode.BadRequest);
                        }

                        BasketDTO dto = await BService.GetById(User, item.Id);

                        if (dto.Count < item.Count)
                        {
                            flag = false;
                            string message = "the number of products must be less than or equal to " + dto.Count;
                            logger.LogError(GetType().Name + " : " + message);
                            throw new onlineshop.Models.HttpException<BasketDTO>("ValidateItem", message, HttpStatusCode.BadRequest);
                        }

                        if (!flag)
                            break;

                    }
                }
                else
                {
                    flag = false;
                }
            }
            else
            {
                flag = false;
            }

            return flag;

        }


        private List<SelectListItem> FormListOfProducts(List<BasketDTO> products)
        {

            logger.LogInformation(GetType().Name + " : FormListOfProducts");

            List<SelectListItem> result = new List<SelectListItem>();

            if (products != null)
            {
                if (products.Count > 0)
                {
                    foreach (var item in products)
                    {
                        string text = item.ProductDTO.Name + " (" + item.Count + "), cost = " + item.IntermediateCost;
                        result.Add(new SelectListItem(text: text, value: item.Id, selected: false));
                    }
                }
            }

            return result;

        }

       
        private async Task<bool> ValidateItem(BasketDTO dto)
        {

            logger.LogInformation(GetType().Name + " : ValidateItem");

            bool isValid = true;

            try
            {
                BasketDTO basketDTO = await BService.GetById(User, dto.Id);

                if (basketDTO != null)
                {
                    isValid = dto.Count >= 0;

                    if (isValid)
                    {
                        isValid = basketDTO.ProductDTO.CountThis >= dto.Count;
                        if (!isValid)
                        {
                            ModelState.AddModelError("Count", $"Count must be between 0 and {basketDTO.ProductDTO.CountThis}");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Count", "Count must be positive or zero");
                    }
                }

            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Basket>)
            {
                isValid = false;
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User>)
            {
                isValid = false;
            }

            return isValid;
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
