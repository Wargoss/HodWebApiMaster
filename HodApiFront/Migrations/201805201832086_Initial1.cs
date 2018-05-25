namespace HodApiFront.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        CharacterId = c.Int(nullable: false, identity: true),
                        CharacterTypeId = c.Int(nullable: false),
                        Skill1Unlock = c.Boolean(nullable: false),
                        Skill2Unlock = c.Boolean(nullable: false),
                        Skill3Unlock = c.Boolean(nullable: false),
                        Skill4Unlock = c.Boolean(nullable: false),
                        Skill5Unlock = c.Boolean(nullable: false),
                        Skill6Unlock = c.Boolean(nullable: false),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterId)
                .ForeignKey("dbo.CharacterTypes", t => t.CharacterTypeId, cascadeDelete: true)
                .Index(t => t.CharacterTypeId);
            
            CreateTable(
                "dbo.CharacterTypes",
                c => new
                    {
                        CharacterTypeId = c.Int(nullable: false, identity: true),
                        CharacterClass = c.String(),
                    })
                .PrimaryKey(t => t.CharacterTypeId);
            
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        ChatId = c.Int(nullable: false, identity: true),
                        TextMessage = c.String(),
                        PlayerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChatId);
            
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
                "dbo.Guilds",
                c => new
                    {
                        GuildId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Icon = c.String(),
                        Title = c.String(),
                        MasterPlayerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GuildId);
            
            CreateTable(
                "dbo.MapCharacterTypeSkills",
                c => new
                    {
                        MapCharacterTypeSkillId = c.Int(nullable: false, identity: true),
                        CharacterTypeId = c.Int(nullable: false),
                        SkillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MapCharacterTypeSkillId)
                .ForeignKey("dbo.CharacterTypes", t => t.CharacterTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .Index(t => t.CharacterTypeId)
                .Index(t => t.SkillId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        SkillText = c.String(),
                        BaseDamage = c.Int(nullable: false),
                        CriticalPct = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillId);
            
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
                "dbo.MapGuildChats",
                c => new
                    {
                        MapGuildChatId = c.Int(nullable: false, identity: true),
                        ChatId = c.Int(nullable: false),
                        GuildId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MapGuildChatId)
                .ForeignKey("dbo.Chats", t => t.ChatId, cascadeDelete: true)
                .ForeignKey("dbo.Guilds", t => t.GuildId, cascadeDelete: true)
                .Index(t => t.ChatId)
                .Index(t => t.GuildId);
            
            CreateTable(
                "dbo.MapPlayerCharacters",
                c => new
                    {
                        MapPlayerCharacterId = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MapPlayerCharacterId)
                .ForeignKey("dbo.Characters", t => t.CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.CharacterId);
            
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
            
            CreateTable(
                "dbo.MapPlayerGuilds",
                c => new
                    {
                        MapPlayerGuildId = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        GuildId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MapPlayerGuildId)
                .ForeignKey("dbo.Guilds", t => t.GuildId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.GuildId);
            
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
            DropForeignKey("dbo.MapPlayerGuilds", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.MapPlayerGuilds", "GuildId", "dbo.Guilds");
            DropForeignKey("dbo.MapPlayerCombats", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.MapPlayerCombats", "CombatId", "dbo.Combats");
            DropForeignKey("dbo.MapPlayerCharacters", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.MapPlayerCharacters", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.MapGuildChats", "GuildId", "dbo.Guilds");
            DropForeignKey("dbo.MapGuildChats", "ChatId", "dbo.Chats");
            DropForeignKey("dbo.MapCombatTurns", "TurnId", "dbo.Turns");
            DropForeignKey("dbo.MapCombatTurns", "CombatId", "dbo.Combats");
            DropForeignKey("dbo.MapCharacterTypeStatsLevels", "StatsLevelIId", "dbo.StatsLevels");
            DropForeignKey("dbo.MapCharacterTypeStatsLevels", "CharacterTypeId", "dbo.CharacterTypes");
            DropForeignKey("dbo.MapCharacterTypeSkills", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.MapCharacterTypeSkills", "CharacterTypeId", "dbo.CharacterTypes");
            DropForeignKey("dbo.Characters", "CharacterTypeId", "dbo.CharacterTypes");
            DropIndex("dbo.Purchases", new[] { "PurchaseTypeId" });
            DropIndex("dbo.MapPlayerPurchases", new[] { "PurchaseId" });
            DropIndex("dbo.MapPlayerPurchases", new[] { "PlayerId" });
            DropIndex("dbo.MapPlayerGuilds", new[] { "GuildId" });
            DropIndex("dbo.MapPlayerGuilds", new[] { "PlayerId" });
            DropIndex("dbo.MapPlayerCombats", new[] { "CombatId" });
            DropIndex("dbo.MapPlayerCombats", new[] { "PlayerId" });
            DropIndex("dbo.MapPlayerCharacters", new[] { "CharacterId" });
            DropIndex("dbo.MapPlayerCharacters", new[] { "PlayerId" });
            DropIndex("dbo.MapGuildChats", new[] { "GuildId" });
            DropIndex("dbo.MapGuildChats", new[] { "ChatId" });
            DropIndex("dbo.MapCombatTurns", new[] { "TurnId" });
            DropIndex("dbo.MapCombatTurns", new[] { "CombatId" });
            DropIndex("dbo.MapCharacterTypeStatsLevels", new[] { "StatsLevelIId" });
            DropIndex("dbo.MapCharacterTypeStatsLevels", new[] { "CharacterTypeId" });
            DropIndex("dbo.MapCharacterTypeSkills", new[] { "SkillId" });
            DropIndex("dbo.MapCharacterTypeSkills", new[] { "CharacterTypeId" });
            DropIndex("dbo.Characters", new[] { "CharacterTypeId" });
            DropTable("dbo.PurchaseTypes");
            DropTable("dbo.Purchases");
            DropTable("dbo.MapPlayerPurchases");
            DropTable("dbo.MapPlayerGuilds");
            DropTable("dbo.MapPlayerCombats");
            DropTable("dbo.MapPlayerCharacters");
            DropTable("dbo.MapGuildChats");
            DropTable("dbo.Turns");
            DropTable("dbo.MapCombatTurns");
            DropTable("dbo.StatsLevels");
            DropTable("dbo.MapCharacterTypeStatsLevels");
            DropTable("dbo.Skills");
            DropTable("dbo.MapCharacterTypeSkills");
            DropTable("dbo.Guilds");
            DropTable("dbo.Combats");
            DropTable("dbo.Chats");
            DropTable("dbo.CharacterTypes");
            DropTable("dbo.Characters");
        }
    }
}
