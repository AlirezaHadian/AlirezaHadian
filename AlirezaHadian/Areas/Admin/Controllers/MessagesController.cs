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
    public class MessagesController : Controller
    {
        private readonly UnitOfWork _db;

        public MessagesController(UnitOfWork db)
        {
            _db = db;
        }

        // GET: Admin/Messages
        public IActionResult Index()
        {
            return View(_db.MessageRepository.Get());
        }

        public IActionResult Details(int? id)
        {
            if (id == null || _db.MessageRepository == null)
            {
                return NotFound();
            }

            var message = _db.MessageRepository.GetById(id);
            if (message == null)
            {
                return NotFound();
            }
            message.Seen = true;
            _db.MessageRepository.Update(message);
            _db.Save();
            return View(message);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || _db.MessageRepository == null)
            {
                return NotFound();
            }

            Message message = _db.MessageRepository.GetById(id);
            if (message == null)
            {
                return NotFound();
            }
            _db.MessageRepository.Delete(id);
            _db.Save();
            return RedirectToAction("Index");
        }


        public IActionResult Todo(int id)
        {
            Message message = _db.MessageRepository.GetById(id);
            if (message.Done == false)
            {
                message.Done = true;
                TempData["Status"] = "Done!";
            }
            else
            {
                message.Done = false;
                TempData["Status"] = "Undone!";
            }
            _db.MessageRepository.Update(message);
            _db.Save();

            return RedirectToAction("Index");
        }
    }
}

