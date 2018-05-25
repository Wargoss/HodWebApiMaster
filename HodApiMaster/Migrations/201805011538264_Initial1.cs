namespace HodApiMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MapCharacterTypeStatsLevels",
                c => new
                    {
                        MapCharacterTypeStatsLevelId = c.Int(nullable: false, identity: true),
                        CharacterTypeId = c.Int(nullable: false),
                        StatsLevelIId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MapCharacterTypeStatsLevelId)
                .ForeignKey("dbo.CharacterTypes", t => t.CharacterTypeId, cascadeDelete: true)
                .ForeignKey("dbo.StatsLevels", t => t.StatsLevelIId, cascadeDelete: true)
                .Index(t => t.CharacterTypeId)
                .Index(t => t.StatsLevelIId);
            
            CreateTable(
                "dbo.StatsLevels",
                c => new
                    {
                        StatsLevelId = c.Int(nullable: false, identity: true),
                        CharacterClass = c.String(),
                        Level = c.Int(nullable: false),
                        Int = c.Int(nullable: false),
                        Str = c.Int(nullable: false),
                        Res = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StatsLevelId);
            
            CreateTable(
                "dbo.MapPlayerPurchases",
                c => new
                    {
                        MapPlayerPurchaseId = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        PurchaseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MapPlayerPurchaseId)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.PurchaseId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.PurchaseId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        PurchaseTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.PurchaseTypes", t => t.PurchaseTypeId, cascadeDelete: true)
                .Index(t => t.PurchaseTypeId);
            
            CreateTable(
                "dbo.PurchaseTypes",
                c => new
                    {
                        PurchaseTypeId = c.Int(nullable: false, identity: true),
                        Gems = c.Int(nullable: false),
                        SubscriptionId = c.Int(nullable: false),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MapPlayerPurchases", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.Purchases", "PurchaseTypeId", "dbo.PurchaseTypes");
            DropForeignKey("dbo.MapPlayerPurchases", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.MapCharacterTypeStatsLevels", "StatsLevelIId", "dbo.StatsLevels");
            DropForeignKey("dbo.MapCharacterTypeStatsLevels", "CharacterTypeId", "dbo.CharacterTypes");
            DropIndex("dbo.Purchases", new[] { "PurchaseTypeId" });
            DropIndex("dbo.MapPlayerPurchases", new[] { "PurchaseId" });
            DropIndex("dbo.MapPlayerPurchases", new[] { "PlayerId" });
            DropIndex("dbo.MapCharacterTypeStatsLevels", new[] { "StatsLevelIId" });
            DropIndex("dbo.MapCharacterTypeStatsLevels", new[] { "CharacterTypeId" });
            DropTable("dbo.PurchaseTypes");
            DropTable("dbo.Purchases");
            DropTable("dbo.MapPlayerPurchases");
            DropTable("dbo.StatsLevels");
            DropTable("dbo.MapCharacterTypeStatsLevels");
        }
    }
}
