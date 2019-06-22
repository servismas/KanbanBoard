using AutoMapper;
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
using Profile = DataAccessLayer.cs.Models.Profile;

//using System.ServiceModel;

namespace PresentationLayer
{
    public partial class MainWindow : MetroWindow
    {
        //public Card card;
        public static ObservableCollection<Card> column1, column2, column3, column4;
        public static User currentUserDb { get; set; }//для заглушки
        public static int curColumn1Id, curColumn2Id, curColumn3Id, curColumn4Id;
        public static ObservableCollection<Column> board;
        public static ObservableCollection<Board> boardS;

        public Column column;
        Board currentBoard { get; set; }
        Team currentTeam;

        Repository<Attachment> attachmentRepos;
        Repository<Board> boardRepos;
        Repository<Card> cardRepository;
        Repository<Column> columnRepository;
        Repository<Profile> profileRepos;
        Repository<Team> teamRepos;
        Repository<User> userRepository;




        int userID = 2;


        public MainWindow()
        {
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                userRepository = new Repository<User>(db);
                User u = userRepository.GetAll().FirstOrDefault(x => x.Mail == "qwerty");
                if (u == null)
                    AddNewDataToDB();
            }

                //AuthoreRegisterWind authoreRegisterWind = new AuthoreRegisterWind();
                //authoreRegisterWind.ShowDialog();
                // currentUser = GetDTOUser(); //(authoreRegisterWind.DataContext as LoginRegistrationViewModel).CurrentUser;
            InitializeComponent();
            GetUserBoard(userID);

            boardS = new ObservableCollection<Board>();
            board = new ObservableCollection<Column>();
            column1 = new ObservableCollection<Card>();
            column2 = new ObservableCollection<Card>();
            column3 = new ObservableCollection<Card>();
            column4 = new ObservableCollection<Card>();
            borderListBox1.ItemsSource = column1;
            borderListBox2.ItemsSource = column2;
            borderListBox3.ItemsSource = column3;
            borderListBox4.ItemsSource = column4;

            ReadFromDb(currentUserDb.Id);

            column1Name_tb.DataContext = board[0];
            column2Name_tb.DataContext = board[1];
            column3Name_tb.DataContext = board[2];
            column4Name_tb.DataContext = board[3];


            var w = GetAllAttachmentsDTO();
            var y = GetAllBoardsDTO();
            var q = GetAllCardsDTO();
            var e = GetAllColumnsDTO();
            var i = GetAllProfilesDTO();
            var r = GetAllTeamsDTO();
            var t = GetAllUsersDTO();
        }

        public UserDTO GetUserDTO()
        {
            UserDTO userDTO = new UserDTO();
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                userRepository = new Repository<User>(db);
                Mapper.Initialize(new Action<IMapperConfigurationExpression>(x => x.CreateMap<User, UserDTO>()));
                userDTO = Mapper.Map<User, UserDTO>(userRepository.Find(1));
                Mapper.Reset();
            }
            return userDTO;
        }
        public List<AttachmentDTO> GetAllAttachmentsDTO()
        {
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                attachmentRepos = new Repository<Attachment>(db);
                Mapper.Initialize(new Action<IMapperConfigurationExpression>(x => x.CreateMap<Attachment, AttachmentDTO>()));
                var res = Mapper.Map<List<Attachment>, List<AttachmentDTO>>(attachmentRepos.GetAll().ToList());
                Mapper.Reset();
                return res;
            }
        }
        public AttachmentDTO GetAttachmentDTO()
        {
            AttachmentDTO attachmentDTO = new AttachmentDTO();
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                attachmentRepos = new Repository<Attachment>(db);
                Mapper.Initialize(new Action<IMapperConfigurationExpression>(x => x.CreateMap<Attachment, AttachmentDTO>()));
                var res = Mapper.Map<Attachment, AttachmentDTO>(attachmentRepos.Find(1));
                Mapper.Reset();
                return res;
            }
        }
        public List<CardDTO> GetAllCardsDTO()
        {
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                cardRepository = new Repository<Card>(db);
                Mapper.Initialize(new Action<IMapperConfigurationExpression>(x => x.CreateMap<Card, CardDTO>()));
                var res = Mapper.Map<List<Card>, List<CardDTO>>(cardRepository.GetAll().ToList());
                Mapper.Reset();
                return res;
            }
        }
        public List<ProfileDTO> GetAllProfilesDTO()
        {
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                profileRepos = new Repository<Profile>(db);
                Mapper.Initialize(new Action<IMapperConfigurationExpression>(x => x.CreateMap<Card, CardDTO>()));
                var res = Mapper.Map<List<Profile>, List<ProfileDTO>>(profileRepos.GetAll().ToList());
                Mapper.Reset();
                return res;
            }
        }
        public List<UserDTO> GetAllUsersDTO()
        {
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                userRepository = new Repository<User>(db);
                Mapper.Initialize(new Action<IMapperConfigurationExpression>(x => x.CreateMap<User, UserDTO>()));
                var res = Mapper.Map<List<User>, List<UserDTO>>(userRepository.GetAll().ToList());
                Mapper.Reset();
                return res;
            }
        }
        public List<ColumnDTO> GetAllColumnsDTO()
        {
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                columnRepository = new Repository<Column>(db);
                Mapper.Initialize(new Action<IMapperConfigurationExpression>(x => x.CreateMap<Column, ColumnDTO>()));
                var res = Mapper.Map<List<Column>, List<ColumnDTO>>(columnRepository.GetAll().ToList());
                Mapper.Reset();
                return res;
            }
        }
        public List<BoardDTO> GetAllBoardsDTO()
        {
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                boardRepos = new Repository<Board>(db);
                Mapper.Initialize(new Action<IMapperConfigurationExpression>(x => x.CreateMap<Board, BoardDTO>()));
                var res = Mapper.Map<List<Board>, List<BoardDTO>>(boardRepos.GetAll().ToList());
                Mapper.Reset();
                return res;
            }
        }
        public List<TeamDTO> GetAllTeamsDTO()
        {
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                teamRepos = new Repository<Team>(db);
                Mapper.Initialize(new Action<IMapperConfigurationExpression>(x => x.CreateMap<Team, TeamDTO>()));
                var teams = teamRepos.GetAll().ToList();
                var res =
                Mapper.Map<List<Team>, List<TeamDTO>>(teams);
                Mapper.Reset();
                return res;
            }
        }


        public void GetUserBoard(int _userId)
        {
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                userRepository = new Repository<User>(db);
                teamRepos = new Repository<Team>(db);
                boardRepos = new Repository<Board>(db);

                currentUserDb = userRepository.Find(_userId);
                currentTeam = teamRepos.Find((int)currentUserDb.TeamId);
                currentBoard = boardRepos.GetWithInclude(b => b.TeamId == currentTeam.Id, b => b.Columns, b => b.Team).FirstOrDefault(b => b.TeamId == currentTeam.Id);
            }
        }
        public void ReadFromDb(int _id)//може айді і не треба
        {
            boardName_tb.DataContext = currentBoard;////////////////////////не міняється ім"я дошки
            boardName_cb.ItemsSource = boardS;
            board.Clear();
            boardS.Clear();
            column1.Clear();
            column2.Clear();
            column3.Clear();
            column4.Clear();
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                cardRepository = new Repository<Card>(db);
                columnRepository = new Repository<Column>(db);

                boardRepos = new Repository<Board>(db);
                var b = boardRepos.GetAll();
                foreach (var item in b)
                {
                    boardS.Add(item);
                }
                foreach (Column column in currentBoard.Columns)
                {
                    board.Add(column);
                }

                borderListBox1.Tag = curColumn1Id = board[0].Id;
                borderListBox2.Tag = curColumn2Id = board[1].Id;
                borderListBox3.Tag = curColumn3Id = board[2].Id;
                borderListBox4.Tag = curColumn4Id = board[3].Id;

                foreach (Card card in cardRepository.GetAll(x => x.ColumnId == curColumn1Id))
                {
                    column1.Add(card);
                }
                foreach (Card card in cardRepository.GetAll(x => x.ColumnId == curColumn2Id))
                {
                    column2.Add(card);
                }
                foreach (Card card in cardRepository.GetAll(x => x.ColumnId == curColumn3Id))
                {
                    column3.Add(card);
                }
                foreach (Card card in cardRepository.GetAll(x => x.ColumnId == curColumn4Id))
                {
                    column4.Add(card);
                }
            }
        }
        private void BoardName_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (boardS.Count == 0) return;
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                boardRepos = new Repository<Board>(db);
                currentBoard = boardRepos.GetWithInclude(b => b.Id == ((sender as ComboBox).SelectedItem as Board).Id,
                    b => b.Columns, b => b.Team).FirstOrDefault();
            }
            ReadFromDb(0);
        }
        private void AddNewBoardBtn_Click(object sender, RoutedEventArgs e)
        {
            AddNewBoard();

        }
        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            CardButton b = (CardButton)e.Data.GetData("Object");
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                cardRepository = new Repository<Card>(db);
                Card c = cardRepository.Find((int)b.Tag);
                int newColumnId = Convert.ToInt32((sender as ListBox).Tag);
                c.ColumnId = newColumnId;
                cardRepository.Edit(c);
            }
            ReadFromDb(currentUserDb.Id);
        }
        private void AddNewTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            CardEditWindow cardEditWindow = new CardEditWindow();
            cardEditWindow.Owner = this;
            cardEditWindow.ShowDialog();
        }


        public void AddNewDataToDB()
        {
            using (KanbanBoardContext context = new KanbanBoardContext())
            {
                User user1 = new User { Mail = "qwerty", Password = "111" };
                User user2 = new User { Mail = "asd", Password = "222" };

                Team team = new Team { Name = "testTeam2" };

                Board board = new Board { Name = "testBoard2" };

                Column column1 = new Column { Name = "Tasks" };
                Column column2 = new Column { Name = "In progress" };
                Column column3 = new Column { Name = "Delayed" };
                Column column4 = new Column { Name = "Ready" };

                Card card1 = new Card { Name = "2testCard1", CreationDate = DateTime.Now, ExpireDate = DateTime.Now.AddDays(10), Description = "Description1 from database" };
                Card card2 = new Card { Name = "2testCard2", CreationDate = DateTime.Now, ExpireDate = DateTime.Now.AddDays(10), Description = "Description2 from database" };
                Card card3 = new Card { Name = "2testCard3", CreationDate = DateTime.Now, ExpireDate = DateTime.Now.AddDays(10), Description = "Description3 from database" };
                //Card card4 = new Card { Name = "2testCard4", CreationDate = DateTime.Now, ExpireDate = DateTime.Now.AddDays(10), Description = "Description4 from database" };
                //Card card5 = new Card { Name = "2testCard5", CreationDate = DateTime.Now, ExpireDate = DateTime.Now.AddDays(10), Description = "Description5 from database" };

                context.Users.Add(user1);
                context.Users.Add(user2);

                context.Teams.Add(team);

                context.Boards.Add(board);

                context.Columns.Add(column1);
                context.Columns.Add(column2);
                context.Columns.Add(column3);
                context.Columns.Add(column4);

                context.Cards.Add(card1);
                context.Cards.Add(card2);
                context.Cards.Add(card3);
                //context.Cards.Add(card4);
                //context.Cards.Add(card5);


                team.Users.Add(user1);
                team.Users.Add(user2);

                user1.Teams.Add(team);
                user2.Teams.Add(team);


                team.Boards.Add(board);

                column1.Cards.Add(card1);
                column1.Cards.Add(card2);
                column1.Cards.Add(card3);
                //column.Cards.Add(card4);
                //column.Cards.Add(card5);

                card1.Users.Add(user1);
                card2.Users.Add(user2);
                //card3.Users.Add(user2);
                //card4.Users.Add(user2);
                //card5.Users.Add(user2);

                board.Columns.Add(column1);
                board.Columns.Add(column2);
                board.Columns.Add(column3);
                board.Columns.Add(column4);

                context.SaveChanges();

                user1.TeamId = team.Id;
                user2.TeamId = team.Id;

                context.SaveChanges();
            }
        }
        public void AddNewBoard()
        {
            Column column1 = new Column { Name = "Tasks" };
            Column column2 = new Column { Name = "In progress" };
            Column column3 = new Column { Name = "Delayed" };
            Column column4 = new Column { Name = "Ready" };
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                boardRepos = new Repository<Board>(db);
                Board newBoard = new Board()
                {
                    Name = "NewBoard",
                    TeamId = currentTeam.Id, 
                    Columns =
                    {
                        new Column { Name = "Tasks" },
                        new Column { Name = "In progress" },
                        new Column { Name = "Delayed" },
                        new Column { Name = "Ready" }
                    }
                };
                boardRepos.Add(newBoard);
                ReadFromDb(0);
            }
        }
        public void AddNewColumn()
        {
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                columnRepository = new Repository<Column>(db);
                Column newColumn = new Column()
                {
                    Name = "newColumn"
                };
            }
        }
        public void AddNewProfile()
        {
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                profileRepos = new Repository<Profile>(db);
                Profile newProfile = new Profile()
                {
                    FirstName = "newFirstName",
                    SecondName = "newSecondName"
                };
                profileRepos.Add(newProfile);
            }
        }
        public void AddNewTeam()
        {
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                teamRepos = new Repository<Team>(db);
                Team newTeam = new Team()
                {
                    Name = "newTeam"
                };
                teamRepos.Add(newTeam);
            }
        }
        public void AddNewUser()
        {
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                userRepository = new Repository<User>(db);
                User newUser = new User()
                {
                    Mail = "email",
                    Password = "pass",
                    TeamId = currentTeam.Id
                };
                userRepository.Add(newUser);
            }
        }


        public User GetUser(int _id)
        {
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                userRepository = new Repository<User>(db);
                return userRepository.Find(_id);
            }
        }
        private void BoardName_lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (boardS.Count == 0) return;
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                boardRepos = new Repository<Board>(db);
                currentBoard = boardRepos.GetWithInclude(b => b.Id == ((sender as ListBox).SelectedItem as Board).Id,
                    b => b.Columns, b => b.Team).FirstOrDefault();
            }
            ReadFromDb(0);
        }
    }
}
