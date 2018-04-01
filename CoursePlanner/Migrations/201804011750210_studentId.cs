namespace CoursePlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "studentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "studentId");
        }
    }
}
