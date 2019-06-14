using DataAccessLayer.cs;
using DataAccessLayer.cs.Models;
using DataAccessLayer.cs.Repository;
using MahApps.Metro.Controls;
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
    public partial class MainWindow : MetroWindow
    {
        //public Card card;
        public static ObservableCollection<Card> column1, column2, column3, column4;
        public static ObservableCollection<Column> board;
        Repository<Card> cardsRepository;
        Repository<Column> columnRepository;
        Repository<User> userRepository;
        UserDTO curUser;
        User curUserDb;//для заглушки
        public MainWindow()
        {
            AuthoreRegisterWind authoreRegisterWind = new AuthoreRegisterWind();
            authoreRegisterWind.ShowDialog();
            curUser = (authoreRegisterWind.DataContext as LoginRegistrationViewModel).CurrentUser;
            InitializeComponent();

            //Zaglushka();
            column1 = new ObservableCollection<Card>();
            column2 = new ObservableCollection<Card>();
            column3 = new ObservableCollection<Card>();
            column4 = new ObservableCollection<Card>();
            borderListBox1.ItemsSource = column1;
            borderListBox2.ItemsSource = column2;
            borderListBox3.ItemsSource = column3;
            borderListBox4.ItemsSource = column4;
            ReadFromDb();
        }
        public void Zaglushka()
        {
            curUser = new UserDTO();
            curUserDb = new User();
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                userRepository = new Repository<User>(db);
                curUserDb = userRepository.Find(1);
            }
            curUser.Id = curUserDb.Id;
            curUser.Mail = curUserDb.Mail;
            curUser.IsDeleted = curUserDb.IsDeleted;
            curUser.Password = curUserDb.Password;
            //curUser.Profile = curUserDb.Profile;
            curUser.ProfileId = curUserDb.ProfileId;
            //curUser.Team = curUserDb.Teams.Last();
            curUser.TeamId = curUserDb.TeamId;
        }
        public void ReadFromDb()
        {
            board = new ObservableCollection<Column>();

            column1.Clear();
            column2.Clear();
            column3.Clear();
            column4.Clear();

            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                cardsRepository = new Repository<Card>(db);
                columnRepository = new Repository<Column>(db);

                foreach (Card card in cardsRepository.GetAll(x => x.ColumnId == 1))
                {
                    column1.Add(card);
                }
                foreach (Card card in cardsRepository.GetAll(x => x.ColumnId == 2))
                {
                    column2.Add(card);
                }
                foreach (Card card in cardsRepository.GetAll(x => x.ColumnId == 3))
                {
                    column3.Add(card);
                }
                foreach (Card card in cardsRepository.GetAll(x => x.ColumnId == 4))
                {
                    column4.Add(card);
                }
            }
        }

        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            CardButton b = (CardButton)e.Data.GetData("Object");

            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                cardsRepository = new Repository<Card>(db);
                Card c = cardsRepository.Find((int)b.Tag);
                int newColumnId = Convert.ToInt32((sender as ListBox).Tag);
                c.ColumnId = newColumnId;
                cardsRepository.Edit(c);
            }
            ReadFromDb();
        }

        private void AddNewTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            CardEditWindow cardEditWindow = new CardEditWindow();
            cardEditWindow.Owner = this;
            cardEditWindow.ShowDialog();
        }
    }
}
