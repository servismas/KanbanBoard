using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.cs.Interfases;
using DataAccessLayer.cs.Repository;
using DataAccessLayer.cs;

namespace WCFHostConsole
{
    public class DbInject : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepository<>)).To(typeof(Repository<>)).WithConstructorArgument("_context", new KanbanBoardContext());
        }
    }
}
