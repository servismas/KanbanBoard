using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFBusinesLayer.DTOModel
{
    public class AttachmentDTO
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int? CardId { get; set; }

        public virtual CardDTO Card { get; set; }
    }
}
