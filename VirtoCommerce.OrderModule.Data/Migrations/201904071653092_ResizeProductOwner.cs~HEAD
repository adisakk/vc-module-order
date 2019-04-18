namespace VirtoCommerce.OrderModule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResizeProductOwner : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderLineItem", "ProductOwner", c => c.String(maxLength: 64));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderLineItem", "ProductOwner", c => c.String());
        }
    }
}
