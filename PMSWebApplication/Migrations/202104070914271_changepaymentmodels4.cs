namespace PMSWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changepaymentmodels4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "PaymentAmount", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Payments", "PayAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "PayAmount", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Payments", "PaymentAmount");
        }
    }
}
