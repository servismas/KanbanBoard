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
    public interface ICreateEditeTeamContract
    {
        [OperationContract]
        void AddNewName(string newName);

        [OperationContract]
        void AddUserToTeam(UserDTO user);

        [OperationContract]
        void DeleteUserFromTeam(UserDTO deleteUser);
        
    }
}
