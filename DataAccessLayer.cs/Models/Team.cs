using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.cs.Models
{
    public class Team
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? BoardId { get; set; }
        //public virtual Board Board { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
