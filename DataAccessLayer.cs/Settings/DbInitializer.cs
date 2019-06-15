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
            User user1 = new User { Mail = "qwerty@qwerty.com", Password = "�࿬쿢䘰囘燶朗㾨ꋷﱊｴ쐺쬌꤅꽿蟡얂翾邊谮蘷쮥␶荜ഓ倽⩣戜悧緖䤍" };
            User user2 = new User { Mail = "asd@asd.com", Password = "䄑㹩豤ꂨᤑཀ⿿䶚體䪛滻禐퍤��滻砊汇䎋༁�쒆䐡셵茙渀ฤ궕" };

            Team team = new Team { Name = "testTeam" };

            Board board = new Board { Name = "testBoard" };

            Column column1 = new Column { Name = "testColumn1" };
            Column column2 = new Column { Name = "testColumn2" };
            Column column3 = new Column { Name = "testColumn3" };
            Column column4 = new Column { Name = "testColumn4" };

            Card card1 = new Card { Name = "testCard1", CreationDate = DateTime.Now, ExpireDate = DateTime.Now.AddDays(10), Description = "Description1 from database" };
            Card card2 = new Card { Name = "testCard2", CreationDate = DateTime.Now, ExpireDate = DateTime.Now.AddDays(10), Description = "Description2 from database" };
            Card card3 = new Card { Name = "testCard3", CreationDate = DateTime.Now, ExpireDate = DateTime.Now.AddDays(10), Description = "Description3 from database" };
            Card card4 = new Card { Name = "testCard4", CreationDate = DateTime.Now, ExpireDate = DateTime.Now.AddDays(10), Description = "Description4 from database" };
            Card card5 = new Card { Name = "testCard5", CreationDate = DateTime.Now, ExpireDate = DateTime.Now.AddDays(10), Description = "Description5 from database" };

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
            context.Cards.Add(card4);
            context.Cards.Add(card5);


            team.Users.Add(user1);
            team.Users.Add(user2);

            user1.Teams.Add(team);
            user2.Teams.Add(team);


            team.Boards.Add(board);

            column1.Cards.Add(card1);
            column1.Cards.Add(card2);
            column1.Cards.Add(card3);
            column1.Cards.Add(card4);
            column1.Cards.Add(card5);

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
}
