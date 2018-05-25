using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HodApiFront.Models
{
    public class Combat
    {
        [Key]
        public int CombatId { get; set; }
        public DateTime CombatDate { get; set; }
        public int Winner { get; set; }
    }
}