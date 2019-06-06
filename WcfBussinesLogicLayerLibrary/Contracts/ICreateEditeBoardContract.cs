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
        void CreateBoard(BoardDTO newBoard);

        [OperationContract]
        void DeleteBoard(BoardDTO deleteBoard);

        [OperationContract]
        void EditeBoardName(BoardDTO editBoard);

        [OperationContract]
        List<BoardDTO> GetAllUsersBoards(TeamDTO userTeam);

        [OperationContract]
        BoardDTO GetBoard(Board board);
    }
}
