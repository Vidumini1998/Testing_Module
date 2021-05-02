namespace PMSWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedtaskIdDataType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "Task_Id", "dbo.Tasks");
            DropIndex("dbo.Payments", new[] { "Task_Id" });
            DropColumn("dbo.Payments", "TaskId");
            RenameColumn(table: "dbo.Payments", name: "Task_Id", newName: "TaskId");
            AlterColumn("dbo.Payments", "TaskId", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "TaskId", c => c.Int(nullable: false));
            CreateIndex("dbo.Payments", "TaskId");
            AddForeignKey("dbo.Payments", "TaskId", "dbo.Tasks", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "TaskId", "dbo.Tasks");
            DropIndex("dbo.Payments", new[] { "TaskId" });
            AlterColumn("dbo.Payments", "TaskId", c => c.Int());
            AlterColumn("dbo.Payments", "TaskId", c => c.String());
            RenameColumn(table: "dbo.Payments", name: "TaskId", newName: "Task_Id");
            AddColumn("dbo.Payments", "TaskId", c => c.String());
            CreateIndex("dbo.Payments", "Task_Id");
            AddForeignKey("dbo.Payments", "Task_Id", "dbo.Tasks", "Id");
        }
    }
}
