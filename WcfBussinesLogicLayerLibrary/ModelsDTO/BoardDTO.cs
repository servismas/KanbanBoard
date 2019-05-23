using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfBussinesLogicLayerLibrary.ModelsDTO
{
    public class BoardDTO
    {        
            public int Id { get; set; }
            public string Name { get; set; }
            public  List<TeamDTO> Teams { get; set; }
            public  List<ColumnDTO> Columns { get; set; }
        
    }
}
