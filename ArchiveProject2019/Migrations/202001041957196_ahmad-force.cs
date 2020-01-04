namespace ArchiveProject2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ahmadforce : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Documents", "KindId", "dbo.Kinds");
            DropForeignKey("dbo.Documents", "TypeMailId", "dbo.TypeMails");
            DropIndex("dbo.Documents", new[] { "KindId" });
            DropIndex("dbo.Documents", new[] { "TypeMailId" });
            AddColumn("dbo.Documents", "IsGeneralize", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Documents", "KindId", c => c.Int());
            AlterColumn("dbo.Documents", "TypeMailId", c => c.Int());
            CreateIndex("dbo.Documents", "KindId");
            CreateIndex("dbo.Documents", "TypeMailId");
            AddForeignKey("dbo.Documents", "KindId", "dbo.Kinds", "Id");
            AddForeignKey("dbo.Documents", "TypeMailId", "dbo.TypeMails", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "TypeMailId", "dbo.TypeMails");
            DropForeignKey("dbo.Documents", "KindId", "dbo.Kinds");
            DropIndex("dbo.Documents", new[] { "TypeMailId" });
            DropIndex("dbo.Documents", new[] { "KindId" });
            AlterColumn("dbo.Documents", "TypeMailId", c => c.Int(nullable: false));
            AlterColumn("dbo.Documents", "KindId", c => c.Int(nullable: false));
            DropColumn("dbo.Documents", "IsGeneralize");
            CreateIndex("dbo.Documents", "TypeMailId");
            CreateIndex("dbo.Documents", "KindId");
            AddForeignKey("dbo.Documents", "TypeMailId", "dbo.TypeMails", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Documents", "KindId", "dbo.Kinds", "Id", cascadeDelete: true);
        }
    }
}
