using DataAccessLayer.cs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.cs.Settings
{
    //public class DbInitializer : CreateDatabaseIfNotExists<KanbanBoardContext>
    public class DbInitializer : DropCreateDatabaseAlways<KanbanBoardContext>
    {
        protected override void Seed(KanbanBoardContext context)
        {
            //base.Seed(context);
            User user1 = new User { Mail = "qwerty@qwerty.com", Password = "qwerty" };
            User user2 = new User { Mail = "asd@asd.com", Password = "asd" };

            Team team = new Team { Name = "Team" };

            Board board = new Board { Name = "Board" };

            Column column1 = new Column { Name = "Column1" };
            Column column2 = new Column { Name = "Column2" };

            Card card1 = new Card { Name = "Card1" };
            Card card2 = new Card { Name = "Card2" };

            context.Users.Add(user1);
            context.Users.Add(user2);

            context.Teams.Add(team);

            context.Boards.Add(board);

            context.Columns.Add(column1);

            context.Cards.Add(card1);
            context.Cards.Add(card2);

            //context.SaveChanges();

            //team.Users.Add(user1);
            //team.Users.Add(user2);

            //column1.Cards.Add(card1);
            //column1.Cards.Add(card2);

            //card1.Users.Add(user1);
            //card2.Users.Add(user2);

            //board.Columns.Add(column1);
            //board.Columns.Add(column2);

            context.SaveChanges();
        }
    }
}
