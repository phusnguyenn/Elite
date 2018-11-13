namespace Elite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IniCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "MainImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "MainImage");
        }
    }
}
    