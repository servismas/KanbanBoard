using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.cs.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Column> Columns { get; set; }
    }
}
