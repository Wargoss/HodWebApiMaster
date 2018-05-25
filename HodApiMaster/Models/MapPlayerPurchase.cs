using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HodApiMaster.Models
{
    public class MapPlayerPurchase
    {
        [Key]
        public int MapPlayerPurchaseId { get; set; }

        [ForeignKey("Player")]
        public int PlayerId { get; set; }

        [ForeignKey("Purchase")]
        public int PurchaseId { get; set; }

        public virtual Player Player { get; set; }
        public virtual Purchase Purchase { get; set; }
    }
}