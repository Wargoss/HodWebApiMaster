using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HodApiFront.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<HodApiFront.Models.Player> Players { get; set; }

        public System.Data.Entity.DbSet<HodApiFront.Models.Character> Characters { get; set; }

        public System.Data.Entity.DbSet<HodApiFront.Models.CharacterType> CharacterTypes { get; set; }

        public System.Data.Entity.DbSet<HodApiFront.Models.Chat> Chats { get; set; }

        public System.Data.Entity.DbSet<HodApiFront.Models.Combat> Combats { get; set; }

        public System.Data.Entity.DbSet<HodApiFront.Models.Guild> Guilds { get; set; }

        public System.Data.Entity.DbSet<HodApiFront.Models.MapCharacterTypeSkill> MapCharacterTypeSkills { get; set; }

        public System.Data.Entity.DbSet<HodApiFront.Models.Skill> Skills { get; set; }

        public System.Data.Entity.DbSet<HodApiFront.Models.MapCharacterTypeStatsLevel> MapCharacterTypeStatsLevels { get; set; }

        public System.Data.Entity.DbSet<HodApiFront.Models.StatsLevel> StatsLevels { get; set; }

        public System.Data.Entity.DbSet<HodApiFront.Models.MapCombatTurn> MapCombatTurns { get; set; }

        public System.Data.Entity.DbSet<HodApiFront.Models.Turn> Turns { get; set; }

        public System.Data.Entity.DbSet<HodApiFront.Models.MapGuildChat> MapGuildChats { get; set; }

        public System.Data.Entity.DbSet<HodApiFront.Models.MapPlayerCharacter> MapPlayerCharacters { get; set; }

        public System.Data.Entity.DbSet<HodApiFront.Models.MapPlayerCombat> MapPlayerCombats { get; set; }

        public System.Data.Entity.DbSet<HodApiFront.Models.MapPlayerGuild> MapPlayerGuilds { get; set; }

        public System.Data.Entity.DbSet<HodApiFront.Models.MapPlayerPurchase> MapPlayerPurchases { get; set; }

        public System.Data.Entity.DbSet<HodApiFront.Models.Purchase> Purchases { get; set; }

        public System.Data.Entity.DbSet<HodApiFront.Models.PurchaseType> PurchaseTypes { get; set; }
    }
}