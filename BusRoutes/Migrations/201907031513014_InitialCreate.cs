namespace BusRoutes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NumberOfRoute = c.Int(nullable: false),
                        TownId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoutesOfTowns", t => t.TownId)
                .Index(t => t.TownId);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Name = c.String(),
                        WaitedArrival = c.DateTime(nullable: false),
                        RealArrival = c.DateTime(),
                        DopDescription = c.String(),
                        DeltaPassengers = c.Int(),
                        StationBegionOfIdRoute = c.Long(),
                        StationEndOfIdRoute = c.Long(),
                        RouteId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Routes", t => t.StationBegionOfIdRoute)
                .ForeignKey("dbo.Routes", t => t.StationEndOfIdRoute)
                .ForeignKey("dbo.Routes", t => t.RouteId)
                .Index(t => t.StationBegionOfIdRoute)
                .Index(t => t.StationEndOfIdRoute)
                .Index(t => t.RouteId);
            
            CreateTable(
                "dbo.RoutesOfTowns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Routes", "TownId", "dbo.RoutesOfTowns");
            DropForeignKey("dbo.Stations", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.Stations", "StationEndOfIdRoute", "dbo.Routes");
            DropForeignKey("dbo.Stations", "StationBegionOfIdRoute", "dbo.Routes");
            DropIndex("dbo.Stations", new[] { "RouteId" });
            DropIndex("dbo.Stations", new[] { "StationEndOfIdRoute" });
            DropIndex("dbo.Stations", new[] { "StationBegionOfIdRoute" });
            DropIndex("dbo.Routes", new[] { "TownId" });
            DropTable("dbo.RoutesOfTowns");
            DropTable("dbo.Stations");
            DropTable("dbo.Routes");
        }
    }
}
