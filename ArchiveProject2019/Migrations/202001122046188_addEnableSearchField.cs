namespace ArchiveProject2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEnableSearchField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fields", "EnableSearch", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fields", "EnableSearch");
        }
    }
}
