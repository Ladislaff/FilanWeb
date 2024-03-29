namespace FilanWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToCustomerName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Costumers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Costumers", "Name", c => c.String());
        }
    }
}
