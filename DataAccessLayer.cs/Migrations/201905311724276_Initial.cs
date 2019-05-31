namespace DataAccessLayer.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        CardId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.CardId)
                .Index(t => t.CardId);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                        ColumnId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Columns", t => t.ColumnId)
                .Index(t => t.ColumnId);
            
            CreateTable(
                "dbo.Columns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Board_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Boards", t => t.Board_Id)
                .Index(t => t.Board_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mail = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        IsDeleted = c.Boolean(),
                        ProfileId = c.Int(),
                        TeamId = c.Int(),
                        Card_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.ProfileId)
                .ForeignKey("dbo.Teams", t => t.TeamId)
                .ForeignKey("dbo.Cards", t => t.Card_Id)
                .Index(t => t.ProfileId)
                .Index(t => t.TeamId)
                .Index(t => t.Card_Id);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BoardId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Boards", t => t.BoardId)
                .Index(t => t.BoardId);
            
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.Users", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Teams", "BoardId", "dbo.Boards");
            DropForeignKey("dbo.Columns", "Board_Id", "dbo.Boards");
            DropForeignKey("dbo.Users", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Cards", "ColumnId", "dbo.Columns");
            DropForeignKey("dbo.Attachments", "CardId", "dbo.Cards");
            DropIndex("dbo.Teams", new[] { "BoardId" });
            DropIndex("dbo.Users", new[] { "Card_Id" });
            DropIndex("dbo.Users", new[] { "TeamId" });
            DropIndex("dbo.Users", new[] { "ProfileId" });
            DropIndex("dbo.Columns", new[] { "Board_Id" });
            DropIndex("dbo.Cards", new[] { "ColumnId" });
            DropIndex("dbo.Attachments", new[] { "CardId" });
            DropTable("dbo.Boards");
            DropTable("dbo.Teams");
            DropTable("dbo.Profiles");
            DropTable("dbo.Users");
            DropTable("dbo.Columns");
            DropTable("dbo.Cards");
            DropTable("dbo.Attachments");
        }
    }
}
