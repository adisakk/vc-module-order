namespace VirtoCommerce.OrderModule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderShipment", "TrackingNumber", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderShipment", "TrackingNumber");
        }
    }
}
