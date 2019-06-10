using AutoMapper;
using DataAccessLayer.cs.Interfases;
using DataAccessLayer.cs.Models;
using DataAccessLayer.cs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfBussinesLogicLayerLibrary.Contracts;
using WcfBussinesLogicLayerLibrary.ModelsDTO;

namespace WcfBussinesLogicLayerLibrary.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ColumnsService : ICreateEditColumnsContract
    {
        private readonly IRepository<Board> BoardRepos;
        private readonly IRepository<Column> ColumRepos;

        public ColumnsService(IRepository<Board> _board, IRepository<Column> _column)
        {
            BoardRepos = _board;
            ColumRepos = _column;
        }
                       

        public void AddNewColumn(ColumnDTO newColumn)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(ColumnDTO), typeof(Column)));
            Column columnEntyti = (Column)Mapper.Map(newColumn, typeof(ColumnDTO), typeof(Column));
            ColumRepos.Add(columnEntyti);
        }

        public void EditeColumnName(ColumnDTO editColumn)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(ColumnDTO), typeof(Column)));
            Column columnEntyti = (Column)Mapper.Map(editColumn, typeof(ColumnDTO), typeof(Column));
            ColumRepos.Edit(columnEntyti);
        }

        public void DeleteColumn(ColumnDTO deleteColumn)
        {
            ColumRepos.Remove(ColumRepos.Find(deleteColumn.Id));
                                              
        }

        
        public List<ColumnDTO> GetUserColumn(BoardDTO userBoard)
        {
            var boardEntity = BoardRepos.Find(userBoard.Id);
            List<Column> columnsEntity = new List<Column>();
            foreach (var c in boardEntity.Columns)
            {
                columnsEntity.Add(c);
            }

            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(List<Column>), typeof(List<ColumnDTO>)));
            return (List<ColumnDTO>)Mapper.Map( columnsEntity, typeof(List<Column>), typeof(List<ColumnDTO>));
            
        }

        public ColumnDTO GetColumn(Column column)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(Column), typeof(ColumnDTO)));
            return (ColumnDTO)Mapper.Map(column, typeof(Column), typeof(ColumnDTO));
        }

        public List<ColumnDTO> GetUserColumnIncludeCards(BoardDTO userBoard)
        {
            
            List<Column> columnsEntity = new List<Column>();
            foreach (var c in ColumRepos.GetAllInclude(x=>x.Cards))
            {
                columnsEntity.Add(c);
            }

            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(List<Column>), typeof(List<ColumnDTO>)));
            return (List<ColumnDTO>)Mapper.Map(columnsEntity, typeof(List<Column>), typeof(List<ColumnDTO>));
        }
    }
}
