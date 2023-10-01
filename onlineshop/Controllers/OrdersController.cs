using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using onlineshop.Models;
using onlineshop.Services;
using onlineshop.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace onlineshop.Controllers
{
    [Route("orders")]
    public class OrdersController : Controller
    {
        private readonly IOrderService OService;

        private readonly IBasketService BService;

        private readonly IDeliveryMethodService DMSercice;

        private readonly IPaymentMethodService PMService;

        private readonly ISupplerFirmService SFService;

        private readonly ILogger logger;

        private static List<string> basketIds = new List<string>();

        private static List<int> productCounts = new List<int>();

        public OrdersController(IOrderService oService, IBasketService bService, IDeliveryMethodService dMService, IPaymentMethodService pMService, ISupplerFirmService sfService)
        {
            this.OService = oService;
            this.BService = bService;

            this.DMSercice = dMService;
            this.PMService = pMService;
            this.SFService = sfService;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<OrdersController>();
        }

      
        [Authorize(Roles = "SELLER, OWNER")]
        [HttpGet("AllOrders")]
        public async Task<IActionResult> AllOrders(
            string cipher, string email, string method,
            PaymentType? type, OrderStatus? status,
            DateTime? creationTimeStart, DateTime? creationTimeEnd)
        {
            logger.LogInformation(GetType().Name + " : AllOrders");

            await Inicialize();

            List<OrderDTO> list = new List<OrderDTO>();

            OrderSearchDTO dto = FormOrderSearchDTO(cipher, email, method, type, status, creationTimeStart, creationTimeEnd);

            bool isExists = true;

            try
            {
                if (dto != null)
                {
                    list = await OService.Search(User, dto);
                }
                else
                {
                    list = await OService.GetAll(User);
                }
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Order>)
            {
                isExists = false;
            }

            List<SelectListItem> deliveryMethods = await InitSelectListOfDeliveryMethods();
            ViewBag.DeliveryMethods = new SelectList(deliveryMethods, "Value", "Text");

            ViewBag.flag = isExists;

            return View(list);
        }

        [Authorize(Roles = "BUYER")]
        [HttpGet("MyOrders")]
        public async Task<IActionResult> MyOrders(
            string cipher, string method, PaymentType? type,
            OrderStatus? status, DateTime? creationTimeStart, DateTime? creationTimeEnd
            )
        {
            logger.LogInformation(GetType().Name + " : MyOrders");

            await Inicialize();

            List<OrderDTO> list = new List<OrderDTO>();

            OrderSearchDTO dto = FormOrderSearchDTO(cipher, null, method, type, status, creationTimeStart, creationTimeEnd);

            bool isExists = true;

            try
            {
                if (dto != null)
                {
                    list = await OService.Search(User, dto);
                }
                else
                {
                    list = await OService.GetOrdersForUser(User);
                }
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Order>)
            {
                isExists = false;
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }

            List<SelectListItem> deliveryMethods = await InitSelectListOfDeliveryMethods();
            ViewBag.DeliveryMethods = new SelectList(deliveryMethods, "Value", "Text");
            ViewBag.flag = isExists;

            return View(list);
        }

        [Authorize(Roles = "BUYER")]
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            logger.LogInformation(GetType().Name + " : Details");

            try
            {
                OrderDTO dto = await OService.GetById(User, id);

                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Order> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "BUYER")]
        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            logger.LogInformation(GetType().Name + " : Create (GET)");

            await Inicialize();

            List<string> basketIds = new List<string>();

            List<int> productCounts = new List<int>();

            string val1 = string.Empty;

            string val2 = string.Empty;

            if (TempData.ContainsKey("arg0"))
            {
                val1 = TempData["arg0"].ToString();
                basketIds = DeserializeToListOfString(val1);
            }

            if (TempData.ContainsKey("arg1"))
            {
                val2 = TempData["arg1"].ToString();
                productCounts = DeserializeTolistOfInt(val2);
            }

            TempData.Clear();

            TempData.Add("arg0", val1);
            TempData.Add("arg1", val2);

            OrderDTO dto = new OrderDTO();

            try
            {
                dto = await OService.InicializeOrder(User, basketIds, productCounts);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Order> ex)
            {
                if (ex.Code == HttpStatusCode.BadRequest)
                {
                    ModelState.AddModelError("", ex.Message);
                }
                else
                {
                    return ExceptionHandler(ex.Message, ex.Code);
                }
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Basket> ex)
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

            List<SelectListItem> deliveryMethods = await InitSelectListOfDeliveryMethods();

            List<SelectListItem> paymentMethods = await InitListOfPaymentMethods();

            ViewBag.DeliveryMethods = new SelectList(deliveryMethods, "Value", "Text");
            ViewBag.PaymentMethods = new SelectList(paymentMethods, "Value", "Text");

            return View("Create", dto);
        }

        [Authorize(Roles = "BUYER")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(OrderDTO dto)
        {
            //get request call in basket/checkout
            logger.LogInformation(GetType().Name + " : Create (POST");

            await Inicialize();

            //get values

            //List<string> basketIds = new List<string>();

            //List<int> productCounts = new List<int>();

            if (TempData.ContainsKey("arg0"))
            {
                string value = TempData["arg0"].ToString();
                basketIds = DeserializeToListOfString(value);
            }

            if (TempData.ContainsKey("arg1"))
            {
                string value = TempData["arg1"].ToString();
                productCounts = DeserializeTolistOfInt(value);
            }

            TempData.Clear();

            List<SelectListItem> deliveryMethods = await InitSelectListOfDeliveryMethods();

            List<SelectListItem> paymentMethods = await InitListOfPaymentMethods();

            ViewBag.deliveryMethods = new SelectList(deliveryMethods, "Value", "Text");
            ViewBag.paymentMethods = new SelectList(paymentMethods, "Value", "Text");


            if (ModelState.IsValid)
            {
                try
                {
                    //уменьшить количество денег на счете покупателя

                    PaymentResult result = await PMService.ChangeBalance(User, dto.PaymentMethodDTOId, dto.Price, false);

                    if (result == PaymentResult.OKAY)
                    {
                        ModelState.Clear();

                        

                        dto = await OService.Add(User, dto, basketIds, productCounts);

                        basketIds = new List<string>();
                        productCounts = new List<int>();

                        return RedirectToAction("MyOrders");
                    }
                    else
                    {
                        if (result == PaymentResult.INSUFFICIENT_MONEY)
                        {
                            return ExceptionHandler("insufficient of money", HttpStatusCode.Forbidden);
                            
                        }
                        else
                        {
                            return ExceptionHandler("date of payment method was expiried", HttpStatusCode.Forbidden);
                          
                        }

                       
                    }

                }
                catch (onlineshop.Models.HttpException<onlineshop.Models.Order> ex)
                {
                    if (ex.Code == HttpStatusCode.Forbidden)
                    {
                        ModelState.AddModelError("", ex.Message);
                        return View();
                    }
                    else
                    {
                        return ExceptionHandler(ex.Message, ex.Code);
                    }
                }
                catch (onlineshop.Models.HttpException<onlineshop.Models.Basket> ex)
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
            }
            else
            {
                return View(dto);
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
                OrderDTO dto = await OService.GetById(User, id);

                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Order> ex)
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
        public async Task<IActionResult> Edit(string id, OrderDTO dto)
        {
            logger.LogInformation(GetType().Name + " : Edit (POST)");

            await Inicialize();

            OrderDTO oViewDTO = await OService.GetById(User, id);

            try
            {
                if (ValidateOrder(dto))
                {
                    await OService.Update(User, dto);

                    return RedirectToAction("MyOrders");
                }
                else
                {
                    return View(oViewDTO);
                }
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Order> ex)
            {
                if (ex.Code == HttpStatusCode.Forbidden)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(oViewDTO);
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

        [Authorize(Roles = "SELLER, OWNER")]
        [HttpGet("RootEdit/{id}")]
        public async Task<IActionResult> RootEdit(string id)
        {
            logger.LogInformation(GetType().Name + " : RootEdit (GET)");

            await Inicialize();

            try
            {
                OrderDTO dto = await OService.GetById(User, id);

                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Order> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "SELLER, OWNER")]
        [HttpPost("RootEdit/{id}")]
        public async Task<IActionResult> RootEdit(string id, OrderDTO dto)
        {
            logger.LogInformation(GetType().Name + " : RootEdit (POST)");

            await Inicialize();

            OrderDTO oViewDTO = await OService.GetById(User, id);

            try
            {
                if (ValidateOrder(dto, true))
                {
                    await OService.Update(User, dto, true);

                    return RedirectToAction("AllOrders");
                }
                else
                {
                    return View(oViewDTO);
                }
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Order> ex)
            {
                if (ex.Code == HttpStatusCode.Forbidden)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(oViewDTO);
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
        [HttpGet("Return/{id}")]
        public async Task<IActionResult> Return(string id)
        {
            logger.LogInformation(GetType().Name + " : Return (GET)");

            await Inicialize();

            try
            {
                List<ProductDTO> list = await OService.GetProductsFromOrder(User, id);

                List<SelectListItem> paymentMethods = await InitListOfPaymentMethods();

                ViewBag.paymentMethods = new SelectList(paymentMethods, "Value", "Text");

                return View(list);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Order> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "BUYER")]
        [HttpPost("Return/{id}")]
        public async Task<IActionResult> Return(string id, string method, List<ProductDTO> list)
        {
            logger.LogInformation(GetType().Name + " : Return (POST)");


            List<SelectListItem> paymentMethods = await InitListOfPaymentMethods();

            ViewBag.paymentMethods = new SelectList(paymentMethods, "Value", "Text");

            if (method == null)
            {
                ModelState.AddModelError("", "please select payment method");
                return View(list);
            }
            else
            {
                try
                {
                    await OService.Delete(User, id, method, list);

                    return RedirectToAction("MyOrders");
                }
                catch (onlineshop.Models.HttpException<onlineshop.Models.Order> ex)
                {
                    if (ex.Code == HttpStatusCode.InternalServerError)
                    {
                        ModelState.AddModelError("", ex.Message);
                        return View(list);
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

           
        }

        private async Task<List<SelectListItem>> InitSelectListOfDeliveryMethods(string selected = null)
        {
            logger.LogInformation(GetType().Name + " : InitSelectListOfDeliveryMethods");

            List<DeliveryMethodDTO> DTOs = await DMSercice.GetAll();

            List<SelectListItem> items = new List<SelectListItem>();

            if (selected != null)
            {
                foreach (var item in DTOs)
                {
                    if (item.Id.Equals(selected))
                    {
                        items.Add(new SelectListItem(text: item.Name, value: item.Id, selected: true));
                    }
                    else
                    {
                        items.Add(new SelectListItem(text: item.Name, value: item.Id));
                    }
                }
            }
            else
            {
                foreach (var item in DTOs)
                {
                    items.Add(new SelectListItem(text: item.Name, value: item.Id));
                }
            }

            return items;
        }

        private async Task<List<SelectListItem>> InitListOfPaymentMethods(string selected = null)
        {
            logger.LogInformation(GetType().Name + " : InitListOfPaymentMethods");

            List<PaymentMethodDTO> DTOs = await PMService.GetAll(User);

            List<SelectListItem> items = new List<SelectListItem>();

            if (selected != null)
            {
                foreach (var item in DTOs)
                {
                    if (item.Id.Equals(selected))
                    {
                        items.Add(new SelectListItem(text: item.Name, value: item.Id, selected: true));
                    }
                    else
                    {
                        items.Add(new SelectListItem(text: item.Name, value: item.Id));
                    }
                }
            }
            else
            {
                foreach (var item in DTOs)
                {
                    items.Add(new SelectListItem(text: item.Name, value: item.Id));
                }
            }

            return items;
        }

        private bool ValidateOrder(OrderDTO order, bool isRoot = false)
        {
            logger.LogInformation(GetType().Name + " : validateOrderMark");

            bool flag = false;

            if (order != null)
            {
                string uid = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (isRoot)
                {
                    if (User.IsInRole("OWNER") || User.IsInRole("SELLER"))
                    {
                        flag = order.OrderStatus.HasValue;
                    }
                }
                else
                {
                    flag = order.Mark > 0 && order.Mark <= 10;
                }
            }

            return flag;
        }

        private List<int> DeserializeTolistOfInt(string value, char divider = '$')
        {
            logger.LogInformation(GetType().Name + " : DeserializeToListOfInt");

            List<int> list = new List<int>();

            if (value != null)
            {
                string[] args = value.Split(divider);

                foreach (string arg in args)
                {
                    try
                    {
                        int temp = int.Parse(arg);
                        list.Add(temp);
                    }
                    catch (FormatException)
                    {
                        logger.LogWarning(GetType().Name + " : convert string to int failed");
                    }
                }
            }
            else
            {
                logger.LogWarning(GetType().Name + " : value parameter is mandatory");
            }

            return list;
        }

        private List<string> DeserializeToListOfString(string value, char divider = '$')
        {
            logger.LogInformation(GetType().Name + " : DeserializeToListOfString");

            List<string> list = new List<string>();

            if (value != null)
            {
                list = value.Split(divider).ToList();
            }
            else
            {
                logger.LogWarning(GetType().Name + " : value parameter is mandatory");
            }

            return list;
        }

        private OrderSearchDTO FormOrderSearchDTO(
            string cipher, string email, string deliveyMethod,
            PaymentType? type, OrderStatus? status,
            DateTime? creationTimeStart, DateTime? creationTimeEnd)
        {
            logger.LogInformation(GetType().Name + " : FormOrderSearchDTO");

            OrderSearchDTO dto = null;

            bool isInit = false;

            if (!string.IsNullOrEmpty(cipher))
            {
                dto = new OrderSearchDTO();
                isInit = true;
                dto.Cipher = cipher;
            }

            if (!string.IsNullOrEmpty(email))
            {
                if (!isInit)
                {
                    dto = new OrderSearchDTO();
                    isInit = true;
                }
                dto.BuyerEmail = email;
            }

            if (!string.IsNullOrEmpty(deliveyMethod))
            {
                if (!isInit)
                {
                    dto = new OrderSearchDTO();
                    isInit = true;
                }
                dto.DeliveryMethodId = deliveyMethod;
            }

            if (type != null)
            {
                if (!isInit)
                {
                    dto = new OrderSearchDTO();
                    isInit = true;
                }
                dto.PaymentType = type.Value;
            }

            if (status != null)
            {
                if (!isInit)
                {
                    dto = new OrderSearchDTO();
                    isInit = true;
                }
                dto.OrderStatus = status.Value;
            }

            if (creationTimeStart != null)
            {
                if (!isInit)
                {
                    dto = new OrderSearchDTO();
                    isInit = true;
                }
                dto.CreationTimeStart = creationTimeStart.Value;
            }

            if (creationTimeEnd != null)
            {
                if (!isInit)
                {
                    dto = new OrderSearchDTO();
                    isInit = true;
                }
                dto.CreationTimeEnd = creationTimeEnd.Value;
            }

            return dto;
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