using MyRezaNabhani.DomainClasses.AboutMe;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRezaNabhani.Services.Repositories
{
    public interface IAboutMeRepository
    {
        List<AboutMe> GetAllAboutMes();
      
        AboutMe GetAboutMeById(int aboutId);
        void InsertAboutMe(AboutMe aboutMe);
        void UpdateAboutMe(AboutMe aboutMe);
        void DeleteAboutMe(AboutMe aboutMe);
        void DeleteAboutMe(int aboutId);
        bool AboutExists(int aboutId);
        void Save();
    }
}
