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
            KanbanBoardContext db = new KanbanBoardContext();
            IRepository<User> repository = new Repository<User>(db);
            User user1 = new User { Mail = "asd@asd.com", Password = "asd" };
            User user2 = new User { Mail = "qwerty@qwerty.com", Password = "qwerty" };
            repository.Add(user1);
            repository.Add(user2);

            var users = db.Users.ToList();
            foreach (User u in users)
            {
                Console.WriteLine(u.Mail);
            }
        }
    }
}
