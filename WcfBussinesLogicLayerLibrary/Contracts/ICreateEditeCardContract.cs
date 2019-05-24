using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfBussinesLogicLayerLibrary.ModelsDTO;

namespace WcfBussinesLogicLayerLibrary.Contracts
{
    [ServiceContract]
    public interface ICreateEditeCardContract
    {
        [OperationContract]
        void AddUser(UserDTO workUser);

        [OperationContract]
        void DeleteUser(UserDTO deleteWorkUser);

        [OperationContract]
        void AddCardName(string name);

        [OperationContract]
        void AddCardDescription(string description);

        [OperationContract]
        void AddCardDate(DateTime date);

        [OperationContract]
        void AddAttachment(string path);

        [OperationContract]
        void DeleteAttachment(string attachment);


    }
}
