using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HodApiMaster.Models
{
    //public class HodApiMasterContext : DbContext : IdentityDbContext<IdentityUser>
    public class HodApiMasterContext : IdentityDbContext<IdentityUser>
    {
        public HodApiMasterContext() : base("name=HodApiMasterContext")
        {
        }

        public System.Data.Entity.DbSet<HodApiMaster.Models.Player> Players { get; set; }

        public System.Data.Entity.DbSet<HodApiMaster.Models.CharacterType> CharacterTypes { get; set; }

        public System.Data.Entity.DbSet<HodApiMaster.Models.Skill> Skills { get; set; }

        public System.Data.Entity.DbSet<HodApiMaster.Models.Character> Characters { get; set; }

        public System.Data.Entity.DbSet<HodApiMaster.Models.MapPlayerCharacter> MapPlayerCharacters { get; set; }

        public System.Data.Entity.DbSet<HodApiMaster.Models.MapCharacterTypeSkill> MapCharacterTypeSkills { get; set; }

        public System.Data.Entity.DbSet<HodApiMaster.Models.StatsLevel> StatsLevels { get; set; }

        public System.Data.Entity.DbSet<HodApiMaster.Models.MapCharacterTypeStatsLevel> MapCharacterTypeStatsLevels { get; set; }

        public System.Data.Entity.DbSet<HodApiMaster.Models.PurchaseType> PurchaseTypes { get; set; }

        public System.Data.Entity.DbSet<HodApiMaster.Models.Purchase> Purchases { get; set; }

        public System.Data.Entity.DbSet<HodApiMaster.Models.MapPlayerPurchase> MapPlayerPurchases { get; set; }

        public System.Data.Entity.DbSet<HodApiMaster.Models.Chat> Chats { get; set; }

        public System.Data.Entity.DbSet<HodApiMaster.Models.Guild> Guilds { get; set; }

        public System.Data.Entity.DbSet<HodApiMaster.Models.MapPlayerGuild> MapPlayerGuilds { get; set; }

        public System.Data.Entity.DbSet<HodApiMaster.Models.MapGuildChat> MapGuildChats { get; set; }

        public System.Data.Entity.DbSet<HodApiMaster.Models.Combat> Combats { get; set; }

        public System.Data.Entity.DbSet<HodApiMaster.Models.Turn> Turns { get; set; }

        public System.Data.Entity.DbSet<HodApiMaster.Models.MapPlayerCombat> MapPlayerCombats { get; set; }

        public System.Data.Entity.DbSet<HodApiMaster.Models.MapCombatTurn> MapCombatTurns { get; set; }
    }
}
