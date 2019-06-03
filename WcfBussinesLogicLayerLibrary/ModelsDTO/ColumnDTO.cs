﻿using DataAccessLayer.cs.Models;
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
            Cards = new List<Card>();
        }
        public int Id { get; set; }
        
        public string Name { get; set; }
        public virtual List<Card> Cards { get; set; }
    }
}
