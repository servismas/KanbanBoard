using AutoMapper;
using DataAccessLayer.cs.Interfases;
using DataAccessLayer.cs.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFBusinesLayer.DTOModel;
using WCFBusinesLayer.Services;

namespace WCFHostConsole
{
    class Program
    {

        static void Main(string[] args)
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




            var kernel = new StandardKernel(new DbInject());
            var repsitoryCard = kernel.Get<IRepository<Card>>();
            var repsitoryColumn = kernel.Get<IRepository<Column>>();
            var repsitoryBoard = kernel.Get<IRepository<Board>>();
            var repsitoryUser = kernel.Get<IRepository<User>>();
            var repsitoryTeam = kernel.Get<IRepository<Team>>();
            var repsitoryAttach = kernel.Get<IRepository<Attachment>>();
            var repsitoryProfile = kernel.Get<IRepository<DataAccessLayer.cs.Models.Profile>>();

            
            //AttachmentService attachmentService = new AttachmentService(repsitoryAttach, repsitoryCard);
            //BoardService boardtService = new BoardService(repsitoryBoard, repsitoryTeam, repsitoryUser);
            //CardService cardService = new CardService(repsitoryCard, repsitoryColumn);
            //ColumnsService columnsService = new ColumnsService(repsitoryBoard, repsitoryColumn);
            LogONService logOn = new LogONService(repsitoryUser);
            //ProfileService profileService = new ProfileService(repsitoryProfile);
            //TeamService teamService = new TeamService(repsitoryTeam, repsitoryUser);
            //UserService userService = new UserService(repsitoryUser);

            try
            {

                //ServiceHost attachHost = new ServiceHost(attachmentService);
                //attachHost.Open();
                //Console.WriteLine("Attachment Service started successfully!");

                //ServiceHost boardHost = new ServiceHost(boardtService);
                //boardHost.Open();
                //Console.WriteLine("Board Service started successfully!");

                //ServiceHost cardHost = new ServiceHost(cardService);
                //cardHost.Open();
                //Console.WriteLine("Card Service started successfully!");

                //ServiceHost columnHost = new ServiceHost(columnsService);
                //columnHost.Open();
                //Console.WriteLine("Column Service started successfully!");

                ServiceHost logOnHost = new ServiceHost(logOn);
                logOnHost.Open();
                Console.WriteLine("LogON Service started successfully!");

                //ServiceHost profileHost = new ServiceHost(profileService);
                //profileHost.Open();
                //Console.WriteLine("Profile Service started successfully!");

                //ServiceHost teamHost = new ServiceHost(teamService);
                //teamHost.Open();
                //Console.WriteLine("Team Service started successfully!");

                //ServiceHost userHost = new ServiceHost(userService);
                //userHost.Open();

                //Console.WriteLine("User Service started successfully!");

                Console.ReadLine();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops!!!!!!!!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
