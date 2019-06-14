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
   public  class MainWindowViewModel:INotifyPropertyChanged
    {
        public MainWindowViewModel(UserDTO user)
        {
            Email ="E-mail: "+user.Mail;
            FirstName = "Name: "+user.Profile.FirstName;
            SecondName ="Surname: " + user.Profile.SecondName;

            BoardName = "TestBoard";
            Photo = new BitmapImage(new Uri(user.Profile.Photo));
        }
       // public string MainUser { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        //public string Photo { get; set; }

        public string Email { get; set; }
        public string BoardName { get; set; }
        public BitmapImage Photo { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
