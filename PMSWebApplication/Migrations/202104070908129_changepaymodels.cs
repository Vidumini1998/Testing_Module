namespace PMSWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changepaymodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "PayAmount", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Payments", "PayMethod", c => c.String());
            AddColumn("dbo.Payments", "PayDiscription", c => c.String());
            DropColumn("dbo.Payments", "PaymentAmount");
            DropColumn("dbo.Payments", "PaymentMethod");
            DropColumn("dbo.Payments", "Discription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "Discription", c => c.String());
            AddColumn("dbo.Payments", "PaymentMethod", c => c.String());
            AddColumn("dbo.Payments", "PaymentAmount", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Payments", "PayDiscription");
            DropColumn("dbo.Payments", "PayMethod");
            DropColumn("dbo.Payments", "PayAmount");
        }
    }
}
