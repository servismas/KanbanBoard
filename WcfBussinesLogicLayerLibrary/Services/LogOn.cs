using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfBussinesLogicLayerLibrary.Contracts;
using System.Security.Cryptography;

namespace WcfBussinesLogicLayerLibrary.Services
{
    public class LogOn : ILogOnUserContract
    {
        public bool CheckCredationals(string login, string pass)
        {
            
            return true;
            
        }

        public string HashPass(string pass)
        {
            byte[] bytePass = Encoding.Unicode.GetBytes(pass);  
            return SHA512.Create().ComputeHash(bytePass).ToString();
        }
    }
}
