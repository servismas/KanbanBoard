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
    public interface ICreateEditeUserContract
    {
        [OperationContract]
        void AddUser(UserDTO newUser);

        
        [OperationContract]
        void DeleteUser(UserDTO deleteUser);

        [OperationContract]
        void EditeUser(UserDTO editeUser);

        
    }
}
