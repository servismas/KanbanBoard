using DataAccessLayer.cs.Interfases;
using DataAccessLayer.cs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFBusinesLayer.Contracts;
using WCFBusinesLayer.DTOModel;

namespace WCFBusinesLayer.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class LogONService : ILogONContract
    {
        private readonly IRepository<User> UserRepos;
        public LogONService(IRepository<User> _users)
        {
            UserRepos = _users;
        }

        public UserDTO CheckCredationals(string login, string pass)
        {
            UserDTO user = null;
            foreach (User entUser in UserRepos.GetAll())
            {
                if (entUser.Mail==login)
                {
                    if (entUser.Password==pass)
                    {
                        LogerClass.WriteLog(entUser.Mail + " "+entUser.GetType().ToString());

                        user =(UserDTO) AutoMapper.Mapper.Map(entUser, typeof(User), typeof(UserDTO));

                        //user.Id = entUser.Id;
                        //user.IsDeleted = entUser.IsDeleted;
                        //user.Mail = entUser.Mail;
                        //user.Password = entUser.Password;
                        //user.Profile.Id = entUser.Profile.Id;
                        //user.Profile.Photo = entUser.Profile.Photo;
                        //user.Profile.FirstName = entUser.Profile.FirstName;
                        //user.Profile.SecondName = entUser.Profile.SecondName;
                        //user.ProfileId = entUser.ProfileId;
                        //user.TeamId = entUser.TeamId;
                        //user.Teams = null;
                        

                        LogerClass.WriteLog(user.Mail + " " + user.GetType().ToString());
                    }
                }
            }
            LogerClass.WriteLog(user.Mail + " " + user.GetType().ToString());
            return user;
        }
    }
}
