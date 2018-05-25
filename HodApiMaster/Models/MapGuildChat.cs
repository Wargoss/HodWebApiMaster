using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HodApiMaster.Models
{
    public class MapGuildChat
    {
        [Key]
        public int MapGuildChatId { get; set; }

        [ForeignKey("Chat")]
        public int ChatId { get; set; }

        [ForeignKey("Guild")]
        public int GuildId { get; set; }

        public virtual Chat Chat { get; set; }
        public virtual Guild Guild { get; set; }
    }
}