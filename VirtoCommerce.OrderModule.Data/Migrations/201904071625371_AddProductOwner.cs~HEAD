namespace VirtoCommerce.OrderModule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductOwner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderLineItem", "ProductOwner", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderLineItem", "ProductOwner");
        }
    }
}
