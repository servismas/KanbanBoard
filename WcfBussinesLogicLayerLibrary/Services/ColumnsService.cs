﻿using AutoMapper;
using DataAccessLayer.cs.Interfases;
using DataAccessLayer.cs.Models;
using DataAccessLayer.cs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfBussinesLogicLayerLibrary.Contracts;
using WcfBussinesLogicLayerLibrary.ModelsDTO;

namespace WcfBussinesLogicLayerLibrary.Services
{
    public class ColumnsService : ICreateEditColumnsContract
    {
        private readonly IRepository<Board> BoardRepos;
        private readonly IRepository<Column> ColumRepos;

        public ColumnsService(IRepository<Board> _board, IRepository<Column> _column)
        {
            BoardRepos = _board;
            ColumRepos = _column;
        }


        //public void AddCard(CardDTO newCard)
        //{
        //    Mapper.Initialize(cfg => cfg.CreateMap(typeof(CardDTO), typeof(Card)));
        //    Card cardEntyti =(Card) Mapper.Map(newCard, typeof(CardDTO), typeof(Card));
        //    CardRepos.Add(cardEntyti);
        //}

        public void AddNewColumn(ColumnDTO newColumn)
        {
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(ColumnDTO), typeof(Column)));
            Column columnEntyti = (Column)Mapper.Map(newColumn, typeof(ColumnDTO), typeof(Column));
            ColumRepos.Add(columnEntyti);
        }

        public void EditeColumnName(ColumnDTO editColumn)
        {
                                 
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(ColumnDTO), typeof(Column)));
            Column columnEntyti = (Column)Mapper.Map(editColumn, typeof(ColumnDTO), typeof(Column));
            ColumRepos.Edit(columnEntyti);
        }

        public void DeleteColumn(ColumnDTO deleteColumn)
        {
            ColumRepos.Remove(ColumRepos.Find(deleteColumn.Id));
                                              
        }

        
        public List<ColumnDTO> GetColumn(BoardDTO userBoard)
        {
            var boardEntity = BoardRepos.Find(userBoard.Id);
            List<Column> columnsEntity = new List<Column>();
            foreach (var c in boardEntity.Columns)
            {
                columnsEntity.Add(c);
            }

            
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(List<Column>), typeof(List<ColumnDTO>)));
            return (List<ColumnDTO>)Mapper.Map( columnsEntity, typeof(List<Column>), typeof(List<ColumnDTO>));
            
        }

        public ColumnDTO GetColumn(Column column)
        {
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(Column), typeof(ColumnDTO)));
            return (ColumnDTO)Mapper.Map(column, typeof(Column), typeof(ColumnDTO));
        }
    }
}
