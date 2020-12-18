using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Dal.Out
{
    public class OutSubscriptionViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public OutSubscriptionTypeViewModel Type { get; set; }
        public DateTime BeginDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool? IsActive { get; set; }
    }
}
