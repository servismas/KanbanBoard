using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.cs.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
        public string Photo { get; set; }
        public bool IsDeleted { get; set; }
        public int? TeamId { get; set; }
        //public virtual Team Team { get; set; }
    }
}
