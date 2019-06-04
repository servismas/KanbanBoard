using DataAccessLayer.cs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.cs.Settings
{
    public class DbInitializer : CreateDatabaseIfNotExists<KanbanBoardContext>
    //public class DbInitializer : DropCreateDatabaseAlways<KanbanBoardContext>
    {
        protected override void Seed(KanbanBoardContext context)
        {
            User user1 = new User { Mail = "qwerty@qwerty.com", Password = "qwerty" };
            User user2 = new User { Mail = "asd@asd.com", Password = "asd" };

            Team team = new Team { Name = "testTeam" };

            Board board = new Board { Name = "testBoard" };

            Column column1 = new Column { Name = "testColumn1" };
            Column column2 = new Column { Name = "testColumn2" };

            Card card1 = new Card { Name = "testCard1", CreationDate = DateTime.Now, ExpireDate = null, Description = "Description from database" };
            Card card2 = new Card { Name = "testCard2", CreationDate = DateTime.Now, ExpireDate = null, Description = "Description from database" };

            context.Users.Add(user1);
            context.Users.Add(user2);

            context.Teams.Add(team);

            context.Boards.Add(board);

            context.Columns.Add(column1);

            context.Cards.Add(card1);
            context.Cards.Add(card2);


            team.Users.Add(user1);
            team.Users.Add(user2);

            user1.Teams.Add(team);
            user2.Teams.Add(team);

            team.Boards.Add(board);

            column1.Cards.Add(card1);
            column1.Cards.Add(card2);

            card1.Users.Add(user1);
            card2.Users.Add(user2);

            board.Columns.Add(column1);
            board.Columns.Add(column2);


            context.SaveChanges();
        }
    }
}
