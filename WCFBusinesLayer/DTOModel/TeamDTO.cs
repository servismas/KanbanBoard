using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFBusinesLayer.DTOModel
{
    public class TeamDTO
    {
        public TeamDTO()
        {
            Users = new List<UserDTO>();
            Boards = new List<BoardDTO>();
        }
        public int Id { get; set; }
      
        public string Name { get; set; }
        public virtual ICollection<BoardDTO> Boards { get; set; }
        public virtual ICollection<UserDTO> Users { get; set; }
    }
}
