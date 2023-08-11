using AlirezaHadian.Models;
using AlirezaHadian.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AlirezaHadian.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UnitOfWork _db;

        public HomeController(ILogger<HomeController> logger, UnitOfWork db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var social = _db.HomeSocialRepository.Get();
            var combinedViewModel = new CombinedViewModel()
            {
                HomeSocials = _db.HomeSocialRepository.Get(),
                AboutInfos = _db.AboutInfoRepository.Get(),
                Abouts = _db.AboutRepostory.Get(),
                Certificates = _db.CertificateRepository.Get(),
                ContactUs = _db.ContactUsRepository.Get(),
                FooterSocials = _db.FooterSocialRepository.Get(),
                Home = _db.HomeRepository.Get(),
                ImageGalleries = _db.PortfolioImageGalleryRepository.Get(),
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

        [HttpPost]
        public IActionResult ContactUs(MessageViewModel message)
        {
            if (ModelState.IsValid)
            {
                Message newMessage = new Message()
                {
                    Name = message.Name,
                    EmailOrPhone = message.EmailOrPhone,
                    MessageText = message.MessageText,
                    Prject = message.Prject
                };
                _db.MessageRepository.Insert(newMessage);
                _db.Save();
                ModelState.Clear();

                TempData["Title"] = "پروژه شما با موفقیت ثبت شد.";
                TempData["SuccessMessage"] = "منتظر تماس ما باشید!";
                return Json(new { success = true, message = "پروژه شما با موفقیت ثبت شد"});
            }

            TempData["Title"] = "خطا...";
            TempData["ErrorMessage"] = "تمامی اطلاعات مورد نیاز را پر کنید!";
            return Json(new { success = false, message = "لطفا تمامی اطلاعات مورد نیاز را وارد کنید!"});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}