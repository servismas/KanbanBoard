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

        Attachment attachment;
        public CardEditWindow()
        {
            InitializeComponent();


        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                Card card = new Card();
                Repository<Card> cardRep = new Repository<Card>(db);
                //card = rep.Find(1);

                card.Name = cardName_tb.Text;
                card.Description = cardDescription_tb.Text;
                card.CreationDate = DateTime.Now;
                card.ExpireDate = cardExpireDate_dp.DisplayDate;
                card.ColumnId = 1;//має приходить в конструктор
                card.Column = db.Columns.Find(card.ColumnId);

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


                cardRep.Add(card);
                MainWindow.cards.Add(card);
                //this.DialogResult = true;
                //this.Closed +=
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
