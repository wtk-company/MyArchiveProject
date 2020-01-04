namespace ArchiveProject2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ahmadforce : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Documents", "StatusId", "dbo.DocumentStatus");
            DropIndex("dbo.Documents", new[] { "StatusId" });
            AlterColumn("dbo.Documents", "StatusId", c => c.Int());
            CreateIndex("dbo.Documents", "StatusId");
            AddForeignKey("dbo.Documents", "StatusId", "dbo.DocumentStatus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "StatusId", "dbo.DocumentStatus");
            DropIndex("dbo.Documents", new[] { "StatusId" });
            AlterColumn("dbo.Documents", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Documents", "StatusId");
            AddForeignKey("dbo.Documents", "StatusId", "dbo.DocumentStatus", "Id", cascadeDelete: true);
        }
    }
}
