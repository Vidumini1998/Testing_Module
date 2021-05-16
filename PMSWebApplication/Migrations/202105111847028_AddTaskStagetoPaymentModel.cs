namespace PMSWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTaskStagetoPaymentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "TaskStages", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "TaskStages");
        }
    }
}
