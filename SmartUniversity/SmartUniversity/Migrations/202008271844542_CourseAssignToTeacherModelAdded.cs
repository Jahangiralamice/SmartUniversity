namespace SmartUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseAssignToTeacherModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseAssignToTeachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: false)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: false)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: false)
                .Index(t => t.TeacherId)
                .Index(t => t.DepartmentId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseAssignToTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.CourseAssignToTeachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.CourseAssignToTeachers", "CourseId", "dbo.Courses");
            DropIndex("dbo.CourseAssignToTeachers", new[] { "CourseId" });
            DropIndex("dbo.CourseAssignToTeachers", new[] { "DepartmentId" });
            DropIndex("dbo.CourseAssignToTeachers", new[] { "TeacherId" });
            DropTable("dbo.CourseAssignToTeachers");
        }
    }
}
