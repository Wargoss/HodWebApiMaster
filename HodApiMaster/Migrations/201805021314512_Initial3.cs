namespace HodApiMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Combats",
                c => new
                    {
                        CombatId = c.Int(nullable: false, identity: true),
                        CombatDate = c.DateTime(nullable: false),
                        Winner = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CombatId);
            
            CreateTable(
                "dbo.MapCombatTurns",
                c => new
                    {
                        MapCombatTurnId = c.Int(nullable: false, identity: true),
                        CombatId = c.Int(nullable: false),
                        TurnId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MapCombatTurnId)
                .ForeignKey("dbo.Combats", t => t.CombatId, cascadeDelete: true)
                .ForeignKey("dbo.Turns", t => t.TurnId, cascadeDelete: true)
                .Index(t => t.CombatId)
                .Index(t => t.TurnId);
            
            CreateTable(
                "dbo.Turns",
                c => new
                    {
                        TurnId = c.Int(nullable: false, identity: true),
                        Player1 = c.Int(nullable: false),
                        Player2 = c.Int(nullable: false),
                        TurnNumber = c.Int(nullable: false),
                        ActivePlayer = c.Int(nullable: false),
                        SkillId = c.Int(nullable: false),
                        Damage = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.TurnId);
            
            CreateTable(
                "dbo.MapPlayerCombats",
                c => new
                    {
                        MapPlayerCombatId = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        CombatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MapPlayerCombatId)
                .ForeignKey("dbo.Combats", t => t.CombatId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.CombatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MapPlayerCombats", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.MapPlayerCombats", "CombatId", "dbo.Combats");
            DropForeignKey("dbo.MapCombatTurns", "TurnId", "dbo.Turns");
            DropForeignKey("dbo.MapCombatTurns", "CombatId", "dbo.Combats");
            DropIndex("dbo.MapPlayerCombats", new[] { "CombatId" });
            DropIndex("dbo.MapPlayerCombats", new[] { "PlayerId" });
            DropIndex("dbo.MapCombatTurns", new[] { "TurnId" });
            DropIndex("dbo.MapCombatTurns", new[] { "CombatId" });
            DropTable("dbo.MapPlayerCombats");
            DropTable("dbo.Turns");
            DropTable("dbo.MapCombatTurns");
            DropTable("dbo.Combats");
        }
    }
}
