namespace PMSWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttachementIdToUpdateTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Updates", "AttachmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Updates", "AttachmentId");
            AddForeignKey("dbo.Updates", "AttachmentId", "dbo.Attachments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Updates", "AttachmentId", "dbo.Attachments");
            DropIndex("dbo.Updates", new[] { "AttachmentId" });
            AlterColumn("dbo.Updates", "AttachmentId", c => c.String());
        }
    }
}
