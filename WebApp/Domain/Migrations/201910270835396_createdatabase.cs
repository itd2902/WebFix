namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CATEGORY",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(maxLength: 2048),
                        Image = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        Status = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PRODUCT",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                        PublicationDate = c.DateTime(),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                        Weight = c.Double(),
                        Height = c.Double(),
                        Width = c.Double(),
                        UrlImage = c.String(),
                        ProductInStock = c.Int(nullable: false),
                        View = c.Int(),
                        QuantityBuy = c.Int(),
                        CategoryId = c.Int(),
                        SupplierId = c.Int(),
                        ManufacturerId = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        Status = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CATEGORY", t => t.CategoryId)
                .ForeignKey("dbo.MANUFACTURER", t => t.ManufacturerId)
                .ForeignKey("dbo.SUPPLIER", t => t.SupplierId)
                .Index(t => t.CategoryId)
                .Index(t => t.SupplierId)
                .Index(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.MANUFACTURER",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(),
                        Website = c.String(maxLength: 250),
                        LogoPath = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        Status = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SUPPLIER",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 250),
                        Email = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        Status = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CUSTOMER",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FistName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        Age = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        Status = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ORDERDETAIL",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuantityProduct = c.Int(nullable: false),
                        BuyPrice = c.Double(nullable: false),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        Status = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ORDER", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.PRODUCT", t => t.ProductId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ORDER",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(),
                        ShippedDate = c.DateTime(),
                        StatusPayment = c.Int(nullable: false),
                        Cancelled = c.Int(nullable: false),
                        Deleted = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        Status = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUSTOMER", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.ROLE",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50, unicode: false),
                        Description = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        Status = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.USER",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(maxLength: 250),
                        LastName = c.String(maxLength: 250),
                        Password = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Age = c.Int(),
                        PhoneNumber = c.String(),
                        RoleId = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        Status = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ROLE", t => t.RoleId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.USER", "RoleId", "dbo.ROLE");
            DropForeignKey("dbo.ORDERDETAIL", "ProductId", "dbo.PRODUCT");
            DropForeignKey("dbo.ORDERDETAIL", "OrderId", "dbo.ORDER");
            DropForeignKey("dbo.ORDER", "CustomerId", "dbo.CUSTOMER");
            DropForeignKey("dbo.PRODUCT", "SupplierId", "dbo.SUPPLIER");
            DropForeignKey("dbo.PRODUCT", "ManufacturerId", "dbo.MANUFACTURER");
            DropForeignKey("dbo.PRODUCT", "CategoryId", "dbo.CATEGORY");
            DropIndex("dbo.USER", new[] { "RoleId" });
            DropIndex("dbo.ORDER", new[] { "CustomerId" });
            DropIndex("dbo.ORDERDETAIL", new[] { "ProductId" });
            DropIndex("dbo.ORDERDETAIL", new[] { "OrderId" });
            DropIndex("dbo.PRODUCT", new[] { "ManufacturerId" });
            DropIndex("dbo.PRODUCT", new[] { "SupplierId" });
            DropIndex("dbo.PRODUCT", new[] { "CategoryId" });
            DropTable("dbo.USER");
            DropTable("dbo.ROLE");
            DropTable("dbo.ORDER");
            DropTable("dbo.ORDERDETAIL");
            DropTable("dbo.CUSTOMER");
            DropTable("dbo.SUPPLIER");
            DropTable("dbo.MANUFACTURER");
            DropTable("dbo.PRODUCT");
            DropTable("dbo.CATEGORY");
        }
    }
}
