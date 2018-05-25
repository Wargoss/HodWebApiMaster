namespace HodApiMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "Skill1Unlock", c => c.Boolean(nullable: false));
            AddColumn("dbo.Characters", "Skill2Unlock", c => c.Boolean(nullable: false));
            AddColumn("dbo.Characters", "Skill3Unlock", c => c.Boolean(nullable: false));
            AddColumn("dbo.Characters", "Skill4Unlock", c => c.Boolean(nullable: false));
            AddColumn("dbo.Characters", "Skill5Unlock", c => c.Boolean(nullable: false));
            AddColumn("dbo.Characters", "Skill6Unlock", c => c.Boolean(nullable: false));
            DropColumn("dbo.MapCharacterTypeSkills", "SkillBloqued");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MapCharacterTypeSkills", "SkillBloqued", c => c.Boolean(nullable: false));
            DropColumn("dbo.Characters", "Skill6Unlock");
            DropColumn("dbo.Characters", "Skill5Unlock");
            DropColumn("dbo.Characters", "Skill4Unlock");
            DropColumn("dbo.Characters", "Skill3Unlock");
            DropColumn("dbo.Characters", "Skill2Unlock");
            DropColumn("dbo.Characters", "Skill1Unlock");
        }
    }
}
