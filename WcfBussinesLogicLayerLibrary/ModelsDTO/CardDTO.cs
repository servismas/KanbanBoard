using DataAccessLayer.cs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfBussinesLogicLayerLibrary.ModelsDTO
{
    public class CardDTO
    {
        public CardDTO()
        {
            Attachments = new List<AttachmentDTO>();
            Users = new List<UserDTO>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? ColumnId { get; set; }
        public ColumnDTO Column { get; set; }
        public List<AttachmentDTO> Attachments { get; set; }
        public List<UserDTO> Users { get; set; }
    }
}
