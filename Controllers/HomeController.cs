using Library.Models;
using Library.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly bookContext _bookContext;
        IWebHostEnvironment _environment; //為了得知網路位置

        public HomeController(ILogger<HomeController> logger, bookContext bookContext , IWebHostEnvironment environment)
        {
            _logger = logger;
            _bookContext = bookContext;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(CLoginViewModel login)
        {
            Tuser user = _bookContext.Tuser.FirstOrDefault(t=>t.PhoneNumber.Equals(login.txtAccount)&&t.Password.Equals(login.txtPassword));

            if (user !=null && user.Password.Equals(login.txtPassword))
            {
                //doit 補session
                login.UserID = user.UserId;
                user.LastLoginTime= DateTime.Now;
                string json = JsonSerializer.Serialize(login);
                HttpContext.Session.SetString(CDictionary.SK_LOGINED_USER, json);
                //將登入資訊json化存於Session中
                ViewBag.LoginErr = "";
                _bookContext.SaveChangesAsync();
                return View("Index");
            }
            else
            {
                ViewBag.LoginErr = "帳戶密碼錯誤";
                return View("Login");
            }

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(CDictionary.SK_LOGINED_USER);
            return RedirectToAction("Login");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(CUserViewModel u)
        {
            Tuser x = new Tuser
            {
                UserId = u.UserId,
                PhoneNumber = u.PhoneNumber,
                Password = u.Password,
                UserName = u.UserName,
                RegistrationTime = DateTime.Now,
                LastLoginTime = null,
                Privilege = "一般會員",
            };
            _bookContext.Tuser.Add(x);
            _bookContext.SaveChangesAsync();
            return RedirectToAction("Login");
        }
    }
}