using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HodApiFront.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }

        [ForeignKey("PurchaseType")]
        public int PurchaseTypeId { get; set; }

        public virtual PurchaseType PurchaseType { get; set; }
    }
}