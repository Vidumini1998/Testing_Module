namespace PMSWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteredDeadlineColumnInUpdateTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Updates", "Deadline", c => c.DateTime(storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Updates", "Deadline", c => c.DateTime());
        }
    }
}
