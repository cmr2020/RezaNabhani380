using Microsoft.EntityFrameworkCore;
using MyRezaNabhani.DataLayer.Context;
using MyRezaNabhani.DomainClasses.ContactUs;
using MyRezaNabhani.Services.Repositories;
using MyRezaNabhani.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRezaNabhani.Services.Services
{
    public class ContactUsRepository : IContactUsRepository
    {
        private MyRezaNabhaniDbContext _dbset;

        public ContactUsRepository(MyRezaNabhaniDbContext dbset)
        {
            _dbset = dbset;
        }


        public async Task CreateContactUs(ContactUs contactUs, string userIp)
        {
            await _dbset.AddAsync(contactUs);
            await _dbset.SaveChangesAsync();
        }

        public IEnumerable<ContactUsViewModel> GetInformationMaster()
        {
            return _dbset.ContactUses.Select(p => new ContactUsViewModel()
            {
                FullName = p.FullName,
                Email = p.Email,
                Subject = p.Subject,
                Text = p.Text,
                Address = _dbset.AboutMes.SingleOrDefault(c => c.ID == p.ID).Address,
                EmailMaster = _dbset.AboutMes.SingleOrDefault(c => c.ID == p.ID).Email,
                Phone = _dbset.AboutMes.SingleOrDefault(c => c.ID == p.ID).Phone
            }).ToList();
        }
    }
}
