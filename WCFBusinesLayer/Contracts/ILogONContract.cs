using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFBusinesLayer.DTOModel;

namespace WCFBusinesLayer.Contracts
{
    [ServiceContract]
   public interface ILogONContract
    {   
        
            [OperationContract]
            UserDTO CheckCredationals(string login, string pass);
       
    }
}
