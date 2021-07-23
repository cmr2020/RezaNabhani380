using Microsoft.EntityFrameworkCore;
using MyRezaNabhani.DataLayer.Context;
using MyRezaNabhani.DomainClasses.AboutMe;
using MyRezaNabhani.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyRezaNabhani.Services.Services
{
    public class AboutMeRepository : IAboutMeRepository
    {
        private MyRezaNabhaniDbContext _db;

        public AboutMeRepository(MyRezaNabhaniDbContext db)
        {
            _db = db;
        }

        public List<AboutMe> GetAllAboutMes()
        {
            return _db.AboutMes.ToList();
        }

        public AboutMe GetAboutMeById(int aboutId)
        {
            return _db.AboutMes.Find(aboutId);
        }

        public void InsertAboutMe(AboutMe aboutMe)
        {
           _db.AboutMes.Add(aboutMe);
        }

        public void UpdateAboutMe(AboutMe aboutMe)
        {
            _db.Entry(aboutMe).State = EntityState.Modified;
        }


        public void DeleteAboutMe(AboutMe aboutMe)
        {
            _db.Entry(aboutMe).State = EntityState.Deleted;
        }

        public void DeleteAboutMe(int aboutId)
        {
            var about = GetAboutMeById(aboutId);
            DeleteAboutMe(about);
        }

              

        public void Save()
        {
            _db.SaveChanges();
        }

        public bool AboutExists(int aboutId)
        {
            return _db.AboutMes.Any(p => p.ID == aboutId);
        }
    }
}
