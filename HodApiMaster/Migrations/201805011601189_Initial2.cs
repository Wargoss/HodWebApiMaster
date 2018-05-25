namespace HodApiMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MapPlayerGuilds", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.MapPlayerGuilds", "GuildId", "dbo.Guilds");
            DropForeignKey("dbo.MapGuildChats", "GuildId", "dbo.Guilds");
            DropForeignKey("dbo.MapGuildChats", "ChatId", "dbo.Chats");
            DropIndex("dbo.MapPlayerGuilds", new[] { "GuildId" });
            DropIndex("dbo.MapPlayerGuilds", new[] { "PlayerId" });
            DropIndex("dbo.MapGuildChats", new[] { "GuildId" });
            DropIndex("dbo.MapGuildChats", new[] { "ChatId" });
            DropTable("dbo.MapPlayerGuilds");
            DropTable("dbo.MapGuildChats");
            DropTable("dbo.Guilds");
            DropTable("dbo.Chats");
        }
    }
}
