using AutoMapper;
using DataAccessLayer.cs.Interfases;
using DataAccessLayer.cs.Models;
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
    public class BoardService : ICreateEditeBoardContract
    {

        private readonly IRepository<Board> BoardRepos;
        private readonly IRepository<Team> TeamRepos;
        

        public BoardService(IRepository<Board> _board, IRepository<Team> _team)
        {
            BoardRepos = _board;
            TeamRepos = _team;
            
        }

        public void CreateBoard(BoardDTO newBoard)
        {
            //Mapper.Reset();
            //Mapper.Initialize(cfg => cfg.CreateMap(typeof(BoardDTO), typeof(Board)));
            //Board boardEntyti = (Board)Mapper.Map(newBoard, typeof(BoardDTO), typeof(Board));

            Mapper.Initialize(new Action<IMapperConfigurationExpression>(x => x.CreateMap<BoardDTO, Board>()));
            Board boardEntyti = Mapper.Map<BoardDTO, Board>(newBoard);
            Mapper.Reset();


            BoardRepos.Add(boardEntyti);
        }

        public void DeleteBoard(BoardDTO deleteBoard)
        {
            BoardRepos.Remove(BoardRepos.Find(deleteBoard.Id));
        }

        public void EditeBoardName(BoardDTO editBoard)
        {
            //Mapper.Reset();
            //Mapper.Initialize(cfg => cfg.CreateMap(typeof(BoardDTO), typeof(Board)));
            //Board boardEntyti = (Board)Mapper.Map(editBoard, typeof(BoardDTO), typeof(Board));

            Mapper.Initialize(new Action<IMapperConfigurationExpression>(x => x.CreateMap<BoardDTO, Board>()));
            Board boardEntyti = Mapper.Map<BoardDTO, Board>(editBoard);
            Mapper.Reset();

            BoardRepos.Edit(boardEntyti);
        }

        public List<BoardDTO> GetAllUsersBoards(TeamDTO userTeam)  
        {
            Team teamEntity = TeamRepos.Find(userTeam.Id);
            List<Board> boards = new List<Board>();
            foreach (var b in teamEntity.Boards)
            {
                boards.Add(b);
            }

            Mapper.Initialize(new Action<IMapperConfigurationExpression>(x => x.CreateMap<Board, BoardDTO>()));
            var res = Mapper.Map<List<Board>, List<BoardDTO>>(boards);
            Mapper.Reset();
            return res;
            //Mapper.Reset();
            //Mapper.Initialize(cfg => cfg.CreateMap(typeof(List<Board>), typeof(List<BoardDTO>)));
            //return (List<BoardDTO>)Mapper.Map(boards, typeof(List<Board>), typeof(List<BoardDTO>));
        }

        public List<BoardDTO> GetAllUsersBoardsIncludColumns(TeamDTO userTeam)
        {
           
            List<Board> boards = new List<Board>();
            foreach (Board b in BoardRepos.GetAllInclude(x=>x.Columns))
            {                
                boards.Add(b);
            }
            //Mapper.Reset();
            //Mapper.Initialize(cfg => cfg.CreateMap(typeof(List<Board>), typeof(List<BoardDTO>)));
            //return (List<BoardDTO>)Mapper.Map(boards, typeof(List<Board>), typeof(List<BoardDTO>));

            Mapper.Initialize(new Action<IMapperConfigurationExpression>(x => x.CreateMap<Board, BoardDTO>()));
            var res = Mapper.Map<List<Board>, List<BoardDTO>>(boards);
            Mapper.Reset();
            return res;
        }

        public BoardDTO GetBoard(Board board)
        {
            //Mapper.Reset();
            //Mapper.Initialize(cfg => cfg.CreateMap(typeof(Board), typeof(BoardDTO)));
            //return (BoardDTO)Mapper.Map(board, typeof(Board), typeof(BoardDTO));
            Mapper.Initialize(new Action<IMapperConfigurationExpression>(x => x.CreateMap<Board, BoardDTO>()));
            BoardDTO boardDto = Mapper.Map<Board, BoardDTO>(board);
            Mapper.Reset();
            return boardDto;
        }
    }
}
