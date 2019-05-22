using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.cs.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection <Board> Boards { get; set; }
    }
}
