using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using WcfBussinesLogicLayerLibrary.ModelsDTO;

namespace PresentationLayer.ViewModels
{
    public class LoginRegistrationViewModel
    {
        //LogOn
        public string Login { get; set; }
        public string Pass { get; set; }
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
                     string heshPass = HeshPass(Pass);
                     CurrentUser = LogOnClient.CheckCredationals(Login, heshPass);   //не хоче чомусь з хеш               
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

        public string HeshPass(string Pass)
        {
            byte[] bytePass = Encoding.ASCII.GetBytes(Pass);
            byte[] heshbyte = SHA512.Create().ComputeHash(bytePass);
            return Encoding.ASCII.GetString(heshbyte);
        }

        //Registration

        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public string Photo { get; set; }
        public string TeamName { get; set; }

        private RelayCommand registration;
        public RelayCommand Registration
        {


            get
            {
                return registration ??
                 (registration = new RelayCommand(obj =>
                 {
                         
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
                     
                 }));
            }


        }

    }
}
