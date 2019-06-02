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
        public void CreateBoard(BoardDTO newBoard)
        {
            throw new NotImplementedException();
        }

        public void DeleteBoard(BoardDTO deleteBoard)
        {
            throw new NotImplementedException();
        }

        public void EditeBoardName(BoardDTO editBoard)
        {
            throw new NotImplementedException();
        }

        public List<BoardDTO> GetAllUsersBoards(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
