using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class UserQuiz
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? QuizId { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual User User { get; set; }
    }
}
