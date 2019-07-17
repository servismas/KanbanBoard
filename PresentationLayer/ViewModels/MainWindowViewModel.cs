using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using WcfBussinesLogicLayerLibrary.ModelsDTO;

namespace PresentationLayer.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(UserDTO user)
        {
            Email = "E-mail: " + user.Mail;
            FirstName = "Name: " + user.Profile.FirstName;
            SecondName = "Surname: " + user.Profile.SecondName;

            BoardName = "Board";
            //Photo = new BitmapImage(new Uri(user.Profile.Photo));

            MainUser = user;
            GetBoard(MainUser);
        }
        private UserDTO MainUser { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        //public string Photo { get; set; }

        public string Email { get; set; }
        public string BoardName { get; set; }
        public BitmapImage Photo { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void GetBoard(UserDTO user)
        {
            TeamService.CreateEditeTeamContractClient teamClient = new TeamService.CreateEditeTeamContractClient();
            List<TeamDTO> teamList = new List<TeamDTO>();
            foreach (var tm in teamClient.GetAllUsersTeams(user))
            {
                teamList.Add(tm);
            }

            BoardService.CreateEditeBoardContractClient boardClient = new BoardService.CreateEditeBoardContractClient();

            
            List<BoardDTO> boardList = new List<BoardDTO>();
            foreach (var br in boardClient.GetAllUsersBoards(teamList[teamList.Count]))
            {
                boardList.Add(br);
            }

            BoardName = boardList[boardList.Count].Name;
        }
    }
}
