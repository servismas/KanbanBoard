using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.cs.Models
{
    public class Attachment
    {

        public int Id { get; set; }
        public string Path { get; set; }
        //[Key]
        //[ForeignKey("Card")]
        public int? CardId { get; set; }

        public virtual Card Card { get; set; }
        public override string ToString()
        {
            return System.IO.Path.GetFileName(Path);
        }
    }
}
