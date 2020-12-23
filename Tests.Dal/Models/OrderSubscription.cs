using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class OrderSubscription
    {
        public int SubscriptionId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Guid OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}
