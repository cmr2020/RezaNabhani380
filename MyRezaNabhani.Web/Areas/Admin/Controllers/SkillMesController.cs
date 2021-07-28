using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyRezaNabhani.DataLayer.Context;
using MyRezaNabhani.DomainClasses.SkillMe;
using MyRezaNabhani.Services;
using MyRezaNabhani.Services.Repositories;

namespace MyRezaNabhani.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillMesController : Controller
    {
        private ISkillMeRepository _skillMeRepository;

        public SkillMesController(ISkillMeRepository skillMeRepository)
        {
            _skillMeRepository = skillMeRepository;
        }

        [PermissionChecker(10)]
        // GET: Admin/SkillMes
        public async Task<IActionResult> Index()
        {
            return View( _skillMeRepository.GetAllSkillMes());
        }

        // GET: Admin/SkillMes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillMe = _skillMeRepository.GetSkillMeById(id.Value);
            if (skillMe == null)
            {
                return NotFound();
            }

            return View(skillMe);
        }

        [PermissionChecker(11)]
        // GET: Admin/SkillMes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/SkillMes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SkillTitle,AmountSkill")] SkillMe skillMe)
        {
            if (ModelState.IsValid)
            {
                _skillMeRepository.InsertSkillMe(skillMe);
                _skillMeRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(skillMe);
        }

        [PermissionChecker(12)]
        // GET: Admin/SkillMes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillMe = _skillMeRepository.GetSkillMeById(id.Value);
            if (skillMe == null)
            {
                return NotFound();
            }
            return View(skillMe);
        }

        // POST: Admin/SkillMes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SkillTitle,AmountSkill")] SkillMe skillMe)
        {
            if (id != skillMe.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _skillMeRepository.UpdateSkillMe(skillMe);
                    _skillMeRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillMeExists(skillMe.ID))
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
            return View(skillMe);
        }

        [PermissionChecker(13)]
        // GET: Admin/SkillMes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillMe = _skillMeRepository.GetSkillMeById(id.Value);
            if (skillMe == null)
            {
                return NotFound();
            }

            return View(skillMe);
        }

        // POST: Admin/SkillMes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _skillMeRepository.DeleteSkillMe(id);
            _skillMeRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool SkillMeExists(int id)
        {
            return _skillMeRepository.SkillExists(id);
        }
    }
}
