namespace FilanWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubsctibedToCustumer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Costumers", "IsSubsctibedToNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Costumers", "IsSubsctibedToNewsletter");
        }
    }
}
