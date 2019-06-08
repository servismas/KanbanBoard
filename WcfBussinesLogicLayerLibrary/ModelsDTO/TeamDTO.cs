using DataAccessLayer.cs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfBussinesLogicLayerLibrary.ModelsDTO
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
        public List<BoardDTO> Boards { get; set; }
        public List<UserDTO> Users { get; set; }

    }
}
