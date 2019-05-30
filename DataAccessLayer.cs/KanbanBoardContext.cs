namespace DataAccessLayer.cs
{
    using DataAccessLayer.cs.Models;
    using DataAccessLayer.cs.Settings;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class KanbanBoardContext : DbContext
    {
        // Контекст настроен для использования строки подключения "KanbanBoardContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "DataAccessLayer.cs.KanbanBoardContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "KanbanBoardContext" 
        // в файле конфигурации приложения.
        public KanbanBoardContext()
            : base("name=KanbanBoardContext")
        {
            Database.SetInitializer(new DbInitializer());
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<User> Users { get; set; }
         public virtual DbSet<Team> Teams { get; set; }
         public virtual DbSet<Column> Columns { get; set; }
         public virtual DbSet<Card> Cards { get; set; }
         public virtual DbSet<Board> Boards { get; set; }
         public virtual DbSet<Attachment> Attachments { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}