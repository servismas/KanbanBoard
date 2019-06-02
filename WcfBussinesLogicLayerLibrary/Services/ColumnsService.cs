using AutoMapper;
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
        //private readonly IRepository<Card> CardRepos;
        //private readonly IRepository<Column> ColumRepos;
        //public ColumnsService(IRepository<Card> _card, IRepository<Column> _column)
        //{
        //    CardRepos = _card;
        //    ColumRepos = _column;
        //}


        //public void AddCard(CardDTO newCard)
        //{
        //    Mapper.Initialize(cfg => cfg.CreateMap(typeof(CardDTO), typeof(Card)));
        //    Card cardEntyti =(Card) Mapper.Map(newCard, typeof(CardDTO), typeof(Card));
        //    CardRepos.Add(cardEntyti);
        //}

        //public void AddNewColumn(ColumnDTO newColumn)
        //{
        //    Mapper.Initialize(cfg => cfg.CreateMap(typeof(ColumnDTO), typeof(Column)));
        //    Column columnEntyti = (Column)Mapper.Map(newColumn, typeof(ColumnDTO), typeof(Column));
        //    ColumRepos.Add(columnEntyti);
        //}

        //public void DeleteCard(CardDTO deleteCard)
        //{
        //    Mapper.Initialize(cfg => cfg.CreateMap(typeof(CardDTO), typeof(Card)));
        //    Card cardEntyti = (Card)Mapper.Map(deleteCard, typeof(CardDTO), typeof(Card));
        //    CardRepos.Remove(cardEntyti);
        //}

        //public void EditeColumnName(ColumnDTO editColumn)
        //{
        //    Mapper.Initialize(cfg => cfg.CreateMap(typeof(ColumnDTO), typeof(Column)));
        //    Column columnEntyti = (Column)Mapper.Map(editColumn, typeof(ColumnDTO), typeof(Column));
        //    ColumRepos.Add(columnEntyti);
        //}
        public void AddNewColumn(ColumnDTO newColumn)
        {
            throw new NotImplementedException();
        }

        public void DeleteColumn(ColumnDTO deleteColumn)
        {
            throw new NotImplementedException();
        }

        public void EditeColumnName(ColumnDTO editColumn)
        {
            throw new NotImplementedException();
        }

        public List<ColumnDTO> GetColumn(BoardDTO userBoard)
        {
            throw new NotImplementedException();
        }
    }
}
