using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class Subscription
    {
        public Subscription()
        {
            OrderSubscriptions = new HashSet<OrderSubscription>();
            SubscriptionDiscounts = new HashSet<SubscriptionDiscount>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int TypeId { get; set; }
        public DateTime BeginDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public virtual SubscriptionType Type { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderSubscription> OrderSubscriptions { get; set; }
        public virtual ICollection<SubscriptionDiscount> SubscriptionDiscounts { get; set; }
    }
}
