using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HodApiFront.Models
{
    public class Chat
    {
        [Key]
        public int ChatId { get; set; }
        public string TextMessage { get; set; }
        public int PlayerId { get; set; }
    }
}