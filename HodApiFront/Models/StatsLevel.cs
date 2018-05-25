using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HodApiFront.Models
{
    public class StatsLevel
    {
        [Key]
        public int StatsLevelId { get; set; }
        public string CharacterClass { get; set; }
        public int Level { get; set; }
        public int Int { get; set; }
        public int Str { get; set; }
        public int Res { get; set; }
    }
}