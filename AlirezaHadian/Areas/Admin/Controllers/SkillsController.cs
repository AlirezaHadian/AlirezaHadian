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
    public class SkillsController : Controller
    {
        private readonly UnitOfWork _db;

        public SkillsController(UnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            AdminSkillViewModel skill = new AdminSkillViewModel()
            {
                categories = _db.SkillsCategoryRepository.Get(),
                skill = _db.SkillRepository.Get(),
            };
            return View(skill);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory(SkillsCategory skillCategroy)
        {
            if (ModelState.IsValid)
            {
                _db.SkillsCategoryRepository.Insert(skillCategroy);
                _db.Save();
                return RedirectToAction("Index");
            }
            
            return View(skillCategroy);
        }

        public IActionResult EditCategory(int? id)
        {
            if (id == null || _db.SkillsCategoryRepository == null)
            {
                return NotFound();
            }

            var category = _db.SkillsCategoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory(int id, SkillsCategory category)
        {
            if (id != category.SkillCategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.SkillsCategoryRepository.Update(category);
                    _db.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillCategoryExists(category.SkillCategoryID))
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
            if (id == null || _db.SkillsCategoryRepository == null)
            {
                return NotFound();
            }

            SkillsCategory category = _db.SkillsCategoryRepository.GetById(id);
            if(category == null)
            {
                return NotFound();
            }
            if (category.Skills.Any())
            {
                foreach(var item in category.Skills)
                {
                    _db.SkillRepository.Delete(item);
                }
            }
            _db.SkillsCategoryRepository.Delete(category);
            _db.Save();
            return RedirectToAction("Index");
        }

        //============= SKILLS =============
        public IActionResult CreateSkill()
        {
            ViewData["SkillsCategoryID"] = new SelectList(_db.SkillsCategoryRepository.Get(), "SkillCategoryID", "SkillCategoryTitle");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSkill(Skill skill)
        {
            if (ModelState.IsValid)
            {
                _db.SkillRepository.Insert(skill);
                _db.Save();
                return RedirectToAction("Index");
            }
            ViewData["SkillsCategoryID"] = new SelectList(_db.SkillsCategoryRepository.Get(), "SkillCategoryID", "SkillCategoryTitle");
            return View(skill);
        }

        public IActionResult EditSkill(int? id)
        {
            if (id == null || _db.SkillRepository == null)
            {
                return NotFound();
            }

            var skill = _db.SkillRepository.GetById(id);
            if (skill == null)
            {
                return NotFound();
            }
            ViewData["SkillsCategoryID"] = new SelectList(_db.SkillsCategoryRepository.Get(), "SkillCategoryID", "SkillCategoryTitle");
            return View(skill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSkill(int id, Skill skill)
        {
            if (id != skill.SkillID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.SkillRepository.Update(skill);
                    _db.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillExists(skill.SkillID))
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
            ViewData["SkillsCategoryID"] = new SelectList(_db.SkillsCategoryRepository.Get(), "SkillCategoryID", "SkillCategoryTitle");
            return View(skill);
        }

        public IActionResult DeleteSkill(int? id)
        {
            if (id == null || _db.SkillRepository == null)
            {
                return NotFound();
            }

            Skill skill = _db.SkillRepository.GetById(id);
            if (skill == null)
            {
                return NotFound();
            }
            _db.SkillRepository.Delete(skill);
            _db.Save();
            return RedirectToAction("Index");
        }


        private bool SkillCategoryExists(int id)
        {
            return (_db.SkillsCategoryRepository.Get()?.Any(e => e.SkillCategoryID == id)).GetValueOrDefault();
        }
        private bool SkillExists(int id)
        {
            return (_db.SkillRepository.Get()?.Any(e => e.SkillID == id)).GetValueOrDefault();
        }
    }
}
