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
            foreach (var entUser in UserRepos.GetAll())
            {
                if (entUser.Mail==login)
                {
                    if (entUser.Password==pass)
                    {
                        LogerClass.WriteLog(entUser.Mail + " "+entUser.GetType().ToString());
                        user = AutoMapper.Mapper.Map<UserDTO>(entUser);
                        LogerClass.WriteLog(user.Mail + " " + user.GetType().ToString());
                    }
                }
            }
            LogerClass.WriteLog(user.Mail + " " + user.GetType().ToString());
            return user;
        }
    }
}
