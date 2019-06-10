using AutoMapper;
using Microsoft.Win32;
using PresentationLayer.TeamService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using WcfBussinesLogicLayerLibrary.ModelsDTO;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace PresentationLayer.ViewModels
{
    public class LoginRegistrationViewModel :INotifyPropertyChanged
    {
        public LoginRegistrationViewModel()
        {
           // CreateEditeTeamContractClient teamClient = new CreateEditeTeamContractClient();

           //// TeamDTO[] teamsDTO = teamClient.GetAllTeams();
           // foreach (var team in teamClient.GetAllTeams())
           // {
           //     TeamName.Add(team.Name);
           // }

            
        }



        //LogOn
        public string Login { get; set; }
        public string Pass { get; set; }
        public string HeshPass { get; set; }
        public UserDTO CurrentUser { get; set; }

        private LogONService.LogOnUserContractClient LogOnClient = new LogONService.LogOnUserContractClient();

        private RelayCommand loginOK;
        public RelayCommand LoginOK
        {


            get
            {
                return loginOK ??
                 (loginOK = new RelayCommand(obj =>
                 {
                     Pass = (obj as PasswordBox).Password;
                     HeshPass = CreateHeshPass(Pass);
                     CurrentUser = LogOnClient.CheckCredationals("qwerty@qwerty.com", "�࿬쿢䘰囘燶朗㾨ꋷﱊｴ쐺쬌꤅꽿蟡얂翾邊谮蘷쮥␶荜ഓ倽⩣戜悧緖䤍"); //тестово
                     // CurrentUser = LogOnClient.CheckCredationals(Login, HeshPass);             
                 }));
            }


        }
        
        public bool Check(string Login)
        {
            string mask = @"^\S\w*@\S\w*\.\S\w{2,3}";
            if (Regex.IsMatch(Login, mask, RegexOptions.IgnoreCase))
                return true;
            else
                return false;
        }

        public string CreateHeshPass(string Pass)
        {
            byte[] bytePass = Encoding.Unicode.GetBytes(Pass);
            byte[] heshbyte = SHA512.Create().ComputeHash(bytePass);
            return Encoding.Unicode.GetString(heshbyte);
        }

        //Registration

        public string FirstName { get; set; }
        public string SecondName { get; set; }

        private string photo = "Your Photo";
        public string Photo
        {
            get
            {
                return photo;
            }
            set
            {
                photo = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Photo"));

            }
        }
        public List<string> TeamName { get; set; }

        private RelayCommand registration;
        public RelayCommand Registration
        {


            get
            {
                return registration ??
                 (registration = new RelayCommand(obj =>
                 {
                     UserService.CreateEditeUserContractClient userServiceClient = new UserService.CreateEditeUserContractClient();
                     UserDTO regUser=new UserDTO();
                     regUser.IsDeleted = false;
                     regUser.Mail = Login;
                     regUser.Password = CreateHeshPass(Pass = (obj as PasswordBox).Password);
                     ProfileService.CreateEditeProfileContractClient profileClient = new ProfileService.CreateEditeProfileContractClient();
                     ProfileDTO newProf = new ProfileDTO();

                     newProf.FirstName = FirstName;
                     newProf.SecondName = SecondName;
                     newProf.Photo = Photo;
                     Mapper.Initialize(cfg => cfg.CreateMap(typeof(ProfileDTO), typeof(ProfileDTO)));
                     ProfileDTO prof = (ProfileDTO)Mapper.Map(newProf, typeof(ProfileDTO), typeof(ProfileDTO));
                     Mapper.Reset();
                     profileClient.AddProfile(prof);

                     regUser.Profile = newProf;
                     Mapper.Reset();
                     Mapper.Initialize(cfg => cfg.CreateMap(typeof(UserDTO), typeof(UserDTO)));
                     UserDTO returnList = (UserDTO)Mapper.Map(regUser, typeof(UserDTO), typeof(UserDTO));
                     userServiceClient.AddUser(returnList);
                 }));
            }


        }

        private RelayCommand cancel;
        public RelayCommand Cancel
        {


            get
            {
                return cancel ??
                 (cancel = new RelayCommand(obj =>
                 {
                     Environment.Exit(1);
                 }));
            }


        }

        private RelayCommand addPhoto;

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand AddPhoto
        {


            get
            {
                return addPhoto ??
                 (addPhoto = new RelayCommand(obj =>
                 {
                     OpenFileDialog ofd = new OpenFileDialog();
                     ofd.Filter = "jpg|*.jpg|bmp|*.bmp|png|*.png";
                     DialogResult rez =ofd.ShowDialog();
                     if (rez==DialogResult.OK)
                     {
                         Photo = ofd.FileName;
                     }
                 }));
            }


        }





    }
}
