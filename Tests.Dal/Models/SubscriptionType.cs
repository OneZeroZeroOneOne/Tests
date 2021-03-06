﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class SubscriptionType
    {
        public SubscriptionType()
        {
            DiscountTypes = new HashSet<DiscountType>();
            Subscriptions = new HashSet<Subscription>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int LongevityTypeId { get; set; }
        public string Name { get; set; }
        public int AvailableTestAmount { get; set; }
        public bool NeedToShow { get; set; }

        public virtual LongevityType LongevityType { get; set; }
        public virtual ICollection<DiscountType> DiscountTypes { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
