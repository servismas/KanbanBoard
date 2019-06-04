using DataAccessLayer.cs.Models;
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
    public interface ICreateEditeBoardContract
    {
        [OperationContract]
        void CreateBoard(AttachmentdDTO newBoard);

        [OperationContract]
        void DeleteBoard(AttachmentdDTO deleteBoard);

        [OperationContract]
        void EditeBoardName(AttachmentdDTO editBoard);

        [OperationContract]
        List<AttachmentdDTO> GetAllUsersBoards(TeamDTO userTeam);

        [OperationContract]
        AttachmentdDTO GetBoard(Board board);
    }
}
