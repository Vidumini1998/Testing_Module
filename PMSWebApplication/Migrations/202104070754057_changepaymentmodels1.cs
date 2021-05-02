namespace PMSWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changepaymentmodels1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "PaymentDate", c => c.DateTime());
            AddColumn("dbo.Payments", "PaymentMethod", c => c.String());
            AddColumn("dbo.Payments", "Discription", c => c.String());
            DropColumn("dbo.Payments", "PayDate");
            DropColumn("dbo.Payments", "PayMethod");
            DropColumn("dbo.Payments", "PayDiscription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "PayDiscription", c => c.String());
            AddColumn("dbo.Payments", "PayMethod", c => c.String());
            AddColumn("dbo.Payments", "PayDate", c => c.DateTime());
            DropColumn("dbo.Payments", "Discription");
            DropColumn("dbo.Payments", "PaymentMethod");
            DropColumn("dbo.Payments", "PaymentDate");
        }
    }
}
