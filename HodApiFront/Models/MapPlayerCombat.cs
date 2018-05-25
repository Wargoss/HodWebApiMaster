using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HodApiFront.Models
{
    public class MapPlayerCombat
    {
        [Key]
        public int MapPlayerCombatId { get; set; }

        [ForeignKey("Player")]
        public int PlayerId { get; set; }

        [ForeignKey("Combat")]
        public int CombatId { get; set; }

        public virtual Player Player { get; set; }
        public virtual Combat Combat { get; set; }
    }
}