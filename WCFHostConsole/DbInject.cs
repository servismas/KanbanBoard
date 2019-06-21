using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.cs.Interfases;
using DataAccessLayer.cs.Repository;
using DataAccessLayer.cs;
using AutoMapper;
using WCFBusinesLayer.DTOModel;
using DataAccessLayer.cs.Models;

namespace WCFHostConsole
{
    public class DbInject : NinjectModule
    {
        public DbInject()
        {
            Mapper.Initialize(cfg =>
            {
                //cfg.CreateMap<AttachmentDTO, Attachment>();
                //cfg.CreateMap<CardDTO, Card>();
                //cfg.CreateMap<ColumnDTO, Column>();
                //cfg.CreateMap<BoardDTO, Board>();
                cfg.CreateMap<UserDTO, User>();
                //cfg.CreateMap<TeamDTO, Team>();
                //cfg.CreateMap<ProfileDTO, DataAccessLayer.cs.Models.Profile>();
            }
           );


        }



        public override void Load()
        {
            Bind(typeof(IRepository<>)).To(typeof(Repository<>)).WithConstructorArgument("_context", new KanbanBoardContext());
        }
    }
}
