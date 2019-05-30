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

            Column column = new Column { Name = "Column" };

            Card card = new Card { Name = "Card" };

            context.Users.Add(user1);
            context.Users.Add(user2);

            context.Teams.Add(team);

            context.Boards.Add(board);

            context.Columns.Add(column);

            context.Cards.Add(card);

            context.SaveChanges();
        }
    }
}
