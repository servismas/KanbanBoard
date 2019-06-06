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
    public class TeamService : ICreateEditeTeamContract
    {
        private readonly IRepository<Team> TeamRepos;
        private readonly IRepository<User> UsersRepos;

        public TeamService(IRepository<Team> _team, IRepository<User> _users)
        {
            TeamRepos = _team;
            UsersRepos = _users;
        }

        public void CreateNewTeam(TeamDTO newTeam)
        {
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(TeamDTO), typeof(Team)));
            Team teamEntyti = (Team)Mapper.Map(newTeam, typeof(TeamDTO), typeof(Team));
            TeamRepos.Add(teamEntyti);
        }

        public void DeleteTeam(TeamDTO deleteTeam)
        {
            TeamRepos.Remove(TeamRepos.Find(deleteTeam.Id));
        }

        public void EditTeam(TeamDTO editTeam)
        {
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(TeamDTO), typeof(Team)));
            Team teamEntyti = (Team)Mapper.Map(editTeam, typeof(TeamDTO), typeof(Team));
            TeamRepos.Edit(teamEntyti);
        }

        public List<TeamDTO> GetAllUsersTeams(UserDTO user)
        {
            User userEntity = UsersRepos.Find(user.Id);
            List<Team> teams = new List<Team>();
            foreach (var t in userEntity.Teams)           //написано під можливість декількох команд
            {
                teams.Add(t);
            }

            Mapper.Initialize(cfg => cfg.CreateMap(typeof(List<Team>), typeof(List<TeamDTO>)));
            return (List<TeamDTO>)Mapper.Map(teams, typeof(List<Team>), typeof(List<TeamDTO>));
        }
    }
}
