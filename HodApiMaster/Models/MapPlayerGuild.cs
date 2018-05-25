using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HodApiMaster.Models
{
    public class MapPlayerGuild
    {
        [Key]
        public int MapPlayerGuildId { get; set; }

        [ForeignKey("Player")]
        public int PlayerId { get; set; }

        [ForeignKey("Guild")]
        public int GuildId { get; set; }

        public virtual Player Player { get; set; }
        public virtual Guild Guild { get; set; }
    }
}