using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HodApiMaster.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }

        [DataType(DataType.DateTime)]
        public string LastLogin { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}