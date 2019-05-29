using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfBussinesLogicLayerLibrary.Contracts
{
    [ServiceContract]
    public interface ILogOnUserContract
    {
        [OperationContract]
        bool CheckCredationals(string login, string pass);

        string HashPass(string pass);

    }
}
