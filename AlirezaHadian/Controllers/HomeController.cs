using AlirezaHadian.Models;
using AlirezaHadian.Utilities;
using AlirezaHadian.ViewModels;
using DeviceDetectorNET;
using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Diagnostics;
using ViewModels;

namespace AlirezaHadian.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UnitOfWork _db;
        private readonly ICaptchaValidator _captchaValidator;
        private IHttpContextAccessor _context;

        public HomeController(ILogger<HomeController> logger, UnitOfWork db, ICaptchaValidator captchaValidator, IHttpContextAccessor context)
        {
            _logger = logger;
            _db = db;
            _captchaValidator = captchaValidator;
            _context = context;
        }

        public IActionResult Index()
        {
            var social = _db.HomeSocialRepository.Get();
            var combinedViewModel = new CombinedViewModel()
            {
                HomeSocials = _db.HomeSocialRepository.Get(),
                AboutInfos = _db.AboutInfoRepository.Get(),
                Abouts = _db.AboutRepository.Get(),
                Certificates = _db.CertificateRepository.Get(),
                ContactUs = _db.ContactUsRepository.Get(),
                FooterSocials = _db.FooterSocialRepository.Get(),
                Home = _db.HomeRepository.Get(),
                JourneyTimelines = _db.JourneyTimelineRepository.Get(),
                Portfolios = _db.PortfolioRepository.Get(),
                Services = _db.ServiceRepository.Get(),
                ServicesCategories = _db.ServicesCategoryRepository.Get(),
                Skills = _db.SkillRepository.Get(),
                SkillsCategories = _db.SkillsCategoryRepository.Get(),
                message = new MessageViewModel()
            };
            return View(combinedViewModel);
        }

        public IActionResult ContactUs()
        {
            return PartialView("_ContactUs");
        }
        public IActionResult Telegram()
        {
            string userAgent = Request.Headers["User-Agent"];
            string userIp = HttpContext.Connection.RemoteIpAddress?.ToString();
            string operatingSystem = "Unknown";
            DateTime requestTime = DateTime.Now;

            if (userAgent.Contains("Windows"))
            {
                operatingSystem = "Windows";
            }
            else if (userAgent.Contains("Macintosh"))
            {
                operatingSystem = "Mac";
            }
            else if (userAgent.Contains("Linux"))
            {
                operatingSystem = "Linux";
            }
            else if (userAgent.Contains("Android"))
            {
                operatingSystem = "Android";

            }
            else if (userAgent.Contains("Iphone"))
            {
                operatingSystem = "Iphone";
            }

            var dd = new DeviceDetector(userAgent);
            dd.Parse();

            string deviceType = dd.GetDeviceName(); // e.g., "Desktop", "Tablet", "Smartphone"
            string brand = dd.GetBrandName(); // e.g., "Apple", "Samsung"
            string model = dd.GetModel(); // e.g., "iPhone 12", "Galaxy S21"
            string deviceSpecifications = $"{deviceType} - {brand} {model}";

            TelegramBotInfo info = new TelegramBotInfo()
            {
                DeviceSpecifications = deviceSpecifications,
                IPAddress = userIp,
                OperatingSystem = operatingSystem,
                RequestTime = DateTime.Now
            };
            _db.TelegramBotInfoRepository.Insert(info);
            _db.Save();

            return Redirect("https://telegram.me/BiChatBot?start=sc-870488-bU4veFH");
        }
        [HttpPost]
        public async Task<IActionResult> ContactUs(MessageViewModel message)
        {
            var isCaptchaValid = await IsCaptchaValid(message.GoogleCaptchaToken, "Index");
            if (isCaptchaValid)
            {
                if (ModelState.IsValid)
                {
                    Message newMessage = new Message()
                    {
                        Name = message.Name,
                        EmailOrPhone = message.EmailOrPhone,
                        MessageText = message.MessageText,
                        Prject = message.Prject,
                        Seen = false,
                        Done = false
                    };
                    _db.MessageRepository.Insert(newMessage);
                    _db.Save();
                    ModelState.Clear();
                    SendSMS.SendWithPattern(DateTime.Now.ToShamsi(), message.Prject, message.Name);
                    TempData["Title"] = "پروژه شما با موفقیت ثبت شد.";
                    TempData["Message"] = "منتظر تماس ما باشید!";
                    return Json(new { success = true, message = "پروژه شما با موفقیت ثبت شد" });
                }
                TempData["Title"] = "خطا...";
                TempData["Message"] = "تمامی اطلاعات مورد نیاز را پر کنید!";
                return Json(new { success = false, message = "لطفا تمامی اطلاعات مورد نیاز را وارد کنید!" });
            }
            TempData["Title"] = "خطا...";
            TempData["Message"] = "کپچا نامعتبر می باشد! صفحه را رفرش کنید.";
            return Json(new { success = false, message = "کپچا معتبر نمی باشد!" });
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private async Task<bool> IsCaptchaValid(string response, string action)
        {
            try
            {
                var secret = "6LflpNEnAAAAANFNFEkh7b9I8ICPloeBYbzp5uLw";
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                    {
                        {"secret", secret},
                        {"response", response},
                        {"remoteip", _context.HttpContext.Connection.RemoteIpAddress.ToString()}
                    };

                    var content = new FormUrlEncodedContent(values);
                    var verify = await client.PostAsync("https://www.google.com/recaptcha/api/siteverify", content);
                    var captchaResponseJson = await verify.Content.ReadAsStringAsync();
                    var captchaResult = JsonConvert.DeserializeObject<CaptchaResponseViewModel>(captchaResponseJson);
                    return captchaResult.Success
                           && captchaResult.Action == action
                           && captchaResult.Score > 0.5;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }


    }
}