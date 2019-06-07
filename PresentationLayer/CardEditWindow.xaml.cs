using DataAccessLayer.cs;
using DataAccessLayer.cs.Models;
using DataAccessLayer.cs.Repository;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for CardEditWindow.xaml
    /// </summary>
    /// 
    public partial class CardEditWindow : Window
    {
        int cardId;
        Attachment attachment;
        Card card;
        public CardEditWindow(int _cardId = 0)
        {

            InitializeComponent();
            // cardId = _cardId;
            if (_cardId != 0)
            {
                cardId = _cardId;
                using (KanbanBoardContext db = new KanbanBoardContext())
                {
                    card = new Card();
                    Repository<Card> cardRep = new Repository<Card>(db);
                    card = cardRep.Find(_cardId);

                    cardName_tb.Text = card.Name;
                    cardDescription_tb.Text = card.Description;
                    //card.CreationDate = DateTime.Now=
                    cardExpireDate_dp.SelectedDate = (DateTime)card.ExpireDate;
                    //card.ColumnId = 1;//має приходить в конструктор
                    //card.Column = db.Columns.Find(card.ColumnId);
                }
            }
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {

            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                // Card card = new Card();
                Repository<Card> cardRep = new Repository<Card>(db);
                //card = rep.Find(1);


                if (card == null)
                {
                    card = new Card();
                    card.CreationDate = DateTime.Now;
                    card.ColumnId = 1; // перевырить чи не треба додавать Column
                    card.ExpireDate = DateTime.Now.AddDays(10);

                }
                else
                    card.ExpireDate = cardExpireDate_dp.SelectedDate;


                card.Name = cardName_tb.Text;
                card.Description = cardDescription_tb.Text;
                //card.CreationDate = DateTime.Now;
                //card.ColumnId = cardId;//має приходить в конструктор //не трогать якшо едітиться???
                //card.Column = db.Columns.Find(card.ColumnId);

                //cardRep.Add(card);

                //Repository<Attachment> attachmentRep = new Repository<Attachment>(db);
                //OpenFileDialog ofd = new OpenFileDialog();
                //if (ofd.ShowDialog() == true)
                //{
                //    attachment.Path = ofd.FileName;
                if (attachment != null)
                {
                    attachment.CardId = card.Id;
                    attachment.Card = card;
                    card.Attachments.Add(attachment);
                }
                //}


                //if (card.Id == cardRep.Find(card.Id).Id)
                //{
                try/////////////////////////костиль
                {
                    cardRep.Edit(card);
                }
                catch (Exception)
                {
                    cardRep.Add(card);
                }
                //cardRep.Add(card);
                //cardRep.Edit(card);
                //MainWindow.cards.Add(card);
                //this.DialogResult = true;
                //this.Closed +=
                //ReadFromDb();
                (this.Owner as MainWindow).ReadFromDb();
                this.Close();
            }
        }

        private void AddAttachment_btn_Click(object sender, RoutedEventArgs e)
        {
            attachment = new Attachment();
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                attachment.Path = ofd.FileName;
                //attachment.CardId = card.Id;
                //attachment.Card = card;
            }
        }

    }
}
