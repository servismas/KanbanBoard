namespace DataAccessLayer.cs
{
    using DataAccessLayer.cs.Models;
    using DataAccessLayer.cs.Settings;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class KanbanBoardContext : DbContext
    {
        //static KanbanBoardContext()
        //{
        //    Database.SetInitializer<KanbanBoardContext>(new DbInitializer());
        //}
        public KanbanBoardContext()
            : base("name=KanbanBoardContext")
        {
             Database.SetInitializer(new DbInitializer());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Column> Columns { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Board> Boards { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
    }
}