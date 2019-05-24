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
        void AddColumn(ColumnDTO newColumn);

        [OperationContract]
        void DeleteColumn(ColumnDTO deleteColumn);

        [OperationContract]
        void AddUser(UserDTO newUser);

        [OperationContract]
        void DeleteUser(UserDTO deleteUser);

        [OperationContract]
        void EditeBoardName(string newBoardName);
    }
}
