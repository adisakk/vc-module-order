namespace VirtoCommerce.OrderModule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderProductOwner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderLineItem", "ProductOwner", c => c.String(maxLength: 64));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderLineItem", "ProductOwner");
        }
    }
}
