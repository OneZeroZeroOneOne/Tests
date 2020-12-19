using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Dal.Out
{
    public class OutSubscriptionTypeViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public OutLongevityTypeViewModel Longevity { get; set; }
        public string Name { get; set; }
        public int AvailableTestAmount { get; set; }
        public bool NeedToShow { get; set; }
    }
}
