using AutoMapper;
using DataAccessLayer.cs.Interfases;
using DataAccessLayer.cs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfBussinesLogicLayerLibrary.Contracts;
using WcfBussinesLogicLayerLibrary.ModelsDTO;

namespace WcfBussinesLogicLayerLibrary.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class UserService : ICreateEditeUserContract
    {
        private readonly IRepository<User> UsersRepos;

        public UserService(IRepository<User> _users)
        {
            UsersRepos = _users;
        }

        public void AddUser(UserDTO newUser)
        {
            //LogerClass.WriteLog(newUser.Team.Count.ToString());
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(UserDTO), typeof(User)));
            User userEntyti = (User)Mapper.Map(newUser, typeof(UserDTO), typeof(User));
            //LogerClass.WriteLog(userEntyti.);
            UsersRepos.Add(userEntyti);
        }

        public void DeleteUser(UserDTO deleteUser)
        {
            UsersRepos.Remove(UsersRepos.Find(deleteUser.Id));
        }

        public void EditeUser(UserDTO editeUser)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(UserDTO), typeof(User)));
            User userEntyti = (User)Mapper.Map(editeUser, typeof(UserDTO), typeof(User));
            UsersRepos.Edit(userEntyti);
        }

       
    }
}
