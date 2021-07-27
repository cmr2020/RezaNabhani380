using MyRezaNabhani.DomainClasses.User;
using MyRezaNabhani.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRezaNabhani.Services.Repositories
{
    public interface IUserRepository
    {
        bool IsExistUserName(string userName);
        bool IsExistEmail(string email);
        int AddUser(User user);
        User LoginUser(LoginViewModel login);
        bool ActiveAccount(string activeCode);
    }
}
