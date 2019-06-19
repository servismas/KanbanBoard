using DataAccessLayer.cs;
using DataAccessLayer.cs.Models;
using DataAccessLayer.cs.Repository;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    public partial class CardEditWindow : MetroWindow
    {
        int cardId;
        Attachment attachment;
        Card card;
        ObservableCollection<string> attactmentCollection = new ObservableCollection<string>();
        Repository<Card> cardRep;
        Repository<Attachment> attachmentRep;
        public CardEditWindow(int _cardId = 0)
        {

            InitializeComponent();
            cardCreationDate_tb.Text = DateTime.Now.ToString();
            if (_cardId != 0)
            {
                cardId = _cardId;
                using (KanbanBoardContext db = new KanbanBoardContext())
                {
                    card = new Card();
                    cardRep = new Repository<Card>(db);
                    card = cardRep.GetWithInclude(c => c.Id == _cardId, c => c.Attachments).FirstOrDefault(/*x => x.Id == _cardId*/);

                    attachment_lb.ItemsSource = attactmentCollection;
                    foreach (Attachment a in card.Attachments)
                    {
                        attactmentCollection.Add((a.Path));
                    } 
                    cardName_tb.Text = card.Name;
                    cardDescription_tb.Text = card.Description;
                    cardCreationDate_tb.Text = card.CreationDate.ToString();
                    cardExpireDate_dp.SelectedDate = (DateTime)card.ExpireDate;
                }
            }
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            if (cardExpireDate_dp.SelectedDate > DateTime.Now)
            {
                using (KanbanBoardContext db = new KanbanBoardContext())
                {
                    cardRep = new Repository<Card>(db);
                    attachmentRep = new Repository<Attachment>(db);
                    if (card == null)
                    {
                        card = new Card();
                        card.CreationDate = DateTime.Now;
                        card.ColumnId = MainWindow.curColumn1Id; 
                        card.ExpireDate = cardExpireDate_dp.SelectedDate;
                        card.Name = cardName_tb.Text;
                        card.Description = cardDescription_tb.Text;
                        cardRep.Add(card);
                    }
                    else
                    {
                        card.ExpireDate = cardExpireDate_dp.SelectedDate;
                        card.Name = cardName_tb.Text;
                        card.Description = cardDescription_tb.Text;
                    }
                    if (attachment != null)
                    {
                        attachment.CardId = card.Id;
                        attachmentRep.Add(attachment);
                        card.Attachments.Add(attachment);
                    }
                        cardRep.Edit(card);
                    (this.Owner as MainWindow).ReadFromDb(MainWindow.currentUserDb.Id);
                    this.Close();
                }
            }
            else
                MessageBox.Show("Input corect ExpireDate");
        }

        private void AddAttachment_btn_Click(object sender, RoutedEventArgs e)
        {
            attachment = new Attachment();
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                attachment.Path = ofd.FileName;
                attactmentCollection.Add((attachment.Path));
            }
        }

        private void Attachment_lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Process.Start((sender as ListBox).SelectedItem.ToString());
        }
    }
}
