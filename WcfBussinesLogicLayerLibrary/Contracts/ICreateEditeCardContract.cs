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
        void CreateCard(CardDTO newCard);

        [OperationContract]
        void EditeCard(CardDTO editCard);

        [OperationContract]
        void DeleteCard(CardDTO deleteCard);

        [OperationContract]
        List<CardDTO> GetAllColumnCards(ColumnDTO column);


    }
}
