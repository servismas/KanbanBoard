using AutoMapper;
using DataAccessLayer.cs.Interfases;
using DataAccessLayer.cs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfBussinesLogicLayerLibrary.Contracts;
using WcfBussinesLogicLayerLibrary.ModelsDTO;

namespace WcfBussinesLogicLayerLibrary.Services
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class AttachmentService : ICreateEditAttachmentContract
    {

        private readonly IRepository<Attachment> AttachmentRepos;
        private readonly IRepository<Card> CardRepos;

        public AttachmentService(IRepository<Attachment> _attachment, IRepository<Card> _card)
        {
            AttachmentRepos = _attachment;
            CardRepos = _card;
        }
        public void AddNewAttachment(AttachmentDTO newAttachment)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(AttachmentDTO), typeof(Attachment)));
            Attachment attachmentEntyti = (Attachment)Mapper.Map(newAttachment, typeof(AttachmentDTO), typeof(Attachment));
            AttachmentRepos.Add(attachmentEntyti);
        }

        public void DeleteAtachment(AttachmentDTO deleteAtachment)
        {
            AttachmentRepos.Remove(AttachmentRepos.Find(deleteAtachment.Id));
        }

       
        public AttachmentDTO GetAttachmentDTO(Attachment attachment)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(Attachment), typeof(AttachmentDTO)));
            return (AttachmentDTO)Mapper.Map(attachment, typeof(Attachment), typeof(AttachmentDTO));
        }

        
        public List<AttachmentDTO> GetAttachments(CardDTO card)
        {
            Card cardEntity = CardRepos.Find(card.Id);
            List<Attachment> attachments = new List<Attachment>();
            foreach (var a in cardEntity.Attachments)
            {
                attachments.Add(a);
            }
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(Attachment), typeof(AttachmentDTO));
            return (List<AttachmentDTO>)Mapper.Map(attachments, typeof(List<Attachment>), typeof(List<AttachmentDTO>));
        }
    }
}
