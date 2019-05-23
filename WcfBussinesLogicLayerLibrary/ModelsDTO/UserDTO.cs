using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfBussinesLogicLayerLibrary.ModelsDTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public bool IsDeleted { get; set; }
        public List<BoardDTO> Boards { get; set; }
    }
}
