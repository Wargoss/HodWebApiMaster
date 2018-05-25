using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HodApiMaster.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public string SkillText { get; set; }
        public int BaseDamage { get; set; }
        public int CriticalPct { get; set; }
    }
}