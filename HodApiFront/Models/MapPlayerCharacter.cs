using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HodApiFront.Models
{
    public class MapPlayerCharacter
    {
        [Key]
        public int MapPlayerCharacterId { get; set; }

        [ForeignKey("Player")]
        public int PlayerId { get; set; }

        [ForeignKey("Character")]
        public int CharacterId { get; set; }

        public virtual Player Player { get; set; }
        public virtual Character Character { get; set; }
    }
}