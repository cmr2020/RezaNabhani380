using Microsoft.EntityFrameworkCore;
using MyRezaNabhani.DataLayer.Context;
using MyRezaNabhani.DomainClasses.SkillMe;
using MyRezaNabhani.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyRezaNabhani.Services.Services
{
    public class SkillMeRepository : ISkillMeRepository
    {
        private MyRezaNabhaniDbContext _db;

        public SkillMeRepository(MyRezaNabhaniDbContext db)
        {
            _db = db;
        }


        public List<SkillMe> GetAllSkillMes()
        {
            return _db.SkillMes.ToList();
        }

        public SkillMe GetSkillMeById(int skillId)
        {
            return _db.SkillMes.Find(skillId);
        }

        public void InsertSkillMe(SkillMe skillMe)
        {
            _db.SkillMes.Add(skillMe);
        }

        public void UpdateSkillMe(SkillMe skillMe)
        {
            _db.Entry(skillMe).State = EntityState.Modified;
        }

        public void DeleteSkillMe(SkillMe skillMe)
        {
            _db.Entry(skillMe).State = EntityState.Deleted;
        }

        public void DeleteSkillMe(int skillId)
        {
            var skill = GetSkillMeById(skillId);
            DeleteSkillMe(skill);
        }

        public bool SkillExists(int skillId)
        {
            return _db.SkillMes.Any(p => p.ID == skillId);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

       

       
    }
}
