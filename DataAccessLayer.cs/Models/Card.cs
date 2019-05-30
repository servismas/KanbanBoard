using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.cs.Models
{
    public class Card
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public DateTime ExpireDate { get; set; }
        public int? ColumnId { get; set; }
        //public virtual Column Column { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
