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
    public class FooterSocialsController : Controller
    {
        private readonly UnitOfWork _db;

        public FooterSocialsController(UnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.FooterSocialRepository.Get());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FooterSocial footerSocial)
        {
            if (ModelState.IsValid)
            {
                _db.FooterSocialRepository.Insert(footerSocial);
                _db.Save();
                return RedirectToAction("Index");
            }
            return View(footerSocial);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || _db.FooterSocialRepository == null)
            {
                return NotFound();
            }

            FooterSocial footerSocial = _db.FooterSocialRepository.GetById(id);
            if (footerSocial == null)
            {
                return NotFound();
            }
            return View(footerSocial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, FooterSocial footerSocial)
        {
            if (id != footerSocial.FooterSocialID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.FooterSocialRepository.Update(footerSocial);
                    _db.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FooterSocialExists(footerSocial.FooterSocialID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(footerSocial);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || _db.FooterSocialRepository == null)
            {
                return NotFound();
            }

            FooterSocial footerSocial = _db.FooterSocialRepository.GetById(id);
            if (footerSocial == null)
            {
                return NotFound();
            }
            _db.FooterSocialRepository.Delete(footerSocial);
            _db.Save();
            return RedirectToAction("Index");
        }

        private bool FooterSocialExists(int id)
        {
          return (_db.FooterSocialRepository.Get()?.Any(e => e.FooterSocialID == id)).GetValueOrDefault();
        }
    }
}
