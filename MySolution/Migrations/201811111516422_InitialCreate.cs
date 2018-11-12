namespace MySolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(maxLength: 100),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDay = c.DateTime(nullable: false),
                        Email = c.String(),
                        Address = c.String(maxLength: 200),
                        Gender = c.String(),
                        PhoneNumber = c.String(maxLength: 20),
                        Token = c.String(),
                        Deteled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.AdminId, t.Username });
            
            CreateTable(
                "dbo.Counselors",
                c => new
                    {
                        CounselorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Image = c.String(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CounselorId);
            
            CreateTable(
                "dbo.GuestInteresteds",
                c => new
                    {
                        HouseId = c.Int(nullable: false),
                        GuestInterestedId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Deteled = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GuestInterestedId)
                .ForeignKey("dbo.House", t => t.HouseId, cascadeDelete: true)
                .Index(t => t.HouseId);
            
            CreateTable(
                "dbo.House",
                c => new
                    {
                        TownShipId = c.Int(),
                        HouseTypeId = c.Int(),
                        OwnerId = c.Int(),
                        HouseId = c.Int(nullable: false, identity: true),
                        Acreage = c.Int(nullable: false),
                        Address = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                        LinkMap = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HouseId)
                .ForeignKey("dbo.HouseTypes", t => t.HouseTypeId)
                .ForeignKey("dbo.Owners", t => t.OwnerId)
                .ForeignKey("dbo.Townships", t => t.TownShipId)
                .Index(t => t.TownShipId)
                .Index(t => t.HouseTypeId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.HouseTypes",
                c => new
                    {
                        HouseTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ImageIntro = c.String(),
                    })
                .PrimaryKey(t => t.HouseTypeId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        HouseId = c.Int(nullable: false),
                        LinkImage = c.String(),
                        Deteled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.House", t => t.HouseId, cascadeDelete: true)
                .Index(t => t.HouseId);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        OwnerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        MoreInformation = c.String(),
                        Deteled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OwnerId);
            
            CreateTable(
                "dbo.Townships",
                c => new
                    {
                        TownshipId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(maxLength: 2000),
                        MainImage = c.String(),
                    })
                .PrimaryKey(t => t.TownshipId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDay = c.DateTime(nullable: false),
                        Gender = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        Token = c.String(),
                        Deteled = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.Username });
            
            CreateTable(
                "dbo.UserInteresteds",
                c => new
                    {
                        UserInterestedId = c.Int(nullable: false, identity: true),
                        HouseId = c.Int(nullable: false),
                        Deteled = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserInterestedId)
                .ForeignKey("dbo.House", t => t.HouseId, cascadeDelete: true)
                .Index(t => t.HouseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInteresteds", "HouseId", "dbo.House");
            DropForeignKey("dbo.GuestInteresteds", "HouseId", "dbo.House");
            DropForeignKey("dbo.House", "TownShipId", "dbo.Townships");
            DropForeignKey("dbo.House", "OwnerId", "dbo.Owners");
            DropForeignKey("dbo.Images", "HouseId", "dbo.House");
            DropForeignKey("dbo.House", "HouseTypeId", "dbo.HouseTypes");
            DropIndex("dbo.UserInteresteds", new[] { "HouseId" });
            DropIndex("dbo.Images", new[] { "HouseId" });
            DropIndex("dbo.House", new[] { "OwnerId" });
            DropIndex("dbo.House", new[] { "HouseTypeId" });
            DropIndex("dbo.House", new[] { "TownShipId" });
            DropIndex("dbo.GuestInteresteds", new[] { "HouseId" });
            DropTable("dbo.UserInteresteds");
            DropTable("dbo.Users");
            DropTable("dbo.Townships");
            DropTable("dbo.Owners");
            DropTable("dbo.Images");
            DropTable("dbo.HouseTypes");
            DropTable("dbo.House");
            DropTable("dbo.GuestInteresteds");
            DropTable("dbo.Counselors");
            DropTable("dbo.Admins");
        }
    }
}
