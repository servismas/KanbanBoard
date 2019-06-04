﻿using AutoMapper;
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
        private readonly IRepository<UserService> UsersRepos;

        public BoardService(IRepository<Board> _board, IRepository<UserService> _users)
        {
            BoardRepos = _board;
            UsersRepos = _users;
        }

        public void CreateBoard(BoardDTO newBoard)
        {
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(BoardDTO), typeof(Board)));
            Board boardEntyti = (Board)Mapper.Map(newBoard, typeof(BoardDTO), typeof(Board));
            BoardRepos.Add(boardEntyti);
        }

        public void DeleteBoard(BoardDTO deleteBoard)
        {
            BoardRepos.Remove(BoardRepos.Find(deleteBoard.Id));
        }

        public void EditeBoardName(BoardDTO editBoard)
        {
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(BoardDTO), typeof(Board)));
            Board boardEntyti = (Board)Mapper.Map(editBoard, typeof(BoardDTO), typeof(Board));
            BoardRepos.Edit(boardEntyti);
        }

        public List<BoardDTO> GetAllUsersBoards(UserDTO user)
        {
            UserService userEntity = UsersRepos.Find(user.Id);
            List<Board> boards = new List<Board>();
            foreach (var b in userEntity.Boards)
            {
                boards.Add(b);
            }

            Mapper.Initialize(cfg => cfg.CreateMap(typeof(List<Board>), typeof(List<BoardDTO>)));
            return (List<BoardDTO>)Mapper.Map(boards, typeof(List<Board>), typeof(List<BoardDTO>));
        }

        public BoardDTO GetBoard(Board board)
        {
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(Board), typeof(BoardDTO)));
            return (BoardDTO)Mapper.Map(board, typeof(Board), typeof(BoardDTO));
        }
    }
}