using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfBussinesLogicLayerLibrary.Contracts;
using System.Security.Cryptography;
using System.ServiceModel;
using WcfBussinesLogicLayerLibrary.ModelsDTO;
using DataAccessLayer.cs.Models;
using DataAccessLayer.cs.Interfases;
using AutoMapper;

namespace WcfBussinesLogicLayerLibrary.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class LogOn : ILogOnUserContract
    {
        private readonly IRepository<User> UserRepos;

        public LogOn(IRepository<User> _users)
        {
            UserRepos = _users;
        }

        UserDTO ILogOnUserContract.CheckCredationals(string login, string pass)
        {
            User userEntity = null;
            UserDTO currentUser = null;
            foreach (var us in UserRepos.GetAll())
            {
                if (us.Mail==login)
                {
                    if (us.Password==pass)
                    {
                        userEntity = UserRepos.Find(us.Id);
                    }
                   
                }
            }

            if (userEntity != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap(typeof(User), typeof(UserDTO)));
                currentUser = (UserDTO)Mapper.Map(userEntity, typeof(User), typeof(UserDTO));
            }       
            
            return currentUser;
        }
    }
}
