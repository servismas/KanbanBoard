using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFBusinesLayer.DTOModel
{
    public class UserDTO
    {
        public UserDTO()
        {
            Teams = new List<TeamDTO>();
        }
        public int Id { get; set; }
       
        public string Mail { get; set; }
       
        public string Password { get; set; }
        public bool? IsDeleted { get; set; }

        public int? ProfileId { get; set; }
        public virtual ProfileDTO Profile { get; set; }
        public int? TeamId { get; set; }
        public virtual ICollection<TeamDTO> Teams { get; set; }
    }
}
