using MyRezaNabhani.DataLayer.Context;
using MyRezaNabhani.DomainClasses.User;
using MyRezaNabhani.Services.Generator;
using MyRezaNabhani.Services.Repositories;
using MyRezaNabhani.Utilities.Convertor;
using MyRezaNabhani.Utilities.Security;
using MyRezaNabhani.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyRezaNabhani.Services.Services
{
    public class UserRepository : IUserRepository
    {
        private MyRezaNabhaniDbContext _context;

        public UserRepository(MyRezaNabhaniDbContext context)
        {
            _context = context;
        }

        public bool ActiveAccount(string activeCode)
        {
            var user = _context.Users.SingleOrDefault(u => u.ActiveCode == activeCode);
            if (user == null || user.IsActive)
                return false;

            user.IsActive = true;
            user.ActiveCode = NameGenerator.GenerateUniqCode();
            _context.SaveChanges();

            return true;
        }

        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }

        public bool IsExistEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsExistUserName(string userName)
        {
            return _context.Users.Any(u => u.UserName == userName);
        }

        public User LoginUser(LoginViewModel login)
        {
            string hashPassword = PasswordHelper.EncodePasswordMd5(login.Password);
            string email = FixedText.FixEmail(login.Email);
            return _context.Users.SingleOrDefault(u => u.Email == email && u.Password == hashPassword);
        }
    }
}
