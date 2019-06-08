using DataAccessLayer.cs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfBussinesLogicLayerLibrary.ModelsDTO
{
    public class UserDTO
    {
        public UserDTO()
        {
            Team =new List<TeamDTO>();
        }

        public int Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool? IsDeleted { get; set; }
        public int? ProfileId { get; set; }
        public ProfileDTO Profile { get; set; }
        public int? TeamId { get; set; }
        public  List<TeamDTO> Team { get; set; }
    }
}
