using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HodApiMaster.Models
{
    public class PurchaseType
    {
        [Key]
        public int PurchaseTypeId { get; set; }

        public int Gems { get; set; }
        public int SubscriptionId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

    }
}