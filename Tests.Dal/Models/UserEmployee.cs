using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class UserEmployee
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
    }
}
