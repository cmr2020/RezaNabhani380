using Microsoft.AspNetCore.Mvc;
using MyRezaNabhani.DomainClasses.AboutMe;
using MyRezaNabhani.Services.Repositories;
using System.Threading.Tasks;

namespace MyRezaNabhani.Web.ViewComponents
{
    public class AboutMeComponent : ViewComponent
    {
        private IAboutMeRepository _aboutMeRepository;

        public AboutMeComponent(IAboutMeRepository aboutMeRepository)
        {
            _aboutMeRepository = aboutMeRepository;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("AboutMeComponent",
               _aboutMeRepository.GetAllAboutMes()));
        }
    }
}
