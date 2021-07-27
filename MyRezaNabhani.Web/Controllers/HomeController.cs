using Microsoft.AspNetCore.Mvc;
using MyRezaNabhani.DomainClasses.ContactUs;
using MyRezaNabhani.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRezaNabhani.Web.Controllers
{
    public class HomeController : SiteBaseController
    {
        private IContactUsRepository _contactUsRepository;

        public HomeController(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }


 
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("contact-us")]
        public async Task<IActionResult> ContactUs()
        {
            return View();
        }


        [HttpPost("contact-us"),ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactUs(ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                var ip = HttpContext.Connection.RemoteIpAddress.ToString();
                await _contactUsRepository.CreateContactUs(contactUs,ip);
                TempData[SuccessMessage] = "پیام شما با موفقیت ارسال شد";
                return RedirectToAction("ContactUs");
            }
            return View();
        }

    }
}
