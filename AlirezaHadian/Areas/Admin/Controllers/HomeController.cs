using AlirezaHadian.Models;
using AlirezaHadian.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace AlirezaHadian.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly UnitOfWork _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HomeController(UnitOfWork db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            AdminIndexViewModel index = new AdminIndexViewModel()
            {
                botInfo = _db.TelegramBotInfoRepository.Get(),
                userData = _db.UserDataRepository.Get(),
                TodayVisit = _db.UserDataRepository.Get().Where(u => u.RequestTime == DateTime.Now.Date).DistinctBy(u => u.IPAddress).Count()
            };
            return View(index);
        }
        public IActionResult DeleteUserLog(int? id)
        {
            if (id == null || _db.UserDataRepository == null)
            {
                return NotFound();
            }

            UserData data = _db.UserDataRepository.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            _db.UserDataRepository.Delete(data);
            _db.Save();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAllUserLog()
        {
            IEnumerable<UserData> userDatas = _db.UserDataRepository.Get();
            foreach (var data in userDatas)
            {
                _db.UserDataRepository.Delete(data);
            }
            _db.Save();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTelegramLog(int? id)
        {
            if (id == null || _db.TelegramBotInfoRepository == null)
            {
                return NotFound();
            }

            TelegramBotInfo info = _db.TelegramBotInfoRepository.GetById(id);
            if (info == null)
            {
                return NotFound();
            }
            _db.TelegramBotInfoRepository.Delete(info);
            _db.Save();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAllTelegramLog()
        {
            IEnumerable<TelegramBotInfo> info = _db.TelegramBotInfoRepository.Get();
            foreach (var item in info)
            {
                _db.TelegramBotInfoRepository.Delete(item);
            }
            _db.Save();
            return RedirectToAction("Index");
        }
        //=============== HOME INFO ================
        public IActionResult HomeInfo()
        {
            Home home = _db.HomeRepository.Get().First();
            AdminHomeViewModel homeVM = new AdminHomeViewModel()
            {
                Home = home,
                HomeSocials = _db.HomeSocialRepository.Get()
            };
            return View(homeVM);
        }

        public IActionResult HomeInfoUpdate(Home home)
        {
            var homeInfo = _db.HomeRepository.Get().First();
            return View(homeInfo);
        }
        //TODO:: Update image file
        [HttpPost]
        public IActionResult HomeInfoUpdate(Home home, IFormFile? file)
        {
            string rootPath = _hostEnvironment.WebRootPath;
            if (ModelState.IsValid)
            {
                var homeInfo = _db.HomeRepository.Get().First();

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var uploadsRoot = Path.Combine(rootPath, "img", fileName);

                    if (homeInfo.Image != null)
                    {
                        var oldImagePath = Path.Combine(rootPath, "img", homeInfo.Image);
                        if (System.IO.File.Exists(oldImagePath))
                            System.IO.File.Delete(oldImagePath);
                    }

                    using (var stream = new FileStream(uploadsRoot, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    homeInfo.Image = fileName;
                }


                homeInfo.Title = home.Title;
                homeInfo.Subtitle = home.Subtitle;
                homeInfo.Description = home.Description;

                _db.HomeRepository.Update(homeInfo);
                _db.Save();

                TempData["Status"] = "اطلاعات صفحه اصلی با موفقیت ویرایش شد";
                return RedirectToAction("HomeInfo");
            }
            TempData["Status"] = "در تغییر اطلاعات صفحه اصلی مشکلی بوجود آمده است!";
            return View(home);
        }

        //=============== HOME SOCIAL ================
        public IActionResult HomeSocialAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HomeSocialAdd(HomeSocial social)
        {
            if (ModelState.IsValid)
            {
                _db.HomeSocialRepository.Insert(social);
                _db.Save();
                return RedirectToAction("HomeInfo");
            }
            return View(social);
        }

        public IActionResult HomeSocialUpdate(int id)
        {
            HomeSocial social = _db.HomeSocialRepository.GetById(id);
            if (social == null)
            {
                return NotFound();
            }
            return View(social);
        }
        [HttpPost]
        public IActionResult HomeSocialUpdate(HomeSocial social)
        {
            if (ModelState.IsValid)
            {
                var homeSocial = _db.HomeSocialRepository.GetById(social.HomeSocialID);
                homeSocial.SocialLink = social.SocialLink;
                homeSocial.SocialIcon = social.SocialIcon;

                _db.HomeSocialRepository.Update(homeSocial);
                _db.Save();

                TempData["Status"] = "سوشال مدیا مد نظر با موفقیت ویرایش شد";
                return View();
            }
            TempData["Status"] = "در تغییر سوشال مدیا مد نظر مشکلی بوجود آمده است!";
            return View(social);
        }
        public IActionResult DeleteHomeSocial(int id)
        {
            HomeSocial social = _db.HomeSocialRepository.GetById(id);
            if (social == null)
            {
                return NotFound();
            }
            _db.HomeSocialRepository.Delete(social);
            _db.Save();

            return RedirectToAction("HomeInfo", "Home");
        }

        //=============== ABOUT ================
        public IActionResult About()
        {
            AdminAboutViewModel aboutVM = new AdminAboutViewModel()
            {
                about = _db.AboutRepository.Get().First(),
                aboutInfo = _db.AboutInfoRepository.Get()
            };
            return View(aboutVM);
        }

        //TODO:: Update image and cv file
        public IActionResult AboutUpdate()
        {
            About about = _db.AboutRepository.Get().First();
            return View(about);
        }
        [HttpPost]
        public IActionResult AboutUpdate(About about, List<IFormFile> files)
        {
            string rootPath = _hostEnvironment.WebRootPath;
            if (ModelState.IsValid)
            {
                var aboutTarget = _db.AboutRepository.Get().First();

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        var fileExtension = Path.GetExtension(fileName);
                        var folderName = "";
                        if (fileExtension.Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                        {
                            if (aboutTarget.CVFile != null)
                            {
                                var oldFilePath = Path.Combine(rootPath, "pdf", aboutTarget.CVFile);
                                if (System.IO.File.Exists(oldFilePath))
                                    System.IO.File.Delete(oldFilePath);
                            }
                            folderName = "pdf";
                            aboutTarget.CVFile = fileName;
                        }
                        else if (fileExtension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                fileExtension.Equals(".png", StringComparison.OrdinalIgnoreCase))
                        {
                            if (aboutTarget.Image != null)
                            {
                                var oldImagePath = Path.Combine(rootPath, "img", aboutTarget.Image);
                                if (System.IO.File.Exists(oldImagePath))
                                    System.IO.File.Delete(oldImagePath);
                            }
                            folderName = "img";
                            aboutTarget.Image = fileName;
                        }

                        if (!string.IsNullOrEmpty(folderName))
                        {
                            var filePath = Path.Combine(rootPath, folderName, fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }
                        }
                    }
                }

                aboutTarget.Text = about.Text;
                _db.AboutRepository.Update(aboutTarget);
                _db.Save();

                return RedirectToAction("About");
            }
            return View(about);
        }

        //=============== ABOUT INFO ================
        public IActionResult AboutInfoAdd()
        {
            int aboutId = _db.AboutRepository.Get().First().AboutID;
            ViewBag.aboutId = aboutId;
            return View();
        }

        [HttpPost]
        public IActionResult AboutInfoAdd(AboutInfo aboutInfo)
        {
            if (ModelState.IsValid)
            {
                _db.AboutInfoRepository.Insert(aboutInfo);
                _db.Save();
                return RedirectToAction("About");
            }
            return View(aboutInfo);
        }

        public IActionResult AboutInfoUpdate(int id)
        {
            AboutInfo aboutInfo = _db.AboutInfoRepository.GetById(id);
            if (aboutInfo == null)
            {
                return NotFound();
            }
            return View(aboutInfo);
        }
        [HttpPost]
        public IActionResult AboutInfoUpdate(AboutInfo aboutInfo)
        {
            if (ModelState.IsValid)
            {
                var about = _db.AboutInfoRepository.GetById(aboutInfo.AboutInfoID);
                about.Title = aboutInfo.Title;
                about.Count = aboutInfo.Count;

                _db.AboutInfoRepository.Update(about);
                _db.Save();

                return RedirectToAction("About");
            }
            return View(aboutInfo);
        }
        public IActionResult DeleteAboutInfo(int id)
        {
            AboutInfo aboutInfo = _db.AboutInfoRepository.GetById(id);
            if (aboutInfo == null)
            {
                return NotFound();
            }
            _db.AboutInfoRepository.Delete(aboutInfo);
            _db.Save();

            return RedirectToAction("About", "Home");
        }
    }
}
