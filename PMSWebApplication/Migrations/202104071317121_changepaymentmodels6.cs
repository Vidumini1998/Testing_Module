namespace PMSWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changepaymentmodels6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payments", "PayMethod", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "PayMethod", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
