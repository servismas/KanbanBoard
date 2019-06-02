using DataAccessLayer.cs.Interfases;
using DataAccessLayer.cs.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFHostConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new DbInject());
            var repsitoryCard = kernel.Get<IRepository<Card>>();
            var repsitoryColumn = kernel.Get<IRepository<Column>>();
            var repsitoryBoard = kernel.Get<IRepository<Board>>();
            var repsitoryUser = kernel.Get<IRepository<User>>();
            var repsitoryTeam = kernel.Get<IRepository<Team>>();

        }
    }
}
