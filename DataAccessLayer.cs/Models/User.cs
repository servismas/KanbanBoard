using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.cs.Models
{
    public class User
    {
        public User()
        {
            Teams = new List<Team>();
        }
        public int Id { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
        public bool? IsDeleted { get; set; }
        //[Key]
        [ForeignKey("Profile")]
        public int? ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
        public int? TeamId { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
