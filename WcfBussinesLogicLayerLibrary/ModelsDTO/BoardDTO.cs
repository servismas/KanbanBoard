using DataAccessLayer.cs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfBussinesLogicLayerLibrary.ModelsDTO
{
    public class BoardDTO
    {
        public BoardDTO()
        {
            Columns = new List<Column>();
        }
        public int Id { get; set; }
       
        public string Name { get; set; }
        public int? TeamId { get; set; }
        public Team Team { get; set; }
        public List<Column> Columns { get; set; }

    }
}
