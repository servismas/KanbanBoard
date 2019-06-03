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
    interface ICreateEditAttachmentContract
    {
        [OperationContract]
        void AddNewAttachment(AttachmentDTO newAtachment);
        [OperationContract]
        void DeleteAtachment(AttachmentDTO deleteAtachment);
        [OperationContract]
        List<AttachmentDTO> GetAttachments(CardDTO card);
        [OperationContract]
        AttachmentDTO GetAttachment(Attachment attachment);


    }
}
