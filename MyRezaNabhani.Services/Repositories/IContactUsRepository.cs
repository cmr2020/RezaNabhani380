using MyRezaNabhani.DomainClasses.ContactUs;
using MyRezaNabhani.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyRezaNabhani.Services.Repositories
{
    public interface IContactUsRepository
    {

        Task CreateContactUs(ContactUs contactUs, string userIp);

        IEnumerable<ContactUsViewModel> GetInformationMaster();

    }
}
