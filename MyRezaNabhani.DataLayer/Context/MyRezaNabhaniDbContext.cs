using Microsoft.EntityFrameworkCore;
using MyRezaNabhani.DomainClasses.AboutMe;
using MyRezaNabhani.DomainClasses.ContactUs;
using MyRezaNabhani.DomainClasses.Permissions;
using MyRezaNabhani.DomainClasses.SkillMe;
using MyRezaNabhani.DomainClasses.User;
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

        #region User

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        #endregion

        #region Permission

        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }

        #endregion

        #region AboutMes
        public DbSet<AboutMe> AboutMes { get; set; }

        #endregion

        #region SkillMes
        public DbSet<SkillMe> SkillMes { get; set; }
        #endregion

        #region ContactUs

        public DbSet<ContactUs> ContactUses { get; set; }
        #endregion
    }
}
