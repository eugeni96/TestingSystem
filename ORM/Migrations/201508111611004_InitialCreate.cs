namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompletedTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeStart = c.DateTime(nullable: false),
                        DateTimeFinish = c.DateTime(nullable: false),
                        IsFinished = c.Boolean(nullable: false),
                        Test_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.Test_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Test_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        IsAnswer = c.Boolean(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OptionCompletedTests",
                c => new
                    {
                        Option_Id = c.Int(nullable: false),
                        CompletedTest_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Option_Id, t.CompletedTest_Id })
                .ForeignKey("dbo.Options", t => t.Option_Id, cascadeDelete: true)
                .ForeignKey("dbo.CompletedTests", t => t.CompletedTest_Id, cascadeDelete: true)
                .Index(t => t.Option_Id)
                .Index(t => t.CompletedTest_Id);
            
            CreateTable(
                "dbo.TestQuestions",
                c => new
                    {
                        Test_Id = c.Int(nullable: false),
                        Question_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Test_Id, t.Question_Id })
                .ForeignKey("dbo.Tests", t => t.Test_Id, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .Index(t => t.Test_Id)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.User_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompletedTests", "User_Id", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.CompletedTests", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.TestQuestions", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.TestQuestions", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.Options", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.OptionCompletedTests", "CompletedTest_Id", "dbo.CompletedTests");
            DropForeignKey("dbo.OptionCompletedTests", "Option_Id", "dbo.Options");
            DropIndex("dbo.RoleUsers", new[] { "User_Id" });
            DropIndex("dbo.RoleUsers", new[] { "Role_Id" });
            DropIndex("dbo.TestQuestions", new[] { "Question_Id" });
            DropIndex("dbo.TestQuestions", new[] { "Test_Id" });
            DropIndex("dbo.OptionCompletedTests", new[] { "CompletedTest_Id" });
            DropIndex("dbo.OptionCompletedTests", new[] { "Option_Id" });
            DropIndex("dbo.Options", new[] { "QuestionId" });
            DropIndex("dbo.CompletedTests", new[] { "User_Id" });
            DropIndex("dbo.CompletedTests", new[] { "Test_Id" });
            DropTable("dbo.RoleUsers");
            DropTable("dbo.TestQuestions");
            DropTable("dbo.OptionCompletedTests");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Tests");
            DropTable("dbo.Questions");
            DropTable("dbo.Options");
            DropTable("dbo.CompletedTests");
        }
    }
}
