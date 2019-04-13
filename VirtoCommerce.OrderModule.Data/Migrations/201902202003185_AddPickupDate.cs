namespace VirtoCommerce.OrderModule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderShipment", "PickupDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderShipment", "PickupDate");
        }
    }
}
