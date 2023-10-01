using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using onlineshop.Services;
using onlineshop.Services.DTO;
using onlineshop.Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace onlineshop.Controllers
{
    [Route("users")]
    public class UsersController : Controller
    {
        private readonly IBasketService BService;

        private readonly IUserService UService;

        private readonly IRoleService RService;

        private readonly ICountryService CService;

        private readonly ISupplerFirmService SFService;

        private readonly ISupperFirmMapper SFMapper;

        private readonly IUserMapper USMapper;

        private readonly ILogger logger;

        public UsersController(IUserService uService, IRoleService rService, ICountryService cService, ISupplerFirmService sfService, ISupperFirmMapper sfMapper, IUserMapper uMapper, IBasketService bService)
        {
            this.UService = uService;
            this.RService = rService;
            this.CService = cService;
            this.BService = bService;

            this.SFService = sfService;
            this.SFMapper = sfMapper;

            this.USMapper = uMapper;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            this.logger = logFactory.CreateLogger<UsersController>();
        }

        [Authorize(Roles = "ADMIN, OWNER")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index(
            string userName, string email, string phoneNumber, string[] roleIds
            )
        {
            logger.LogInformation(GetType().Name + " : Index");

            await Inicialize();

            List<UserDTO> list = new List<UserDTO>();

            UserSearchDTO dto = new UserSearchDTO();

            bool isSearch = false;

            bool isExists = true;

            if (!string.IsNullOrEmpty(userName))
            {
                isSearch = true;
                dto.UserName = userName;
            }

            if (!string.IsNullOrEmpty(email))
            {
                isSearch = true;
                dto.Email = email;
            }

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                isSearch = true;
                dto.PhoneNumber = phoneNumber;
            }
            if (roleIds.Length > 0)
            {
                dto.RoleIds = roleIds;
                isSearch = true;
            }

            try
            {
                if (isSearch)
                {
                    list = await UService.Search(dto);
                }
                else
                {
                    list = await UService.GetAll();
                }
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User>)
            {
                isExists = false;
            }

            List<SelectListItem> roles = await InitSelectListOfAllRoles();

            ViewBag.Roles = new MultiSelectList(roles, "Value", "Text");

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
                UserDTO dto = await UService.GetById(User, id);

                List<RoleDTO> userRolesList = await UService.GetRolesForUser(id);

                List<SupplerFirmDTO> supplerFirmsList = await UService.GetDependentSupplerFirmsForUser(User, id);

                ViewBag.UserRoles = userRolesList;
                ViewBag.SupplerFirms = supplerFirmsList;

                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "BUYER")]
        [HttpGet("Current")]
        public async Task<IActionResult> Current()
        {
            logger.LogInformation(GetType().Name + "Current");

            await Inicialize();

            try
            {
                string currentId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                UserDTO dto = await UService.GetById(User, currentId);

                List<RoleDTO> userRolesList = await UService.GetRolesForUser(currentId);

                List<SupplerFirmDTO> supplerFirmsList = await UService.GetDependentSupplerFirmsForUser(User, currentId);

                ViewBag.SupplerFirms = supplerFirmsList;

                ViewBag.UserRoles = userRolesList;

                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
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

            List<SelectListItem> listOfUserRoles = await InitListOfUserRoles();

            List<SelectListItem> listOfCountries = InitSelectListOfCountries();

            List<SelectListItem> listOfSSupplerFirms = await InitSelectListOfSupplerFirms();

            ViewBag.Roles = new SelectList(listOfUserRoles, "Value", "Text");

            ViewBag.Countries = new SelectList(listOfCountries, "Value", "Text");

            ViewBag.SupplerFirms = new SelectList(listOfSSupplerFirms, "Value", "Text");

            return View();
        }

        [Authorize(Roles = "ADMIN, OWNER")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(UserRegisterDTO dto)
        {
            logger.LogInformation(GetType().Name + " : Create (POST)");

            await Inicialize();

            

            List<SelectListItem> listOfUserRoles = await InitListOfUserRoles();

            List<SelectListItem> listOfCountries = InitSelectListOfCountries();

            List<SelectListItem> listOfSupplerFirms = await InitSelectListOfSupplerFirms();

            ViewBag.Roles = new SelectList(listOfUserRoles, "Value", "Text");

            ViewBag.Countries = new SelectList(listOfCountries, "Value", "Text");

            ViewBag.SupplerFirms = new SelectList(listOfSupplerFirms, "Value", "Text");

            if (ModelState.IsValid)
            {
                bool flag = await UService.CheckUserName(User, dto.UserName);

                if (flag)
                {
                    ModelState.AddModelError("UserName", "username is already used");
                }

                flag = await UService.CheckEmail(User, dto.Email);

                if (flag)
                {
                    ModelState.AddModelError("Email", "email is already used");
                }

                flag = await UService.CheckPhoneNumber(User, dto.PhoneNumber);

                if (flag)
                {
                    ModelState.AddModelError("Phone", "phonenumber is already used");
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        ModelState.Clear();

                        UserDTO result = await UService.Add(dto);

                        return RedirectToAction("Index");
                    }
                    catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
                    {
                        if (ex.Code == HttpStatusCode.Forbidden)
                        {
                            ModelState.AddModelError("UserSupplerFirms", ex.Message);
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
            else
            {
                return View(dto);
            }
        }

        [Authorize(Roles = "ADMIN, OWNER")]
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            logger.LogInformation(GetType().Name + " : Edit (GET)");

            await Inicialize();

            try
            {
                UserDTO dto = await UService.GetById(User, id);

                dto.PasswordHash = null;

                UserUpdateData uUpdateData = await InitListOfUserUpdateData(id);

                ViewBag.uRoles = new SelectList(uUpdateData.UserRoles, "Value", "Text");
                ViewBag.oRoles = new SelectList(uUpdateData.OtherRoles, "Value", "Text");
                ViewBag.uSupplerFirms = new SelectList(uUpdateData.UserSupplerFirms, "Value", "Text");
                ViewBag.oSupplerFirms = new SelectList(uUpdateData.OtherSupplerFirms, "Value", "Text");

                List<SelectListItem> list = InitSelectListOfCountries();

                ViewBag.Countries = new SelectList(list, "Value", "Text");

                UserUpdateDTO result = USMapper.ToUpdateDTO(dto, uUpdateData.UserRolesValues, uUpdateData.OtherRolesValues);

                return View(result);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "ADMIN, OWNER")]
        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(string id, UserUpdateDTO dto)
        {
            logger.LogInformation(GetType().Name + " : Edit (POST)");

            await Inicialize();

            string cuid = dto.Id;

            UserUpdateData uUpdateData = await InitListOfUserUpdateData(id);

            ViewBag.uRoles = new SelectList(uUpdateData.UserRoles, "Value", "Text");
            ViewBag.oRoles = new SelectList(uUpdateData.OtherRoles, "Value", "Text");
            ViewBag.uSupplerFirms = new SelectList(uUpdateData.UserSupplerFirms, "Value", "Text");
            ViewBag.oSupplerFirms = new SelectList(uUpdateData.OtherSupplerFirms, "Value", "Text");

            List<SelectListItem> list = InitSelectListOfCountries();

            ViewBag.Countries = new SelectList(list, "Value", "Text");

            if (ModelState.IsValid)
            {
                bool flag = await UService.CheckUserName(User, dto.UserName, cuid);

                if (flag)
                {
                    ModelState.AddModelError("UserName", "username is already used");
                }

                flag = await UService.CheckEmail(User, dto.Email, cuid);

                if (flag)
                {
                    ModelState.AddModelError("Email", "email is already used");
                }

                flag = await UService.CheckPhoneNumber(User, dto.PhoneNumber, cuid);

                if (flag)
                {
                    ModelState.AddModelError("Phone", "phonenumber is already used");
                }

                List<string> errors = ValidatePassword(dto.Password);

                if (errors.Count > 0)
                {
                    flag = false;
                    string message = "";
                    foreach (string error in errors)
                    {
                        message += error + ", ";
                    }

                    message = message.Substring(0, message.Length - 2);
                    ModelState.AddModelError("Password", message);
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        ModelState.Clear();
                        UserDTO result = await UService.Update(User, dto);

                        return RedirectToAction("Index");
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
            else
            {
                return View(dto);
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
                UserDTO dto = await UService.GetById(User, id);

                return View(dto);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [Authorize(Roles = "ADMIN, OWNER")]
        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete(string id, UserDTO dto)
        {
            logger.LogInformation(GetType().Name + " Delete (POST)");

            try
            {
                await UService.Delete(User, id);

                string uid = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (id.Equals(uid))
                {
                    await UService.SignOut();
                }

                return RedirectToAction("Index");
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                return ExceptionHandler(ex.Message, ex.Code);
            }
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            logger.LogInformation(GetType().Name + " : Register (GET)");

            List<SelectListItem> list = InitSelectListOfCountries();

            ViewBag.Countries = new SelectList(list, "Value", "Text");

            return View();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDTO dto)
        {
            logger.LogInformation(GetType().Name + " : Register (POST)");

            List<SelectListItem> list = InitSelectListOfCountries();

            ViewBag.Countries = new SelectList(list, "Value", "Text");

            if (ModelState.IsValid)
            {
                bool flag = await UService.CheckUserName(User, dto.UserName);

                if (flag)
                {
                    ModelState.AddModelError("UserName", "username is already used");
                }

                flag = await UService.CheckEmail(User, dto.Email);

                if (flag)
                {
                    ModelState.AddModelError("Email", "email is already used");
                }

                flag = await UService.CheckPhoneNumber(User, dto.PhoneNumber);

                if (flag)
                {
                    ModelState.AddModelError("Phone", "phonenumber is already used");
                }

                List<string> errors = ValidatePassword(dto.Password);

                if (errors.Count > 0)
                {
                    flag = false;
                    string message = "";
                    foreach (string error in errors)
                    {
                        message += error + ", ";
                    }

                    message = message.Substring(0, message.Length - 2);
                    ModelState.AddModelError("Password", message);
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        ModelState.Clear();

                        UserDTO result = await UService.Add(dto);

                        //autentificate user by email
                        await Autentificate(result.Id, result.Email, LoginType.Email);

                        return RedirectToAction("Index", "Home");
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
            else
            {
                return View();
            }
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            logger.LogInformation(GetType().Name + " Login (GET)");

            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDTO dto)
        {
            logger.LogInformation(GetType().Name + " : Login (POST)");

            if (ModelState.IsValid)
            {
                try
                {
                    bool flag = true;

                    switch (dto.Type)
                    {
                        case LoginType.UserName:
                            {
                                flag = dto.Login.Length <= 50 && dto.Login.Length >= 4;
                                if (!flag)
                                {
                                    ModelState.AddModelError("Login", "username is incorrect");
                                }
                            }

                            break;

                        case LoginType.PhoneNumber:
                            {
                                flag = Regex.Match(dto.Login, @"\(?\d{3}\)?[-\.]? *\d{3}[-\.]? *[-\.]?\d{4}").Success;
                                if (!flag)
                                {
                                    ModelState.AddModelError("Login", "phone is incorrect");
                                }
                            }

                            break;

                        case LoginType.Email:
                            {
                                flag = Regex.Match(dto.Login, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success;
                                if (!flag)
                                {
                                    ModelState.AddModelError("Login", "email is incorrect");
                                }
                            }
                            break;
                    }

                    List<string> errors = ValidatePassword(dto.Password);

                    if (errors.Count > 0)
                    {
                        flag = false;
                        string message = "";
                        foreach (string error in errors)
                        {
                            message += error + ", ";
                        }

                        message = message.Substring(0, message.Length - 2);
                        ModelState.AddModelError("Password", message);
                    }

                    if (ModelState.IsValid)
                    {
                        ModelState.Clear();

                        UserDTO dtoUser = await UService.CheckUser(dto);
                        if (dtoUser != null)
                        {
                            //autentificate
                            await Autentificate(dtoUser.Id, dto.Login, dto.Type);

                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("Login", "login or password are incorrect");
                            return View();
                        }
                    }
                    else
                    {
                        return View();
                    }
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

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            logger.LogInformation(GetType().Name + " : Logout");

            await UService.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("ResetPassword")]
        public IActionResult ResetPassword()
        {
            logger.LogInformation(GetType().Name + " : ResetPassword (GET)");

            return View();
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> Resetpassword(UserResetPasswordDTO dto)
        {
            logger.LogInformation(GetType().Name + " : ResetPassword (POST)");

            await UService.ResetPassword(dto);

            return RedirectToAction("Login", "Users");
        }

        public async Task Autentificate(string id, string login, LoginType type)
        {
            logger.LogInformation(GetType().Name + " Autentificate");

            try
            {
                await UService.SignIn(id, login, type);

                await Inicialize();
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                throw ex;
            }
        }

        private async Task<List<SelectListItem>> InitListOfUserRoles(IList<RoleDTO> selected = null)
        {
            logger.LogInformation(GetType().Name + " : InitListOfAllRoles");

            List<SelectListItem> result = new List<SelectListItem>();

            try
            {
                List<RoleDTO> list = await RService.GetAll();

                if (selected == null)
                {
                    foreach (var item in list)
                    {
                        result.Add(new SelectListItem(text: item.Name, value: item.Id));
                    }
                }
                else
                {
                    foreach (var item in list)
                    {
                        bool isSelected = false;

                        foreach (var role in selected)
                        {
                            if (role.Name.Equals(item.Name))
                            {
                                isSelected = true;
                                break;
                            }
                        }

                        if (isSelected)
                        {
                            result.Add(new SelectListItem(text: item.Name, value: item.Id));
                        }
                       
                    }
                }
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Role> ex)
            {
                logger.LogWarning("InitListOfUserroles : " + ex.Message);
            }

            return result;
        }

        private async Task<List<SelectListItem>> InitSelectListOfAllRoles()
        {
            logger.LogInformation(GetType().Name + " : InitSelectListOfAllRoles");

            List<SelectListItem> items = new List<SelectListItem>();

            try
            {
                List<RoleDTO> roles = await RService.GetAll();

                foreach (var role in roles)
                {
                    items.Add(new SelectListItem(text: role.Name, value: role.Id));
                }
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Role> ex)
            {
                logger.LogWarning("InitSelectListOfAllRoles : " + ex.Message);
            }

            return items;
        }

        private List<SelectListItem> InitSelectListOfCountries(string selected = null)
        {
            logger.LogInformation(GetType().Name + " : InitSelectListOfCountries");

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

        private async Task<List<SelectListItem>> InitSelectListOfSupplerFirms(List<SupplerFirmDTO> selected = null)
        {

            logger.LogInformation(GetType().Name + " : InitSelectListOfSupplerFirms");

            List<SelectListItem> items = new List<SelectListItem>();

            try
            {
                List<SupplerFirmDTO> firms = await SFService.GetAll();

                

                if (selected == null)
                {
                    foreach (var firm in firms)
                    {
                        items.Add(new SelectListItem(text: firm.Name, value: firm.Id));
                    }
                }
                else
                {
                    foreach (var firm in firms)
                    {
                        bool isSelected = false;

                        foreach (var item in selected)
                        {
                            if (item.Name.Equals(firm.Name))
                            {
                                isSelected = true;
                                break;
                            }
                        }

                        if (isSelected)
                        {
                            items.Add(new SelectListItem(text: firm.Name, value: firm.Id));
                        }
                    }
                }

               
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.SupplerFirm> ex)
            {
                logger.LogWarning("InitSelectListOfSupplerFirms : " + ex.Message);
            }

            return items;

        }

        public List<string> ValidatePassword(string password)
        {
            logger.LogInformation(GetType().Name + " ValidatePassword");

            List<string> errors = new List<string>();

            if (password != null)
            {
                if (password.Length < 6 || password.Length > 256)
                {
                    errors.Add("password must be between 6 and 256");
                }
                bool flag = password.Any(char.IsUpper);

                if (!flag)
                {
                    errors.Add("password must be include symbol in upper case");
                }

                flag = password.Any(char.IsDigit);

                if (!flag)
                {
                    errors.Add("password must be include digit");
                }
            }
            else
            {
                errors.Add("pasword field is mandatoty");
            }

            return errors;
        }

        private struct UserUpdateData
        {
            public List<SelectListItem> UserRoles { get; set; }

            public List<RoleDTO> UserRolesValues { get; set; }

            public List<SelectListItem> OtherRoles { get; set; }

            public List<RoleDTO> OtherRolesValues { get; set; }

            public List<SelectListItem> UserSupplerFirms { get; set; }

            public List<SupplerFirmDTO> UserSupplerFirmsValues { get; set; }

            public List<SelectListItem> OtherSupplerFirms { get; set; }

            public List<SupplerFirmDTO> OtherSupplerFirmsValues { get; set; }
        }

        private async Task<UserUpdateData> InitListOfUserUpdateData(string id)
        {
            logger.LogInformation(GetType().Name + " : InitListOfUserUpdateData");

            UserUpdateData result = new UserUpdateData();

            try
            {
                List<RoleDTO> allRoles = await RService.GetAll();

                List<RoleDTO> userRolesValues = await UService.GetRolesForUser(id);

                List<SelectListItem> userRoles = await InitListOfUserRoles(userRolesValues);

                List<RoleDTO> otherRolesValues = new List<RoleDTO>();

                List<SupplerFirmDTO> allSupplerFirms = await SFService.GetAll();

                List<SupplerFirmDTO> userSupplerFirmsValues = await UService.GetDependentSupplerFirmsForUser(User, id);

                List<SelectListItem> userSupplerFirms =  await InitSelectListOfSupplerFirms(userSupplerFirmsValues);

                List<SupplerFirmDTO> otherSupplerFirmsValues = new List<SupplerFirmDTO>();


                if (userRolesValues != null)
                {
                    foreach (var role in allRoles)
                    {
                        bool flag = true;

                        foreach (var temp in userRolesValues)
                        {
                            if (temp.Name.Equals(role.Name))
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (flag)
                        {
                            otherRolesValues.Add(role);
                        }
                    }
                }

                if (userSupplerFirmsValues != null)
                {
                    foreach (var firm in allSupplerFirms)
                    {
                        bool flag = true;

                        foreach (var temp in userSupplerFirmsValues)
                        {
                            if (temp.Name.Equals(firm.Name))
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (flag)
                        {
                            otherSupplerFirmsValues.Add(firm);
                        }
                    }
                }

                List<SelectListItem> otherRoles = await InitListOfUserRoles(otherRolesValues);

                List<SelectListItem> otherSupplerFirms = await InitSelectListOfSupplerFirms(otherSupplerFirmsValues);

                if (userRoles != null && otherRoles != null)
                {
                    result.UserRoles = userRoles;
                    result.UserRolesValues = userRolesValues;
                    result.OtherRoles = otherRoles;
                    result.OtherRolesValues = otherRolesValues;
                    result.UserSupplerFirms = userSupplerFirms;
                    result.UserSupplerFirmsValues = userSupplerFirmsValues;
                    result.OtherSupplerFirms = otherSupplerFirms;
                    result.OtherSupplerFirmsValues = otherSupplerFirmsValues;
                }
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.Role> ex)
            {
                logger.LogWarning("InitListOfUpdateUserRoles : " + ex.Message);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.User> ex)
            {
                logger.LogWarning("InitListOfUpdateUserRoles : " + ex.Message);
            }
            catch (onlineshop.Models.HttpException<onlineshop.Models.SupplerFirm> ex)
            {
                logger.LogWarning("InitListOfUpdateUserRoles : " + ex.Message);
            }
            return result;
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