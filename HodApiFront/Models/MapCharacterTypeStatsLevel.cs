using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HodApiFront.Models
{
    public class MapCharacterTypeStatsLevel
    {
        [Key]
        public int MapCharacterTypeStatsLevelId { get; set; }

        [ForeignKey("CharacterType")]
        public int CharacterTypeId { get; set; }

        [ForeignKey("StatsLevel")]
        public int StatsLevelIId { get; set; }

        public virtual CharacterType CharacterType { get; set; }
        public virtual StatsLevel StatsLevel { get; set; }
    }
}