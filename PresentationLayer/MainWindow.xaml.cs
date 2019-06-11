using DataAccessLayer.cs;
using DataAccessLayer.cs.Models;
using DataAccessLayer.cs.Repository;
using PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WcfBussinesLogicLayerLibrary.ModelsDTO;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public Card card;
        public int counter=1;
        public static ObservableCollection <Card> cards1, cards2, cards3, cards4;
        public static ObservableCollection<Column> board;
        Repository<Card> cardsRepository;
        Repository<Column> columnRepository;
        CompositeCollection cc = new CompositeCollection();
        UserDTO curUser;
        public MainWindow()
        {
            AuthoreRegisterWind authoreRegisterWind = new AuthoreRegisterWind();
            authoreRegisterWind.ShowDialog();
            curUser = (authoreRegisterWind.DataContext as LoginRegistrationViewModel).CurrentUser;
            InitializeComponent();
             
            ReadFromDb();
        }
        public void ReadFromDb()
        {
            board = new ObservableCollection<Column>();

            cards1 = new ObservableCollection<Card>();
            cards2 = new ObservableCollection<Card>();
            cards3 = new ObservableCollection<Card>();
            cards4 = new ObservableCollection<Card>();
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                cardsRepository = new Repository<Card>(db);
                columnRepository = new Repository<Column>(db);
                main_listBox.ItemsSource = board;

                foreach (Column column in columnRepository.GetAll())
                {
                    board.Add(column);
                    //foreach (Card card in cardsRepository.GetAll(x => x.ColumnId == column.Id))
                    //{
                    //    board.
                    //    cards1.Add(card);
                    //}
                }
                foreach (Card card in board[0].Cards)
                {
                    
                    CardButton b = new CardButton();
                    b.Content = card.Name;
                    main_listBox.Items.Add(b);
                    //cards1.Add(card);
                }
                foreach (Card card in cardsRepository.GetAll(x => x.ColumnId == 2))
                {
                    cards2.Add(card);
                }
                foreach (Card card in cardsRepository.GetAll(x => x.ColumnId == 3))
                {
                    cards3.Add(card);
                }
                foreach (Card card in cardsRepository.GetAll(x => x.ColumnId == 4))
                {
                    cards4.Add(card);
                }


                //foreach (Card card in cardsRepository.GetAll(x => x.ColumnId == 1))
                //{
                //    cards1.Add(card);
                //}
                //foreach (Card card in cardsRepository.GetAll(x => x.ColumnId == 2))
                //{
                //    cards2.Add(card);
                //}
                //foreach (Card card in cardsRepository.GetAll(x => x.ColumnId == 3))
                //{
                //    cards3.Add(card);
                //}
                //foreach (Card card in cardsRepository.GetAll(x => x.ColumnId == 4))
                //{
                //    cards4.Add(card);
                //}
                
                
                
                //cards2.Add(new Card { Name = "xdfsdfg", Description = "dfgasdfgasfdgasfgsafgasfg" });
            }
            //borderListBox.ItemsSource = cards1;
            //borderListBox2.ItemsSource = cards2;
            //borderListBox3.ItemsSource = cards3;
            //borderListBox4.ItemsSource = cards4;
        }
        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            //UIElement _element = (UIElement)e.Data.GetData("Object");
            ////ListBox _sourceListBox = (ListBox)_element;
            //ListBox _destinationListBox = (ListBox)sender;
            //while (/*(VisualTreeHelper.GetParent(_element) != null) || */!(_element is ListBox))
            //{
            //    _element = (UIElement)VisualTreeHelper.GetParent(_element);
            //}
            //using (KanbanBoardContext db = new KanbanBoardContext())
            //{
            //    cardsRepository = new Repository<Card>(db);
            //    columnRepository = new Repository<Column>(db);
                
            //    CardButton b = (CardButton)e.Data.GetData("Object");
            //    //MessageBox.Show(b.Tag.ToString());
            //    Card c = cardsRepository.Find((int)b.Tag);
            //    c.ColumnId = MainStackPanel.Children.IndexOf(_destinationListBox);
            //    //c.Column = columnRepository.Find((int)c.ColumnId);
            //    cardsRepository.Edit(c);
            //}

            //ReadFromDb();

        }
        private void AddNewTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            CardEditWindow cardEditWindow = new CardEditWindow();
            cardEditWindow.Owner = this;
            cardEditWindow.ShowDialog();
        }
        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MessageBox.Show("Button_MouseMove");
                // Package the data.
                DataObject data = new DataObject();
                data.SetData("Object", this);

                // Inititate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }
        private void Button_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MessageBox.Show("Button_PreviewMouseMove");
                // Package the data.
                DataObject data = new DataObject();
                data.SetData("Object", this);

                // Inititate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }
    }
}
