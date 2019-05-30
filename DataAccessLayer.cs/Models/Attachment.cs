using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.cs.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int? CardId { get; set; }

        //public virtual Card Card { get; set; }
    }
}
