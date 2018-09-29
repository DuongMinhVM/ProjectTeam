namespace DataAccessLayer.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class db : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserEntities", newName: "AspNetUsers");
            DropPrimaryKey("dbo.AspNetUsers");
            CreateTable(
                "dbo.CategoryEntities",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    CategoryName = c.String(),
                    CreateDate = c.DateTime(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            AddColumn("dbo.CountryEntities", "ZipCode", c => c.String());
            AddColumn("dbo.CountryEntities", "City", c => c.String());
            AddColumn("dbo.CountryEntities", "StreetAddress", c => c.String());
            AddColumn("dbo.CountryEntities", "CityPrefix", c => c.String());
            AddColumn("dbo.CountryEntities", "CitySuffix", c => c.String());
            AddColumn("dbo.CountryEntities", "StreetName", c => c.String());
            AddColumn("dbo.CountryEntities", "BuildingNumber", c => c.String());
            AddColumn("dbo.CountryEntities", "StreetSuffix", c => c.String());
            AddColumn("dbo.CountryEntities", "Country", c => c.String());
            AddColumn("dbo.CountryEntities", "FullAddress", c => c.String());
            AddColumn("dbo.CountryEntities", "CountryCode", c => c.String());
            AddColumn("dbo.CountryEntities", "State", c => c.String());
            AddColumn("dbo.CountryEntities", "StateAbbreviation", c => c.String());
            AddColumn("dbo.CountryEntities", "Latitude", c => c.String());
            AddColumn("dbo.CountryEntities", "Longitude", c => c.String());
            AddColumn("dbo.CountryEntities", "Direction", c => c.String());
            AddColumn("dbo.CountryEntities", "CardinalDirection", c => c.String());
            AddColumn("dbo.CountryEntities", "OrdinalDirection", c => c.String());
            AddColumn("dbo.OrderEntities", "Description", c => c.String());
            AddColumn("dbo.OrderEntities", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OrderEntities", "Tax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OrderEntities", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OrderEntities", "CouponCode", c => c.String());
            AddColumn("dbo.ProductEntities", "Department", c => c.String());
            AddColumn("dbo.ProductEntities", "Categories", c => c.Guid(nullable: false));
            AddColumn("dbo.ProductEntities", "ProductName", c => c.String());
            AddColumn("dbo.ProductEntities", "Color", c => c.String());
            AddColumn("dbo.ProductEntities", "Ean8", c => c.String());
            AddColumn("dbo.ProductEntities", "Ean13", c => c.String());
            AddColumn("dbo.ProductEntities", "Fashion", c => c.String());
            AddColumn("dbo.ProductEntities", "Description", c => c.String());
            AddColumn("dbo.AspNetUsers", "FulllName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Avatar", c => c.String());
            AddColumn("dbo.AspNetUsers", "Password", c => c.String());
            AddColumn("dbo.AspNetUsers", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PasswordHash", c => c.String());
            AddColumn("dbo.AspNetUsers", "SecurityStamp", c => c.String());
            AddColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.OrderItemEntities", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.AspNetUsers", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            AddPrimaryKey("dbo.AspNetUsers", "Id");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            DropColumn("dbo.CountryEntities", "Name");
            DropColumn("dbo.CountryEntities", "ContinentName");
            DropColumn("dbo.ProductEntities", "Name");
            DropColumn("dbo.AspNetUsers", "CreateDate");
            DropTable("dbo.CatagoryEntities");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.CatagoryEntities",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Name = c.String(),
                    CreateDate = c.DateTime(),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.AspNetUsers", "CreateDate", c => c.DateTime());
            AddColumn("dbo.ProductEntities", "Name", c => c.String());
            AddColumn("dbo.CountryEntities", "ContinentName", c => c.String());
            AddColumn("dbo.CountryEntities", "Name", c => c.String());
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropPrimaryKey("dbo.AspNetUsers");
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.OrderItemEntities", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "UserName");
            DropColumn("dbo.AspNetUsers", "AccessFailedCount");
            DropColumn("dbo.AspNetUsers", "LockoutEnabled");
            DropColumn("dbo.AspNetUsers", "LockoutEndDateUtc");
            DropColumn("dbo.AspNetUsers", "TwoFactorEnabled");
            DropColumn("dbo.AspNetUsers", "PhoneNumberConfirmed");
            DropColumn("dbo.AspNetUsers", "PhoneNumber");
            DropColumn("dbo.AspNetUsers", "SecurityStamp");
            DropColumn("dbo.AspNetUsers", "PasswordHash");
            DropColumn("dbo.AspNetUsers", "EmailConfirmed");
            DropColumn("dbo.AspNetUsers", "Password");
            DropColumn("dbo.AspNetUsers", "Avatar");
            DropColumn("dbo.AspNetUsers", "FulllName");
            DropColumn("dbo.ProductEntities", "Description");
            DropColumn("dbo.ProductEntities", "Fashion");
            DropColumn("dbo.ProductEntities", "Ean13");
            DropColumn("dbo.ProductEntities", "Ean8");
            DropColumn("dbo.ProductEntities", "Color");
            DropColumn("dbo.ProductEntities", "ProductName");
            DropColumn("dbo.ProductEntities", "Categories");
            DropColumn("dbo.ProductEntities", "Department");
            DropColumn("dbo.OrderEntities", "CouponCode");
            DropColumn("dbo.OrderEntities", "Discount");
            DropColumn("dbo.OrderEntities", "Tax");
            DropColumn("dbo.OrderEntities", "Total");
            DropColumn("dbo.OrderEntities", "Description");
            DropColumn("dbo.CountryEntities", "OrdinalDirection");
            DropColumn("dbo.CountryEntities", "CardinalDirection");
            DropColumn("dbo.CountryEntities", "Direction");
            DropColumn("dbo.CountryEntities", "Longitude");
            DropColumn("dbo.CountryEntities", "Latitude");
            DropColumn("dbo.CountryEntities", "StateAbbreviation");
            DropColumn("dbo.CountryEntities", "State");
            DropColumn("dbo.CountryEntities", "CountryCode");
            DropColumn("dbo.CountryEntities", "FullAddress");
            DropColumn("dbo.CountryEntities", "Country");
            DropColumn("dbo.CountryEntities", "StreetSuffix");
            DropColumn("dbo.CountryEntities", "BuildingNumber");
            DropColumn("dbo.CountryEntities", "StreetName");
            DropColumn("dbo.CountryEntities", "CitySuffix");
            DropColumn("dbo.CountryEntities", "CityPrefix");
            DropColumn("dbo.CountryEntities", "StreetAddress");
            DropColumn("dbo.CountryEntities", "City");
            DropColumn("dbo.CountryEntities", "ZipCode");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.CategoryEntities");
            AddPrimaryKey("dbo.AspNetUsers", "Id");
            RenameTable(name: "dbo.AspNetUsers", newName: "UserEntities");
        }
    }
}