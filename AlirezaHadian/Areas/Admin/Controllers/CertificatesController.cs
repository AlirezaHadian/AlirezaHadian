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
    public class CertificatesController : Controller
    {
        private readonly UnitOfWork _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CertificatesController(UnitOfWork db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Admin/Certificates
        public IActionResult Index()
        {
            return View(_db.CertificateRepository.Get());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Certificate certificate, IFormFile? file)
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

                    certificate.Image = fileName;
                }
                _db.CertificateRepository.Insert(certificate);
                _db.Save();
                return RedirectToAction("Index");
            }
            return View(certificate);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || _db.CertificateRepository == null)
            {
                return NotFound();
            }

            Certificate certificate = _db.CertificateRepository.GetById(id);
            if (certificate == null)
            {
                return NotFound();
            }
            return View(certificate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Certificate certificate, IFormFile? file)
        {
            if (id != certificate.CertificateID)
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

                        if (certificate.Image != null)
                        {
                            var oldImagePath = Path.Combine(rootPath, "img", certificate.Image);
                            if (System.IO.File.Exists(oldImagePath))
                                System.IO.File.Delete(oldImagePath);
                        }

                        using (var stream = new FileStream(uploadsRoot, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        certificate.Image = fileName;
                    }

                    _db.CertificateRepository.Update(certificate);
                    _db.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificateExists(certificate.CertificateID))
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
            return View(certificate);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || _db.CertificateRepository == null)
            {
                return NotFound();
            }

            Certificate certificate = _db.CertificateRepository.GetById(id);
            if (certificate == null)
            {
                return NotFound();
            }
            _db.CertificateRepository.Delete(certificate);
            _db.Save();
            return RedirectToAction("Index");
        }

        private bool CertificateExists(int id)
        {
            return (_db.CertificateRepository.Get()?.Any(e => e.CertificateID == id)).GetValueOrDefault();
        }
    }
}
