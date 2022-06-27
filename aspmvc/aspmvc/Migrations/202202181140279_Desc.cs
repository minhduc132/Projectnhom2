namespace aspmvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Desc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Desc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Desc");
        }
    }
}
