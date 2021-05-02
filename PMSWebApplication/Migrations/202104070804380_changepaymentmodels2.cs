namespace PMSWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changepaymentmodels2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "PayDate", c => c.DateTime());
            DropColumn("dbo.Payments", "PaymentDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "PaymentDate", c => c.DateTime());
            DropColumn("dbo.Payments", "PayDate");
        }
    }
}
