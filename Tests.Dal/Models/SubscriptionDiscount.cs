using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class SubscriptionDiscount
    {
        public int SubscriptionId { get; set; }
        public int DiscountTypeId { get; set; }
        public decimal TotalDiscount { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public virtual DiscountType DiscountType { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}
