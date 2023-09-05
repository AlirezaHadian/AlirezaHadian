using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlirezaHadian.Data;
using AlirezaHadian.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace AlirezaHadian.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PortfoliosController : Controller
    {
        private readonly UnitOfWork _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PortfoliosController(UnitOfWork db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Admin/Portfolios
        public IActionResult Index()
        {
            return View(_db.PortfolioRepository.Get());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Portfolio portfolio, IFormFile? file)
        {
            string rootPath = _hostEnvironment.WebRootPath;

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var uploadsRoot = Path.Combine(rootPath, "img", fileName);

                    using (var stream = new FileStream(uploadsRoot, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    portfolio.Image = fileName;
                }

                _db.PortfolioRepository.Insert(portfolio);
                _db.Save();
                return RedirectToAction("Index");
            }
            return View(portfolio);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || _db.PortfolioRepository == null)
            {
                return NotFound();
            }

            var portfolio = _db.PortfolioRepository.GetById(id);
            if (portfolio == null)
            {
                return NotFound();
            }
            return View(portfolio);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Portfolio portfolio, IFormFile? file)
        {
            if (id != portfolio.PortfolioID)
            {
                return NotFound();
            }
            string rootPath = _hostEnvironment.WebRootPath;

            if (ModelState.IsValid)
            {
                try
                {
                    if (file != null)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        var uploadsRoot = Path.Combine(rootPath, "img", fileName);

                        if (portfolio.Image != null)
                        {
                            var oldImagePath = Path.Combine(rootPath, "img", portfolio.Image);
                            if (System.IO.File.Exists(oldImagePath))
                                System.IO.File.Delete(oldImagePath);
                        }

                        using (var stream = new FileStream(uploadsRoot, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        portfolio.Image = fileName;
                    }

                    _db.PortfolioRepository.Update(portfolio);
                    _db.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortfolioExists(portfolio.PortfolioID))
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
            return View(portfolio);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || _db.PortfolioRepository == null)
            {
                return NotFound();
            }

            Portfolio portfolio = _db.PortfolioRepository.GetById(id);
            if (portfolio == null)
            {
                return NotFound();
            }
            string rootPath = _hostEnvironment.WebRootPath;

            if (portfolio.Image != null)
            {
                var oldImagePath = Path.Combine(rootPath, "img", portfolio.Image);
                if (System.IO.File.Exists(oldImagePath))
                    System.IO.File.Delete(oldImagePath);
            }
            _db.PortfolioRepository.Delete(portfolio);
            _db.Save();
            return RedirectToAction("Index");
        }

        private bool PortfolioExists(int id)
        {
            return (_db.PortfolioRepository.Get()?.Any(e => e.PortfolioID == id)).GetValueOrDefault();
        }
    }
}
