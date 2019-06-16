//using AutoMapper;
using DataAccessLayer.cs;
using DataAccessLayer.cs.Models;
using DataAccessLayer.cs.Repository;
using MahApps.Metro.Controls;
using PresentationLayer.CardService;
using PresentationLayer.ColumnService;
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
        public Column column;

        Repository<Attachment> attachmentRepos;
        Repository<Board> boardRepos;
        Repository<Card> cardsRepository;
        Repository<Column> columnRepository;
        Repository<Profile> profileRepos;
        Repository<Team> teamRepos;
        Repository<User> userRepository;

        UserDTO curUser;
        public static User curUserDb { get; set; }//для заглушки


        CreateEditColumnsContractClient columnsClient = new CreateEditColumnsContractClient();
        CreateEditeCardContractClient cardsClient = new CreateEditeCardContractClient();


        public MainWindow()
        {
            //AuthoreRegisterWind authoreRegisterWind = new AuthoreRegisterWind();
            //authoreRegisterWind.ShowDialog();
            // curUser = GetDTOUser(); //(authoreRegisterWind.DataContext as LoginRegistrationViewModel).CurrentUser;
            curUserDb = GetUser(1);
            InitializeComponent();
            
            board = new ObservableCollection<Column>();

            column1 = new ObservableCollection<Card>();
            column2 = new ObservableCollection<Card>();
            column3 = new ObservableCollection<Card>();
            column4 = new ObservableCollection<Card>();
            borderListBox1.ItemsSource = column1;
            borderListBox2.ItemsSource = column2;
            borderListBox3.ItemsSource = column3;
            borderListBox4.ItemsSource = column4;

            ReadFromDb(curUserDb.Id);

            column1Name_tb.DataContext = board[0];
            column2Name_tb.DataContext = board[1];
            column3Name_tb.DataContext = board[2];
            column4Name_tb.DataContext = board[3];
            //borderListBox1.ItemsSource = board[0].Cards as ObservableCollection<Card>;
            //borderListBox2.ItemsSource = board[1].Cards as ObservableCollection<Card>;
            //borderListBox3.ItemsSource = board[2].Cards as ObservableCollection<Card>;
            //borderListBox4.ItemsSource = board[3].Cards as ObservableCollection<Card>;
            //BoardDTO b = new BoardDTO() { Id = 1 };

            //  var res = columnsClient.GetUserColumn(b);

        }

        public User GetUser(int _id)
        {
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                userRepository = new Repository<User>(db);
                return userRepository.Find(_id);
            }
        }
        //public UserDTO GetDTOUser()
        //{


        //    curUser = new UserDTO();
        //    curUserDb = new User();
        //    using (KanbanBoardContext db = new KanbanBoardContext())
        //    {
        //        userRepository = new Repository<User>(db);




        //        //AutoMapper.Mapper.Initialize(new Action<AutoMapper.IMapperConfigurationExpression>(x => x.CreateMap<User, UserDTO>()));
        //        //var res = userRepository.GetAll();
        //        //return AutoMapper.Mapper.Map<List<User>, List<UserDTO>>(res.ToList());




        //        curUserDb = userRepository.Find(1);
        //    }
        //    AutoMapper.Mapper.Initialize(new Action<AutoMapper.IMapperConfigurationExpression>(x => x.CreateMap<User, UserDTO>()));
        //    return Mapper.Map<UserDTO>(curUserDb);



        //    //curUser.Id = curUserDb.Id;
        //    //curUser.Mail = curUserDb.Mail;
        //    //curUser.IsDeleted = curUserDb.IsDeleted;
        //    //curUser.Password = curUserDb.Password;
        //    ////curUser.Profile = curUserDb.Profile;
        //    //curUser.ProfileId = curUserDb.ProfileId;
        //    ////curUser.Team = curUserDb.Teams.Last();
        //    //curUser.TeamId = curUserDb.TeamId;
        //    //return curUser;
        //}

        //[Obsolete]
        //public List<ColumnDTO> GetAllCollumns()
        //{
        //    using (KanbanBoardContext db = new KanbanBoardContext())
        //    {
        //        columnRepository = new Repository<Column>(db);
        //        AutoMapper.Mapper.Initialize((new Action<AutoMapper.IMapperConfigurationExpression>(x => x.CreateMap<Column, ColumnDTO>())));
        //        var res = columnRepository.GetAll();
        //        return AutoMapper.Mapper.Map<List<Column>, List<ColumnDTO>>(res.ToList());

        //    }
        //}
        public void GetCards()
        {
            column1.Clear();
            column2.Clear();
            column3.Clear();
            column4.Clear();
        }

        
        public void ReadFromDb(int _id)
        {
            column = new Column();
            board.Clear();

            column1.Clear();
            column2.Clear();
            column3.Clear();
            column4.Clear();
            List<Team> listTeams = new List<Team>();
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                cardsRepository = new Repository<Card>(db);
                columnRepository = new Repository<Column>(db);


                foreach (Column column in columnRepository.GetAllInclude(x => x.Cards))
                {
                    board.Add(column);
                }


                User user = (db.Users.FirstOrDefault(u => u.Id == _id));




                //db.Teams.FirstOrDefault(t => t.Users.FirstOrDefault(u => u.Id == _id));


                //listTeams = db.Teams.Include("Users").Include("Users.Teams").Include("Boards").Include("Boards.Columns").Include("Boards.Columns.Cards").Include("Boards.Columns.Cards.Users").ToList();
                //listTeams[0].Users.Add(new User { Mail = "qaz@qaz.qaz", Password = "qaz" });
                //db.SaveChanges();


                foreach (Card card in cardsRepository.GetAll(x => x.ColumnId == 1/*, y => y.User_Id = _id*/))
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
            //var i = res[0];
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
            ReadFromDb(curUserDb.Id);
        }

        private void AddNewTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            CardEditWindow cardEditWindow = new CardEditWindow();
            cardEditWindow.Owner = this;
            cardEditWindow.ShowDialog();
        }
    }
}
