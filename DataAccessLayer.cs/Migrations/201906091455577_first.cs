namespace DataAccessLayer.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
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
                        ExpireDate = c.DateTime(),
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
                .ForeignKey("dbo.Cards", t => t.Card_Id)
                .Index(t => t.ProfileId)
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TeamId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamId)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.TeamUsers",
                c => new
                    {
                        Team_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Team_Id, t.User_Id })
                .ForeignKey("dbo.Teams", t => t.Team_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Team_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.TeamUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.TeamUsers", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Boards", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Columns", "Board_Id", "dbo.Boards");
            DropForeignKey("dbo.Users", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Cards", "ColumnId", "dbo.Columns");
            DropForeignKey("dbo.Attachments", "CardId", "dbo.Cards");
            DropIndex("dbo.TeamUsers", new[] { "User_Id" });
            DropIndex("dbo.TeamUsers", new[] { "Team_Id" });
            DropIndex("dbo.Boards", new[] { "TeamId" });
            DropIndex("dbo.Users", new[] { "Card_Id" });
            DropIndex("dbo.Users", new[] { "ProfileId" });
            DropIndex("dbo.Columns", new[] { "Board_Id" });
            DropIndex("dbo.Cards", new[] { "ColumnId" });
            DropIndex("dbo.Attachments", new[] { "CardId" });
            DropTable("dbo.TeamUsers");
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
