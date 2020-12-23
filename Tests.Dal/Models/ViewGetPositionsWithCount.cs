using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class ViewGetPositionsWithCount
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long? Count { get; set; }
        public bool? IsCandidate { get; set; }
        public int? UserId { get; set; }
    }
}
