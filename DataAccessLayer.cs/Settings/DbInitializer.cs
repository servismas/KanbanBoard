using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.cs.Settings
{
    public class DbInitializer : CreateDatabaseIfNotExists<KanbanBoardContext>
    {
        protected override void Seed(KanbanBoardContext context)
        {
            //base.Seed(context);


        }
    }
}
