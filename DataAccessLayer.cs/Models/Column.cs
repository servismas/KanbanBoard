using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.cs.Models
{
    public class Column
    {
        public Column()
        {
            Cards = new List<Card>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
    }
}
