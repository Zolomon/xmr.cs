namespace xmr.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        ProblemID = c.Int(nullable: false),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Problems", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Problems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Index = c.Int(nullable: false),
                        ExamID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Exams", t => t.ExamID, cascadeDelete: true)
                .Index(t => t.ExamID);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        ProblemID = c.Int(nullable: false),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Problems", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.TagLinks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TagID = c.Int(nullable: false),
                        ProblemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Problems", t => t.ProblemID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.TagID)
                .Index(t => t.ProblemID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "ID", "dbo.Problems");
            DropForeignKey("dbo.TagLinks", "TagID", "dbo.Tags");
            DropForeignKey("dbo.TagLinks", "ProblemID", "dbo.Problems");
            DropForeignKey("dbo.Questions", "ID", "dbo.Problems");
            DropForeignKey("dbo.Problems", "ExamID", "dbo.Exams");
            DropForeignKey("dbo.Exams", "CourseID", "dbo.Courses");
            DropIndex("dbo.TagLinks", new[] { "ProblemID" });
            DropIndex("dbo.TagLinks", new[] { "TagID" });
            DropIndex("dbo.Questions", new[] { "ID" });
            DropIndex("dbo.Exams", new[] { "CourseID" });
            DropIndex("dbo.Problems", new[] { "ExamID" });
            DropIndex("dbo.Answers", new[] { "ID" });
            DropTable("dbo.Tags");
            DropTable("dbo.TagLinks");
            DropTable("dbo.Questions");
            DropTable("dbo.Courses");
            DropTable("dbo.Exams");
            DropTable("dbo.Problems");
            DropTable("dbo.Answers");
        }
    }
}
