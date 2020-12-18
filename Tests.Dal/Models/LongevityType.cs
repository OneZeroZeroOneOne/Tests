using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class LongevityType
    {
        public LongevityType()
        {
            SubscriptionTypes = new HashSet<SubscriptionType>();
        }

        public int Id { get; set; }
        public int LongevityValue { get; set; }
        public string LongevityMeasureName { get; set; }

        public virtual ICollection<SubscriptionType> SubscriptionTypes { get; set; }
    }
}
