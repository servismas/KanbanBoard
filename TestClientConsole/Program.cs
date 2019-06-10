using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestClientConsole.AttachmentServiceReference;
using TestClientConsole.BoardServiceReference;
using TestClientConsole.CardServiceReference;
using TestClientConsole.ColumnServiceReference;
using TestClientConsole.LogOnServiceReference;
using TestClientConsole.ProFileServiceReference;
using TestClientConsole.TeamServiceReference;
using TestClientConsole.UserServiceReference;
using BoardDTO = TestClientConsole.BoardServiceReference.BoardDTO;
using TeamDTO = TestClientConsole.TeamServiceReference.TeamDTO;
//using TeamDTO = TestClientConsole.BoardServiceReference.TeamDTO;
using UserDTO = TestClientConsole.TeamServiceReference.UserDTO;
//using UserDTO = TestClientConsole.UserServiceReference.UserDTO;

namespace TestClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateEditColumnsContractClient    columnClient      =  new CreateEditColumnsContractClient();
            CreateEditeBoardContractClient     boardClient       =  new CreateEditeBoardContractClient();
            CreateEditeCardContractClient      cardClient        =  new CreateEditeCardContractClient();
            CreateEditeTeamContractClient      teamClient        =  new CreateEditeTeamContractClient();
            CreateEditeUserContractClient      userClient        =  new CreateEditeUserContractClient();
            CreateEditeProfileContractClient   profileClient     =  new CreateEditeProfileContractClient();
            CreateEditAttachmentContractClient attachmentClient  =  new CreateEditAttachmentContractClient();
            LogOnUserContractClient            logOnUserClient   =  new LogOnUserContractClient();

            UserDTO user = new UserDTO { Id = 1, Mail = "qwerty@qwerty.com", Password = "qwerty" };
            TeamDTO teamDTO = new TeamDTO();
            BoardDTO boardDTO = new BoardDTO();
            teamDTO = teamClient.GetAllUsersTeams(user).Last();
            //List < TeamDTO > = new List<TeamDTO>();
            boardDTO = teamDTO.Boards.Last();

            boardClient.GetBoard()
            columnClient.GetColumn();

            //cardClient.GetAllColumnCards()
        }
    }
}
