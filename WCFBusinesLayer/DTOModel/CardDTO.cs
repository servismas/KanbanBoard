using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFBusinesLayer.DTOModel
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
        public virtual ColumnDTO Column { get; set; }
        public virtual ICollection<AttachmentDTO> Attachments { get; set; }
        public virtual ICollection<UserDTO> Users { get; set; }
    }
}
