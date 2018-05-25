using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HodApiFront.Models
{
    public class CharacterType
    {
        [Key]
        public int CharacterTypeId { get; set; }

        public string CharacterClass { get; set; }
    }
}