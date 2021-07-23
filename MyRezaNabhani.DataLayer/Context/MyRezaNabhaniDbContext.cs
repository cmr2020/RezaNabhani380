using Microsoft.EntityFrameworkCore;
using MyRezaNabhani.DomainClasses.AboutMe;
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
    }
}
