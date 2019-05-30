﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.cs.Models
{
    public class Board
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? TeamId { get; set; }
        //public virtual Team Team { get; set; }
        public virtual ICollection<Column> Columns { get; set; }
    }
}
