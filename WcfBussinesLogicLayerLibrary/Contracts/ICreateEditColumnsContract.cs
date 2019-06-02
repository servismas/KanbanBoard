﻿using System;
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
        void EditeColumnName(ColumnDTO editColumn);

        [OperationContract]
        void DeleteColumn(ColumnDTO deleteColumn);

        [OperationContract]
        List<ColumnDTO> GetColumn(BoardDTO userBoard);

    }
}
