namespace PMSWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProjectModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "ProjectName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Projects", "ProjectDescription", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Projects", "SDate", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.Projects", "EDate", c => c.DateTime(storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "EDate", c => c.DateTime());
            AlterColumn("dbo.Projects", "SDate", c => c.DateTime());
            AlterColumn("dbo.Projects", "ProjectDescription", c => c.String());
            AlterColumn("dbo.Projects", "ProjectName", c => c.String());
        }
    }
}
