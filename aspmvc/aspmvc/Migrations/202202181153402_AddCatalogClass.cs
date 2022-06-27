namespace aspmvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCatalogClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catalogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Catalogs");
        }
    }
}
