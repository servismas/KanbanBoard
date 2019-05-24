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
        void AddUserName(string email);

        bool ValidUserMail(string email); //внутрішній метод на зовні не віддаєм

        [OperationContract]
        void AdduserPass(string pas);

        string EncodePass(string pas); //внутрішній метод на зовні не віддаєм

        [OperationContract]
        void ChangePhoto(string newPhoto);

        [OperationContract]
        void ChangeDeleteFlag(UserDTO user);

        [OperationContract]
        void JoinToBoard(BoardDTO newBoard);

        [OperationContract]
        void UnsubscribeFromBoard(BoardDTO oldBoard);

    }
}
