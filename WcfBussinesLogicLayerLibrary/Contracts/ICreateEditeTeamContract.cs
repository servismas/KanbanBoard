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
        void CreateNewTeam(TeamDTO newTeam);

        [OperationContract]
        void EditTeam(TeamDTO editTeam);

        [OperationContract]
        void DeleteTeam(TeamDTO deleteTeam);

        [OperationContract]
        List<TeamDTO> GetAllUsersTeams(UserDTO user);
        
    }
}
