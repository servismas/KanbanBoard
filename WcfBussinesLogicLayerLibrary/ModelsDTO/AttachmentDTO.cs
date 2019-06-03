using DataAccessLayer.cs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfBussinesLogicLayerLibrary.ModelsDTO
{
    public class AttachmentDTO
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int? CardId { get; set; }

        public Card Card { get; set; }
    }
}
