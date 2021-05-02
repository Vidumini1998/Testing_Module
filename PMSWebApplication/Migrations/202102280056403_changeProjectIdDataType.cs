namespace PMSWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeProjectIdDataType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attachments", "Project_Id", "dbo.Projects");
            DropIndex("dbo.Attachments", new[] { "Project_Id" });
            DropColumn("dbo.Attachments", "ProjectId");
            RenameColumn(table: "dbo.Attachments", name: "Project_Id", newName: "ProjectId");
            AlterColumn("dbo.Attachments", "ProjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Attachments", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Attachments", "ProjectId");
            AddForeignKey("dbo.Attachments", "ProjectId", "dbo.Projects", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attachments", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Attachments", new[] { "ProjectId" });
            AlterColumn("dbo.Attachments", "ProjectId", c => c.Int());
            AlterColumn("dbo.Attachments", "ProjectId", c => c.String());
            RenameColumn(table: "dbo.Attachments", name: "ProjectId", newName: "Project_Id");
            AddColumn("dbo.Attachments", "ProjectId", c => c.String());
            CreateIndex("dbo.Attachments", "Project_Id");
            AddForeignKey("dbo.Attachments", "Project_Id", "dbo.Projects", "Id");
        }
    }
}
