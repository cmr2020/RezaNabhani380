using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyRezaNabhani.DataLayer.Context;
using MyRezaNabhani.DomainClasses.ContactUs;

namespace MyRezaNabhani.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactUsController : Controller
    {
        private readonly MyRezaNabhaniDbContext _context;

        public ContactUsController(MyRezaNabhaniDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ContactUs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactUses.ToListAsync());
        }

        // GET: Admin/ContactUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUs = await _context.ContactUses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contactUs == null)
            {
                return NotFound();
            }

            return View(contactUs);
        }

        // GET: Admin/ContactUs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ContactUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FullName,Email,Subject,Text")] ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactUs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactUs);
        }

        // GET: Admin/ContactUs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUs = await _context.ContactUses.FindAsync(id);
            if (contactUs == null)
            {
                return NotFound();
            }
            return View(contactUs);
        }

        // POST: Admin/ContactUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FullName,Email,Subject,Text")] ContactUs contactUs)
        {
            if (id != contactUs.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactUs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactUsExists(contactUs.ID))
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
            return View(contactUs);
        }

        // GET: Admin/ContactUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUs = await _context.ContactUses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contactUs == null)
            {
                return NotFound();
            }

            return View(contactUs);
        }

        // POST: Admin/ContactUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactUs = await _context.ContactUses.FindAsync(id);
            _context.ContactUses.Remove(contactUs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactUsExists(int id)
        {
            return _context.ContactUses.Any(e => e.ID == id);
        }
    }
}
