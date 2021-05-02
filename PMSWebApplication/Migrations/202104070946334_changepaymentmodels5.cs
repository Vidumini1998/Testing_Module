namespace PMSWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changepaymentmodels5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payments", "PayDate", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.Payments", "PaymentAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Payments", "PayMethod", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Payments", "PayDiscription", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "PayDiscription", c => c.String());
            AlterColumn("dbo.Payments", "PayMethod", c => c.String());
            AlterColumn("dbo.Payments", "PaymentAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Payments", "PayDate", c => c.DateTime());
        }
    }
}
