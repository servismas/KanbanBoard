using AutoMapper;
using DataAccessLayer.cs.Interfases;
using DataAccessLayer.cs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfBussinesLogicLayerLibrary.Contracts;
using WcfBussinesLogicLayerLibrary.ModelsDTO;

namespace WcfBussinesLogicLayerLibrary.Services
{
    public class BoardService : ICreateEditeBoardContract
    {

        private readonly IRepository<Board> BoardRepos;
        private readonly IRepository<Team> TeamRepos;

        public BoardService(IRepository<Board> _board, IRepository<Team> _team)
        {
            BoardRepos = _board;
            TeamRepos = _team;
        }

        public void CreateBoard(AttachmentdDTO newBoard)
        {
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(AttachmentdDTO), typeof(Board)));
            Board boardEntyti = (Board)Mapper.Map(newBoard, typeof(AttachmentdDTO), typeof(Board));
            BoardRepos.Add(boardEntyti);
        }

        public void DeleteBoard(AttachmentdDTO deleteBoard)
        {
            BoardRepos.Remove(BoardRepos.Find(deleteBoard.Id));
        }

        public void EditeBoardName(AttachmentdDTO editBoard)
        {
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(AttachmentdDTO), typeof(Board)));
            Board boardEntyti = (Board)Mapper.Map(editBoard, typeof(AttachmentdDTO), typeof(Board));
            BoardRepos.Edit(boardEntyti);
        }

        public List<AttachmentdDTO> GetAllUsersBoards(TeamDTO userTeam)  
        {
            Team teamEntity = TeamRepos.Find(userTeam.Id);
            List<Board> boards = new List<Board>();
            foreach (var b in teamEntity.Boards)
            {
                boards.Add(b);
            }

            Mapper.Initialize(cfg => cfg.CreateMap(typeof(List<Board>), typeof(List<AttachmentdDTO>)));
            return (List<AttachmentdDTO>)Mapper.Map(boards, typeof(List<Board>), typeof(List<AttachmentdDTO>));
        }

        public AttachmentdDTO GetBoard(Board board)
        {
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(Board), typeof(AttachmentdDTO)));
            return (AttachmentdDTO)Mapper.Map(board, typeof(Board), typeof(AttachmentdDTO));
        }
    }
}
