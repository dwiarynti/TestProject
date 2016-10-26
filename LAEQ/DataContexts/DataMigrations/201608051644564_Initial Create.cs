namespace LAEQ.DataContexts.DataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactName = c.String(),
                        Title = c.String(),
                        JobPosition = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Mobile = c.String(),
                        Notes = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.String(),
                        Customers_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customers_Id)
                .Index(t => t.Customers_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Website = c.String(),
                        Phone = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MachineId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        RentPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remark = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Machines", t => t.MachineId, cascadeDelete: true)
                .Index(t => t.MachineId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Machines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MachineID = c.String(),
                        SerialNumber = c.String(),
                        Brand = c.String(),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                        Status = c.String(),
                        PM = c.Boolean(nullable: false),
                        Calibration = c.String(),
                        CalibrationDate = c.DateTime(nullable: false),
                        PMDate = c.DateTime(nullable: false),
                        Remark = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MachineId = c.Int(nullable: false),
                        Location = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Remark = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Machines", t => t.MachineId, cascadeDelete: true)
                .Index(t => t.MachineId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "MachineId", "dbo.Machines");
            DropForeignKey("dbo.Projects", "MachineId", "dbo.Machines");
            DropForeignKey("dbo.Rents", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerContacts", "Customers_Id", "dbo.Customers");
            DropIndex("dbo.Projects", new[] { "MachineId" });
            DropIndex("dbo.Rents", new[] { "CustomerId" });
            DropIndex("dbo.Rents", new[] { "MachineId" });
            DropIndex("dbo.CustomerContacts", new[] { "Customers_Id" });
            DropTable("dbo.Projects");
            DropTable("dbo.Machines");
            DropTable("dbo.Rents");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerContacts");
        }
    }
}
