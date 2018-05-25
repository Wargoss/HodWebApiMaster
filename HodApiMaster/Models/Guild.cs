using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HodApiMaster.Models
{
    public class Guild
    {
        [Key]
        public int GuildId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public int MasterPlayerId { get; set; }



    }
}