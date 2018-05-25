using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HodApiFront.Models
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }

        [ForeignKey("CharacterType")]
        public int CharacterTypeId { get; set; }

        public bool Skill1Unlock { get; set; }
        public bool Skill2Unlock { get; set; }
        public bool Skill3Unlock { get; set; }
        public bool Skill4Unlock { get; set; }
        public bool Skill5Unlock { get; set; }
        public bool Skill6Unlock { get; set; }
        public int Level { get; set; }


        public virtual CharacterType CharacterType { get; set; }
    }
}