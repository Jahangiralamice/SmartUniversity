namespace SmartUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDesignation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Designations", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Designations", "Name", c => c.String());
        }
    }
}
