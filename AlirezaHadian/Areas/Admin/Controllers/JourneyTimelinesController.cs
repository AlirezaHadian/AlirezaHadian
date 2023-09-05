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
    public class JourneyTimelinesController : Controller
    {
        private readonly UnitOfWork _db;

        public JourneyTimelinesController(UnitOfWork db)
        {
            _db = db;
        }

        // GET: Admin/JourneyTimelines
        public IActionResult Index()
        {
            return View(_db.JourneyTimelineRepository.Get());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(JourneyTimeline journeyTimeline)
        {
            if (ModelState.IsValid)
            {
                _db.JourneyTimelineRepository.Insert(journeyTimeline);
                _db.Save();
                return RedirectToAction("Index");
            }
            return View(journeyTimeline);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || _db.JourneyTimelineRepository == null)
            {
                return NotFound();
            }

            JourneyTimeline journeyTimeline = _db.JourneyTimelineRepository.GetById(id);
            if (journeyTimeline == null)
            {
                return NotFound();
            }
            return View(journeyTimeline);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, JourneyTimeline journeyTimeline)
        {
            if (id != journeyTimeline.JourneyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.JourneyTimelineRepository.Update(journeyTimeline);
                    _db.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JourneyTimelineExists(journeyTimeline.JourneyID))
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
            return View(journeyTimeline);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || _db.JourneyTimelineRepository == null)
            {
                return NotFound();
            }

            JourneyTimeline journeyTimeline = _db.JourneyTimelineRepository.GetById(id);
            if (journeyTimeline == null)
            {
                return NotFound();
            }
            _db.JourneyTimelineRepository.Delete(journeyTimeline);
            _db.Save();
            return RedirectToAction("Index");
        }

        private bool JourneyTimelineExists(int id)
        {
          return (_db.JourneyTimelineRepository.Get()?.Any(e => e.JourneyID == id)).GetValueOrDefault();
        }
    }
}
