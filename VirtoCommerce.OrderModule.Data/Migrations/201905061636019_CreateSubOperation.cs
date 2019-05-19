namespace VirtoCommerce.OrderModule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSubOperation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubOrderOperation",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Number = c.String(nullable: false, maxLength: 64),
                        IsApproved = c.Boolean(nullable: false),
                        Status = c.String(maxLength: 64),
                        Comment = c.String(maxLength: 2048),
                        Currency = c.String(nullable: false, maxLength: 3),
                        Sum = c.Decimal(nullable: false, storeType: "money"),
                        IsCancelled = c.Boolean(nullable: false),
                        CancelledDate = c.DateTime(),
                        CancelReason = c.String(maxLength: 2048),
                        OwnerName = c.String(),
                        CustomerOrderId = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 64),
                        ModifiedBy = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerOrder", t => t.CustomerOrderId)
                .Index(t => t.CustomerOrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubOrderOperation", "CustomerOrderId", "dbo.CustomerOrder");
            DropIndex("dbo.SubOrderOperation", new[] { "CustomerOrderId" });
            DropTable("dbo.SubOrderOperation");
        }
    }
}
