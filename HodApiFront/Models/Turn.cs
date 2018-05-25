using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HodApiFront.Models
{
    public class Turn
    {
        [Key]
        public int TurnId { get; set; }
        public int Player1 { get; set; }
        public int Player2 { get; set; }
        public int TurnNumber { get; set; }
        public int ActivePlayer { get; set; }
        public int SkillId { get; set; }
        public float Damage { get; set; }
    }
}