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
    public class CardService :ICreateEditeCardContract
    {
        private readonly IRepository<Card> CardRepos;
        private readonly IRepository<Column> ColumnRepos;

        public CardService(IRepository<Card> _card, IRepository<Column> _column)
        {
            CardRepos = _card;
            ColumnRepos = _column;
        }

       
        public void CreateCard(CardDTO newCard)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(CardDTO), typeof(Card)));
            Card cardEntyti = (Card)Mapper.Map(newCard, typeof(CardDTO), typeof(Card));
            CardRepos.Add(cardEntyti);
        }

        public void DeleteCard(CardDTO deleteCard)
        {
            CardRepos.Remove(CardRepos.Find(deleteCard.Id));
        }

        public void EditeCard(CardDTO editCard)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(CardDTO), typeof(Card)));
            Card cardEntyti = (Card)Mapper.Map(editCard, typeof(CardDTO), typeof(Card));
            CardRepos.Edit(cardEntyti);
        }

        public List<CardDTO> GetAllCardsIncludeAttach(ColumnDTO column)
        {
            
            List<Card> cards = new List<Card>();
            List<Card> fullCards = new List<Card>();
            foreach (var c in CardRepos.GetAllInclude(x=>x.Attachments))
            {
                cards.Add(c);
                
            }
            
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(List<Card>), typeof(List<CardDTO>)));
            return (List<CardDTO>)Mapper.Map(cards, typeof(List<Card>), typeof(List<CardDTO>));
        }

        public List<CardDTO> GetAllColumnCards(ColumnDTO column)
        {
            Column columnEntity = ColumnRepos.Find(column.Id);
            List<Card> cards = new List<Card>();
            foreach (var c in columnEntity.Cards)
            {
                cards.Add(c);
            }
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(List<Card>), typeof(List<CardDTO>)));
            return (List<CardDTO>)Mapper.Map(cards, typeof(List<Card>), typeof(List<CardDTO>));
        }
    }
}
