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
        public Team()
        {
            Users = new List<User>();
            Boards = new List<Board>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Board> Boards { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
