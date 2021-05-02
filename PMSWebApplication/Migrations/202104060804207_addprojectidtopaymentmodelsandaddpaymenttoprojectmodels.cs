namespace PMSWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addprojectidtopaymentmodelsandaddpaymenttoprojectmodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "ProjectId", c => c.Int(nullable: false));
            AddColumn("dbo.Payments", "InvoiceNo", c => c.Int(nullable: false));
            CreateIndex("dbo.Payments", "ProjectId");
            AddForeignKey("dbo.Payments", "ProjectId", "dbo.Projects", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Payments", new[] { "ProjectId" });
            DropColumn("dbo.Payments", "InvoiceNo");
            DropColumn("dbo.Payments", "ProjectId");
        }
    }
}
