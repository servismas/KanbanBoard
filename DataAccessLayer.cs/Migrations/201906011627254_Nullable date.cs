namespace DataAccessLayer.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nullabledate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cards", "CreationDate", c => c.DateTime());
            AlterColumn("dbo.Cards", "ExpireDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cards", "ExpireDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Cards", "CreationDate", c => c.DateTime(nullable: false));
        }
    }
}
