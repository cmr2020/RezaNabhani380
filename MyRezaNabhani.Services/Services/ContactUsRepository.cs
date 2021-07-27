using MyRezaNabhani.DataLayer.Context;
using MyRezaNabhani.DomainClasses.ContactUs;
using MyRezaNabhani.Services.Repositories;
using System;
using System.Collections.Generic;
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
    }
}
