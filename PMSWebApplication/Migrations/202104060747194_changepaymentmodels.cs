namespace PMSWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changepaymentmodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "PayDate", c => c.DateTime());
            AddColumn("dbo.Payments", "PayDiscription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "PayDiscription");
            DropColumn("dbo.Payments", "PayDate");
        }
    }
}
