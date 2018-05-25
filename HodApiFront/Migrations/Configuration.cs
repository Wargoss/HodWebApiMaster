namespace HodApiFront.Migrations
{
    using HodApiFront.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HodApiFront.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HodApiFront.Models.ApplicationDbContext";
        }

        protected override void Seed(HodApiFront.Models.ApplicationDbContext context)
        {

            context.Players.AddOrUpdate(
              p => p.PlayerId,
              new Models.Player { Name = "David", User = "Wargos", Pass = "david" }
            );

            //  This method will be called after migrating to the latest version.


            context.CharacterTypes.AddOrUpdate(
              p => p.CharacterTypeId,
                new CharacterType { CharacterClass = "Archer" },
                new CharacterType { CharacterClass = "Barbarian" },
                new CharacterType { CharacterClass = "Ninja" },
                new CharacterType { CharacterClass = "Orc" },
                new CharacterType { CharacterClass = "Witch" },
                new CharacterType { CharacterClass = "Wizard" },
                new CharacterType { CharacterClass = "Thief" },
                new CharacterType { CharacterClass = "Paladin" }
            );

            context.Skills.AddOrUpdate(
                p => p.SkillId,
                new Skill { SkillText = "Disparo de cobra (daño de sangrado a 1 target)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Trampa congelante (stun a 1 target)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Bengala (quita stun a 1 PJ amistoso)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Trampa explosiva (daño directo en área)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Disparo arcano (daño directo a 1 target)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Disparo de conmoción (debuff de velocidad al grupo enemigo)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Salto heroico (stunear dos enemigos – resta defensa a el mismo)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Cargar (stunear un enemigo)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Grito de batalla (buffo ataque al grupo)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Golpes de barrido (daño directo en área)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Golpe implacable (daño directo a 1 target)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Ataque de la victoria (daño de sangrado a 1 target)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Envenenar (daño sangrado a 1 target)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Vendetta (debuff a 1 enemigo, reduce su defensa)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Abanico de shurikens (daño área directo)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Capa de las sombras (buff, aumenta defensa contra magia)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Pies ligeros (buff, aumenta su velocidad)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Habilidad (daño directo a 1 target)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Arremetida de cabeza (daño directo a 1 target)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Ansia de sangre (buff velocidad al grupo)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Zurrar (daño sangrado a 1 target)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Heridas profundas (daño sangrado en área)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Embate (stun a 1 target)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Berserk (gran daño a 1 target – se hace daño el mismo también)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Descarga de sombras (daño directo a 1target)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Miedo (stun a 1 target)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Robo de vida (daño directo a 1 target y se cura a el mismo)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Maldición (daño de sangrado a 1 target)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Quebrar alma (reduce defensa del grupo enemigo)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Cataclismo (daño de área de sangrado)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Bola de fuego (daño directo a 1 target)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Descarga de escarcha (stun a 1 objetivo)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Explosión arcana (daño directo de área)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Escudo arcano (escudo que absorbe daño al grupo)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Escudo de mana (escudo que absorbe daño en 1 target)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Luminosidad Arcana (buff de inteligencia)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Puñalada (stun a 1 target, solo en el primer turno)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Hemorragia (daño sangrado a 1 target)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Golpe revelador (gran daño a 1target, solo en el primer turno)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Asesinato múltiple (daño directo en área)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Mutilar (debuff a 1 enemigo, reduce su velocidad)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Puyazo (daño directo a 1 target)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Luz sagrada (heal al grupo)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Luz santificada (heal a un objetivo)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Consagración (daño área)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Escudo sagrado (buffo defensa al grupo)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Cólera vengativa (daño directo a 1 target)", BaseDamage = 10, CriticalPct = 0 },
                new Skill { SkillText = "Martillo de cólera (daño directo a 1 target, ultima línea enemiga)", BaseDamage = 10, CriticalPct = 0 }
                );



            context.StatsLevels.AddOrUpdate(
                p => p.StatsLevelId,
                new StatsLevel { Level = 1, CharacterClass = "Archer", Int = 1, Str = 1, Res = 1 },
                new StatsLevel { Level = 2, CharacterClass = "Archer", Int = 2, Str = 2, Res = 2 },
                new StatsLevel { Level = 3, CharacterClass = "Archer", Int = 3, Str = 3, Res = 3 },
                new StatsLevel { Level = 4, CharacterClass = "Archer", Int = 4, Str = 4, Res = 4 },
                new StatsLevel { Level = 5, CharacterClass = "Archer", Int = 5, Str = 5, Res = 5 },
                new StatsLevel { Level = 6, CharacterClass = "Archer", Int = 6, Str = 6, Res = 6 },
                new StatsLevel { Level = 7, CharacterClass = "Archer", Int = 7, Str = 7, Res = 7 },
                new StatsLevel { Level = 8, CharacterClass = "Archer", Int = 8, Str = 8, Res = 8 },
                new StatsLevel { Level = 9, CharacterClass = "Archer", Int = 9, Str = 9, Res = 9 },
                new StatsLevel { Level = 10, CharacterClass = "Archer", Int = 10, Str = 10, Res = 10 },
                new StatsLevel { Level = 1, CharacterClass = "Barbarian", Int = 1, Str = 1, Res = 1 },
                new StatsLevel { Level = 2, CharacterClass = "Barbarian", Int = 2, Str = 2, Res = 2 },
                new StatsLevel { Level = 3, CharacterClass = "Barbarian", Int = 3, Str = 3, Res = 3 },
                new StatsLevel { Level = 4, CharacterClass = "Barbarian", Int = 4, Str = 4, Res = 4 },
                new StatsLevel { Level = 5, CharacterClass = "Barbarian", Int = 5, Str = 5, Res = 5 },
                new StatsLevel { Level = 6, CharacterClass = "Barbarian", Int = 6, Str = 6, Res = 6 },
                new StatsLevel { Level = 7, CharacterClass = "Barbarian", Int = 7, Str = 7, Res = 7 },
                new StatsLevel { Level = 8, CharacterClass = "Barbarian", Int = 8, Str = 8, Res = 8 },
                new StatsLevel { Level = 9, CharacterClass = "Barbarian", Int = 9, Str = 9, Res = 9 },
                new StatsLevel { Level = 10, CharacterClass = "Barbarian", Int = 10, Str = 10, Res = 10 },
                new StatsLevel { Level = 1, CharacterClass = "Ninja", Int = 1, Str = 1, Res = 1 },
                new StatsLevel { Level = 2, CharacterClass = "Ninja", Int = 2, Str = 2, Res = 2 },
                new StatsLevel { Level = 3, CharacterClass = "Ninja", Int = 3, Str = 3, Res = 3 },
                new StatsLevel { Level = 4, CharacterClass = "Ninja", Int = 4, Str = 4, Res = 4 },
                new StatsLevel { Level = 5, CharacterClass = "Ninja", Int = 5, Str = 5, Res = 5 },
                new StatsLevel { Level = 6, CharacterClass = "Ninja", Int = 6, Str = 6, Res = 6 },
                new StatsLevel { Level = 7, CharacterClass = "Ninja", Int = 7, Str = 7, Res = 7 },
                new StatsLevel { Level = 8, CharacterClass = "Ninja", Int = 8, Str = 8, Res = 8 },
                new StatsLevel { Level = 9, CharacterClass = "Ninja", Int = 9, Str = 9, Res = 9 },
                new StatsLevel { Level = 10, CharacterClass = "Ninja", Int = 10, Str = 10, Res = 10 },
                new StatsLevel { Level = 1, CharacterClass = "Orc", Int = 1, Str = 1, Res = 1 },
                new StatsLevel { Level = 2, CharacterClass = "Orc", Int = 2, Str = 2, Res = 2 },
                new StatsLevel { Level = 3, CharacterClass = "Orc", Int = 3, Str = 3, Res = 3 },
                new StatsLevel { Level = 4, CharacterClass = "Orc", Int = 4, Str = 4, Res = 4 },
                new StatsLevel { Level = 5, CharacterClass = "Orc", Int = 5, Str = 5, Res = 5 },
                new StatsLevel { Level = 6, CharacterClass = "Orc", Int = 6, Str = 6, Res = 6 },
                new StatsLevel { Level = 7, CharacterClass = "Orc", Int = 7, Str = 7, Res = 7 },
                new StatsLevel { Level = 8, CharacterClass = "Orc", Int = 8, Str = 8, Res = 8 },
                new StatsLevel { Level = 9, CharacterClass = "Orc", Int = 9, Str = 9, Res = 9 },
                new StatsLevel { Level = 10, CharacterClass = "Orc", Int = 10, Str = 10, Res = 10 },
                new StatsLevel { Level = 1, CharacterClass = "Witch", Int = 1, Str = 1, Res = 1 },
                new StatsLevel { Level = 2, CharacterClass = "Witch", Int = 2, Str = 2, Res = 2 },
                new StatsLevel { Level = 3, CharacterClass = "Witch", Int = 3, Str = 3, Res = 3 },
                new StatsLevel { Level = 4, CharacterClass = "Witch", Int = 4, Str = 4, Res = 4 },
                new StatsLevel { Level = 5, CharacterClass = "Witch", Int = 5, Str = 5, Res = 5 },
                new StatsLevel { Level = 6, CharacterClass = "Witch", Int = 6, Str = 6, Res = 6 },
                new StatsLevel { Level = 7, CharacterClass = "Witch", Int = 7, Str = 7, Res = 7 },
                new StatsLevel { Level = 8, CharacterClass = "Witch", Int = 8, Str = 8, Res = 8 },
                new StatsLevel { Level = 9, CharacterClass = "Witch", Int = 9, Str = 9, Res = 9 },
                new StatsLevel { Level = 10, CharacterClass = "Witch", Int = 10, Str = 10, Res = 10 },
                new StatsLevel { Level = 1, CharacterClass = "Wizard", Int = 1, Str = 1, Res = 1 },
                new StatsLevel { Level = 2, CharacterClass = "Wizard", Int = 2, Str = 2, Res = 2 },
                new StatsLevel { Level = 3, CharacterClass = "Wizard", Int = 3, Str = 3, Res = 3 },
                new StatsLevel { Level = 4, CharacterClass = "Wizard", Int = 4, Str = 4, Res = 4 },
                new StatsLevel { Level = 5, CharacterClass = "Wizard", Int = 5, Str = 5, Res = 5 },
                new StatsLevel { Level = 6, CharacterClass = "Wizard", Int = 6, Str = 6, Res = 6 },
                new StatsLevel { Level = 7, CharacterClass = "Wizard", Int = 7, Str = 7, Res = 7 },
                new StatsLevel { Level = 8, CharacterClass = "Wizard", Int = 8, Str = 8, Res = 8 },
                new StatsLevel { Level = 9, CharacterClass = "Wizard", Int = 9, Str = 9, Res = 9 },
                new StatsLevel { Level = 10, CharacterClass = "Wizard", Int = 10, Str = 10, Res = 10 },
                new StatsLevel { Level = 1, CharacterClass = "Thief", Int = 1, Str = 1, Res = 1 },
                new StatsLevel { Level = 2, CharacterClass = "Thief", Int = 2, Str = 2, Res = 2 },
                new StatsLevel { Level = 3, CharacterClass = "Thief", Int = 3, Str = 3, Res = 3 },
                new StatsLevel { Level = 4, CharacterClass = "Thief", Int = 4, Str = 4, Res = 4 },
                new StatsLevel { Level = 5, CharacterClass = "Thief", Int = 5, Str = 5, Res = 5 },
                new StatsLevel { Level = 6, CharacterClass = "Thief", Int = 6, Str = 6, Res = 6 },
                new StatsLevel { Level = 7, CharacterClass = "Thief", Int = 7, Str = 7, Res = 7 },
                new StatsLevel { Level = 8, CharacterClass = "Thief", Int = 8, Str = 8, Res = 8 },
                new StatsLevel { Level = 9, CharacterClass = "Thief", Int = 9, Str = 9, Res = 9 },
                new StatsLevel { Level = 10, CharacterClass = "Thief", Int = 10, Str = 10, Res = 10 },
                new StatsLevel { Level = 1, CharacterClass = "Spearman", Int = 1, Str = 1, Res = 1 },
                new StatsLevel { Level = 2, CharacterClass = "Spearman", Int = 2, Str = 2, Res = 2 },
                new StatsLevel { Level = 3, CharacterClass = "Spearman", Int = 3, Str = 3, Res = 3 },
                new StatsLevel { Level = 4, CharacterClass = "Spearman", Int = 4, Str = 4, Res = 4 },
                new StatsLevel { Level = 5, CharacterClass = "Spearman", Int = 5, Str = 5, Res = 5 },
                new StatsLevel { Level = 6, CharacterClass = "Spearman", Int = 6, Str = 6, Res = 6 },
                new StatsLevel { Level = 7, CharacterClass = "Spearman", Int = 7, Str = 7, Res = 7 },
                new StatsLevel { Level = 8, CharacterClass = "Spearman", Int = 8, Str = 8, Res = 8 },
                new StatsLevel { Level = 9, CharacterClass = "Spearman", Int = 9, Str = 9, Res = 9 },
                new StatsLevel { Level = 10, CharacterClass = "Spearman", Int = 10, Str = 10, Res = 10 }
                );



            context.PurchaseTypes.AddOrUpdate(
                p => p.PurchaseTypeId,
                new PurchaseType { Gems = 50, SubscriptionId = 0, Name = "Bolsa pequeña de gemas", Price = 1 },
                new PurchaseType { Gems = 100, SubscriptionId = 0, Name = "Bolsa mediana de gemas", Price = 2 },
                new PurchaseType { Gems = 200, SubscriptionId = 0, Name = "Bolsa grande de gemas", Price = 4 },
                new PurchaseType { Gems = 500, SubscriptionId = 0, Name = "Baul de gemas", Price = 10 },
                new PurchaseType { Gems = 50, SubscriptionId = 1, Name = "Subscripcion por un mes de gemas diarias", Price = 5 }
                );

            // -------------------------------------------------------------------------------------------------
            // -------------------------------------------------------------------------------------------------
            // -------------------------------------------------------------------------------------------------
            // HASTA AQUI ES LA PRIMERA PARTE QUE HAY QUE EJECUTAR CUANDO HACEMOS EL UPDATE-DATABASE
            // APARTIR DE AQUI HAY QUE TENER CARGADAS LAS TABLAS MAESTRAS ANTERIORMENTE O DA ERROR 
            // -------------------------------------------------------------------------------------------------
            // -------------------------------------------------------------------------------------------------
            // -------------------------------------------------------------------------------------------------

            //Con esta linea podemos ejecutar todo sin problemas.
            context.SaveChanges();

            context.MapCharacterTypeSkills.AddOrUpdate(
                p => p.MapCharacterTypeSkillId,
                new MapCharacterTypeSkill { CharacterTypeId = 1, SkillId = 1 },
                new MapCharacterTypeSkill { CharacterTypeId = 1, SkillId = 2 },
                new MapCharacterTypeSkill { CharacterTypeId = 1, SkillId = 3 },
                new MapCharacterTypeSkill { CharacterTypeId = 1, SkillId = 4 },
                new MapCharacterTypeSkill { CharacterTypeId = 1, SkillId = 5 },
                new MapCharacterTypeSkill { CharacterTypeId = 1, SkillId = 6 },
                new MapCharacterTypeSkill { CharacterTypeId = 2, SkillId = 7 },
                new MapCharacterTypeSkill { CharacterTypeId = 2, SkillId = 8 },
                new MapCharacterTypeSkill { CharacterTypeId = 2, SkillId = 9 },
                new MapCharacterTypeSkill { CharacterTypeId = 2, SkillId = 10 },
                new MapCharacterTypeSkill { CharacterTypeId = 2, SkillId = 11 },
                new MapCharacterTypeSkill { CharacterTypeId = 2, SkillId = 12 },
                new MapCharacterTypeSkill { CharacterTypeId = 3, SkillId = 13 },
                new MapCharacterTypeSkill { CharacterTypeId = 3, SkillId = 14 },
                new MapCharacterTypeSkill { CharacterTypeId = 3, SkillId = 15 },
                new MapCharacterTypeSkill { CharacterTypeId = 3, SkillId = 16 },
                new MapCharacterTypeSkill { CharacterTypeId = 3, SkillId = 17 },
                new MapCharacterTypeSkill { CharacterTypeId = 3, SkillId = 18 },
                new MapCharacterTypeSkill { CharacterTypeId = 4, SkillId = 19 },
                new MapCharacterTypeSkill { CharacterTypeId = 4, SkillId = 20 },
                new MapCharacterTypeSkill { CharacterTypeId = 4, SkillId = 21 },
                new MapCharacterTypeSkill { CharacterTypeId = 4, SkillId = 22 },
                new MapCharacterTypeSkill { CharacterTypeId = 4, SkillId = 23 },
                new MapCharacterTypeSkill { CharacterTypeId = 4, SkillId = 24 },
                new MapCharacterTypeSkill { CharacterTypeId = 5, SkillId = 25 },
                new MapCharacterTypeSkill { CharacterTypeId = 5, SkillId = 26 },
                new MapCharacterTypeSkill { CharacterTypeId = 5, SkillId = 27 },
                new MapCharacterTypeSkill { CharacterTypeId = 5, SkillId = 28 },
                new MapCharacterTypeSkill { CharacterTypeId = 5, SkillId = 29 },
                new MapCharacterTypeSkill { CharacterTypeId = 5, SkillId = 30 },
                new MapCharacterTypeSkill { CharacterTypeId = 6, SkillId = 31 },
                new MapCharacterTypeSkill { CharacterTypeId = 6, SkillId = 32 },
                new MapCharacterTypeSkill { CharacterTypeId = 6, SkillId = 33 },
                new MapCharacterTypeSkill { CharacterTypeId = 6, SkillId = 34 },
                new MapCharacterTypeSkill { CharacterTypeId = 6, SkillId = 35 },
                new MapCharacterTypeSkill { CharacterTypeId = 6, SkillId = 36 },
                new MapCharacterTypeSkill { CharacterTypeId = 7, SkillId = 37 },
                new MapCharacterTypeSkill { CharacterTypeId = 7, SkillId = 38 },
                new MapCharacterTypeSkill { CharacterTypeId = 7, SkillId = 39 },
                new MapCharacterTypeSkill { CharacterTypeId = 7, SkillId = 40 },
                new MapCharacterTypeSkill { CharacterTypeId = 7, SkillId = 41 },
                new MapCharacterTypeSkill { CharacterTypeId = 7, SkillId = 42 },
                new MapCharacterTypeSkill { CharacterTypeId = 8, SkillId = 43 },
                new MapCharacterTypeSkill { CharacterTypeId = 8, SkillId = 44 },
                new MapCharacterTypeSkill { CharacterTypeId = 8, SkillId = 45 },
                new MapCharacterTypeSkill { CharacterTypeId = 8, SkillId = 46 },
                new MapCharacterTypeSkill { CharacterTypeId = 8, SkillId = 47 },
                new MapCharacterTypeSkill { CharacterTypeId = 8, SkillId = 48 }
                );



            context.MapCharacterTypeStatsLevels.AddOrUpdate(
                p => p.MapCharacterTypeStatsLevelId,
                new MapCharacterTypeStatsLevel { CharacterTypeId = 1, StatsLevelIId = 1 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 1, StatsLevelIId = 2 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 1, StatsLevelIId = 3 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 1, StatsLevelIId = 4 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 1, StatsLevelIId = 5 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 1, StatsLevelIId = 6 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 1, StatsLevelIId = 7 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 1, StatsLevelIId = 8 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 1, StatsLevelIId = 9 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 1, StatsLevelIId = 10 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 2, StatsLevelIId = 11 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 2, StatsLevelIId = 12 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 2, StatsLevelIId = 13 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 2, StatsLevelIId = 14 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 2, StatsLevelIId = 15 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 2, StatsLevelIId = 16 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 2, StatsLevelIId = 17 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 2, StatsLevelIId = 18 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 2, StatsLevelIId = 19 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 2, StatsLevelIId = 20 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 3, StatsLevelIId = 21 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 3, StatsLevelIId = 22 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 3, StatsLevelIId = 23 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 3, StatsLevelIId = 24 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 3, StatsLevelIId = 25 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 3, StatsLevelIId = 26 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 3, StatsLevelIId = 27 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 3, StatsLevelIId = 28 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 3, StatsLevelIId = 29 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 3, StatsLevelIId = 30 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 4, StatsLevelIId = 31 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 4, StatsLevelIId = 32 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 4, StatsLevelIId = 33 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 4, StatsLevelIId = 34 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 4, StatsLevelIId = 35 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 4, StatsLevelIId = 36 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 4, StatsLevelIId = 37 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 4, StatsLevelIId = 38 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 4, StatsLevelIId = 39 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 4, StatsLevelIId = 40 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 5, StatsLevelIId = 41 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 5, StatsLevelIId = 42 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 5, StatsLevelIId = 43 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 5, StatsLevelIId = 44 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 5, StatsLevelIId = 45 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 5, StatsLevelIId = 46 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 5, StatsLevelIId = 47 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 5, StatsLevelIId = 48 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 5, StatsLevelIId = 49 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 5, StatsLevelIId = 50 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 6, StatsLevelIId = 51 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 6, StatsLevelIId = 52 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 6, StatsLevelIId = 53 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 6, StatsLevelIId = 54 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 6, StatsLevelIId = 55 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 6, StatsLevelIId = 56 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 6, StatsLevelIId = 57 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 6, StatsLevelIId = 58 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 6, StatsLevelIId = 59 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 6, StatsLevelIId = 60 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 7, StatsLevelIId = 61 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 7, StatsLevelIId = 62 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 7, StatsLevelIId = 63 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 7, StatsLevelIId = 64 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 7, StatsLevelIId = 65 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 7, StatsLevelIId = 66 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 7, StatsLevelIId = 67 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 7, StatsLevelIId = 68 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 7, StatsLevelIId = 69 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 7, StatsLevelIId = 70 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 8, StatsLevelIId = 71 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 8, StatsLevelIId = 72 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 8, StatsLevelIId = 73 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 8, StatsLevelIId = 74 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 8, StatsLevelIId = 75 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 8, StatsLevelIId = 76 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 8, StatsLevelIId = 77 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 8, StatsLevelIId = 78 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 8, StatsLevelIId = 79 },
                new MapCharacterTypeStatsLevel { CharacterTypeId = 8, StatsLevelIId = 80 }
                );

        }
    }
}
