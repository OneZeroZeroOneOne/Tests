using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            Questions = new HashSet<Question>();
            UserAnswers = new HashSet<EmployeeAnswer>();
        }

        public int Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int StatusId { get; set; }
        public string AddressKey { get; set; }
        public int UserId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Status Status { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<EmployeeAnswer> UserAnswers { get; set; }
    }
}
