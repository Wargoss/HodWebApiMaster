using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HodApiMaster.Models
{
    public class MapCombatTurn
    {
        [Key]
        public int MapCombatTurnId { get; set; }

        [ForeignKey("Combat")]
        public int CombatId { get; set; }

        [ForeignKey("Turn")]
        public int TurnId { get; set; }

        public virtual Combat Combat { get; set; }
        public virtual Turn Turn { get; set; }
    }
}