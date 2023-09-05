using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlirezaHadian.Data;
using AlirezaHadian.Models;
using Microsoft.AspNetCore.Authorization;

namespace AlirezaHadian.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactUsController : Controller
    {
        private readonly UnitOfWork _db;

        public ContactUsController(UnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.ContactUsRepository.Get().First());
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || _db.ContactUsRepository == null)
            {
                return NotFound();
            }

            ContactUs contactUs = _db.ContactUsRepository.GetById(id);
            if (contactUs == null)
            {
                return NotFound();
            }
            return View(contactUs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ContactUs contactUs)
        {
            if (id != contactUs.ContactUsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.ContactUsRepository.Update(contactUs);
                    _db.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactUsExists(contactUs.ContactUsID))
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
            return View(contactUs);
        }

        private bool ContactUsExists(int id)
        {
          return (_db.ContactUsRepository.Get()?.Any(e => e.ContactUsID == id)).GetValueOrDefault();
        }
    }
}
