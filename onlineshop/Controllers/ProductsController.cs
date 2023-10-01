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
    [Route("products")]
    public class ProductsController : Controller
    {
        private readonly IProductService PService;

        private readonly IBasketService BService;

        private readonly ICategoryService CService;

        private readonly ISupplerFirmService SFService;

        private readonly ILogger logger;

        public ProductsController(IProductService pService, IBasketService bService, ICategoryService CService, ISupplerFirmService SFService)
        {
            this.PService = pService;
            this.BService = bService;
            this.CService = CService;
            this.SFService = SFService;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<ProductsController>();
        }

        [HttpGet("Index")]
        [Authorize(Roles = "SELLER, OWNER")]
        public async Task<IActionResult> Index(
            string name, string category, string[] supplerFirmIds,
            double? lowestPrice, double? higestPrice,
            double? lowestRating, double? higestRating,
            string isHot
            )
        {
            logger.LogInformation(GetType().Name + " : Index");

            await Inicialize();

            List<ProductDTO> list = new List<ProductDTO>();

            ProductSearchDTO dto = FormProductSearchDTO(name, category, supplerFirmIds, lowestPrice, higestPrice, lowestRating, higestRating, isHot);

            bool isExists = true;

            try
            {
                if (dto != null)
                {
                    list = await PService.Search(dto, true);
                }
                else
                {
                    list = await PService.GetAll();
                }
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Product>)
            {
                isExists = false;
            }

            List<SelectListItem> categories = await InitSelectListOfCategories();

            List<SelectListItem> supplerFirms = await InitSelectListOfSupplerFirms();

            ViewBag.Categories = new SelectList(categories, "Value", "Text");
            ViewBag.SupplerFirms = new MultiSelectList(supplerFirms, "Value", "Text");

            ViewBag.flag = isExists;

            return View(list);
        }

        [HttpGet("Catalog")]
        public async Task<IActionResult> Catalog(
            string name, string category, string[] supplerFirmIds,
            double? lowestPrice, double? higestPrice,
            double? lowestRating, double? higestRating,
            string isHot
            )
        {
            logger.LogInformation(GetType().Name + " : Catalog");

            await Inicialize();

            List<ProductDTO> list = new List<ProductDTO>();

            ProductSearchDTO dto = FormProductSearchDTO(name, category, supplerFirmIds, lowestPrice, higestPrice, lowestRating, higestRating, isHot);

            bool isExists = true;

            try
            {
                if (dto != null)
                {
                    list = await PService.Search(dto);
                }
                else
                {
                    list = await PService.GetProductsInCatalog();
                }
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Product>)
            {
                isExists = false;
            }

            List<SelectListItem> categories = await InitSelectListOfCategories();

            List<SelectListItem> supplerFirms = await InitSelectListOfSupplerFirms();

            ViewBag.Categories = new SelectList(categories, "Value", "Text");
            ViewBag.SupplerFirms = new MultiSelectList(supplerFirms, "Value", "Text");

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
                ProductDTO dto = await PService.GetById(id);
                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Product> ex)
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

            List<SelectListItem> categories = await InitSelectListOfCategories();

            List<SelectListItem> supplerFirms = await InitSelectListOfSupplerFirms();

            ViewBag.Categories = new SelectList(categories, "Value", "Text");
            ViewBag.SupplerFirms = new SelectList(supplerFirms, "Value", "Text");

            return View();
        }

        [Authorize(Roles = "SELLER, OWNER")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(ProductDTO dto)
        {
            logger.LogInformation(GetType().Name + " : Create (POST)");

            await Inicialize();

            List<SelectListItem> categories = await InitSelectListOfCategories();

            List<SelectListItem> supplerFirms = await InitSelectListOfSupplerFirms();

            ViewBag.Categories = new SelectList(categories, "Value", "Text");
            ViewBag.SupplerFirms = new SelectList(supplerFirms, "Value", "Text");

            if (Validate(dto))
            {
                ModelState.Clear();

                try
                {
                    dto = await PService.Add(dto);

                    return RedirectToAction("Index");
                }
                catch (onlineshop.Models.HttpException<onlineshop.Models.Product> ex)
                {
                    return ExceptionHandler(ex.Message, ex.Code);
                }
            }
            else
            {
                ModelState.AddModelError("Name", "name \"removed product\" not allowed");
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
                ProductDTO dto = await PService.GetById(id);

                List<SelectListItem> categories = await InitSelectListOfCategories(dto.CategoryDTO.Name);

                List<SelectListItem> supplerFirms = await InitSelectListOfSupplerFirms(dto.SupplerFirmDTO.Name);

                ViewBag.Categories = new SelectList(categories, "Value", "Text");
                ViewBag.SupplerFirms = new SelectList(supplerFirms, "Value", "Text");

                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Product> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "SELLER, OWNER")]
        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(string id, ProductDTO dto)
        {
            logger.LogInformation(GetType().Name + " : Edit (POST)");

            await Inicialize();

            if (Validate(dto))
            {
                ModelState.Clear();

                try
                {
                    List<SelectListItem> categories = await InitSelectListOfCategories(dto.CategoryDTOId);

                    List<SelectListItem> supplerFirms = await InitSelectListOfSupplerFirms(dto.SupplerFirmDTOId);

                    ViewBag.Categories = new SelectList(categories, "Value", "Text");
                    ViewBag.SupplerFirms = new SelectList(supplerFirms, "Value", "Text");

                    dto = await PService.Update(User, dto);

                    return RedirectToAction("Index");
                }
                catch (onlineshop.Models.HttpException<onlineshop.Models.Product> ex)
                {
                    return ExceptionHandler(ex.Message, ex.Code);
                }
            }
            else
            {
                ModelState.AddModelError("Name", "name \"removed product\" not allowed");
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
                ProductDTO dto = await PService.GetById(id);

                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Product> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "SELLER, OWNER")]
        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete(string id, ProductDTO dto)
        {
            logger.LogInformation(GetType().Name + " : Delete (POST)");

            try
            {
                await PService.Delete(id);

                return RedirectToAction("Index");
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Product> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "BUYER")]
        [HttpGet("RateProduct/{id}")]
        public async Task<IActionResult> RateProduct(string id)
        {
            logger.LogInformation(GetType().Name + " : RateProduct (GET)");

            await Inicialize();

            try
            {
                ProductDTO dto = await PService.LoadProduct(User, id);
                dto.Rating = 0;

                TempData.Clear();

                TempData.Add("productId", dto.Id);
                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Product> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "BUYER")]
        [HttpPost("RateProduct/{id}")]
        public async Task<IActionResult> RateProduct(string id, ProductDTO dto)
        {
            logger.LogInformation(GetType().Name + " : RateProduct (POST)");

            if (ValidateMark(dto))
            {
                try
                {
                    ModelState.Clear();

                    string productId = "";

                    if (TempData.ContainsKey("productId"))
                    {
                        productId = TempData["productId"].ToString();
                    }

                    TempData.Clear();

                    dto.Id = productId;

                    dto = await PService.RateProduct(User, id, dto);

                    return RedirectToAction("Catalog");
                }
                catch (onlineshop.Models.HttpException<onlineshop.Models.Product> ex)
                {
                    return ExceptionHandler(ex.Message, ex.Code);
                }
                catch (onlineshop.Models.HttpException<onlineshop.Models.EvaluationQueue> ex)
                {
                    if (ex.Code == HttpStatusCode.Forbidden)
                    {
                        ModelState.AddModelError("Mark", ex.Message);

                        return View(dto);
                    }
                    else
                    {
                        return ExceptionHandler(ex.Message, ex.Code);
                    }
                }
            }
            else
            {
                return View(dto);
            }
        }

        [Authorize(Roles = "BUYER")]
        [HttpGet("AddProductToBasket/{id}")]
        public async Task<IActionResult> AddProductTobasket(string id)
        {
            logger.LogInformation(GetType().Name + " : AddProductToBasket (GET)");

            try
            {
                ProductDTO dto = await PService.GetById(id);

                BasketDTO Bdto = new BasketDTO();
                Bdto.ProductDTO = dto;

                return View(Bdto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Product> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "BUYER")]
        [HttpPost("AddProductToBasket/{id}")]
        public async Task<IActionResult> AddProductToBasket(string id, BasketDTO dto)
        {
            logger.LogInformation(GetType().Name + " : AddProductTobasket (POST)");

            try
            {
                dto = await BService.AddProductToBasket(User, dto);

                return RedirectToAction("Catalog");
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Product> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        private async Task<List<SelectListItem>> InitSelectListOfCategories(string selected = null)
        {
            logger.LogInformation(GetType().Name + " : InitSelectListOFCategories");

            List<CategoryDTO> DTOs = await CService.GetAll();

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

        private async Task<List<SelectListItem>> InitSelectListOfSupplerFirms(string selected = null)
        {
            logger.LogInformation(GetType().Name + " : InitSelectListOfSupplerFirms");

            List<SupplerFirmDTO> DTOs = await SFService.GetAll();

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

        private ProductSearchDTO FormProductSearchDTO(
            string name, string categoryId, string[] supplerFirmIds,
            double? lowestPrice, double? higestPrice,
            double? lowestRating, double? higestRating,
            string isHot
            )
        {
            logger.LogInformation(GetType().Name + " : FormProductSearchDTO");

            ProductSearchDTO dto = null;

            bool isInit = false;

            if (!string.IsNullOrEmpty(name))
            {
                dto = new ProductSearchDTO();
                isInit = true;
                dto.Name = name;
            }

            if (!string.IsNullOrEmpty(categoryId))
            {
                if (!isInit)
                {
                    dto = new ProductSearchDTO();
                }
                dto.CategoryId = categoryId;
            }

            if (supplerFirmIds.Length > 0)
            {
                if (!isInit)
                {
                    dto = new ProductSearchDTO();
                }
                if (supplerFirmIds.Length == 1)
                {
                    if (supplerFirmIds[0] != null)
                    {
                        dto.SupplerFirmIds = supplerFirmIds;
                    }
                }
                else
                {
                    dto.SupplerFirmIds = supplerFirmIds;
                }
            }

            if (lowestPrice != null)
            {
                if (!isInit)
                {
                    dto = new ProductSearchDTO();
                }
                dto.LowestPrice = lowestPrice.Value;
            }

            if (higestPrice != null)
            {
                if (!isInit)
                {
                    dto = new ProductSearchDTO();
                }
                dto.HigestPrice = higestPrice.Value;
            }

            if (lowestRating != null)
            {
                if (!isInit)
                {
                    dto = new ProductSearchDTO();
                }
                dto.LowestRating = lowestRating.Value;
            }

            if (higestRating != null)
            {
                if (!isInit)
                {
                    dto = new ProductSearchDTO();
                }
                dto.HigestRating = higestRating.Value;
            }

            if (isHot != null)
            {
                if (!isInit)
                {
                    dto = new ProductSearchDTO();
                }
                dto.IsHot = true;
            }

            return dto;
        }

        private bool Validate(ProductDTO dto)
        {
            logger.LogInformation(GetType().Name + " : Validate");
            bool flag = !dto.Name.Equals("removed product");
            return flag;
        }

        private bool ValidateMark(ProductDTO dto)
        {
            logger.LogInformation(GetType().Name + " : ValidateMark");

            return dto.Rating > 0 && dto.Rating <= 10;
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