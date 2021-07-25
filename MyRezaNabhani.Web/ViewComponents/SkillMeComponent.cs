using Microsoft.AspNetCore.Mvc;
using MyRezaNabhani.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRezaNabhani.Web.ViewComponents
{
    public class SkillMeComponent:ViewComponent
    {
        private ISkillMeRepository _skillMeRepository;

        public SkillMeComponent(ISkillMeRepository skillMeRepository)
        {
            _skillMeRepository = skillMeRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("SkillMeComponent",
               _skillMeRepository.GetAllSkillMes()));
        }

    }
}
