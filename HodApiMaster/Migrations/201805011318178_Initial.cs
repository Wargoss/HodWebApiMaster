namespace HodApiMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        CharacterId = c.Int(nullable: false, identity: true),
                        CharacterTypeId = c.Int(nullable: false),
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
                "dbo.MapCharacterTypeSkills",
                c => new
                    {
                        MapCharacterTypeSkillId = c.Int(nullable: false, identity: true),
                        CharacterTypeId = c.Int(nullable: false),
                        SkillId = c.Int(nullable: false),
                        SkillBloqued = c.Boolean(nullable: false),
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
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        User = c.String(),
                        Pass = c.String(),
                        LastLogin = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MapPlayerCharacters", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.MapPlayerCharacters", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.MapCharacterTypeSkills", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.MapCharacterTypeSkills", "CharacterTypeId", "dbo.CharacterTypes");
            DropForeignKey("dbo.Characters", "CharacterTypeId", "dbo.CharacterTypes");
            DropIndex("dbo.MapPlayerCharacters", new[] { "CharacterId" });
            DropIndex("dbo.MapPlayerCharacters", new[] { "PlayerId" });
            DropIndex("dbo.MapCharacterTypeSkills", new[] { "SkillId" });
            DropIndex("dbo.MapCharacterTypeSkills", new[] { "CharacterTypeId" });
            DropIndex("dbo.Characters", new[] { "CharacterTypeId" });
            DropTable("dbo.Players");
            DropTable("dbo.MapPlayerCharacters");
            DropTable("dbo.Skills");
            DropTable("dbo.MapCharacterTypeSkills");
            DropTable("dbo.CharacterTypes");
            DropTable("dbo.Characters");
        }
    }
}
