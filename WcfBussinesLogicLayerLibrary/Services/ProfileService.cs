﻿using AutoMapper;
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
using Profile = DataAccessLayer.cs.Models.Profile;

namespace WcfBussinesLogicLayerLibrary.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ProfileService : ICreateEditeProfileContract
    {
       
        private readonly IRepository<DataAccessLayer.cs.Models.Profile> ProfileRepos;
        

        public ProfileService(IRepository<Profile> _profile)
        {
            ProfileRepos = _profile;            
        }

        public void AddProfile(ProfileDTO newProfile)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(ProfileDTO), typeof(Profile)));
            Profile profileEntyti = (Profile)Mapper.Map(newProfile, typeof(ProfileDTO), typeof(Profile));
            ProfileRepos.Add(profileEntyti);
        }

        public void EditeProfile(ProfileDTO editeProfile)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(ProfileDTO), typeof(Profile)));
            Profile profileEntyti = (Profile)Mapper.Map(editeProfile, typeof(ProfileDTO), typeof(Profile));
            ProfileRepos.Edit(profileEntyti);
        }

        public Profile GetProfile(ProfileDTO profileDTO)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(ProfileDTO), typeof(Profile)));
            return (Profile)Mapper.Map(profileDTO, typeof(ProfileDTO), typeof(Profile));
        }

        public ProfileDTO GetProfileDTO(Profile profile)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(Profile), typeof(ProfileDTO)));
            return (ProfileDTO)Mapper.Map(profile, typeof(Profile), typeof(ProfileDTO));
        }
    }
}
