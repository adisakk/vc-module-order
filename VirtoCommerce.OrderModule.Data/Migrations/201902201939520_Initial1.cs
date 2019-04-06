namespace VirtoCommerce.OrderModule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderShipment", "PickupDate");
            DropColumn("dbo.OrderShipment", "TrackingNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderShipment", "TrackingNumber", c => c.String(maxLength: 64));
            AddColumn("dbo.OrderShipment", "PickupDate", c => c.DateTime());
        }
    }
}
