using DataAccessLayer.cs;
using DataAccessLayer.cs.Interfases;
using DataAccessLayer.cs.Models;
using DataAccessLayer.cs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
        KanbanBoardContext db;
            using (db = new KanbanBoardContext())
            {
                IRepository<User> repository = new Repository<User>(db);
                User user1 = new User { Mail = "mail@asd.com", Password = "pass" };
                User user2 = new User { Mail = "mail@qwerty.com", Password = "pass_qwerty" };
                repository.Add(user1);
                repository.Add(user2);

                //DateTime date = new DateTime();
                //var cards = db.Cards.ToList();
                //foreach(Card card in cards)
                //{
                //    date = card.CreationDate;
                //}

                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine(u.Mail);
                }
                //Console.ReadLine();
            }

        }
    }
}
