namespace NorthWindDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Description = c.String(),
                        Picture = c.Binary(storeType: "image"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        SupplierId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        QuantityPerUnit = c.String(),
                        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                        UnitsInStock = c.Short(nullable: false),
                        UnitsOnOrder = c.Short(nullable: false),
                        ReorderLevel = c.Short(nullable: false),
                        Discontinued = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Single(nullable: false),
                        RowVersion = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.String(maxLength: 128),
                        EmployeeId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        RequiredDate = c.DateTime(nullable: false),
                        ShippedDate = c.DateTime(),
                        ShipVia = c.Int(nullable: false),
                        Fright = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShipName = c.String(),
                        ShipAddress = c.String(),
                        ShipCity = c.String(),
                        ShipRegion = c.String(),
                        ShipPostalCode = c.String(),
                        ShipCountry = c.String(),
                        Shipper_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Shippers", t => t.Shipper_Id)
                .Index(t => t.CustomerId)
                .Index(t => t.EmployeeId)
                .Index(t => t.Shipper_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CompanyName = c.String(),
                        ContactName = c.String(),
                        ContactTitle = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerDemographics",
                c => new
                    {
                        TypeId = c.String(nullable: false, maxLength: 128),
                        CustomerDescription = c.String(),
                    })
                .PrimaryKey(t => t.TypeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Title = c.String(),
                        TitleOfCourtesy = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        PostalCode = c.String(),
                        HomePhone = c.String(),
                        Extension = c.String(),
                        Photo = c.Binary(storeType: "image"),
                        Notes = c.String(),
                        ReportsTo = c.Int(),
                        PhotoPath = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Employees", t => t.ReportsTo)
                .Index(t => t.ReportsTo);
            
            CreateTable(
                "dbo.Territories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TerritoryDescription = c.String(),
                        RegionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegionRescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        ContactName = c.String(),
                        ContactTitle = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        HomePage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerCustomerDemo",
                c => new
                    {
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        CustomerTypeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.CustomerTypeId })
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.CustomerDemographics", t => t.CustomerTypeId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.CustomerTypeId);
            
            CreateTable(
                "dbo.EmployeeTerritories",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        TerritoryId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.TerritoryId })
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Territories", t => t.TerritoryId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.TerritoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders", "Shipper_Id", "dbo.Shippers");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.EmployeeTerritories", "TerritoryId", "dbo.Territories");
            DropForeignKey("dbo.EmployeeTerritories", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Territories", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Employees", "ReportsTo", "dbo.Employees");
            DropForeignKey("dbo.Orders", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerCustomerDemo", "CustomerTypeId", "dbo.CustomerDemographics");
            DropForeignKey("dbo.CustomerCustomerDemo", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.EmployeeTerritories", new[] { "TerritoryId" });
            DropIndex("dbo.EmployeeTerritories", new[] { "EmployeeId" });
            DropIndex("dbo.CustomerCustomerDemo", new[] { "CustomerTypeId" });
            DropIndex("dbo.CustomerCustomerDemo", new[] { "CustomerId" });
            DropIndex("dbo.Territories", new[] { "RegionId" });
            DropIndex("dbo.Employees", new[] { "ReportsTo" });
            DropIndex("dbo.Orders", new[] { "Shipper_Id" });
            DropIndex("dbo.Orders", new[] { "EmployeeId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropTable("dbo.EmployeeTerritories");
            DropTable("dbo.CustomerCustomerDemo");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Shippers");
            DropTable("dbo.Regions");
            DropTable("dbo.Territories");
            DropTable("dbo.Employees");
            DropTable("dbo.CustomerDemographics");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
