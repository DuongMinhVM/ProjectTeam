namespace DataAccessLayer.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class newdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductEntities", "Size", c => c.String());
            AlterColumn("dbo.ProductEntities", "Price", c => c.String());
            AlterColumn("dbo.ProductEntities", "Status", c => c.String());
        }

        public override void Down()
        {
            AlterColumn("dbo.ProductEntities", "Status", c => c.Boolean());
            AlterColumn("dbo.ProductEntities", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.ProductEntities", "Size");
        }
    }
}