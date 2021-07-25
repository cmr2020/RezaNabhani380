using MyRezaNabhani.DomainClasses.SkillMe;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRezaNabhani.Services.Repositories
{
    public interface ISkillMeRepository
    {
        List<SkillMe> GetAllSkillMes();

        SkillMe GetSkillMeById(int skillId);
        void InsertSkillMe(SkillMe skillMe);
        void UpdateSkillMe(SkillMe skillMe);
        void DeleteSkillMe(SkillMe skillMe);
        void DeleteSkillMe(int skillId);
        bool SkillExists(int skillId);
        void Save();


    }
}
