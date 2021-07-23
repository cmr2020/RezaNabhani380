using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyRezaNabhani.DataLayer.Context;
using MyRezaNabhani.DomainClasses.AboutMe;
using MyRezaNabhani.Services.Repositories;

namespace MyRezaNabhani.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutMesController : Controller
    {

        private IAboutMeRepository _aboutMeRepository;

        public AboutMesController(IAboutMeRepository aboutMeRepository)
        {
            _aboutMeRepository = aboutMeRepository;
        }


        // GET: Admin/AboutMes
        public  IActionResult Index()
        {
          
            return View(_aboutMeRepository.GetAllAboutMes());
        }

        // GET: Admin/AboutMes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutMe = _aboutMeRepository.GetAboutMeById(id.Value);

            if (aboutMe == null)
            {
                return NotFound();
            }

            return View(aboutMe);
        }

        // GET: Admin/AboutMes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AboutMes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FullName,Age,Address,Email,Phone,Status,Description,Avatar,CreateDate")] AboutMe aboutMe, IFormFile imgup)
        {
            if (ModelState.IsValid)
            {
                aboutMe.CreateDate = DateTime.Now;

                if (imgup != null)
                {
                    aboutMe.Avatar = Guid.NewGuid().ToString() + Path.GetExtension(imgup.FileName);
                    string savePath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/AboutImages", aboutMe.Avatar
                    );

                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                       await imgup.CopyToAsync(stream);
                    }

                }

                _aboutMeRepository.InsertAboutMe(aboutMe);
                _aboutMeRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(aboutMe);
        }

        // GET: Admin/AboutMes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutMe =  _aboutMeRepository.GetAboutMeById(id.Value);
            if (aboutMe == null)
            {
                return NotFound();
            }
            return View(aboutMe);
        }

        // POST: Admin/AboutMes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FullName,Age,Address,Email,Phone,Status,Description,Avatar,CreateDate")] AboutMe aboutMe, IFormFile imgup)
        {
            //if (id != aboutMe.ID)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    if (imgup != null)
                    {

                        if (aboutMe.Avatar == null)
                        {
                            aboutMe.Avatar = Guid.NewGuid().ToString() + Path.GetExtension(imgup.FileName);
                        }

                        string savePath = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot/AboutImages", aboutMe.Avatar
                        );
                        var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AboutImages", aboutMe.Avatar);
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                        using (var stream = new FileStream(savePath, FileMode.Create))
                        {
                            await imgup.CopyToAsync(stream);
                        }

                    }
                    _aboutMeRepository.UpdateAboutMe(aboutMe);
                    _aboutMeRepository.Save();
                
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutMeExists(aboutMe.ID))
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
            return View(aboutMe);
        }

        // GET: Admin/AboutMes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutMe = _aboutMeRepository.GetAboutMeById(id.Value);
            if (aboutMe == null)
            {
                return NotFound();
            }

            return View(aboutMe);
        }

        // POST: Admin/AboutMes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _aboutMeRepository.DeleteAboutMe(id);
            _aboutMeRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutMeExists(int id)
        {
            return _aboutMeRepository.AboutExists(id);
        }
    }
}
