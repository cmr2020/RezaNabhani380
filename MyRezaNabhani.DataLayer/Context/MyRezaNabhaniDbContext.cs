using Microsoft.EntityFrameworkCore;
using MyRezaNabhani.DomainClasses.AboutMe;
using MyRezaNabhani.DomainClasses.ContactUs;
using MyRezaNabhani.DomainClasses.SkillMe;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRezaNabhani.DataLayer.Context
{
    public class MyRezaNabhaniDbContext:DbContext
    {

        public MyRezaNabhaniDbContext(DbContextOptions<MyRezaNabhaniDbContext> options):base(options)
        {

        }


        public DbSet<AboutMe> AboutMes { get; set; }
        public DbSet<SkillMe> SkillMes { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
    }
}
