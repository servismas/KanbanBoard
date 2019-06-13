using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfBussinesLogicLayerLibrary
{
   public static class LogerClass
    {
        public static void WriteLog(string logTxt)
        {
            using (StreamWriter sr = new StreamWriter("D:\\Logfile\\logTxt.txt", true))
            {
                sr.WriteLine(logTxt);
            }

        }
    }
}
