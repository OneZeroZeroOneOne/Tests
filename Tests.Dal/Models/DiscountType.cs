using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class DiscountType
    {
        public DiscountType()
        {
            SubscriptionDiscounts = new HashSet<SubscriptionDiscount>();
        }

        public int Id { get; set; }
        public int BreakpointLongevityValue { get; set; }
        public int BreakpointSubscriptionTypeId { get; set; }
        public bool IsAccumulative { get; set; }
        public decimal DiscountValue { get; set; }

        public virtual SubscriptionType BreakpointSubscriptionType { get; set; }
        public virtual ICollection<SubscriptionDiscount> SubscriptionDiscounts { get; set; }
    }
}
