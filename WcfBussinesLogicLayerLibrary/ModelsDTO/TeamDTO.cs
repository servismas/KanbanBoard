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
            Users = new List<User>();
            Boards = new List<Board>();
        }
        public int Id { get; set; }

        public string Name { get; set; }
        public virtual List<Board> Boards { get; set; }
        public virtual List<User> Users { get; set; }

    }
}
