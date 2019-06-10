using DataAccessLayer.cs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfBussinesLogicLayerLibrary.ModelsDTO
{
    public class ColumnDTO
    {
        public ColumnDTO()
        {
            Cards = new List<CardDTO>();
        }
        public int Id { get; set; }
        
        public string Name { get; set; }
        public List<CardDTO> Cards { get; set; }
    }
}
