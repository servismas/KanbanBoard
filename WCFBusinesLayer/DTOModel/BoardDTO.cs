using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFBusinesLayer.DTOModel
{
    public class BoardDTO
    {
        public BoardDTO()
        {
            Columns = new List<ColumnDTO>();
        }
        public int Id { get; set; }
       
        public string Name { get; set; }
        public int? TeamId { get; set; }
        public virtual TeamDTO Team { get; set; }
        public virtual ICollection<ColumnDTO> Columns { get; set; }
    }
}
