namespace SmartUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(nullable: false, maxLength: 10),
                        CourseName = c.String(nullable: false, maxLength: 255),
                        Credit = c.Double(nullable: false),
                        Description = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.SemesterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Courses", new[] { "SemesterId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropTable("dbo.Courses");
        }
    }
}
