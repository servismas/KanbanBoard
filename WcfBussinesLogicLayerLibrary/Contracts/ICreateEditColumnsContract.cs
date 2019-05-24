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
    public interface ICreateEditColumnsContract
    {
        [OperationContract]
        void AddNewColumn(ColumnDTO newColumn);
        [OperationContract]
        void EditeColumnName(ColumnDTO editColumn, string newName);

        [OperationContract]
        void AddCard(CardDTO newCard);
        [OperationContract]
        void DeleteCard(CardDTO deleteCard);
    }
}
