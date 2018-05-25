using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HodApiMaster.Models
{
    public class MapCharacterTypeSkill
    {
        [Key]
        public int MapCharacterTypeSkillId { get; set; }

        [ForeignKey("CharacterType")]
        public int CharacterTypeId { get; set; }

        [ForeignKey("Skill")]
        public int SkillId { get; set; }

        public virtual CharacterType CharacterType { get; set; }
        public virtual Skill Skill { get; set; }
    }
}