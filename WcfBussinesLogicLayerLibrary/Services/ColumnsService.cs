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
        private readonly IRepository<Card> CardRepos;
        private readonly IRepository<Column> ColumRepos;
        public ColumnsService(IRepository<Card> _card, IRepository<Column> _column)
        {
            CardRepos = _card;
            ColumRepos = _column;
        }

        public void AddCard(CardDTO newCard)
        {
            Card newEntityCard=new Card();

            // newEntityCard.Attachment = newCard.Attachment;
            newEntityCard.Column.Id = newCard.Column.Id;
            newEntityCard.Date = newCard.Date;
            newEntityCard.Description = newCard.Description;
            newEntityCard.Name = newCard.Name;
           // newEntityCard.Users. = newCard.Users;

            CardRepos.Add(newEntityCard);
        }

        public void AddNewColumn(ColumnDTO newColumn)
        {
            throw new NotImplementedException();
        }

        public void DeleteCard(CardDTO deleteCard)
        {
            throw new NotImplementedException();
        }

        public void EditeColumnName(ColumnDTO editColumn, string newName)
        {
            throw new NotImplementedException();
        }
    }
}
