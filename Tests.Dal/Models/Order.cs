using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderSubscriptions = new HashSet<OrderSubscription>();
        }

        public Guid Id { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public virtual OrderStatus Status { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderSubscription> OrderSubscriptions { get; set; }
    }
}
