using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using WCFBusinesLayer.DTOModel;


namespace PresentationLayer.ViewModels
{
   public  class MainWindowViewModel:INotifyPropertyChanged
    {
        public MainWindowViewModel(UserDTO user)
        {
            Email ="E-mail: "+user.Mail;
            FirstName = "Name: "+user.Profile.FirstName;
            SecondName ="Surname: " + user.Profile.SecondName;

            BoardName = "TestBoard";
            Photo = new BitmapImage(new Uri(user.Profile.Photo));

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
          //  PresentationLayer.BoardService.CreateEditeBoardContractClient boardClient = new BoardService.CreateEditeBoardContractClient();
           // boardClient.GetCurrentUserBoard(user);
        }

    }
}
