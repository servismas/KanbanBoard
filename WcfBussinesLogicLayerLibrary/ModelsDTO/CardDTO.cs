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
            Attachments = new List<Attachment>();
            Users = new List<User>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? ColumnId { get; set; }
        public virtual Column Column { get; set; }
        public virtual List<Attachment> Attachments { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
