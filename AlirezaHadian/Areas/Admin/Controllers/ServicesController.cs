using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlirezaHadian.Data;
using AlirezaHadian.Models;
using AlirezaHadian.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace AlirezaHadian.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ServicesController : Controller
    {
        private readonly UnitOfWork _db;

        public ServicesController(UnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            AdminServicesViewModel service = new AdminServicesViewModel()
            {
                serviceCategories = _db.ServicesCategoryRepository.Get(),
                services = _db.ServiceRepository.Get()
            };
            return View(service);
        }

        public IActionResult CreateCategory()
        {
            //ViewData["ServicesCategoryID"] = new SelectList(_context.ServicesCategories, "ServicesCategoryID", "ServicesCategoryIcon");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory(ServicesCategory category)
        {
            if (ModelState.IsValid)
            {
                _db.ServicesCategoryRepository.Insert(category);
                _db.Save();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult EditCategory(int? id)
        {
            if (id == null || _db.ServicesCategoryRepository == null)
            {
                return NotFound();
            }

            var category = _db.ServicesCategoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory(int id, ServicesCategory category)
        {
            if (id != category.ServicesCategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.ServicesCategoryRepository.Update(category);
                    _db.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceCategoryExists(category.ServicesCategoryID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult DeleteCategory(int? id)
        {
            if (id == null || _db.ServicesCategoryRepository == null)
            {
                return NotFound();
            }

            ServicesCategory category = _db.ServicesCategoryRepository.GetById(id);
            if(category == null)
            {
                return NotFound();
            }
            _db.ServicesCategoryRepository.Delete(category);
            _db.Save();
            return RedirectToAction("Index");
        }

        //================ SERVICES =================
        public IActionResult CreateService()
        {
            ViewData["ServicesCategoryID"] = new SelectList(_db.ServicesCategoryRepository.Get(), "ServicesCategoryID", "ServicesCategoryTitle");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateService(Service service)
        {
            if (ModelState.IsValid)
            {
                _db.ServiceRepository.Insert(service);
                _db.Save();
                return RedirectToAction("Index");
            }
            ViewData["ServicesCategoryID"] = new SelectList(_db.ServicesCategoryRepository.Get(), "ServicesCategoryID", "ServicesCategoryTitle");
            return View(service);
        }

        // GET: Admin/Services/Edit/5
        public IActionResult EditService(int? id)
        {
            if (id == null || _db.ServiceRepository == null)
            {
                return NotFound();
            }

            Service service = _db.ServiceRepository.GetById(id);
            if (service == null)
            {
                return NotFound();
            }
            ViewData["ServicesCategoryID"] = new SelectList(_db.ServicesCategoryRepository.Get(), "ServicesCategoryID", "ServicesCategoryTitle");
            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditService(int id, Service service)
        {
            if (id != service.ServiceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.ServiceRepository.Update(service);
                    _db.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.ServiceID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ServicesCategoryID"] = new SelectList(_db.ServicesCategoryRepository.Get(), "ServicesCategoryID", "ServicesCategoryTitle");
            return View(service);
        }

        public IActionResult DeleteService(int? id)
        {
            if (id == null || _db.ServiceRepository == null)
            {
                return NotFound();
            }

            Service service = _db.ServiceRepository.GetById(id);
            if (service == null)
            {
                return NotFound();
            }
            _db.ServiceRepository.Delete(service);
            _db.Save();
            return RedirectToAction("Index");
        }
        private bool ServiceCategoryExists(int id)
        {
            return (_db.ServicesCategoryRepository.Get()?.Any(e => e.ServicesCategoryID == id)).GetValueOrDefault();
        }
        private bool ServiceExists(int id)
        {
          return (_db.ServiceRepository.Get()?.Any(e => e.ServiceID == id)).GetValueOrDefault();
        }
    }
}
