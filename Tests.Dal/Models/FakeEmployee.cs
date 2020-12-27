using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class FakeEmployee
    {
        public int Id { get; set; }

        public virtual Employee IdNavigation { get; set; }
    }
}
