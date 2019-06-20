using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFBusinesLayer.DTOModel
{
   public  class ColumnDTO
    {
        public ColumnDTO()
        {
            Cards = new List<CardDTO>();
        }
        public int Id { get; set; }
       
        public string Name { get; set; }
        public virtual ICollection<CardDTO> Cards { get; set; }
    }
}
